using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.SharedModels;

namespace wxd.tool.cmdL.dao
{
    /// <summary>
    /// 命令数据的数据访问类
    /// </summary>
    public interface CMDDAO
    {
        /// <summary>
        /// 将命令列表保存到文件中
        /// </summary>
        /// <param name="savePath">文件保存路径</param>
        void flush(String savePath,List<CMD> cmdList);

        /// <summary>
        /// 加载数据库中的数据到内存中
        /// </summary>
        List<CMD> load(String filePath);
    }
}
