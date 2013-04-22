using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxd.tool.cmdL.SharedModels
{
    /// <summary>
    /// 代表一条命令
    /// </summary>
    public class CMD
    {
              
        /// <summary>
        /// 命令名称
        /// </summary>
        public String Name
        {
            get;
            set;
        }
        /// <summary>
        /// 参数
        /// </summary>
        public String Args
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>
        public String Description
        {
            get;
            set;
        }

        /// <summary>
        /// 可执行文件在文件系统中的路径，如果为空，则使用系统自带的命令执行器来执行
        /// </summary>
        public String Path
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("CMD[");
            builder.Append("name=");
            builder.Append(Name);
            builder.Append(";");
            builder.Append("path=");
            builder.Append(Path);
            builder.Append(";");
            builder.Append("args=");
            builder.Append(Args);
            builder.Append("]");
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CMD))
            {
                return false;
            }

            CMD paramCMD = (CMD)obj;
            if (this.Name.Equals(paramCMD.Name))
            {
                return true;
            }
            return false;
        }
    }
}
