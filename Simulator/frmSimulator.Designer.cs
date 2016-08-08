namespace Simulator
{
    partial class frmSimulator
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.txtDeviceKey = new System.Windows.Forms.TextBox();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.txtHumidity = new System.Windows.Forms.TextBox();
            this.txtPM25 = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblDeviceId = new System.Windows.Forms.Label();
            this.lblDeviceKey = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblPM25 = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtData = new System.Windows.Forms.TextBox();
            this.tiSend = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(132, 12);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(735, 36);
            this.txtDeviceId.TabIndex = 0;
            // 
            // txtDeviceKey
            // 
            this.txtDeviceKey.Location = new System.Drawing.Point(134, 54);
            this.txtDeviceKey.Name = "txtDeviceKey";
            this.txtDeviceKey.Size = new System.Drawing.Size(733, 36);
            this.txtDeviceKey.TabIndex = 1;
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(144, 131);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(100, 36);
            this.txtTemperature.TabIndex = 2;
            this.txtTemperature.Text = "28.5";
            this.txtTemperature.Leave += new System.EventHandler(this.ChangeSensorValue);
            // 
            // txtHumidity
            // 
            this.txtHumidity.Location = new System.Drawing.Point(144, 173);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.Size = new System.Drawing.Size(100, 36);
            this.txtHumidity.TabIndex = 2;
            this.txtHumidity.Text = "54";
            this.txtHumidity.Leave += new System.EventHandler(this.ChangeSensorValue);
            // 
            // txtPM25
            // 
            this.txtPM25.Location = new System.Drawing.Point(144, 215);
            this.txtPM25.Name = "txtPM25";
            this.txtPM25.Size = new System.Drawing.Size(100, 36);
            this.txtPM25.TabIndex = 2;
            this.txtPM25.Text = "0.3";
            this.txtPM25.Leave += new System.EventHandler(this.ChangeSensorValue);
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(144, 257);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(100, 36);
            this.txtFrequency.TabIndex = 2;
            this.txtFrequency.Text = "1000";
            this.txtFrequency.Leave += new System.EventHandler(this.txtFrequency_Leave);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(711, 299);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(792, 299);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.Location = new System.Drawing.Point(28, 24);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(98, 24);
            this.lblDeviceId.TabIndex = 4;
            this.lblDeviceId.Text = "Device Id";
            // 
            // lblDeviceKey
            // 
            this.lblDeviceKey.AutoSize = true;
            this.lblDeviceKey.Location = new System.Drawing.Point(12, 57);
            this.lblDeviceKey.Name = "lblDeviceKey";
            this.lblDeviceKey.Size = new System.Drawing.Size(116, 24);
            this.lblDeviceKey.TabIndex = 4;
            this.lblDeviceKey.Text = "Device Key";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(12, 134);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(126, 24);
            this.lblTemperature.TabIndex = 5;
            this.lblTemperature.Text = "Temperature";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(43, 176);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(95, 24);
            this.lblHumidity.TabIndex = 6;
            this.lblHumidity.Text = "Humidity";
            // 
            // lblPM25
            // 
            this.lblPM25.AutoSize = true;
            this.lblPM25.Location = new System.Drawing.Point(61, 218);
            this.lblPM25.Name = "lblPM25";
            this.lblPM25.Size = new System.Drawing.Size(77, 24);
            this.lblPM25.TabIndex = 7;
            this.lblPM25.Text = "PM 2.5";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(33, 260);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(105, 24);
            this.lblFrequency.TabIndex = 8;
            this.lblFrequency.Text = "Frequency";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(16, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 4);
            this.panel1.TabIndex = 9;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(250, 131);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(617, 162);
            this.txtData.TabIndex = 10;
            // 
            // tiSend
            // 
            this.tiSend.Tick += new System.EventHandler(this.tiSend_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Location = new System.Drawing.Point(12, 299);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(693, 60);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "[Message]";
            // 
            // frmSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 368);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.lblPM25);
            this.Controls.Add(this.lblHumidity);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.lblDeviceKey);
            this.Controls.Add(this.lblDeviceId);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.txtPM25);
            this.Controls.Add(this.txtHumidity);
            this.Controls.Add(this.txtTemperature);
            this.Controls.Add(this.txtDeviceKey);
            this.Controls.Add(this.txtDeviceId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSimulator";
            this.Text = "模擬器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.TextBox txtDeviceKey;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.TextBox txtPM25;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.Label lblDeviceKey;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblPM25;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Timer tiSend;
        private System.Windows.Forms.Label lblMessage;
    }
}

