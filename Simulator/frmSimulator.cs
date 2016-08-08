using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Microsoft.Azure.Devices.Client;
using System.Configuration;

namespace Simulator
{
    public partial class frmSimulator : Form
    {
        // 定義IoT Hub物件
        static DeviceClient deviceIoT = null;
        static string iotHubUri = ConfigurationSettings.AppSettings["IoTHubUrl"].ToString();

        public frmSimulator()
        {
            InitializeComponent();
            
            // 先綁定一次資料至JSON欄位中
            this.ChangeSensorValue(this, EventArgs.Empty);

            tiSend.Interval = int.Parse(txtFrequency.Text);
            txtDeviceId.Text = ConfigurationSettings.AppSettings["DeviceId"].ToString();
            txtDeviceKey.Text = ConfigurationSettings.AppSettings["DeviceKey"].ToString();
        }

        /// <summary>
        /// 改變感知器的數值動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChangeSensorValue(object sender, EventArgs e)
        {
            // 組合Json字串
            Models.SensorData objData = new Models.SensorData()
            {
                DeviceId = txtDeviceId.Text,
                Temperature = decimal.Parse(txtTemperature.Text),
                Humidity = decimal.Parse(txtHumidity.Text),
                PM25 = decimal.Parse(txtPM25.Text),
                SendDateTime = DateTime.Now
            };

            txtData.Text = JsonConvert.SerializeObject(objData);
        }

        /// <summary>
        /// 點擊開始發送的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            tiSend.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        /// <summary>
        /// 點擊停止的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            tiSend.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        /// <summary>
        /// 計時器開始動作，定時發送訊息至IoT Hub的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void tiSend_Tick(object sender, EventArgs e)
        {            
            // 重新更改一次數據
            this.ChangeSensorValue(sender, e);

            // 設定送出的訊息協定
            TransportType objTransType = TransportType.Mqtt;

            try
            {
                deviceIoT = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(txtDeviceId.Text, txtDeviceKey.Text), objTransType);
                await deviceIoT.SendEventAsync(new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(txtData.Text)));

                lblMessage.Text = $"訊息已送出：{DateTime.Now}";
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"訊息送出失敗：{DateTime.Now}，Exception：{ex.Message}";
            }
        }

        /// <summary>
        /// 變更送出頻率的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFrequency_Leave(object sender, EventArgs e)
        {
            tiSend.Interval = int.Parse(txtFrequency.Text);
        }
    }
}
