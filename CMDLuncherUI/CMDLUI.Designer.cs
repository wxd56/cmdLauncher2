namespace CMDLuncherUI
{
    partial class CMDLUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMDLUI));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputCMD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入命令：";
            // 
            // txtInputCMD
            // 
            this.txtInputCMD.Location = new System.Drawing.Point(83, 6);
            this.txtInputCMD.Name = "txtInputCMD";
            this.txtInputCMD.Size = new System.Drawing.Size(462, 21);
            this.txtInputCMD.TabIndex = 1;
            this.txtInputCMD.TextChanged += new System.EventHandler(this.txtInputCMD_TextChanged);
            this.txtInputCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputCMD_KeyDown);
            // 
            // CMDLUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 30);
            this.Controls.Add(this.txtInputCMD);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CMDLUI";
            this.Text = "命令执行助手v0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputCMD;
    }
}

