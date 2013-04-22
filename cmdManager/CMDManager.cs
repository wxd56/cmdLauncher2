using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.SharedModels;
namespace wxd.tool.cmdL.manager
{

    public interface CMDManager
    {
        /// <summary>
        /// 重新加载命令
        /// </summary>
        /// <param name="savePath">文件路径，可以为空</param>
        void reLoadCmds(String filePath);

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        String execCMD(CMD cmd);

        /// <summary>
        /// 根据命令名称来查找命令，模糊查找
        /// </summary>
        /// <param name="cmdName">命令名称</param>
        /// <returns></returns>
        List<CMD> findCmds(String cmdName);

        /// <summary>
        /// 根据命令的名称来精确查找命令
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        CMD findByName(String cmdName);

        /// <summary>
        /// 保存命令
        /// </summary>
        /// <param name="savePath">文件路径，可以为空</param>
        void saveCMD(String savePath);

        /// <summary>
        /// 得到命令列表
        /// </summary>
        /// <returns></returns>
        List<CMD> getCMDList();

    }
}
