using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rs485loader_csharp.Rs485
{
    class UserLoadFlash
    {
        public UserLoadFlash()
        {
            ;
        }

        //需要更新的网络号及结点号
        public static int LoadNet = 254;
        public static int LoadEcu = 254;

        public static void UpdataLoadNet(int net, int ecu)
        {
            LoadNet = net;
            LoadEcu = ecu;
        }
	
    }
}
