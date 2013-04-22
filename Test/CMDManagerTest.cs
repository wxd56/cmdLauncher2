using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.manager;
using wxd.tool.cmdL.SharedModels;

namespace wxd.tool.cmdL.Test
{
    class CMDManagerTest
    {
        
        public static void test()
        { 
            CMDManager manager = CMDManagerFactory.getManager();
            CMD cmd = manager.getCMDList()[0];
            Console.WriteLine(cmd.ToString());
            manager.execCMD(cmd);

            List<CMD> result = manager.findCmds("my");
            Console.WriteLine("search result:" + result.ToString());
        }

        private static void testFind()
        { 
            
        }
        
    }
}
