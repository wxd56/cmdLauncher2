using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.SharedModels;

namespace wxd.tool.cmdL.Test
{
    /// <summary>
    /// 测试cmd model
    /// </summary>
    class CmdModelTest
    {
        public static void test()
        {
            CMD cmd = new CMD();
            cmd.Path = "sfds";
            cmd.Path = "d:\test";
            cmd.Name = "test";
            Console.WriteLine(cmd.ToString());
        }
    }
}
