using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace rs485loader_csharp
{
    public static class Class1
    {
        public static Form LocalForm1;
        public static Form LocalForm2;
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

    
        static void Main()
        {
          //  AttachConsole(ATTACH_PARENT_PROCESS);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Class1.LocalForm1 = new MainFrame();
            Class1.LocalForm2 = new RS232ConfigFrame();
            //  Application.Run(new MainFrame());
           Application.Run(Class1.LocalForm1);
        }
    }
}
