
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
using System.IO;
using System.IO.Ports;
using System.Threading;
 

namespace rs485loader_csharp
{
    class RS485Driver
    { 
        private static RS485Driver com;          /* 通信处理对象 */
        private static SerialPort serialport;          /* 串口通信对象 */ 
        public static int ComPortWorkState = 0;				//0关闭 1打开
        public static int SlaveId = 0x6e;					//从站地址
        public AntiInfo antiData;                /* 遥测量 */
        public class AntiInfo
        {          
            public int ComPortWorkState { get; set; }
        }
        public static int portstate { get; set; }
        public RS485Driver()
        {
            if (serialport == null)
            {
                serialport = new SerialPort();
                serialport.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            }
            antiData = new AntiInfo();
      
        }
        public static RS485Driver GetCommunication()
        {
            if (com == null)
            {
                com = new RS485Driver();
            }
            return com;
        }

        public static Boolean IsWorking()
        {
            if (ComPortWorkState == 1)
            {
                return (true);
            }

            return (false);
        }
   
        public int OpenCom(String ComportName, int Rate, int DataBit, int stopbit, int partity, int getId)
        {
            MainFrame mainfr=new MainFrame();
            if (serialport != null)
            {
                try
                {
                    serialport.PortName = ComportName;
                    serialport.BaudRate = Rate;
                    serialport.DataBits = DataBit;
                    serialport.Open();
                    portstate = 1;
                }
                catch
                {
                    MessageBox.Show("当前串口资源被占用");
                    return (-1);
                }
          
            }
      
            SlaveId = getId;
            ComPortWorkState = 1; 
            return (0);
        }
        public void CloseCom()
        {
            MainFrame mainfr = new MainFrame();
            antiData.ComPortWorkState = 0;
            try
            {
                if (serialport != null)
                {
                    serialport.Close();
                    serialport.Dispose();
                    portstate = 0;
                }

            }
            catch (IOException e)
            {
                return;
            }
            ComPortWorkState = 0;
        }

        private long received_count = 0;
        private StringBuilder builder = new StringBuilder();
        void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
          //  serialport.ReadExisting(); 
            //Thread.Sleep(100);
            //int n = serialport.BytesToRead;
            //byte[] buf = new byte[n];
            //received_count += n;
            //serialport.Read(buf, 0, n);
          //  builder.Clear();

        }

        public  void SetRS485DeviceState(ref MainFrame mf, int state)
        {
            if (state > 0)
            {
                mf.PortState.Text = "运行";        
            }
            else
            {
                mf.PortState.Text = "关闭";
            }
        }
        public  bool serialstate()
        {
            if (serialport != null)
            {
                return serialport.IsOpen;
            }
            else
            {
                return false;
            }
        }
        public static int SendRS485DataApi(byte[] data, int length)
        {
           // if (length == 0 || data == null || outputStream == null)

            if (length == 0 || data == null )
            {
                return (-1);
            }
            try
            {         
                if (serialport.IsOpen)
                    serialport.Write(data, 0, length);
               // outputStream.flush();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                // e.printStackTrace();
                return (-1);
            }

            return (0);
        }

        public static int ReadModbusAPI(int slaveid, int startaddr, int reqlen)
        {
            byte[] txdata = new byte[8];
            int dataCRC = 0;
            int result = 0;

            txdata[0] = (byte)(slaveid & 0xff);
            txdata[1] = 0x03;
            txdata[2] = (byte)((startaddr >> 8) & 0xff);
            txdata[3] = (byte)(startaddr & 0xff);
            txdata[4] = (byte)((reqlen >> 8) & 0xff);
            txdata[5] = (byte)(reqlen & 0xff);

            dataCRC = CalcDataCrc(txdata, 6);

            txdata[7] = (byte)((dataCRC >> 8) & 0xff);
            txdata[6] = (byte)(dataCRC & 0xff);

            result = SendRS485DataApi(txdata, 8);

            return (result);

        }

        public static int WriteflashDataAPI(int slaveid, int sectionNum, int startAddr, int byteCount, byte[] flashdata)
        {
            byte[] txdata = new byte[2200];
            int dataCRC = 0;
            int regedistNum = 0;
            int result;

            regedistNum = byteCount / 2 + 4;

            if ( byteCount <= 0 || byteCount > 2048)
            {
                return (-1);
            }

            txdata[0] = (byte)(slaveid & 0xff);		//从站地址
            txdata[1] = 0x10;							//功能码
            txdata[2] = 0x00;
            txdata[3] = 44;								//flash更新的起始地址为44
            txdata[4] = (byte)((regedistNum >> 8) & 0xff);
            txdata[5] = (byte)(regedistNum & 0xff);
            txdata[6] = (byte)(byteCount & 0xff);

            //段号
            txdata[7] = (byte)((sectionNum >> 8) & 0xff);
            txdata[8] = (byte)(sectionNum & 0xff);

            //起始地址
            txdata[9] = (byte)((startAddr >> 24) & 0xff);
            txdata[10] = (byte)((startAddr >> 16) & 0xff);
            txdata[11] = (byte)((startAddr >> 8) & 0xff);
            txdata[12] = (byte)(startAddr & 0xff);

            //数据长度
            txdata[13] = (byte)((byteCount >> 8) & 0xff);
            txdata[14] = (byte)(byteCount & 0xff);

            for (int i = 0; i < byteCount; i++)
            {
                txdata[15 + i] = flashdata[i];
            }


            dataCRC = CalcDataCrc(txdata, 15 + byteCount);

            txdata[16 + byteCount] = (byte)((dataCRC >> 8) & 0xff);
            txdata[15 + byteCount] = (byte)(dataCRC & 0xff);

            result = SendRS485DataApi(txdata, 17 + byteCount);

            return (result);


        }

