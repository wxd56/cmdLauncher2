using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.manager;
using wxd.tool.cmdL.dao;
using wxd.tool.cmdL.dao.impl;
using wxd.tool.cmdL.SharedModels;
using System.ComponentModel;
using System.IO;

namespace wxd.tool.cmdL.manager.impl
{
    class CMDManagerImpl :  CMDManager
    {
        private static String defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\cmdL.xml";

        private CMDDAO cmdDAO = new CMDDAOImpl();
        private List<CMD> cmdList = null;


        /// <summary>
        /// 重新加载命令
        /// </summary>
        /// <param name="savePath">文件路径，可以为空</param>
        public void reLoadCmds(String filePath) 
        {
            if (filePath == null) filePath = defaultPath;

            //判断文件是否存在
            if (!File.Exists(filePath))
            {
               //复制默认的模板文件到我的文档下面
                File.Copy(Environment.CurrentDirectory + @"\cmdL.xml", filePath);
            }

            this.cmdList = cmdDAO.load(filePath);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        public String execCMD(CMD cmd)
        {
            
                if (cmd.Path.Equals(String.Empty))
                {
                    //调用默认的命令执行器来执行
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("explorer.exe");
                    psi.Arguments = "/e," + cmd.Args;
                    System.Diagnostics.Process.Start(psi);

                }
                else
                {
                    //判断文件是否存在
                    if (!File.Exists(cmd.Path)) {
                        return "文件不存在：" + cmd.Path;
                    } 

                    //调用制定的执行器
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(cmd.Path);
                    psi.Arguments = cmd.Args;
                    System.Diagnostics.Process.Start(psi);
                }
                return null;
            
        }

        /// <summary>
        /// 根据命令名称来查找命令
        /// </summary>
        /// <param name="cmdName">命令名称</param>
        /// <returns></returns>
        public List<CMD> findCmds(String cmdName)
        {
            if (cmdName == null || cmdName.Equals(String.Empty)) return this.cmdList;
            return this.cmdList.FindAll(
                delegate(CMD cmd) {
                    if (cmd.Name.StartsWith(cmdName))
                    {
                        return true;
                    }
                    return false;
            });
        }

        /// <summary>
        /// 保存命令
        /// </summary>
        /// <param name="savePath">文件路径，可以为空</param>
        public void saveCMD(String savePath)
        {
            if (savePath == null) savePath = defaultPath;
            this.cmdDAO.flush(savePath, this.cmdList);
        }

        /// <summary>
        /// 得到命令列表
        /// </summary>
        /// <returns></returns>
        public List<CMD> getCMDList()
        {
            if (this.cmdList == null) this.reLoadCmds(null);
            return this.cmdList;
        }

        /// <summary>
        /// 根据命令的名称来精确查找命令
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        public  CMD findByName(String cmdName)
        {
            this.getCMDList();
            foreach (CMD c in this.cmdList)
            {
                if (c.Name.Equals(cmdName)) return c;
            }
            return null;
        }

    }
}
