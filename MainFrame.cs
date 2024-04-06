using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rs485loader_csharp.Api;
using rs485loader_csharp.Rs485;
using System.IO.Ports;

namespace rs485loader_csharp
{
    public partial class MainFrame : Form
    {
      //  public static MainFrame mainFrm;

        public static int FLASH_DATA_BUF_SIZE = 1024;
        public static int FLASH_DATA_BUF_LENGTH = 65536;

        public static String FREESCALE_START_FLAG = "S0";	//s19文件起始标识
        public static String FREESCALE_DATA_TYPE1 = "S1";	//S19文件数据域
        public static String FREESCALE_DATA_TYPE2 = "S2";	//S19文件数据域标识
        public static String FREESCALE_END_FLAG = "S9";		//文件结束标识符
        public static int INTER_HEX_END = 0x01;				//结束标记符
        public static int INTER_HEX_SECTION = 0x02;			//段地址标识符,左移4位
        public static int INTER_HEX_DATA = 0x00;			//数据标识符
        public static int INTER_LINE_FLAG = 0x04;			//线性地址标识符
        public static int INTER_HEX_STARTADDR = 0x05;		//程序入口地址
        public static String INTER_START_FLAG = ":";		//起始标识符        
        public static int e_TRANSMIT_MODEL = 0;    /*转发模式*/
        public static int e_CANLOAD_MODEL = 1;     /*烧录模式*/
        public static int e_PROGRAME_MODEL = 2;    /*应用程序运行模式*/
        public  const int e_LOADTRANSMIT_STATE = 0;            /*无应用程序转发状态*/
        public  const int e_PROTRANSMIT_STATE = 1;            /*应用程序转发状态*/
        public  const int e_CANLOADREADY_OK = 2;            /*烧录准备*/
        public  const int e_CANLOADREADY_FAIL = 3;            /*烧录准备失败*/
        public  const int e_CANLOADPRE_OK = 4;            /*烧录就绪*/
        public  const int e_CANLOADTRANSMITING = 5;            /*正在传输*/
        public  const int e_CANLOADTRANSMIT_FAIL = 6;            /*传输失败*/
        public  const int e_CANLOADTRANSMIT_OK = 7;            	/*传输成功*/
        public  const int e_CANLOADFLASH_FAIL = 8;             /*烧录失败*/
        public  const int e_CANLOADFLASH_OK = 9;            	/*烧录成功*/
        public  const int e_PRORUN_STATE = 10;           /*应用程序运行状态*/
        public static int e_HANDLE_MSG = 0xE0;                 /*烧录握手*/
        public static int e_STARTLOAD_MSG = 0xE1;                 /*启动烧录*/
        public static int e_LOADDATA_MSG = 0xE2;                 /*发送数据*/
        public static int e_RESTARTLOAD_MSG = 0xE3;                 /*丢帧重发*/
        public static int e_STARTCRC_MSG = 0xE4;                 /*校验帧*/
        public static int e_ROUTER_MSG = 0xE5;                 /*路由信息发送*/
        public static int e_SEARCHSTATE_MSG = 0xE6;                  /*广播查询报文*/
        public static int e_RESETNET_CMD = 1;                       /*重新设置设备类型及设备号*/
        public static int e_REQRESET_CMD = 2;                       /*请求复新复命令*/
        public static int e_INTOLOAD_CMD = 3;                       /*进入程序烧录模式命令*/
        public static int e_OUTLOAD_CMD = 4;                       /*退出程序烧录模式命令*/
        public static int e_INTTRANSMIT_CMD = 5;                    /*进入转发模式命令*/
        public static int e_OUTTRANSMIT_CMD = 6;                     /*退出转发模式命令*/
        public MainFrame()
        {
            InitializeComponent();
       
            for (int i = 0; i < 8; i++)
                this.dataGridView1.Rows.Add();
                //  mainFrm = this;
        }

        public void OpenCanLoaderFile()
        {
            String Pathname = null;
            String[] filter = { "*.s19;*.glo;*.hex" };
            //if (openhexFileDialog.ShowDialog() == null)
            //{
            //    return;
            //}
            openhexFileDialog.ShowDialog();
            if (openhexFileDialog.FileName.EndsWith(".s19")
               || openhexFileDialog.FileName.EndsWith(".glo")
               || openhexFileDialog.FileName.EndsWith(".hex"))
            {
                UserExplainFile testUser = new UserExplainFile();
                //Pathname = openhexFileDialog.getFilterPath() + "\\" + openhexFileDialog.getFileName();
                Pathname = openhexFileDialog.FileName;

                if (testUser.ReadFile(Pathname) == 0)//文件解析成功
                {                 
                    text_sectionNum.Text=(UserExplainFile.Flash_SectionNum).ToString();
                }
                else
                {                 
                   MessageBox.Show("文件解析失败");
                    text_sectionNum.Text=("0");                 
                }
            }
            else
            {             
                MessageBox.Show("文件类型错误");
            }

        }
	
	