        public static int WriteflashCommandAPI(int slaveid, int Command, int data)
        {
            byte[] txdata = new byte[13];
            int dataCRC = 0;
            int result = 0;

            txdata[0] = (byte)(slaveid & 0xff);		//从站地址
            txdata[1] = 0x10;							//功能码
            txdata[2] = 0x00;
            txdata[3] = 42;								//flash更新的起始地址为42
            txdata[4] = 0;
            txdata[5] = 2;
            txdata[6] = 4;

            //命令码
            txdata[7] = (byte)((Command >> 8) & 0xff);
            txdata[8] = (byte)(Command & 0xff);

            //烧录总段长
            txdata[9] = (byte)((data >> 8) & 0xff);
            txdata[10] = (byte)(data & 0xff);


            dataCRC = CalcDataCrc(txdata, 11);

            txdata[12] = (byte)((dataCRC >> 8) & 0xff);
            txdata[11] = (byte)(dataCRC & 0xff);

            result = SendRS485DataApi(txdata, 13);
            return (result);


        }
        public static int mframe_net = 0;
        public static int mframe_ecu = 0;
        public static int mframe_bootver = 0;
        public static int mframe_prover = 0;
        public static int mframe_runModel = 0;
        public static int mframe_runState = 0;
        public static int mframe_ecutype = 0;
        public static int mframe_CANNUM = 0;
        // private static DataTable table;
        public static void UpdataDeviceTable(ref MainFrame mr, int net, int ecu, int bootVersion,
               int ProgramVersion, int runModel, int runState, int ecutype, int cannum)
        {
             
            mframe_net = net;
            mframe_ecu = ecu;
            mframe_bootver = bootVersion;
            mframe_prover = ProgramVersion;
            mframe_runModel = runModel;
            mframe_runState = runState;
            mframe_ecutype = ecutype;
            mframe_CANNUM = cannum;
            String[] device = new String[9];
            int curNet = 0;
            int curEcu = 0;
            //	device[0] =  (( MainFrame.mainFrm.dataGridView1.Rows.Count+1)).ToString();		
            device[0] = "1";
            device[1] = (mframe_net).ToString();
            device[2] = (mframe_ecu).ToString();
            device[3] = "v" + ((mframe_bootver >> 8) & 0xff).ToString() + "." + (mframe_bootver & 0xff).ToString();
            device[4] = "v" + ((mframe_prover >> 8) & 0xff).ToString() + "." + (mframe_prover & 0xff).ToString();
            if (mframe_CANNUM == 0xff)
            {
                device[8] = "以太网";
            }
            else if (mframe_CANNUM == 0xfe)
            {
                device[8] = "RS485";
            }
            else
            {
                device[8] = "CAN" + (mframe_CANNUM).ToString(); ;
            }

            if (mframe_runModel == Api.UserConfig.e_TRANSMIT_MODEL)
            {
                device[5] = "转发模式";
            }
            else if (mframe_runModel == Api.UserConfig.e_CANLOAD_MODEL)
            {
                device[5] = "烧录模式";
            }
            else if (mframe_runModel == Api.UserConfig.e_PROGRAME_MODEL)
            {
                device[5] = "应用程序运行模式";
            }
            else
            {
                device[5] = "未知模式";
            }
            switch (mframe_runState)
            {
                case 0:            /*无应用程序转发状态*/
                    device[6] = "无应用程序转发状态";
                    break;
                case 1:
                    device[6] = "应用程序转发状态";
                    break;
                case 2:
                    device[6] = "烧录准备";
                    break;
                case 3:
                    device[6] = "烧录准备失败";
                    break;
                case 4:
                case 5:
                case 6:
                    device[6] = "正在烧录";
                    break;
                case 7:
                    device[6] = "传输失败";
                    break;
                case 8:
                    device[6] = "烧录失败";
                    break;
                case 9:
                    device[6] = "烧写成功";
                    break;
                case 10:
                    device[6] = "应用程序运行状态";
                    break;
                default:
                    device[6] = "未知状态";
                    break;
            }
            if (mframe_ecutype == 0)
            {
                device[7] = "MC9S08DZ60";
            }
            else if (mframe_ecutype == 1)
            {
                device[7] = "MC9S12XEQ512";
            }
            else if (mframe_ecutype == 2)
            {
                device[7] = "TM4C129ENDPT";
            }
            else if (mframe_ecutype == 3)
            {
                device[7] = "STM32F103";
            }
            else  
            {
                device[7] = "未知类型";
            }
            try
            { 
                for (int columnName = 0; columnName < 9; columnName++)
                    mr.dataGridView1.Rows[0].Cells[columnName].Value = device[columnName];
            }
            catch
            {
                return;
            }
         
 
        }
        public static Boolean Explain03Response(byte[] readbuf, int readlength)
        {
            int funcode = 0;
            int CRC = 0;
            int CRCHi = 0;
            int CRCLo = 0;
            int[] userReadData = new int[9];
            UserDeviceMsg user = new UserDeviceMsg();
            funcode = readbuf[1] & 0xff;
            if ((readlength != 23) || ((readbuf[0] & 0xff) != RS485Driver.SlaveId) || (readbuf[2] != 18) || funcode != 0x03)//回复长度不足
            {
                System.Console.Write("RS485Driver:接收到异常数据:" + "\n");
                for (int i = 0; i < readlength; i++)
                {
                    //System.Console.Write(Integer.toHexString(readbuf[i] & 0xff) + " ");
                    System.Console.Write((readbuf[i] & 0xff).ToString() + "\n");
                }
                //System.Console.Write();
                return false;
            }
            CRC = CalcDataCrc(readbuf, readlength - 2);
            CRCHi = (CRC >> 8) & 0xff;
            CRCLo = CRC & 0xff;
            if ((CRCHi != (readbuf[readlength - 1] & 0xff)) || (CRCLo != (readbuf[readlength - 2] & 0xff)))
            {
                System.Console.Write("RS485Driver: receive data's CRC is Error!" + "\n");
                return false;
            }
            for (int i = 0; i < 9; i++)
            {
                userReadData[i] = ((readbuf[3 + i * 2] & 0xff) << 8) | (readbuf[4 + i * 2] & 0xff);
            }
            int bootVersion = userReadData[5];
            int ProgramVersion = userReadData[4];
            int pro = userReadData[8];
            int runModel = userReadData[7];
            int runState = userReadData[6];
            int ecutype = userReadData[3];
            int canNum = 0xfe;
            int net = userReadData[1];
            int ecu = userReadData[2];

            MainFrame ff = (MainFrame)Class1.LocalForm1;
             

            UpdataDeviceTable(ref ff, net, ecu, bootVersion,
                    ProgramVersion, runModel, runState, ecutype, canNum);

            user.BootVersion = bootVersion;
            user.ProgrameVersion = ProgramVersion;
            user.LoadingProcess = pro;
            user.Net = net;
            user.Ecu = ecu;
            user.RunModel = runModel;
            user.RunState = runState;

            if (net == UserLoadFlash.LoadNet && ecu == UserLoadFlash.LoadEcu)
            {
                RS485Updateflash.UserLoadingState = runState;
                RS485Updateflash.UserLoadingNum = pro;

                System.Console.Write("MC9S08DZ60已完成更新第" + user.LoadingProcess + "段!" + "\n");
            }

            UserMsgRecord.Updata(user);

            return true;
        }

