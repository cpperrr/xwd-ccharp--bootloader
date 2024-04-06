using Microsoft.Win32;
using rs485loader_csharp.Rs485;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rs485loader_csharp
{
    public partial class RS232ConfigFrame : Form
    {
        public RS232ConfigFrame()
        {
            InitializeComponent();
            EnumComportfromReg(combo_PortName);
            combo_PortName.SelectedIndex = 1;
            combo_Rate.SelectedIndex = 1;
            combo_DataBit.SelectedIndex=3;
            combo_StopBit.SelectedIndex = 0;
            combo_Parity.SelectedIndex=0;
            text_getslaveId.Text = "110";
        }
        private void EnumComportfromReg(ComboBox Combobox)
        {
            Combobox.Items.Clear();
            ///定义注册表子Path
            string strRegPath = @"Hardware\\DeviceMap\\SerialComm";
            ///创建两个RegistryKey类，一个将指向Root Path，另一个将指向子Path
            RegistryKey regRootKey;
            RegistryKey regSubKey;
            ///定义Root指向注册表HKEY_LOCAL_MACHINE节点
            regRootKey = Registry.LocalMachine;
            regSubKey = regRootKey.OpenSubKey(strRegPath);
            if (regSubKey.GetValueNames() == null) return;
            string[] strCommList = regSubKey.GetValueNames();
            foreach (string VName in strCommList)
            {
                //向listbox1中添加字符串的名称和数据，数据是从rk对象中的GetValue(it)方法中得来的
                Combobox.Items.Add(regSubKey.GetValue(VName));
            }
            // if (Combobox.Items.Count > 0)
            //    Combobox.SelectedIndex = 0;
            if (Combobox.Items.Count <= 0)
            { MessageBox.Show("Error Device Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); return; }
            else
            { Combobox.SelectedIndex = 0; }
            regSubKey.Close();
            regRootKey.Close();
        }

        public int result =0;      
        private void btn_ok_Click(object sender, EventArgs e)
        {

            RS485Driver com = RS485Driver.GetCommunication();             
           
            RS232ConfigFrame rs232f = this;
            try
            {
                String PortName = combo_PortName.Text;
                int Rate = int.Parse(combo_Rate.Text);
                int dataBit = int.Parse(combo_DataBit.Text);
                int StopBit = combo_StopBit.SelectedIndex + 1;
                int Parity = combo_Parity.SelectedIndex;
                int getId = int.Parse(text_getslaveId.Text);

                result = com.OpenCom(PortName, Rate, dataBit, StopBit, Parity, getId);

                RS485Updateflash rs485thread = new RS485Updateflash();          //打开串口之后 开启线程
                rs485thread.thread_query();                                     //线程 函数 启动
                 
                    if (result == -1)
                    {
                        MessageBox.Show("打开失败");
                        return;
                    }
                    else
                    {
                        this.Close();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
