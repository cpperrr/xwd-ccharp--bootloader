using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using rs485loader_csharp.Rs485;
using rs485loader_csharp.Api;

namespace rs485loader_csharp.Api
{
    /*
     * 解析文件
     */
    public class UserExplainFile
    {

        public static UserFileData[] flash_Data = new UserFileData[Api.UserConfig.FLASH_DATA_BUF_LENGTH];
        public static int CurSecNum = 0xffffff;
        public static int Flash_SectionNum = 0;

        public static int gFileState = -1;		//读取文件的状态 0：未读取 1:读取成功

        public UserExplainFile()
        {
            ;
        }

        public static int IsHasFile()
        {
            return gFileState;
        }

        public static void InitUserFile()
        {
            for (int i = 0; i < Api.UserConfig.FLASH_DATA_BUF_LENGTH; i++)
            {
                flash_Data[i] = new UserFileData();

                UserExplainFile.flash_Data[i].StartAddress = 0;
                UserExplainFile.flash_Data[i].SectionDataNum = 0;

                for (int k = 0; k < Api.UserConfig.FLASH_DATA_BUF_SIZE; k++)
                {
                    UserExplainFile.flash_Data[i].data[k] = (byte)0xff;
                }
            }

            Flash_SectionNum = 0;
            CurSecNum = 0xffffff;
            gFileState = 0;
            System.Console.Write("初始化加载设备\n");

        }

        public static int GetSectionNum()
        {
            return (Flash_SectionNum);
        }

        public static UserFileData GetSectionData(int Num)
        {
            UserFileData temp = new UserFileData();

            temp.CRC = 0;
            temp.SectionDataNum = 0;
            temp.StartAddress = 0xfffffff;

            if (Num >= Api.UserConfig.FLASH_DATA_BUF_LENGTH)
            {
                return (temp);
            }

            return (flash_Data[Num]);
        }

        public int ReadFile(String pathname)
        {
            int result = -1;
            if (pathname.EndsWith(".hex"))
            {
                result = ReadHex(pathname);
            }
            else if (pathname.EndsWith(".s19") || pathname.EndsWith(".glo"))
            {
                result = ReadS19orGlo(pathname);
            }
            else
            {
                result = -1;
            }

            return result;
        }

