using rs485loader_csharp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;//在C#中使用ArrayList必须引用Collections类
using rs485loader_csharp.Rs485;

namespace rs485loader_csharp.Rs485
{
  
    class UserMsgRecord
    {

        public static List<UserDeviceMsg> device = new List<UserDeviceMsg>();
      //  public static ArrayList device = new ArrayList();
        public static void RemoveAll()
        {
            device.Clear();
        }
        public static int IsExistDevice()
        {
            if (device.Count == 0)
            {
                return (-1);
            }

            return (0);
        }

        /*
         * 判断是否存在此设备
         */
        public static int IsExist(UserDeviceMsg e)
        {
            for (int i = 0; i < device.Count; i++)
            {
                if (device[i].Net == e.Net && device[i].Ecu == e.Ecu)
                {
                    return (0);
                }
            }

            return (-1);
        }

        /*
         * 查询是否处于烧录准备
         */
        public static int IsLoadReadyState(int net, int ecu)
        {
            if (ecu <= 0xff)
            {
                for (int i = 0; i < device.Count; i++)
                {
                    if (device[i].Net == net)
                    {
                        if ((device[i].RunState == Api.UserConfig.e_CANLOADREADY_OK)
                        && (device[i].RunModel == Api.UserConfig.e_CANLOAD_MODEL))
                        {
                            return (0);
                        }
                        else
                        {
                            return (-1);
                        }

                    }

                }
            }
            else
            {
                for (int i = 0; i < device.Count; i++)
                {
                    if (device[i].Net == net && device[i].Ecu == ecu)
                    {
                        if ((device[i].RunState == Api.UserConfig.e_CANLOADREADY_OK)
                        && (device[i].RunModel == Api.UserConfig.e_CANLOAD_MODEL))
                        {
                            return (0);
                        }
                        else
                        {
                            return (-1);
                        }

                    }

                }
            }

            return (-2);
        }

        /*
         * 查询是否处于烧录就绪
         */
        public static int IsRecSectionMsg(int net, int ecu)
        {

            int Ready = 0;
            for (int i = 0; i < device.Count; i++)
            {
                if ((device[i].Net == net && ecu == 0xff)
                    || (device[i].Net == net && device[i].Ecu == ecu)
                    )
                {
                    if ((device[i].RunState != Api.UserConfig.e_CANLOADPRE_OK)
                    || (device[i].RunModel != Api.UserConfig.e_CANLOAD_MODEL))
                    {
                        return (-1);
                    }
                    else
                    {
                        Ready++;
                    }

                }
            }

            if (Ready > 0)
            {
                return (0);
            }

            return (-2);
        }

        /*
         * 查询是否传输完成
         */
        public static int IsCanTransmitOk(int net, int ecu)
        {
            int flashOk = 0;
            int deviceNum = 0;
            int transmitOk = 0;
            for (int i = 0; i < device.Count; i++)
            {
                if ((device[i].Net == net && ecu == 0xff)
                    || (device[i].Net == net && device[i].Ecu == ecu)
                    )
                {
                    deviceNum++;
                    if (device[i].RunState == Api.UserConfig.e_CANLOADTRANSMIT_FAIL)//传输失败
                    {
                        return (-1);
                    }
                    else if (device[i].RunState == Api.UserConfig.e_CANLOADFLASH_FAIL)//烧录失败
                    {
                        return (-2);
                    }
                    else if (device[i].RunState == Api.UserConfig.e_CANLOADTRANSMITING)//正在传输
                    {
                        return (-3);
                    }

                    if ((device[i].RunState == Api.UserConfig.e_CANLOADFLASH_OK)
                       && (device[i].RunModel == Api.UserConfig.e_CANLOAD_MODEL))
                    {
                        flashOk++;
                        //return (1);
                    }

                    if ((device[i].RunState == Api.UserConfig.e_CANLOADTRANSMIT_OK)
                       && (device[i].RunModel == Api.UserConfig.e_CANLOAD_MODEL))
                    {
                        transmitOk++;
                        //return(0);
                    }
                }
            }

            if (deviceNum == flashOk)
            {
                return (1);
            }

            if (transmitOk == deviceNum)
            {
                return (0);
            }

            return (-4);
        }              
        /*
         * 判断是否允许开始烧录
         */
        public static int IsAllowCanLoad()
        {
            for (int i = 0; i < device.Count; i++)
            {
                //if(device[i].RunModel !=)
            }

            return (0);
        }
        /*
         * 清除所有的设备信息
         */
        public static void Updata(UserDeviceMsg e)
        {
            for (int i = 0; i < device.Count; i++)
            {
                if (device[i].Net == e.Net && device[i].Ecu == e.Ecu)
                {
                    device[i].BootVersion = e.BootVersion;
                    device[i].ProgrameVersion = e.ProgrameVersion;
                    device[i].LoadingProcess = e.ProgrameVersion;
                    device[i].RunModel = e.RunModel;
                    device[i].RunState = e.RunState;
                    return;
                }
            }
            device.Add(e);
        }
        /*
         * 判断所有设备是否都处于转发模式中
         */
        public static int IsAllInTrasmitModel()
        {
            for (int i = 0; i < device.Count; i++)
            {
                if (device[i].RunModel != Api.UserConfig.e_TRANSMIT_MODEL)
                {
                    return (-1);
                }
            }
            return (0);
        }

        public static int IsRightNessToCanLoad()
        {
            for (int i = 0; i < device.Count; i++)
            {

            }
            return (0);
        }

        /*
         * 判断所有设备是否都处于烧录模式
         */
        public static int IsAllInCanLoading()
        {
            for (int i = 0; i < device.Count; i++)
            {
                if (device[i].RunModel != Api.UserConfig.e_CANLOAD_MODEL)
                {
                    return (-1);
                }
            }
            return (0);
        }

        /*
         * 判断同一设备类型的设备是否处于烧录模式
         */
        public static int IsAllInCanLoading(int net)
        {
            for (int i = 0; i < device.Count; i++)
            {
                if (device[i].Net == net)
                {
                    if (device[i].RunModel != Api.UserConfig.e_CANLOAD_MODEL)
                    {
                        return (-1);
                    }
                }
            }
            return (0);
        }

    }
}
