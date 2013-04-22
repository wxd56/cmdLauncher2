using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.manager.impl;

namespace wxd.tool.cmdL.manager
{
    /// <summary>
    /// 命令管理器的工厂类
    /// </summary>
    public class CMDManagerFactory
    {
        private CMDManagerFactory() { }

        private static CMDManager manager = null;

        public static CMDManager getManager()
        {
            if (manager == null)
            {
                manager = new CMDManagerImpl();
            }
            return  manager;
        }
    }
}