        public int ReadHex(String pathname)
        {
            FileStream f = new FileStream(pathname, FileMode.Open);
            String readData = null;
            BufferedStream readbuf; //
            StreamReader readfile;  //
            int SectionDataNum = 0;	//数据长度
            int lineType = 0;		/*数据类型*/
            UInt16 offset = 0;		/*起始地址*/
            int AddrHighPart = 0;	/*起始地址高位*/
            int temp = 0;			/*临时变量*/
            int i = 0;
            byte[] flashdata = new byte[Api.UserConfig.FLASH_DATA_BUF_SIZE];/*存储临时一段的数据*/
            int StartAddress = 0;
            int CurSection = 0;

            InitUserFile();		//初始化文件
            gFileState = -1;

            /*文件允许读写*/
            if (File.Exists(pathname) && f.CanRead)
            {

                try
                {
                    readfile = new StreamReader(f);
                    MemoryStream memStream = new MemoryStream(); 
                    readbuf = new BufferedStream(memStream);

                    while ((readData = readfile.ReadLine()) != null)
                    {
                        /*读取数据长度，起始地址，及类型*/
                        CurSection++;         
                        offset = Convert.ToUInt16(readData.Substring(3, 4), 16);
                       lineType = Convert.ToInt16(readData.Substring(7, 2), 16);
                       SectionDataNum = Convert.ToInt16(readData.Substring(1, 2), 16);
                        if (lineType == Api.UserConfig.INTER_HEX_DATA)/*数据段  00  */
                        {
                         
                            for (i = 0; i < SectionDataNum; i++)
                            {
                                flashdata[i] = (byte)Convert.ToInt16(readData.Substring(9 + i * 2, 2), 16);
                            }

                            StartAddress = AddrHighPart + offset;

                            if (CurSecNum == 0xffffff)
                            {
                                CurSecNum = 0;
                                flash_Data[CurSecNum].StartAddress = StartAddress;
                                flash_Data[CurSecNum].SectionDataNum = SectionDataNum;
                                for (i = 0; i < SectionDataNum; i++)
                                {
                                    flash_Data[CurSecNum].data[i] = flashdata[i];
                                }
                            }//合并到一起			
                            else
                            {
                                if ((StartAddress == (flash_Data[CurSecNum].StartAddress + flash_Data[CurSecNum].SectionDataNum))
                                && ((SectionDataNum + flash_Data[CurSecNum].SectionDataNum) <= Api.UserConfig.FLASH_DATA_BUF_SIZE))
                                {
                                    for (i = 0; i < SectionDataNum; i++)
                                    {
                                        flash_Data[CurSecNum].data[flash_Data[CurSecNum].SectionDataNum + i] = flashdata[i];
                                    }
                                    flash_Data[CurSecNum].SectionDataNum += SectionDataNum;
                                }
                                else
                                {
                                    CurSecNum++;
                                    flash_Data[CurSecNum].StartAddress = StartAddress;
                                    flash_Data[CurSecNum].SectionDataNum = SectionDataNum;
                                    for (i = 0; i < SectionDataNum; i++)
                                    {
                                        flash_Data[CurSecNum].data[i] = flashdata[i];
                                    }
                                }
                            }
                        }
                        else if (lineType == Api.UserConfig.INTER_HEX_END)/*文件结束*/ // 01
                        {
                            Flash_SectionNum = CurSecNum + 1;
                            for (i = 0; i < Flash_SectionNum; i++)
                            {
                                flash_Data[i].CRC = UserExplainFile.CalcDataCrc(flash_Data[i].data, flash_Data[i].SectionDataNum);
                                System.Console.Write("段号为:" + i + "，起始地址为:" + Convert.ToString((flash_Data[i].StartAddress),16) +
                                        "，长度为:" + flash_Data[i].SectionDataNum+"\n");                           
                            }
                            System.Console.Write("文件加载完成\n");
                        }
        /* 不存在*/    else if (lineType == Api.UserConfig.INTER_HEX_SECTION)/*偏移段地址*/
                        {
                            temp = Convert.ToInt16(readData.Substring(7, 4), 16);
                            AddrHighPart = temp << 4;
                        }
                        else if (lineType == Api.UserConfig.INTER_LINE_FLAG)/*偏移段线性地址*/ //04 文件开头
                        {
                             temp = Convert.ToInt32(readData.Substring(9, 4), 16);
                          //   AddrHighPart = temp << 16;
                             AddrHighPart = 0x8000000;
                            System.Console.Write("AddrHighPart地址为:" + AddrHighPart.ToString()+"\n");
                        }
                        else if (lineType == Api.UserConfig.INTER_HEX_STARTADDR)        //05  文件结束
                        {
                            temp = Convert.ToInt32(readData.Substring(9, 8), 16);
                            System.Console.Write("程序入口地址为：0x" + temp.ToString() + "\n");
                        }
                        else
                        {
                            System.Console.Write("异常标识符:" + lineType + ",第" + CurSection + "行" + "\n");
                            readbuf.Close();
                            readfile.Close();
                            return (-1);
                        }

                    }
                    readbuf.Close();
                    readfile.Close();

                }
                catch (FileNotFoundException e)
                {
                    System.Console.Write("转换异常" + "\n");             
                    return (-1);
                }
                catch (IOException e)
                {
                
                    System.Console.Write("转换异常" + "\n");
                    return (-1);
                }
                catch (NullReferenceException e)
                {            
                    System.Console.Write("转换异常" + "\n");
                    return (-1);
                }

            }

            gFileState = 0;	//文件解析完成
            return (0);
        }
        public int ReadS19orGlo(String pathname)
        {
          //  FileStream f = new FileStream(pathname, FileMode.Open);
            String readData = null;
           // BinaryReader readbuf;
          //  StreamReader readfile;
            FileStream fs = new FileStream(pathname, FileMode.Open);
            StreamReader reader = new StreamReader(fs, Encoding.UTF8);
            InitUserFile();	//初始化参数
            gFileState = -1;	//文件解析完成
            if (File.Exists(pathname))
            {
               // try
                {
                    while ((readData = reader.ReadLine()) != null)
                    {
                        if (readData.StartsWith("S1"))	//数据域
                        {
                            Explain_S1(readData);
                        }
                        else if (readData.StartsWith("S2"))
                        {
                            Explain_S2(readData);
                        }
                        else if (readData.StartsWith("S0"))//起始域
                        {
                            System.Console.Write("Start to explain the file......" + "\n"); ;
                        }
                        else if (readData.StartsWith("S9"))//结束域
                        {
                            Flash_SectionNum = CurSecNum + 1;
                            for (int i = 0; i < Flash_SectionNum; i++)
                            {
                                flash_Data[i].CRC = UserExplainFile.CalcDataCrc(flash_Data[i].data, flash_Data[i].SectionDataNum);
                            }
                        }
                        else
                        {
                            reader.Close();
                            fs.Close();
                            return (-1);
                        }
                    }
                    reader.Close();
                    fs.Close();
                }
       
            }
            else
            {
                System.Console.Write("文件不存在或不允许读取" + "\n");
                return (-1);
            }

            gFileState = 0;	//文件解析完成
            return 0;
        }

