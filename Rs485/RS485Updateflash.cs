using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rs485loader_csharp.Api;
using System.Threading;

namespace rs485loader_csharp.Rs485
{
    class RS485Updateflash
    {
            public RS485Updateflash()
            {
                _keepReading = true;
                _readThread = new Thread(run);
                _readThread.Start();
            }

            public void thread_quit()
            {
                //_readThread.Suspend();
                _readThread = new Thread(run);
                _readThread.Abort();
            }
            public void thread_query()
            {
          
            }
            
            public static void StartRS485Update()
            {
                if (IsFlashUpdataStart == true)
                {
                    return;
                }

                gLoadingSection = 0;
                updateStep = 0;
                StartTime = DateTime.Now.Millisecond;
                ReSendtime = 0;
                IsFlashUpdataStart = true;
            }

            public static int updateStep = 0;	//更新程序的步骤
            public static Boolean IsFlashUpdataStart = false;
            public static int gLoadingSection = 0;
            public static long StartTime = 0;
            public static UserFileData flashdata;
            public static int ReSendtime = 0;
            public static int UserLoadingState = 0xff;
            public static int UserLoadingNum = 0xffff;
            public static int Cycletimer = 300;

           Thread _readThread;
            bool _keepReading;
         
            public void run()
	        {		                
             //   MainFrame ff = (MainFrame)Class1.LocalForm1;              
		        while(true)
		        {
			        if(RS485Driver.IsWorking() == true)
			        {
				        if(IsFlashUpdataStart == true)
				        {
					        long Curtime = DateTime.Now.Millisecond;
					        int time = (int) (Curtime - StartTime);
					        int pro = (gLoadingSection)*100/UserExplainFile.Flash_SectionNum;
					       // UpdataLoadingState(ref ff);		
							System.Console.Write(DateTime.Now.ToString("HH:mm:ss"));	
					        switch(updateStep)
					        {
						        case 0:		
							        RS485Driver.ReadReceiveRS485Data();
							        flashdata = UserExplainFile.GetSectionData(gLoadingSection);
                                    System.Console.Write("正在发送第" + gLoadingSection + "段!" + "\n");
                                    System.Console.ReadLine(); 
							        RS485Driver.WriteflashDataAPI(RS485Driver.SlaveId, gLoadingSection + 1, flashdata.StartAddress, flashdata.SectionDataNum, flashdata.data);
							        updateStep = 1;
							        Cycletimer = 500;       //1000
							        break;
						        case 1:
							        if(RS485Driver.ReadReceiveRS485Data() == true)
							        {
                                        if (UserLoadingState == Api.UserConfig.e_CANLOADTRANSMIT_FAIL)
								        {
									        updateStep = 0;
									        ReSendtime++;
                                            System.Console.Write("正在重传第" + gLoadingSection + "段!" + "\n");
								        }
                                        else if (UserLoadingState == Api.UserConfig.e_CANLOADFLASH_FAIL)
								        {
									        updateStep = 4;
                                            System.Console.Write("程序更新失败" + "\n");
								        }
                                        else if (UserLoadingState == Api.UserConfig.e_CANLOADTRANSMITING && UserLoadingNum == gLoadingSection + 1)
								        {
									        updateStep = 0;
									        gLoadingSection++;
								        }

                                        System.Console.Write("RS485升级，发送完段号：" + gLoadingSection + "\n");
								        if(gLoadingSection >= UserExplainFile.Flash_SectionNum)
								        {
									        updateStep = 2;
								        }
								        else
								        {
									        updateStep = 0;
								        }	
								
								        Cycletimer = 100;
								
							        }
							        else
							        {
								        //发送查询报文
								        RS485Driver.ReadModbusAPI(RS485Driver.SlaveId, 33, 9);
								        Cycletimer = 400;       //400
							        }
							
							        break;
								
						        case 2:
							        //发送烧录结束符
                                    RS485Driver.WriteflashCommandAPI(RS485Driver.SlaveId, Rs485.RS485CanLoadInterface.e_Cmd_FinishLoad, 0);
							        Cycletimer = 200;
							        updateStep = 3;
							        break;
						        case 3:
							        if(RS485Driver.ReadReceiveRS485Data() == true)
							        {
                                        if ((UserLoadingState == Api.UserConfig.e_CANLOADFLASH_OK) || (UserLoadingState == Api.UserConfig.e_CANLOADFLASH_FAIL))
								        {
									        IsFlashUpdataStart = false;
								        }
                                        else if (UserLoadingState == Api.UserConfig.e_CANLOADTRANSMITING)
								        {
									        updateStep = 2;
								        }
								        Cycletimer = 100;	
							        }
							        else
							        {
								        RS485Driver.ReadModbusAPI(RS485Driver.SlaveId, 33, 9);
								        Cycletimer = 200;   //300
							        }
							        break;
						        case 4:
							
							        break;
						        default:
							        break;
					        }
				        }
				        else
				        {
					        RS485Driver.ReadReceiveRS485Data();
					        RS485Driver.ReadModbusAPI(RS485Driver.SlaveId, 33, 9);
					        Cycletimer = 500;
				        }
			        }
			 
				    Thread.Sleep(Cycletimer);
			       
			      
		        }
	        }
    }
}
