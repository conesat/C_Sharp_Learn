using nncqweekly.myclass.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nncqweekly.form
{
    public partial class NewWeeklyModelForm : Form
    {
        private MyModel myModel;
        private WeeklyModeForm weeklyModeForm;
        private int i = 0;
        private List<String> reviewText = new List<string>();
        public NewWeeklyModelForm(WeeklyModeForm weeklyModeForm,int i)
        {
            InitializeComponent();
            this.weeklyModeForm = weeklyModeForm;
            this.timeCheck.SelectedIndex = 0;
            if (i > 0)
            {
                myModel = weeklyModeForm.models[i];
                String[] ss = myModel.title.Split('+');
                foreach (String s in ss) {
                    reviewText.Add(s);
                }
                if (myModel.timeType!=null&&myModel.timeType.Equals("天-小时")) {
                    this.timeCheck.SelectedIndex = 1;
                }
            }
            else {
                myModel = new MyModel();
                reviewText.Add("序号");
                reviewText.Add("间隔");
                reviewText.Add("内容");
                reviewText.Add("间隔");
                reviewText.Add("时间");
            }
            this.i = i;
          
            this.timeCheck.SelectedIndexChanged += TimeCheck_SelectedIndexChanged;
            initdata();
            ShowDialog();
        }

        private void TimeCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            initdata();
        }

        public void initdata() {
            this.title.Text = "";
            this.review.Clear();

            if (reviewText.Count > 0) {
                for (int x = 0; x < reviewText.Count - 1; x++)
                {
                    this.title.Text += reviewText[x] + "+";
                }

                this.title.Text += reviewText[reviewText.Count - 1];

                for (int x = 0; x < 10; x++)
                {
                    String s = this.title.Text.Replace("+", "");
                    s = s.Replace("序号", x + "");
                    s = s.Replace("内容", "我的工作安排" + x);
                    s = s.Replace("间隔", this.intervalContent.Text);
                    s = s.Replace("时间", "1" + this.timeCheck.Text.Split('-')[1]);
                    this.review.AppendText(s + "\n");
                }
            }
           
        }
        

        private void save_Click(object sender, EventArgs e)
        {
            myModel.timeType = this.timeCheck.Text;
            if (i > 0)
            {
                myModel.title = this.title.Text;
                weeklyModeForm.models[i] = myModel;
            }
            else {
                MyModel my = new MyModel();
                my.title = this.title.Text;
                weeklyModeForm.models.Add(my);
            }
            weeklyModeForm.save();
            MessageBox.Show("已保存", "完成");
        }

        private void interval_Click(object sender, EventArgs e)
        {
            if (this.intervalContent.Text.Equals(""))
            {
                MessageBox.Show("间隔不能为空!", "输入有误");
            }
            else {
                reviewText.Add("间隔");
                initdata();
            }
        }

        private void id_Click(object sender, EventArgs e)
        {
            reviewText.Add("序号");
            initdata();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            reviewText.RemoveAt(reviewText.Count - 1);
            initdata();
        }

        private void workContent_Click(object sender, EventArgs e)
        {
            reviewText.Add("内容");
            initdata();
        }

        private void time_Click(object sender, EventArgs e)
        {
            reviewText.Add("时间");
            initdata();
        }
    }
}
