using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    partial class MainPointForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ttpSettings = new System.Windows.Forms.ToolTip(this.components);
            this.addWorkPlan = new System.Windows.Forms.PictureBox();
            this.finisWorkPlan = new System.Windows.Forms.PictureBox();
            this.home = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.addWorkPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finisWorkPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.home)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpSettings
            // 
            this.ttpSettings.AutoPopDelay = 5000;
            this.ttpSettings.InitialDelay = 200;
            this.ttpSettings.ReshowDelay = 200;
            this.ttpSettings.ShowAlways = true;
            // 
            // addWorkPlan
            // 
            this.addWorkPlan.BackgroundImage = global::nncqweekly.Properties.Resources.添加0;
            this.addWorkPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addWorkPlan.Location = new System.Drawing.Point(50, 15);
            this.addWorkPlan.Name = "addWorkPlan";
            this.addWorkPlan.Size = new System.Drawing.Size(30, 30);
            this.addWorkPlan.TabIndex = 0;
            this.addWorkPlan.TabStop = false;
            this.ttpSettings.SetToolTip(this.addWorkPlan, "添加工作安排");
            this.addWorkPlan.MouseEnter += this.PIC_MouseEnter;
            this.addWorkPlan.MouseLeave += this.PIC_MouseLeave;
            // 
            // finisWorkPlan
            // 
            this.finisWorkPlan.BackgroundImage = global::nncqweekly.Properties.Resources.完成0;
            this.finisWorkPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.finisWorkPlan.Location = new System.Drawing.Point(90, 15);
            this.finisWorkPlan.Name = "finisWorkPlan";
            this.finisWorkPlan.Size = new System.Drawing.Size(30, 30);
            this.finisWorkPlan.TabIndex = 1;
            this.finisWorkPlan.TabStop = false;
            this.ttpSettings.SetToolTip(this.finisWorkPlan, "完成工作");
            this.finisWorkPlan.MouseEnter += this.PIC_MouseEnter;
            this.finisWorkPlan.MouseLeave += this.PIC_MouseLeave;
            // 
            // home
            // 
            this.home.BackgroundImage = global::nncqweekly.Properties.Resources.首页0;
            this.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.home.Location = new System.Drawing.Point(10, 15);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(30, 30);
            this.home.TabIndex = 0;
            this.home.TabStop = false;
            this.home.Click += new System.EventHandler(this.home_Click);
            this.ttpSettings.SetToolTip(this.home, "打开首页");
            this.home.MouseEnter += this.PIC_MouseEnter;
            this.home.MouseLeave += this.PIC_MouseLeave;
            // 
            // MainPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(319, 63);
            this.Controls.Add(this.home);
            this.Controls.Add(this.addWorkPlan);
            this.Controls.Add(this.finisWorkPlan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPointForm";
            this.Load += new System.EventHandler(this.MainPointForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addWorkPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finisWorkPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.home)).EndInit();
            this.ResumeLayout(false);

        }

        private void PIC_MouseEnter(object sender, EventArgs e)
        {
            PictureBox PIC = (PictureBox)sender;
            switch (PIC.Name) {
                case "home":
                    PIC.BackgroundImage = global::nncqweekly.Properties.Resources.首页;
                    break;
                case "addWorkPlan":
                    PIC.BackgroundImage = global::nncqweekly.Properties.Resources.添加;
                    break;
                case "finisWorkPlan":
                    PIC.BackgroundImage = global::nncqweekly.Properties.Resources.完成;
                    break;
            }
            
        }

        private void PIC_MouseLeave(object sender, EventArgs e)
        {
            PictureBox PIC = (PictureBox)sender;
            switch (PIC.Name)
            {
                case "home":
                    PIC.BackgroundImage = global::nncqweekly.Properties.Resources.首页0;
                    break;
                case "addWorkPlan":
                    PIC.BackgroundImage = global::nncqweekly.Properties.Resources.添加0;
                    break;
                case "finisWorkPlan":
                    PIC.BackgroundImage = global::nncqweekly.Properties.Resources.完成0;
                    break;
            }
        }


        #endregion

        private PictureBox home;//首页

        private PictureBox addWorkPlan;//添加工作安排

        private PictureBox finisWorkPlan;//完成一项工作安排
        private ToolTip ttpSettings;
    }
}