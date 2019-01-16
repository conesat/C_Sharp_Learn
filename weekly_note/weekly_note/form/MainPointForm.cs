using nncqweekly.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MainPointForm : Form
    {
        private Point ptMouseCurrrnetPos, ptMouseNewPos, ptFormPos, ptFormNewPos;
        private bool blnMouseDown = false;
       

        public MainPointForm()
        {

            InitializeComponent();
            this.ShowDialog();
            Animation.hideF(this);
        }

        private void MainPointForm_Load(object sender, EventArgs e)
        {
            FormTopMost_Load(sender, e);
        }

        /// <summary>
        /// 悬浮窗口的Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTopMost_Load(object sender, EventArgs e)
        {
            // 无标题
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 250, 250, 250);
            this.MouseDown += this.FormTopMost_MouseDown;
            this.MouseUp += this.FormTopMost_MouseUp;
            this.MouseMove += this.FormTopMost_MouseMove;
            this.MouseEnter += this.FormTopMost_MouseEnter;
            this.MouseLeave += this.FormTopMost_MouseLeave;


            this.home.MouseEnter += PIC_MouseEnter;
            this.home.MouseLeave += PIC_MouseLeave;

            this.addWorkPlan.MouseEnter += PIC_MouseEnter;
            this.addWorkPlan.MouseLeave += PIC_MouseLeave;

            this.finisWorkPlan.MouseEnter += PIC_MouseEnter;
            this.finisWorkPlan.MouseLeave += PIC_MouseLeave;

            // 任务栏不显示
            this.ShowInTaskbar = false;
            // 点击穿透
            // this.BackColor = SystemColors.Control;
            // this.TransparencyKey = System.Drawing.SystemColors.Control;
            // 最上层显示
            this.TopMost = true;
            this.Top = -59;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - 160;
            this.Width = 320;
            this.Height = 60;
        }


        private void FormTopMost_MouseEnter(object sender, EventArgs e)
        {
            if (this.Top <= 0) {
                Animation.isShow = false;
                Animation.show(this);
            }
        }

        private void FormTopMost_MouseLeave(object sender, EventArgs e)
        {
            Point point = Control.MousePosition;
            if (point.X <= this.Left || point.X >= this.Left + this.Width || point.Y <= this.Top || point.Y >= this.Top + this.Height)
            {
                Animation.hide(this);
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            if (MainForm.mainForm == null)
            {
                MainForm.mainForm = new MainForm();
            }
            else if (MainForm.mainForm.WindowState == FormWindowState.Minimized)
            {
                MainForm.mainForm.WindowState = FormWindowState.Normal;
            }
            else {
                MainForm.mainForm.Show();
            }
           
        }


        /// <summary>
        /// 移动鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTopMost_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnMouseDown)
            {

                ptMouseNewPos = Control.MousePosition;
                ptFormNewPos.X = ptMouseNewPos.X - ptMouseCurrrnetPos.X + ptFormPos.X;
                ptFormNewPos.Y = ptMouseNewPos.Y - ptMouseCurrrnetPos.Y + ptFormPos.Y;
                Location = ptFormNewPos;
                ptFormPos = ptFormNewPos;
                ptMouseCurrrnetPos = ptMouseNewPos;
            }
        }
        /// <summary>
        /// 鼠标点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTopMost_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Animation.isShow = false;
                blnMouseDown = true;
                ptMouseCurrrnetPos = Control.MousePosition;
                ptFormPos = Location;
            }
        }
        /// <summary>
        /// 鼠标起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTopMost_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = false;
            }

        }


        private void PIC_MouseEnter(object sender, EventArgs e)
        {
            PictureBox PIC = (PictureBox)sender;
            switch (PIC.Name)
            {
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

    }
}
