using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace JobServiceBusProcessor
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }

        /*
        // 寫入至過載資料庫
        if (obj.Temperature >= 40 || obj.Humidity >= 60 || obj.PM25 > decimal.Parse("0.3"))
        {
            // 寫入過載資料庫
            InsertOverEvents(obj);

            // 發送Notification訊息
            await SendAndroidNotificationAsync(obj);
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

        private static async Task SendAndroidNotificationAsync(Models.SensorData objData)
        {
            string strMessageContent = "{ data:{ message:'DeviceId：{0}發生異常，啟動日期：{1}'} }";

            // 建立Notification的連線
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString
                (
                strNotificationConnectionString,
                strNotificationHubName
                );

            // 準備Notification的訊息內容並送出
            var toast = strMessageContent.Replace("{0}", objData.DeviceId);
            toast = toast.Replace("{1}", objData.SendDateTime.ToString());
            var results = await hub.SendGcmNativeNotificationAsync(toast);
            Console.WriteLine(results);
        }
        */
    }
}
