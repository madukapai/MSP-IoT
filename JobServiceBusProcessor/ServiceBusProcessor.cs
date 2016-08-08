using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace JobServiceBusProcessor
{
    public class ServiceBusProcessor
    {
        private static string strServiceBusConnectinString = ConfigurationSettings.AppSettings["ServiceBusConnectionString"].ToString();
        private static string strQueueName = ConfigurationSettings.AppSettings["ServiceBusQueue"].ToString();
        private static SqlCommand SqlCmd = new SqlCommand();
        private static SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        public static void LookupNotification()
        {
            // 開啟資料庫
            SqlCmd.Connection = SqlConn;
            SqlCmd.Connection.Open();

            // 取得Queue裡的資料
            QueueClient qc = QueueClient.CreateFromConnectionString(strServiceBusConnectinString, strQueueName);
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            // Callback to handle received messages.
            qc.OnMessage((message) =>
            {
                try
                {
                    var o = message.GetBody<System.IO.Stream>();
                    using (var r = new StreamReader(o))
                    {
                        var msg = r.ReadToEnd();

                        msg = msg.Replace(@"@string3http://schemas.microsoft.com/2003/10/Serialization/�s", "");

                        Models.SensorData obj = JsonConvert.DeserializeObject<Models.SensorData>(msg);

                        // 寫入至過載資料庫
                        if (obj.Temperature >= 40 || obj.Humidity >= 60 || obj.PM25 > decimal.Parse("0.3"))
                        {
                            InsertOverEvents(obj);
                        }

                        Console.WriteLine("Body: " + msg);
                        Console.WriteLine("MessageID: " + message.MessageId);
                        message.Complete();
                    }

                }
                catch (Exception exp)
                {
                    // Indicates a problem, unlock message in queue.
                    Console.WriteLine("EXCEPTION:" + exp.Message);
                    if (exp.InnerException != null)
                    {
                        Console.WriteLine("INNER:" + exp.Message);
                    }
                    if (exp.StackTrace != null)
                    {
                        Console.WriteLine($"Stack:{exp.StackTrace}");
                    }

                    message.Abandon();
                    //message.Complete();

                    if (SqlCmd.Connection.State == System.Data.ConnectionState.Open)
                        SqlCmd.Connection.Close();
                }
            }, options);
        }

        private static void InsertOverEvents(Models.SensorData objData)
        {
            SqlCmd.CommandText = "Insert Into IoTOverEvents Values (@DeviceId, @Temperature, @Humidity, @PM25, @SendDateTime)";

            SqlCmd.Parameters.Clear();
            SqlCmd.Parameters.AddWithValue("@DeviceId", objData.DeviceId);
            SqlCmd.Parameters.AddWithValue("@Temperature", objData.Temperature);
            SqlCmd.Parameters.AddWithValue("@Humidity", objData.Humidity);
            SqlCmd.Parameters.AddWithValue("@PM25", objData.PM25);
            SqlCmd.Parameters.AddWithValue("@SendDateTime", objData.SendDateTime);

            if (SqlCmd.Connection.State == System.Data.ConnectionState.Closed)
                SqlCmd.Connection.Open();

            Console.WriteLine("Insert To IoTOverEvents:" + SqlCmd.CommandText);

            SqlCmd.ExecuteNonQuery();
        }
    }
}