        // public void SetRS485DeviceState(ref MainFrame mf, int state)
        //{ 
        //    if (state > 0)
        //    {
        //        mf.PortState.Text = "运行";
        //    }
        //    else
        //    {
        //        mf.PortState.Text = "关闭";
        //    }
        //}
        private void 文件加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int net = 0xfe;
            int ecu = 0xfe;

            if (RS485Updateflash.IsFlashUpdataStart == false)
            {
               // UpdataCanLoaderConfig("单个烧录", Integer.toString(net), Integer.toString(ecu));
                UserLoadFlash.UpdataLoadNet(net, ecu);
            }

            OpenCanLoaderFile();
             

        //    String Pathname = null;
        ////    openhexFileDialog.ShowDialog();     //获取S19文件
        //    if (openhexFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        UserExplainFile testUser = new UserExplainFile();
        //        Pathname = openhexFileDialog.FileName;
        //        if (testUser.ReadFile(Pathname) == 0)//文件解析成功
        //        {
        //            text_sectionNum.Text = ((UserExplainFile.Flash_SectionNum).ToString());
        //        }
        //        else
        //        {
        //          //  MessageBox msgbox = new MessageBox(shell, SWT.NONE);
        //           MessageBox.Show("文件解析失败");
        //          //  text_sectionNum.setText("0");
        //          //  msgbox.open();
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    } 
        }
        //打开串口设备
        private void 打开串口设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RS485Driver com = RS485Driver.GetCommunication();
            //RS485Updateflash userRS485Loadflash = new RS485Updateflash(); 
            RS232ConfigFrame userRS485 = new RS232ConfigFrame();
            userRS485.ShowDialog();
             

        }
        //关闭串口设备
        private void 关闭串口设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RS485Driver com = new RS485Driver();
          //  MainFrame mf = (MainFrame)Class1.LocalForm1;             
            com.CloseCom();
            Baud.Text = "0";
        
        }

  
        //进入转发
        private void button_IntoRS485TransmitCmd_Click(object sender, EventArgs e)
        {
            if (UserMsgRecord.IsExistDevice() == -1)
            {
                MessageBox.Show("无设备，请查询设备后再操作");      
                return;
            }
            else if (RS485Driver.IsWorking() == false)
            {
                MessageBox.Show("RS485设备未工作，请打开RS485");          
                return;
            }
            else if (RS485Updateflash.IsFlashUpdataStart == true)
            {
                MessageBox.Show("正在烧录中，不能进入转发");           
                return;
            }
            else
            {
                button_IntoRS485Load.Enabled = true;
                RS485Driver.WriteflashCommandAPI(RS485Driver.SlaveId, Rs485.RS485CanLoadInterface.e_Cmd_IntoTransmit, 0x5AA5);
            }	
        }
        //程序烧录
        private void button_IntoRS485Load_Click(object sender, EventArgs e)
        {
            int net = UserLoadFlash.LoadNet;
            int ecu = UserLoadFlash.LoadEcu;
            int isExist = 0;
          

         //   for (int k = 0; k < table.getItemCount(); k++)
            {
                int CurNet = 254;
                int CurEcu = 254;
                if ((net == CurNet && ecu == CurEcu) || (net == CurNet && ecu <= 255))
                {
                    isExist = 1;
                   // break;
                }
            }

            if (isExist == 0)
            {
                MessageBox.Show("设备不存在，需重新设置烧录设备号及类型");           
                return;
            }

            if (RS485Driver.IsWorking() == false)
            {
                MessageBox.Show("RS485设备未工作，请打开RS485");  
                return;
            }

            if (UserMsgRecord.IsAllInTrasmitModel() == -1)
            {
                MessageBox.Show("有设备未进入转发状态");                
                return;
            }
						
            if (UserExplainFile.IsHasFile() == -1)
            {
                OpenCanLoaderFile();
            } 
            if (UserExplainFile.Flash_SectionNum <= 0)
            {
                MessageBox.Show("加载的数据段为0，请确认加载文件是否正常");                
                return;
            }

            System.Console.Write("File 数据段长度为：" + UserExplainFile.Flash_SectionNum + "\n");
			RS485Driver.WriteflashCommandAPI(RS485Driver.SlaveId, RS485CanLoadInterface.e_Cmd_IntoLoad, UserExplainFile.Flash_SectionNum);
        
        }
        //开始烧录
        private void button_StartRS485Load_Click(object sender, EventArgs e)
        {
            int net = UserLoadFlash.LoadNet;
            int ecu = UserLoadFlash.LoadEcu;
            if (RS485Driver.IsWorking() == false)
            {
                MessageBox.Show("串口未打开，请打开串口");
                return;
            }
            //if (UserExplainFile.IsHasFile() == -1)
            //{
            //    OpenCanLoaderFile();
            //}
            if (UserExplainFile.Flash_SectionNum <= 0)
            {
                MessageBox.Show("加载的数据段为0，请确认加载文件是否正常");
                return;
            }
            if (UserMsgRecord.IsLoadReadyState(net, ecu) != 0)
            {
                MessageBox.Show("烧录设备未准备就绪");
                return;
            }
            if (RS485Updateflash.IsFlashUpdataStart == false)
            {
                RS485Updateflash.StartRS485Update();		//开始进行烧录
                //	userRS485Loadflash.start();
            }
            else
            {
                MessageBox.Show("正在烧录中...");
                return;
            }
        }
        //暂停烧录
        private void button_RS485StopLoad_Click(object sender, EventArgs e)
        {

        }
        //退出烧录
        private void button_OutRS485Load_Click(object sender, EventArgs e)
        { 
            if (RS485Driver.IsWorking() == false)
            {
               MessageBox.Show("串口设备未工作，打开串口");
               
                return;
            }

            RS485Updateflash.IsFlashUpdataStart = false;
            RS485Driver.WriteflashCommandAPI(RS485Driver.SlaveId, RS485CanLoadInterface.e_Cmd_ExitLoad, 0x5AA5);

            button_StartRS485Load.Enabled=(false);	//关闭开始烧录的按钮
            button_StartRS485Load.Enabled=(true);
           // button_UpLoadFile.setEnabled(true);
            button_IntoRS485TransmitCmd.Enabled=(true);
            button_OutRS485Transmit.Enabled=(true);
            button_RS485ResetCmd.Enabled=(true);
            button_RS485ClearDevice.Enabled=(true);
      
        }
        //退出BOOT
        private void button_OutRS485Transmit_Click(object sender, EventArgs e)
        {
            //   MessageBox mb = new MessageBox(shell, SWT.NONE);
            if (RS485Driver.IsWorking() == false)
            {
                MessageBox.Show("串口设备未工作，请打开串设备");
                return;
            }

            if (RS485Updateflash.IsFlashUpdataStart == true)
            {
                MessageBox.Show("正在烧录中，不能退出转发!");
                return;
            }
            //RemoveAllDevice();
            RS485Driver.WriteflashCommandAPI(RS485Driver.SlaveId, RS485CanLoadInterface.e_Cmd_ExitTransmit, 0x5AA5);

         
        }
        //复位设备
        private void button_RS485ResetCmd_Click(object sender, EventArgs e)
        {
            //  MessageBox mb = new MessageBox(shell, SWT.NONE);
            if (RS485Driver.IsWorking() == false)
            {
                MessageBox.Show("串口设备未工作，请打开串口设备");

                return;
            }

            if (RS485Updateflash.IsFlashUpdataStart == true)
            {
                MessageBox.Show("正在烧录中，不能复位设备");

                return;
            }
            //   RemoveAllDevice();
           // button_StartRS485Load.Enabled = (false);//开始烧录的按钮不能用
            RS485Driver.WriteflashCommandAPI(RS485Driver.SlaveId, RS485CanLoadInterface.e_Cmd_Reset, 0x5AA5);

        }
        //清除设备
        private void button_RS485ClearDevice_Click(object sender, EventArgs e)
        {

            if (RS485Updateflash.IsFlashUpdataStart == true)
            { 
                MessageBox.Show("正在烧录中，不能清除列表");               
                return;
            }
             
            dataGridView1.Rows.Clear();

            for (int i = 0; i < 8; i++)
                this.dataGridView1.Rows.Add();
          //  UserMsgRecord.RemoveAll();
           // table.removeAll();
        }
    
       
        public static UserFileData flashdata;
        public static int gLoadingSection = 0;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            RS485Driver com = RS485Driver.GetCommunication();
            flashdata = UserExplainFile.GetSectionData(gLoadingSection);
            RS485Driver.WriteflashDataAPI(RS485Driver.SlaveId, gLoadingSection + 1, flashdata.StartAddress, flashdata.SectionDataNum, flashdata.data);
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {       
            RS485Updateflash rs_thread=new RS485Updateflash();
            rs_thread.thread_quit();
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            //RS485Driver com = RS485Driver.GetCommunication();
            //com.CloseCom();
            //this.Dispose();

            Environment.Exit(0);
      
        }
    }
}
