using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rs485loader_csharp.Api
{
    public class UserDeviceMsg 
    {
	    public int Net = 0;			//net
	    public int Ecu = 0;			//ecu
	    public int RunModel = 0;	//device run model
	    public int RunState = 0;	//device run state
	    public int BootVersion = 0;	//device boot version
	    public int ProgrameVersion = 0;	//device programe version
	    public int LoadingProcess = 0;	//device loading Programe

    }

}
