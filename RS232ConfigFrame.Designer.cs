namespace rs485loader_csharp
{
    partial class RS232ConfigFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_PortName = new System.Windows.Forms.ComboBox();
            this.combo_Parity = new System.Windows.Forms.ComboBox();
            this.combo_StopBit = new System.Windows.Forms.ComboBox();
            this.combo_DataBit = new System.Windows.Forms.ComboBox();
            this.combo_Rate = new System.Windows.Forms.ComboBox();
            this.text_getslaveId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(68, 174);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(247, 174);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "校验位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "数据位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "波特率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "站地址";
            // 
            // combo_PortName
            // 
            this.combo_PortName.FormattingEnabled = true;
            this.combo_PortName.Location = new System.Drawing.Point(100, 46);
            this.combo_PortName.Name = "combo_PortName";
            this.combo_PortName.Size = new System.Drawing.Size(85, 20);
            this.combo_PortName.TabIndex = 2;
            // 
            // combo_Parity
            // 
            this.combo_Parity.FormattingEnabled = true;
            this.combo_Parity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验"});
            this.combo_Parity.Location = new System.Drawing.Point(100, 84);
            this.combo_Parity.Name = "combo_Parity";
            this.combo_Parity.Size = new System.Drawing.Size(85, 20);
            this.combo_Parity.TabIndex = 2;
            // 
            // combo_StopBit
            // 
            this.combo_StopBit.FormattingEnabled = true;
            this.combo_StopBit.Items.AddRange(new object[] {
            "1",
            "2",
            "1.5"});
            this.combo_StopBit.Location = new System.Drawing.Point(100, 125);
            this.combo_StopBit.Name = "combo_StopBit";
            this.combo_StopBit.Size = new System.Drawing.Size(85, 20);
            this.combo_StopBit.TabIndex = 2;
            // 
            // combo_DataBit
            // 
            this.combo_DataBit.FormattingEnabled = true;
            this.combo_DataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.combo_DataBit.Location = new System.Drawing.Point(292, 46);
            this.combo_DataBit.Name = "combo_DataBit";
            this.combo_DataBit.Size = new System.Drawing.Size(85, 20);
            this.combo_DataBit.TabIndex = 2;
            // 
            // combo_Rate
            // 
            this.combo_Rate.FormattingEnabled = true;
            this.combo_Rate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400"});
            this.combo_Rate.Location = new System.Drawing.Point(292, 84);
            this.combo_Rate.Name = "combo_Rate";
            this.combo_Rate.Size = new System.Drawing.Size(85, 20);
            this.combo_Rate.TabIndex = 2;
            // 
            // text_getslaveId
            // 
            this.text_getslaveId.Location = new System.Drawing.Point(292, 125);
            this.text_getslaveId.Name = "text_getslaveId";
            this.text_getslaveId.Size = new System.Drawing.Size(100, 21);
            this.text_getslaveId.TabIndex = 3;
            // 
            // RS232ConfigFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 239);
            this.Controls.Add(this.text_getslaveId);
            this.Controls.Add(this.combo_StopBit);
            this.Controls.Add(this.combo_Rate);
            this.Controls.Add(this.combo_Parity);
            this.Controls.Add(this.combo_DataBit);
            this.Controls.Add(this.combo_PortName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.MinimizeBox = false;
            this.Name = "RS232ConfigFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_PortName;
        private System.Windows.Forms.ComboBox combo_Parity;
        private System.Windows.Forms.ComboBox combo_StopBit;
        private System.Windows.Forms.ComboBox combo_DataBit;
        private System.Windows.Forms.ComboBox combo_Rate;
        private System.Windows.Forms.TextBox text_getslaveId;
    }
}