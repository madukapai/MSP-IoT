using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using System.Collections;
using System.Threading.Tasks;
using IoTGateway.Models;
using StackExchange.Redis;
using Microsoft.Azure.Devices.Client;
using System.Text;
using Newtonsoft.Json;

namespace IoTGateway.Controllers
{
    public class MessagesController : ApiController
    {
        static string iotHubUri = ConfigurationManager.AppSettings["Microsoft.Azure.IoT.Url"].ToString();
        static IDictionary DicIoTHub = new Hashtable();
        static string strConn = ConfigurationManager.AppSettings["Microsoft.Azure.Cache.ConnectionString"].ToString();
        DeviceClient deviceClient = null;

        // 開啟Redis Cache的連線
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(strConn);
        });

        public static ConnectionMultiplexer objConn
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        // 定義Entity Framework Model
        IoTModel objModel = new IoTModel();

        /// <summary>
        /// 發送訊息至IoT Hub
        /// </summary>
        /// <param name="value">發送物件</param>
        /// <returns>true:發送成功  false:發送失敗</returns>
        public async Task<string> Post([FromBody]SensorModel value)
        {
            string strReturnValue = "false";
            string strDeviceId = value.DeviceId;

            try
            {
                // 先確認快取中有沒有資料
                IDatabase objCache = objConn.GetDatabase();
                RedisValue objValue = objCache.StringGet(strDeviceId);
                string strKey = (objValue.HasValue) ? objValue.ToString() : "";

                // 如果Key是空的，就從資料庫找出Key值
                if (strKey == "")
                {
                    IoTDevice objDevice = objModel.IoTDevices.FirstOrDefault(x => x.DeviceId == strDeviceId);
                    if (objDevice != null)
                    {
                        strKey = objDevice.DeviceKey;
                        // 寫入到快取
                        objCache.StringSet(value.DeviceId, strKey);
                    }
                }

                // 如果連資料庫都找不到，就代表這個裝置不在資料庫中，無法取得Key值，也無法轉拋訊息
                if (strKey != "")
                {
                    string strMessage = JsonConvert.SerializeObject(value);
                    // 送到IoT
                    deviceClient = DeviceClient.CreateFromConnectionString($"HostName={iotHubUri};DeviceId={strDeviceId};SharedAccessKey={strKey}", Microsoft.Azure.Devices.Client.TransportType.Amqp);
                    await deviceClient.SendEventAsync(new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(strMessage)));
                    strReturnValue = "true";
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return strReturnValue;
        }
    }
}