        public void Explain_S1(String data)
        {
            String temp = null;
            byte[] flashdata = new byte[Api.UserConfig.FLASH_DATA_BUF_SIZE];
            int i = 0;
            int StartNum = 8;

            int StartAddress = 0;
            int SectionDataNum = 0;

          //  temp = data.Substring(2, 4);
            temp = data.Substring(2, 2);
            SectionDataNum = Convert.ToInt16(temp, 16) - 3;

            //  temp = data.substring(4,8);	
            temp = data.Substring(4, 4);
            StartAddress = Convert.ToInt16(temp, 16);

            for (i = 0; i < SectionDataNum; i++)
            {
               // temp = data.Substring(StartNum, StartNum + 2);
                temp = data.Substring(StartNum, 2);
                StartNum = StartNum + 2;
                flashdata[i] = (byte)(Convert.ToInt16(temp, 16) & 0xff);
            }

            if (CurSecNum == 0xffffff)
            {
                CurSecNum = 0;
                flash_Data[CurSecNum].StartAddress = StartAddress;
                flash_Data[CurSecNum].SectionDataNum = SectionDataNum;
                for (i = 0; i < SectionDataNum; i++)
                {
                    flash_Data[CurSecNum].data[i] = flashdata[i];
                }
            }//合并到一起			
            else
            {
                if ((StartAddress == (flash_Data[CurSecNum].StartAddress + flash_Data[CurSecNum].SectionDataNum))
                && ((SectionDataNum + flash_Data[CurSecNum].SectionDataNum) <= Api.UserConfig.FLASH_DATA_BUF_SIZE))
                {
                    for (i = 0; i < SectionDataNum; i++)
                    {
                        flash_Data[CurSecNum].data[flash_Data[CurSecNum].SectionDataNum + i] = flashdata[i];
                    }
                    flash_Data[CurSecNum].SectionDataNum += SectionDataNum;
                }
                else
                {
                    CurSecNum++;
                    flash_Data[CurSecNum].StartAddress = StartAddress;
                    flash_Data[CurSecNum].SectionDataNum = SectionDataNum;
                    for (i = 0; i < SectionDataNum; i++)
                    {
                        flash_Data[CurSecNum].data[i] = flashdata[i];
                    }
                }
            }

        }

        public void Explain_S2(String data)
        {
            String temp = null;
            byte[] flashdata = new byte[Api.UserConfig.FLASH_DATA_BUF_SIZE];
            int i = 0;
            int StartNum = 10;

            int StartAddress = 0;
            int SectionDataNum = 0;

            temp = data.Substring(2, 4);
            SectionDataNum = Convert.ToInt16(temp, 16) - 4;

            temp = data.Substring(4, 10);
            StartAddress = Convert.ToInt16(temp, 16);

            for (i = 0; i < SectionDataNum; i++)
            {
                temp = data.Substring(StartNum, StartNum + 2);
                StartNum = StartNum + 2;
                flashdata[i] = (byte)(Convert.ToInt16(temp, 16) & 0xff);
            }

            if (CurSecNum == 0xffffff)
            {
                CurSecNum = 0;
                flash_Data[CurSecNum].StartAddress = StartAddress;
                flash_Data[CurSecNum].SectionDataNum = SectionDataNum;
                for (i = 0; i < SectionDataNum; i++)
                {
                    flash_Data[CurSecNum].data[i] = flashdata[i];
                }
            }//合并到一起			
            else
            {
                if ((StartAddress == (flash_Data[CurSecNum].StartAddress + flash_Data[CurSecNum].SectionDataNum))
                && ((SectionDataNum + flash_Data[CurSecNum].SectionDataNum) <= Api.UserConfig.FLASH_DATA_BUF_SIZE))
                {
                    for (i = 0; i < SectionDataNum; i++)
                    {
                        flash_Data[CurSecNum].data[flash_Data[CurSecNum].SectionDataNum + i] = flashdata[i];
                    }
                    flash_Data[CurSecNum].SectionDataNum += SectionDataNum;
                }
                else
                {
                    CurSecNum++;
                    flash_Data[CurSecNum].StartAddress = StartAddress;
                    flash_Data[CurSecNum].SectionDataNum = SectionDataNum;
                    for (i = 0; i < SectionDataNum; i++)
                    {
                        flash_Data[CurSecNum].data[i] = flashdata[i];
                    }
                }
            }

        }

        public static int CalcDataCrc(byte[] data, int len)
        {
            int i = 0;
            int j = 0;
            int sCRC = 0xFFFF;
            for (i = 0; i < len; i++)
            {
                sCRC = sCRC ^ (data[i] & 0xff);
                for (j = 0; j < 8; j++)
                {
                    if ((sCRC & 0x01) == 1)
                    {
                        sCRC = (sCRC ^ 0xA001);
                    }
                    sCRC = (sCRC >> 1);
                }

            }

            return (sCRC & 0xffff);
        }

    }
}

