using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JobHeartBeatProcessor
{
    using JobHeartBeatProcessor.Processors;
    using JobHeartBeatProcessor.Models;

    public class HeartBeatProcessor
    {
        static int intMaxCountOfDevices = int.Parse(ConfigurationManager.AppSettings["Microsoft.Azure.IoT.MaxDeviceCount"].ToString());
        static string strIoTHubConnectionString = ConfigurationManager.ConnectionStrings["Microsoft.Azure.IoT.ConnectionString"].ToString();

        public static async Task Process()
        {
            // 找出裝置的清單
            DevicesProcessor devicesProcessor = new DevicesProcessor(strIoTHubConnectionString, intMaxCountOfDevices, "");
            List<DeviceEntity> devicesList = await devicesProcessor.GetDevices();
            Console.WriteLine("All Devices Count:" + devicesList.Count.ToString());

            // 過濾出離線的裝置資料
            List<DeviceEntity> offlineDevices = devicesList.FindAll(
                delegate (DeviceEntity device) 
                {
                    return device.ConnectionState == "Disconnected" && device.State == "Enabled";
                }
            );
            Console.WriteLine("Offline Devices Count:" + offlineDevices.Count.ToString());

            // 取出離線的裝置客戶資料
            for (int i = 0; i < offlineDevices.Count; i++)
            {
                string strDeviceId = offlineDevices[i].Id;
                DateTime dtLastStateTime = offlineDevices[i].LastConnectionStateUpdatedTime;

                Console.WriteLine($"Device [{offlineDevices[i].Id}] is offline, Last updated time :[{dtLastStateTime.ToString()}]");

                /*
                    在這邊加入通知或是告警的機制，如透過SnedGrid寄發EMail通知
                */
            }
        }
    }
}