        static int readlength = 0;
        public static Boolean ReadReceiveRS485Data()
        {
         
            byte[] readbuf = new byte[1024];
            Boolean Result = true;

            byte[] splitdata = new byte[23];
            int splitlength = 0;
            int splitStart = 0;

            readlength = serialport.BytesToRead;

            try
            {
                if (serialport.Read(readbuf, 0, readlength) != 0)//读取发送的信息
                {                   
                   // readlength = readbuf.Length;
                    while (splitStart < readlength)
                    {
                        splitlength = readbuf[splitlength + 2] + 5;
                        if (readlength < splitlength)
                        {
                            System.Console.Write("长度超限制");
                            return false;
                        }

                        for (int i = 0; i < splitlength; i++)
                        {
                            splitdata[i] = readbuf[splitStart + i];
                        }

                        Result = Explain03Response(splitdata, splitlength);

                        splitStart = splitStart + splitlength;

                        if (Result == false)
                        {
                            return false;
                        }

                    }

                    return true;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("读取失败");
                return false;
            }

            return false;
        }
    
        static int CalcDataCrc(byte[] buf, int len)
        {
            int i = 0;
            int j = 0;
            int c = 0;
            int crc = 0xFFFF;

            for (i = 0; i < len; i++)
            {
                c = buf[i] & 0x00FF;
                crc ^= c;
                for (j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return (crc);
        }


    }
}