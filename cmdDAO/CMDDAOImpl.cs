using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxd.tool.cmdL.dao;
using wxd.tool.cmdL.SharedModels;
using System.Xml;
namespace wxd.tool.cmdL.dao.impl
{
    public class CMDDAOImpl:CMDDAO 
    {        
        public void flush(String savePath,List<CMD> cmdList)
        {
            XmlDocument doc = new XmlDocument();
            doc.CreateXmlDeclaration("1.0","gbk","yes");            
            XmlElement root =  doc.CreateElement("cmds");
            doc.AppendChild(root);

            foreach (CMD cmd in cmdList)
            {
                XmlElement item = doc.CreateElement("item");
                XmlElement name = doc.CreateElement("name");
                name.InnerText = cmd.Name;               
                XmlElement path = doc.CreateElement("path");
                path.InnerText =  cmd.Path;
                XmlElement desc = doc.CreateElement("desc");
                desc.InnerText =  cmd.Description;
                XmlElement args = doc.CreateElement("args");
                args.InnerText = cmd.Args;

                item.AppendChild(name);
                item.AppendChild(path);
                item.AppendChild(desc);
                item.AppendChild(args);

                root.AppendChild(item);

            }

            //保存到文件
            doc.Save(savePath);

        }

        /// <summary>
        /// 加载数据库中的数据到内存中
        /// </summary>
        public List<CMD> load(String filePath)
        {           

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = doc.DocumentElement;

            List<CMD> list = new List<CMD>();

            //遍历所有的子节点
            foreach (XmlElement item in root.ChildNodes)
            {
                CMD cmd = new CMD();
                cmd.Name = getElementText(item, "name");
                cmd.Path = getElementText(item, "path");
                cmd.Description = getElementText(item, "desc");
                cmd.Args = getElementText(item, "args");                              

                list.Add(cmd);
            }
            return list;
        }

        /// <summary>
        /// 得到文档中某个节点的文本值
        /// </summary>
        /// <param name="item">文档父节点</param>
        /// <param name="elementName">子节点名称</param>
        /// <returns></returns>
        private String getElementText(XmlElement item,String elementName)
        {
            XmlNodeList list = item.GetElementsByTagName(elementName);
            if (list.Count > 0)
            {
                return list[0].InnerText;
            }
            return String.Empty;
        }
    }
}
