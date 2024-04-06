using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using rs485loader_csharp.Rs485;
using rs485loader_csharp.Api;

namespace rs485loader_csharp.Api
{
    public class UserConfig
    {
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

        public static int e_LOADTRANSMIT_STATE = 0;            /*无应用程序转发状态*/
        public static int e_PROTRANSMIT_STATE = 1;            /*应用程序转发状态*/
        public static int e_CANLOADREADY_OK = 2;            /*烧录准备*/
        public static int e_CANLOADREADY_FAIL = 3;            /*烧录准备失败*/
        public static int e_CANLOADPRE_OK = 4;            /*烧录就绪*/
        public static int e_CANLOADTRANSMITING = 5;            /*正在传输*/
        public static int e_CANLOADTRANSMIT_FAIL = 6;            /*传输失败*/
        public static int e_CANLOADTRANSMIT_OK = 7;            	/*传输成功*/
        public static int e_CANLOADFLASH_FAIL = 8;             /*烧录失败*/
        public static int e_CANLOADFLASH_OK = 9;            	/*烧录成功*/
        public static int e_PRORUN_STATE = 10;           /*应用程序运行状态*/

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

    }
}