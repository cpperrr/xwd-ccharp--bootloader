namespace rs485loader_csharp
{
    partial class MainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_IntoRS485TransmitCmd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设备信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开串口设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭串口设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.校验和计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_IntoRS485Load = new System.Windows.Forms.Button();
            this.button_RS485StopLoad = new System.Windows.Forms.Button();
            this.button_StartRS485Load = new System.Windows.Forms.Button();
            this.button_RS485ClearDevice = new System.Windows.Forms.Button();
            this.button_RS485ResetCmd = new System.Windows.Forms.Button();
            this.button_OutRS485Transmit = new System.Windows.Forms.Button();
            this.button_OutRS485Load = new System.Windows.Forms.Button();
            this.openhexFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DownLoadType = new System.Windows.Forms.TextBox();
            this.DownLoadTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_sectionNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PortState = new System.Windows.Forms.TextBox();
            this.DownLoadSection = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Baud = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Device = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DeviceType = new System.Windows.Forms.TextBox();
            this.ReUploadTimes = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_IntoRS485TransmitCmd
            // 
            this.button_IntoRS485TransmitCmd.Location = new System.Drawing.Point(15, 426);
            this.button_IntoRS485TransmitCmd.Name = "button_IntoRS485TransmitCmd";
            this.button_IntoRS485TransmitCmd.Size = new System.Drawing.Size(75, 23);
            this.button_IntoRS485TransmitCmd.TabIndex = 0;
            this.button_IntoRS485TransmitCmd.Text = "进入转发";
            this.button_IntoRS485TransmitCmd.UseVisualStyleBackColor = true;
            this.button_IntoRS485TransmitCmd.Click += new System.EventHandler(this.button_IntoRS485TransmitCmd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备信息ToolStripMenuItem,
            this.文件加载ToolStripMenuItem,
            this.校验和计算器ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设备信息ToolStripMenuItem
            // 
            this.设备信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开串口设备ToolStripMenuItem,
            this.关闭串口设备ToolStripMenuItem});
            this.设备信息ToolStripMenuItem.Name = "设备信息ToolStripMenuItem";
            this.设备信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.设备信息ToolStripMenuItem.Text = "设备信息";
            // 
            // 打开串口设备ToolStripMenuItem
            // 
            this.打开串口设备ToolStripMenuItem.Name = "打开串口设备ToolStripMenuItem";
            this.打开串口设备ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打开串口设备ToolStripMenuItem.Text = "打开串口设备";
            this.打开串口设备ToolStripMenuItem.Click += new System.EventHandler(this.打开串口设备ToolStripMenuItem_Click);
            // 
            // 关闭串口设备ToolStripMenuItem
            // 
            this.关闭串口设备ToolStripMenuItem.Name = "关闭串口设备ToolStripMenuItem";
            this.关闭串口设备ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关闭串口设备ToolStripMenuItem.Text = "关闭串口设备";
            this.关闭串口设备ToolStripMenuItem.Click += new System.EventHandler(this.关闭串口设备ToolStripMenuItem_Click);
            // 
            // 文件加载ToolStripMenuItem
            // 
            this.文件加载ToolStripMenuItem.Name = "文件加载ToolStripMenuItem";
            this.文件加载ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.文件加载ToolStripMenuItem.Text = "文件加载";
            this.文件加载ToolStripMenuItem.Click += new System.EventHandler(this.文件加载ToolStripMenuItem_Click);
            // 
            // 校验和计算器ToolStripMenuItem
            // 
            this.校验和计算器ToolStripMenuItem.Name = "校验和计算器ToolStripMenuItem";
            this.校验和计算器ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.校验和计算器ToolStripMenuItem.Text = "校验和计算器";
            // 
            // button_IntoRS485Load
            // 
            this.button_IntoRS485Load.Location = new System.Drawing.Point(118, 426);
            this.button_IntoRS485Load.Name = "button_IntoRS485Load";
            this.button_IntoRS485Load.Size = new System.Drawing.Size(75, 23);
            this.button_IntoRS485Load.TabIndex = 2;
            this.button_IntoRS485Load.Text = "程序烧录";
            this.button_IntoRS485Load.UseVisualStyleBackColor = true;
            this.button_IntoRS485Load.Click += new System.EventHandler(this.button_IntoRS485Load_Click);
            // 
            // button_RS485StopLoad
            // 
            this.button_RS485StopLoad.Location = new System.Drawing.Point(324, 426);
            this.button_RS485StopLoad.Name = "button_RS485StopLoad";
            this.button_RS485StopLoad.Size = new System.Drawing.Size(75, 23);
            this.button_RS485StopLoad.TabIndex = 4;
            this.button_RS485StopLoad.Text = "暂停烧录";
            this.button_RS485StopLoad.UseVisualStyleBackColor = true;
            this.button_RS485StopLoad.Click += new System.EventHandler(this.button_RS485StopLoad_Click);
            // 
            // button_StartRS485Load
            // 
            this.button_StartRS485Load.Location = new System.Drawing.Point(221, 426);
            this.button_StartRS485Load.Name = "button_StartRS485Load";
            this.button_StartRS485Load.Size = new System.Drawing.Size(75, 23);
            this.button_StartRS485Load.TabIndex = 3;
            this.button_StartRS485Load.Text = "开始烧录";
            this.button_StartRS485Load.UseVisualStyleBackColor = true;
            this.button_StartRS485Load.Click += new System.EventHandler(this.button_StartRS485Load_Click);
            // 
            // button_RS485ClearDevice
            // 
            this.button_RS485ClearDevice.Location = new System.Drawing.Point(736, 426);
            this.button_RS485ClearDevice.Name = "button_RS485ClearDevice";
            this.button_RS485ClearDevice.Size = new System.Drawing.Size(75, 23);
            this.button_RS485ClearDevice.TabIndex = 8;
            this.button_RS485ClearDevice.Text = "清除设备";
            this.button_RS485ClearDevice.UseVisualStyleBackColor = true;
            this.button_RS485ClearDevice.Click += new System.EventHandler(this.button_RS485ClearDevice_Click);
            // 
            // button_RS485ResetCmd
            // 
            this.button_RS485ResetCmd.Location = new System.Drawing.Point(633, 426);
            this.button_RS485ResetCmd.Name = "button_RS485ResetCmd";
            this.button_RS485ResetCmd.Size = new System.Drawing.Size(75, 23);
            this.button_RS485ResetCmd.TabIndex = 7;
            this.button_RS485ResetCmd.Text = "复位设备";
            this.button_RS485ResetCmd.UseVisualStyleBackColor = true;
            this.button_RS485ResetCmd.Click += new System.EventHandler(this.button_RS485ResetCmd_Click);
            // 
            // button_OutRS485Transmit
            // 
            this.button_OutRS485Transmit.Location = new System.Drawing.Point(530, 426);
            this.button_OutRS485Transmit.Name = "button_OutRS485Transmit";
            this.button_OutRS485Transmit.Size = new System.Drawing.Size(75, 23);
            this.button_OutRS485Transmit.TabIndex = 6;
            this.button_OutRS485Transmit.Text = "退出BOOT";
            this.button_OutRS485Transmit.UseVisualStyleBackColor = true;
            this.button_OutRS485Transmit.Click += new System.EventHandler(this.button_OutRS485Transmit_Click);
            // 
            // button_OutRS485Load
            // 
            this.button_OutRS485Load.Location = new System.Drawing.Point(427, 426);
            this.button_OutRS485Load.Name = "button_OutRS485Load";
            this.button_OutRS485Load.Size = new System.Drawing.Size(75, 23);
            this.button_OutRS485Load.TabIndex = 5;
            this.button_OutRS485Load.Text = "退出烧录";
            this.button_OutRS485Load.UseVisualStyleBackColor = true;
            this.button_OutRS485Load.Click += new System.EventHandler(this.button_OutRS485Load_Click);
            // 
            // openhexFileDialog
            // 
            this.openhexFileDialog.Filter = "hex文件|*.hex";
            // 
            // DownLoadType
            // 
            this.DownLoadType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DownLoadType.Location = new System.Drawing.Point(85, 284);
            this.DownLoadType.Name = "DownLoadType";
            this.DownLoadType.Size = new System.Drawing.Size(100, 21);
            this.DownLoadType.TabIndex = 10;
            this.DownLoadType.Text = "单个烧录";
            // 
            // DownLoadTime
            // 
            this.DownLoadTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DownLoadTime.Location = new System.Drawing.Point(259, 284);
            this.DownLoadTime.Name = "DownLoadTime";
            this.DownLoadTime.Size = new System.Drawing.Size(100, 21);
            this.DownLoadTime.TabIndex = 11;
            this.DownLoadTime.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "烧录类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "烧录时间";
            // 
            // text_sectionNum
            // 
            this.text_sectionNum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.text_sectionNum.Location = new System.Drawing.Point(412, 284);
            this.text_sectionNum.Name = "text_sectionNum";
            this.text_sectionNum.Size = new System.Drawing.Size(100, 21);
            this.text_sectionNum.TabIndex = 13;
            this.text_sectionNum.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "段长度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "串口状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "烧录段号";
            // 
            // PortState
            // 
            this.PortState.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PortState.Location = new System.Drawing.Point(771, 281);
            this.PortState.Name = "PortState";
            this.PortState.Size = new System.Drawing.Size(100, 21);
            this.PortState.TabIndex = 17;
            this.PortState.Text = "关闭";
            // 
            // DownLoadSection
            // 
            this.DownLoadSection.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DownLoadSection.Location = new System.Drawing.Point(590, 281);
            this.DownLoadSection.Name = "DownLoadSection";
            this.DownLoadSection.Size = new System.Drawing.Size(100, 21);
            this.DownLoadSection.TabIndex = 16;
            this.DownLoadSection.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(531, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "串口速率";
            // 
            // Baud
            // 
            this.Baud.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Baud.Location = new System.Drawing.Point(590, 321);
            this.Baud.Name = "Baud";
            this.Baud.Size = new System.Drawing.Size(100, 21);
            this.Baud.TabIndex = 26;
            this.Baud.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "设备号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "设备类型";
            // 
            // Device
            // 
            this.Device.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Device.Location = new System.Drawing.Point(412, 324);
            this.Device.Name = "Device";
            this.Device.Size = new System.Drawing.Size(100, 21);
            this.Device.TabIndex = 23;
            this.Device.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "重发次数";
            // 
            // DeviceType
            // 
            this.DeviceType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeviceType.Location = new System.Drawing.Point(259, 324);
            this.DeviceType.Name = "DeviceType";
            this.DeviceType.Size = new System.Drawing.Size(100, 21);
            this.DeviceType.TabIndex = 21;
            this.DeviceType.Text = "0";
            // 
            // ReUploadTimes
            // 
            this.ReUploadTimes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReUploadTimes.Location = new System.Drawing.Point(85, 324);
            this.ReUploadTimes.Name = "ReUploadTimes";
            this.ReUploadTimes.Size = new System.Drawing.Size(100, 21);
            this.ReUploadTimes.TabIndex = 20;
            this.ReUploadTimes.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(85, 372);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(786, 23);
            this.progressBar1.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "烧录进度";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(15, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(929, 231);
            this.dataGridView1.TabIndex = 32;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "设备类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "设备号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Boot版本号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "应用程序版本号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "运行模式";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "运行状态";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "芯片类型";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "通信通道";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 508);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Baud);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Device);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DeviceType);
            this.Controls.Add(this.ReUploadTimes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PortState);
            this.Controls.Add(this.DownLoadSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_sectionNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownLoadTime);
            this.Controls.Add(this.DownLoadType);
            this.Controls.Add(this.button_RS485ClearDevice);
            this.Controls.Add(this.button_RS485ResetCmd);
            this.Controls.Add(this.button_OutRS485Transmit);
            this.Controls.Add(this.button_OutRS485Load);
            this.Controls.Add(this.button_RS485StopLoad);
            this.Controls.Add(this.button_StartRS485Load);
            this.Controls.Add(this.button_IntoRS485Load);
            this.Controls.Add(this.button_IntoRS485TransmitCmd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rs485loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_IntoRS485TransmitCmd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设备信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开串口设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭串口设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件加载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 校验和计算器ToolStripMenuItem;
        private System.Windows.Forms.Button button_IntoRS485Load;
        private System.Windows.Forms.Button button_RS485StopLoad;
        private System.Windows.Forms.Button button_StartRS485Load;
        private System.Windows.Forms.Button button_RS485ClearDevice;
        private System.Windows.Forms.Button button_RS485ResetCmd;
        private System.Windows.Forms.Button button_OutRS485Transmit;
        private System.Windows.Forms.Button button_OutRS485Load;
        private System.Windows.Forms.OpenFileDialog openhexFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox DownLoadType;
        public System.Windows.Forms.TextBox DownLoadTime;
        public System.Windows.Forms.TextBox text_sectionNum;
        public  System.Windows.Forms.TextBox PortState;
        public System.Windows.Forms.TextBox DownLoadSection;
        public System.Windows.Forms.TextBox Baud;
        public System.Windows.Forms.TextBox Device;
        public System.Windows.Forms.TextBox DeviceType;
        public System.Windows.Forms.TextBox ReUploadTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}

