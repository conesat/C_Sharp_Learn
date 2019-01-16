using nncqweekly.myclass;
using nncqweekly.myclass.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Weekly_List_Item;
using weekly_note;
using WindowsFormsApp2;
using System.Timers;

namespace nncqweekly.form
{
    public partial class MainForm : Form
    {

        private System.Timers.Timer myTimer = new System.Timers.Timer();
        private Boolean active = false;
        private int style = 0;

        private List<String> todoChecks = new List<string>();//选中选项

        private List<String> finshChecks = new List<string>();//选中选项

        private ItemOne beforItem = new ItemOne();//上一个焦点item

        private String date;//当前日期

        public WorkList workListEntity = new WorkList();


        public static MainForm mainForm = null;
        public static MainPointForm mainPointForm = null;
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;//不加这句  子线程更新视图会报错
            InitializeComponent();
            mainForm = this;
            this.datePickerControl1.PickerDate += DatePickerControl1_PickerDate;
            myTimer.Interval = 1;
            myTimer.Elapsed += Timer_Elapsed;//计时时间 
           
            loadWorkPlan(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);

        }

        private void DatePickerControl1_PickerDate(object sender, string date)
        {
            loadWorkPlan(date);
        }


        public void loadWorkPlan(String date)
        {
            if (File.Exists(Program.modelPath + "\\" + date + ".bat"))
            {
                try
                {
                    //读取model
                    FileStream fs = new FileStream(Program.modelPath + "\\" + date + ".bat", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    workListEntity = bf.Deserialize(fs) as WorkList;
                    fs.Close();
                }
                catch (Exception e) { }
            }
            else
            {
                workListEntity = new WorkList();
            }
            this.date = date;
            todoChecks.Clear();
            finshChecks.Clear();
            Label nothing = null;
            Control last = null;
            this.workList.Controls.Clear();
            String[] dates = date.Split('-');
            DateTime datetime = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
            this.workTitle.Text = dates[0] + "年" + dates[1] + "月" + dates[2] + "日 星期" + getWeek(datetime.DayOfWeek) + " 工作安排";

            Label todolabel = new Label();
            todolabel.Location = new Point(10, 10);
            todolabel.ForeColor = System.Drawing.Color.YellowGreen;
            todolabel.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            todolabel.Text = "待完成工作";
            this.workList.Controls.Add(todolabel);



            if (workListEntity.todo.Count == 0)
            {
                nothing = new Label();
                last = this.workList.Controls[this.workList.Controls.Count - 1];
                nothing.Location = new Point(10, last.Location.Y + last.Height + 10);
                nothing.Width = 450;
                nothing.ForeColor = System.Drawing.Color.Gray;
                nothing.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                nothing.Text = "目前没有工作安排";
                nothing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                nothing.AutoSize = false;
                this.workList.Controls.Add(nothing);
            }
            else
            {
                for (int i = 0; i < workListEntity.todo.Count; i++)
                {
                    ItemOne item = new ItemOne(workListEntity.todo[i].id);
                    item.workText.Text = workListEntity.todo[i].content;
                    item.CheckChange += Item_CheckChange;
                    if (this.workList.Controls.Count >= 1)
                    {
                        last = this.workList.Controls[this.workList.Controls.Count - 1];
                        item.Location = new Point(0, last.Location.Y + last.Height);
                    }
                    item.ID = i + "";
                    item.finish.Visible = false;
                    item.delete.Visible = false;
                    item.edit.Visible = false;
                    item.MouseEnter += Item_MouseEnter;
                    item.MouseLeave += Item_MouseLeave;
                    item.DeleteWork += Item_DeleteWork;
                    item.FinishWork += Item_FinishWork;
                    item.EditWork += Item_EditWork;
                    this.workList.Controls.Add(item);
                }
            }

            Label finishlabel = new Label();
            last = this.workList.Controls[this.workList.Controls.Count - 1];
            finishlabel.Location = new Point(10, last.Location.Y + last.Height + 30);
            finishlabel.ForeColor = System.Drawing.Color.ForestGreen;
            finishlabel.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            finishlabel.Text = "已完成工作";
            this.workList.Controls.Add(finishlabel);


            if (workListEntity.finsh.Count == 0)
            {
                nothing = new Label();
                last = this.workList.Controls[this.workList.Controls.Count - 1];
                nothing.Location = new Point(10, last.Location.Y + last.Height + 10);
                nothing.Width = 450;
                nothing.ForeColor = System.Drawing.Color.Gray;
                nothing.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                nothing.Text = "还没有完成任何工作哦";
                nothing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                nothing.AutoSize = false;
                this.workList.Controls.Add(nothing);
            }
            else
            {
                for (int i = 0; i < workListEntity.finsh.Count; i++)
                {
                    ItemOne item = new ItemOne(workListEntity.finsh[i].id);
                    item.workText.Text = workListEntity.finsh[i].content;
                    item.CheckChange += Item_CheckChange1;
                    if (this.workList.Controls.Count >= 1)
                    {
                        last = this.workList.Controls[this.workList.Controls.Count - 1];
                        item.Location = new Point(0, last.Location.Y + last.Height);
                    }
                    item.ID = i + "";
                    item.finish.Visible = false;
                    item.delete.Visible = false;
                    item.edit.Visible = false;
                    item.MouseEnter += Item_MouseEnter1;
                    item.MouseLeave += Item_MouseLeave1;
                    item.DeleteWork += Item_DeleteWork1;
                    this.workList.Controls.Add(item);
                }
            }
        }




        //已完成项
        //删除已完成的
        private void Item_DeleteWork1(object sender, string id)
        {
            workListEntity.finsh.RemoveAt(int.Parse(id));
            save();
        }
        private void Item_MouseLeave1(object sender, EventArgs e)
        {
            ItemOne item = (ItemOne)sender;
            Point point = item.PointToClient(Control.MousePosition);
            if (point.X <= 0 || point.X >= item.Width || point.Y <= 0 || point.Y >= item.Height)
            {
                item.delete.Visible = false;
            }
        }

        private void Item_MouseEnter1(object sender, EventArgs e)
        {
            ItemOne item = (ItemOne)sender;
            if (!beforItem.Equals(item))
            {
                beforItem.delete.Visible = false;
                beforItem = item;
            }
            item.delete.Visible = true;
        }
        private void Item_CheckChange1(object sender, bool check, string id)
        {
            if (check)
            {
                finshChecks.Add(id);
            }
            else
            {
                finshChecks.Remove(id);
            }

            showSelectItem();
        }
        //已完成项 end
        //待完成项


        private void showSelectItem()
        {
            if (finshChecks.Count() > 0 || todoChecks.Count > 0)
            {
                if (finshChecks.Count <= 0)
                {
                    this.finishSelect.Enabled = true;
                    this.finishSelect.BackgroundImage = global::nncqweekly.Properties.Resources.完成1;
                }
                else
                {
                    this.finishSelect.Enabled = false;
                    this.finishSelect.BackgroundImage = global::nncqweekly.Properties.Resources.完成10;
                }
                this.deleteSelect.Enabled = true;
                this.deleteSelect.BackgroundImage = global::nncqweekly.Properties.Resources.删除;
            }
            else
            {
                this.deleteSelect.Enabled = false;
                this.finishSelect.Enabled = false;
                this.deleteSelect.BackgroundImage = global::nncqweekly.Properties.Resources.删除0;
                this.finishSelect.BackgroundImage = global::nncqweekly.Properties.Resources.完成10;
            }
        }

        //删除工作安排
        private void Item_DeleteWork(object sender, string id)
        {
            workListEntity.todo.RemoveAt(int.Parse(id));
            save();
        }

        private void Item_MouseLeave(object sender, EventArgs e)
        {
            ItemOne item = (ItemOne)sender;
            Point point = item.PointToClient(Control.MousePosition);
            if (point.X <= 0 || point.X >= item.Width || point.Y <= 0 || point.Y >= item.Height)
            {
                item.finish.Visible = false;
                item.delete.Visible = false;
                item.edit.Visible = false;
            }
        }

        private void Item_MouseEnter(object sender, EventArgs e)
        {
            ItemOne item = (ItemOne)sender;
            if (!beforItem.Equals(item))
            {
                beforItem.finish.Visible = false;
                beforItem.delete.Visible = false;
                beforItem.edit.Visible = false;
                beforItem = item;
            }
            item.finish.Visible = true;
            item.delete.Visible = true;
            item.edit.Visible = true;
        }
        private void Item_CheckChange(object sender, bool check, string id)
        {
            if (check)
            {
                todoChecks.Add(id);
            }
            else
            {
                todoChecks.Remove(id);
            }
            showSelectItem();

        }

        private void Item_FinishWork(object sender, string id)
        {
            workListEntity.todo[int.Parse(id)].endTime = DateTime.Now;
            workListEntity.finsh.Add(workListEntity.todo[int.Parse(id)]);
            workListEntity.todo.RemoveAt(int.Parse(id));
            save();
        }

        private void Item_EditWork(object sender, string id)
        {
            new NewWorkPlanForm(workListEntity.todo[int.Parse(id)], date, this, int.Parse(id));
        }
        //待完成项 end


        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (mainPointForm == null)
            {
                mainPointForm = new MainPointForm();
                mainPointForm.ShowDialog();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (mainPointForm == null)
            {
                mainPointForm = new MainPointForm();
                mainPointForm.ShowDialog();
            }
        }


        //获取星期几
        private String getWeek(DayOfWeek weekName)
        {
            String week = "";
            switch (weekName)
            {
                case DayOfWeek.Sunday:
                    week = "日";
                    break;
                case DayOfWeek.Monday:
                    week = "一";
                    break;
                case DayOfWeek.Tuesday:
                    week = "二";
                    break;
                case DayOfWeek.Wednesday:
                    week = "三";
                    break;
                case DayOfWeek.Thursday:
                    week = "四";
                    break;
                case DayOfWeek.Friday:
                    week = "五";
                    break;
                case DayOfWeek.Saturday:
                    week = "六";
                    break;
            }
            return week;
        }

        private void editModel_Click(object sender, EventArgs e)
        {
            new WeeklyModeForm();
        }

        private void addWork_Click(object sender, EventArgs e)
        {
            new NewWorkPlanForm(null, date, this, -1);
        }


        public void save()
        {
            FileStream fs = new FileStream(Program.modelPath + "\\" + date + ".bat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, workListEntity);
            fs.Close();
            loadWorkPlan(date);
        }

        private void deleteSelect_Click(object sender, EventArgs e)
        {
            this.deleteSelect.Enabled = false;
            this.finishSelect.Enabled = false;
            this.deleteSelect.BackgroundImage = global::nncqweekly.Properties.Resources.删除0;
            this.finishSelect.BackgroundImage = global::nncqweekly.Properties.Resources.完成10;
            todoChecks.Sort((x, y) => -x.CompareTo(y));
            foreach (String id in todoChecks)
            {
                workListEntity.todo.RemoveAt(int.Parse(id));
            }
            finshChecks.Sort((x, y) => -x.CompareTo(y));
            foreach (String id in finshChecks)
            {
                workListEntity.finsh.RemoveAt(int.Parse(id));
            }
            save();
        }

        private void finishSelect_Click(object sender, EventArgs e)
        {
            this.deleteSelect.Enabled = false;
            this.finishSelect.Enabled = false;
            this.deleteSelect.BackgroundImage = global::nncqweekly.Properties.Resources.删除0;
            this.finishSelect.BackgroundImage = global::nncqweekly.Properties.Resources.完成10;

            todoChecks.Sort((x, y) => -x.CompareTo(y));
            foreach (String id in todoChecks)
            {
                workListEntity.todo[int.Parse(id)].endTime = DateTime.Now;
                workListEntity.finsh.Add(workListEntity.todo[int.Parse(id)]);
                workListEntity.todo.RemoveAt(int.Parse(id));
            }
            save();
        }


        private void about_Click(object sender, EventArgs e)
        {
            this.aboutPanel.X = this.about.Left + this.about.Width / 2;
            this.aboutPanel.Y = this.about.Top + this.about.Height / 2;
            this.aboutPanel.Visible = true;
            this.aboutContentPanle.Visible = false;
            style = 0;
            MOVE = 10;
            this.aboutPanel.R = 0;
            myTimer.Start();//开始计时更新时间
        }

        int MOVE = 0;

        //秒钟刷新事件
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            if (style == 0)
            {
                this.aboutPanel.R += MOVE++;
                if (this.aboutPanel.R >=this.Width)
                {
                    this.aboutContentPanle.Visible = true;
                    myTimer.Stop();
                }
            }
            else
            {
                if (MOVE < 20) MOVE++;
                this.aboutPanel.R -= MOVE++;
                if (this.aboutPanel.R <= 0)
                {
                    this.aboutPanel.Visible = false;
                    myTimer.Stop();
                }
            }
            this.aboutPanel.Render();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            this.aboutPanel.X = this.Width+50;
            this.aboutPanel.Y = -50;
            this.aboutContentPanle.Visible = false;
            if (this.aboutPanel.Visible)
            {
                style = 1;
            }
            MOVE = 10;
            myTimer.Start();//开始计时更新时间
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/conesat/C_Sharp_Learn");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitee.com/conesat/C_Sharp_Learn");
        }
    }
}
