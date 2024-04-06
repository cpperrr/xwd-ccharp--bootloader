using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rs485loader_csharp.Api;

namespace rs485loader_csharp.Rs485
{ 
        public class UserFileData 
        {
	        public int StartAddress = 0;
	        public byte[] data = new byte[Api.UserConfig.FLASH_DATA_BUF_SIZE];
	        public int SectionDataNum = 0;
	        public int CRC = 0;
        }

}
