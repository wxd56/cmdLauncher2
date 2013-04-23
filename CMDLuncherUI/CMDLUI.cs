using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wxd.tool.cmdL.manager;
using wxd.tool.cmdL.SharedModels;

namespace CMDLuncherUI
{
    public partial class CMDLUI : Form
    {
        private CMDManager cmdManager = CMDManagerFactory.getManager();
        private Boolean isDelKeyDown = false; //是否按下了delete键
        public CMDLUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载命令
            cmdManager.reLoadCmds(null);

            //注册热键
            RegisterHotKeyClass _RegisKey = new RegisterHotKeyClass();
            _RegisKey.Keys = Keys.C;
            _RegisKey.ModKey =  RegisterHotKeyClass.MODKEY.MOD_ALT;
            _RegisKey.WindowHandle = this.Handle;
            _RegisKey.HotKey += new RegisterHotKeyClass.HotKeyPass(_Regis_HotKey);
            _RegisKey.StarHotKey();
        }

        private void txtInputCMD_TextChanged(object sender, EventArgs e)
        {
            String cmdName = this.txtInputCMD.Text;
            List<CMD> list =  this.cmdManager.findCmds(cmdName);
            if (list.Count > 0) {
               
                if (this.isDelKeyDown)
                {
                    return;
                }
                else
                {
                    this.txtInputCMD.Text = list[0].Name;
                    this.txtInputCMD.Select(cmdName.Length, list[0].Name.Length);
                }
                
            }
            
        }

        private void txtInputCMD_KeyDown(object sender, KeyEventArgs e)
        {
            //如果是回车则执行命令
            if (e.KeyValue == 13)
            {
                String cmdName = this.txtInputCMD.Text;
                CMD cmd = this.cmdManager.findByName(cmdName);
                if (cmd != null)
                {
                    this.cmdManager.execCMD(cmd);
                    this.isDelKeyDown = true;
                    this.txtInputCMD.Clear();
                    this.isDelKeyDown = false;
                }
                else
                {
                    MessageBox.Show("没有找到命令：" + cmdName);
                }
            }

            //如果是delete键盘
            if (e.KeyValue == 8)
            {
                this.isDelKeyDown = true;
            }
            else
            {
                this.isDelKeyDown = false;
            }
           
        }

        private void _Regis_HotKey()
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.TopMost = true;
                this.Activate();
                this.txtInputCMD.Focus();
            }
        }
    }
}
