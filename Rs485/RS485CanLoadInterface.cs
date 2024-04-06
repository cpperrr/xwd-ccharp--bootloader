using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rs485loader_csharp.Rs485
{
     public class RS485CanLoadInterface
    {
        public static int e_Cmd_IntoTransmit = 0xE0;                 /*进入转发模式*/
        public static int e_Cmd_ExitTransmit = 0xE1;                 /*退出转发模式*/
        public static int e_Cmd_Reset = 0xE2;                 /*请求复位*/
        public static int e_Cmd_IntoLoad = 0xE3;                 /*请求烧录*/
        public static int e_Cmd_ExitLoad = 0xE4;                 /*退出烧录*/
        public static int e_Cmd_FinishLoad = 0xE5;                 /*烧录完成*/
    }
}
