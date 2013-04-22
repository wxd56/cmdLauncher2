using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxd.tool.cmdL.Test
{
    class OpenExplorerTest
    {
        public static void test()
        {
            String currPath = System.Environment.CurrentDirectory;

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(currPath + @"\cmdExecutor\defaultExec.bat");
            psi.Arguments = @"D:\test";
            System.Diagnostics.Process.Start(psi);

        }
    }
}
