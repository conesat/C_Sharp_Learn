using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatePicker.myclass;

namespace DatePicker
{
    public partial class DatePickerControl: UserControl
    {

        MouseHook mh;
        public DatePickerControl()
        {
            Control.CheckForIllegalCrossThreadCalls = false;//不加这句  子线程更新视图会报错
            InitializeComponent();
            initDate();
        }

        
        private void DatePickLabel_Click(object sender, EventArgs e)
        {

        }

        private void DatePickLeftPic_Click(object sender, EventArgs e)
        {
            beforeMoth();
        }

        private void DatePickRightPic_Click(object sender, EventArgs e)
        {
            nextMoth();
        }

        private void nowDateLabel_Click(object sender, EventArgs e)
        {
            nowMoth();
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseMoveEvent += Mh_MouseMoveEvent;
        }

        private void Mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            try {
                this.tableLayoutPanel1.X = e.X - PointToScreen(this.tableLayoutPanel1.Location).X;
                this.tableLayoutPanel1.Y = e.Y - PointToScreen(this.tableLayoutPanel1.Location).Y;
                this.tableLayoutPanel1.Render();
            } catch (Exception ex) { }
        }

      
        private void MainControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            mh.UnHook();
        }

        public delegate void NextMonthHandler(object sender, String date);
        public event NextMonthHandler NextMonth;

        public delegate void BeforMonthHandler(object sender, String date);
        public event BeforMonthHandler BeforMonth;

        public delegate void NowMonthHandler(object sender, String date);
        public event NowMonthHandler NowMonth;

        public delegate void PickerDateHandler(object sender, String date);
        public event PickerDateHandler PickerDate;
    }
}
