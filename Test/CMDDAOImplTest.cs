using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using wxd.tool.cmdL.dao.impl;
using wxd.tool.cmdL.dao;
using wxd.tool.cmdL.SharedModels;
namespace wxd.tool.cmdL.Test
{
    /// <summary>
    /// 测试cmd DAOd的默认实现
    /// </summary>
    class CMDDAOImplTest
    {
        private static CMDDAO dao = new CMDDAOImpl();
        private static String myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);            

        public static void test() 
        {
            testLoad();
            //testFlush();
        }


        private static void testFlush()
        { 
          List<CMD> cmdList = testLoad();
          dao.flush(myDocPath + "\\ssssss.xml",cmdList);

        }

        private  static List<CMD> testLoad()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("test CMDDAOImpl.load()");
            Console.WriteLine("---------------");

            
            String filePath = myDocPath + @"\cmdL.xml";

            List<CMD> cmds = dao.load(filePath);
            foreach (CMD cmd in cmds)
            {
                Console.WriteLine(cmd.ToString());
            }

            return cmds;

        }
    }
}
