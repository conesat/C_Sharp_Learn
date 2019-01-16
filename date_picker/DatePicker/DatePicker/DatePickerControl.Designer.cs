using System;
using System.Drawing;
using System.Timers;

namespace DatePicker
{
    partial class DatePickerControl
    {
        private int pickYear;//选择的年份
        private int pickMoth;//选择的月份
        private int pickDay;//选择的天

        private String picDate = "";//点击的日期

        private Boolean pick = false;
        private System.Windows.Forms.Label pickLabel = null;
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

        private void initDate()
        {

            Timer myTimer = new Timer();
            myTimer.Interval = 1000;
            myTimer.Elapsed += Timer_Elapsed;//计时时间  更新时分秒

            pickYear = DateTime.Now.Year;
            pickMoth = DateTime.Now.Month;
            pickDay = DateTime.Now.Day;

            this.TimeLable.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;//初始化 时间
            this.DateLable.Text = DateTime.Now.ToLongDateString();//初始化时间下面的日期

            this.MonthGoingProgressBar.Value = getWeek(DateTime.Now.DayOfWeek);

            loadMoth();//初始化选择的 年月 为当前

            myTimer.Start();//开始计时更新时间

            //day鼠标划过事件
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i].HasChildren)
                {
                    tableLayoutPanel1.Controls[i].Controls[0].MouseEnter += Daylabe_MouseEnter;
                    tableLayoutPanel1.Controls[i].Controls[0].MouseLeave += Daylabe_MouseLeave;
                    tableLayoutPanel1.Controls[i].Controls[0].Click += MainControl_Click;
                }
            }
        }

        //日期点击事件
        private void MainControl_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
          
            if (PickerDate != null)
            {
                PickerDate(this, label.Tag.ToString());
            }

            if (pickLabel == null)
            {
                pickLabel = label;
                pick = true;
                if (this.BackColor.Equals(System.Drawing.SystemColors.Control))
                {
                    pickLabel.Parent.BackColor = Color.White;
                }
                else
                {
                    pickLabel.Parent.BackColor = System.Drawing.SystemColors.ControlDark;
                }
            }
            else
            {
                if (label.Equals(pickLabel) && pick && label.Tag.ToString().Equals(picDate))
                {
                    pick = false;
                    pickLabel.Parent.BackColor = this.BackColor;
                }
                else
                {
                    pick = true;
                    pickLabel.Parent.BackColor = this.BackColor;
                    pickLabel = label;
                    if (this.BackColor.Equals(System.Drawing.SystemColors.Control))
                    {
                        pickLabel.Parent.BackColor = Color.White;
                    }
                    else
                    {
                        pickLabel.Parent.BackColor = System.Drawing.SystemColors.ControlDark;
                    }

                }
            }
            picDate = label.Tag.ToString();
        }


        //获取星期几
        private int getWeek(DayOfWeek weekName)
        {
            int week = 1;
            switch (weekName)
            {
                case DayOfWeek.Sunday:
                    week = 7;
                    break;
                case DayOfWeek.Monday:
                    week = 1;
                    break;
                case DayOfWeek.Tuesday:
                    week = 2;
                    break;
                case DayOfWeek.Wednesday:
                    week = 3;
                    break;
                case DayOfWeek.Thursday:
                    week = 4;
                    break;
                case DayOfWeek.Friday:
                    week = 5;
                    break;
                case DayOfWeek.Saturday:
                    week = 6;
                    break;
            }
            return week;
        }


        //加载日期到视图
        private void loadMoth()
        {
            this.DatePickLabel.Text = pickYear + "年" + pickMoth + "月";

            DateTime datetime = new DateTime(pickYear, pickMoth, 1);

            DateTime lastDay = datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);

            int week = getWeek(datetime.DayOfWeek);

            int day = 1, nextday = 1;

            //获取上一个月数据
            int[] beforMoth = getBeforDate();
            DateTime beforDateTime = new DateTime(beforMoth[0], beforMoth[1], 1);
            DateTime beforLastDay = beforDateTime.AddDays(1 - beforDateTime.Day).AddMonths(1).AddDays(-1);
            //下一个月
            int[] nextMoth = getNextDate();

            int temp = week - 2;
            if (pickLabel != null)
            {
                pickLabel.Parent.BackColor = this.BackColor;
            }

            for (int i = 0; i < week - 1; i++)
            {
               
                tableLayoutPanel1.Controls[i].Controls[0].Parent.BackColor = this.BackColor;
                tableLayoutPanel1.Controls[i].Controls[0].BackColor = this.BackColor;
                tableLayoutPanel1.Controls[i].Controls[0].ForeColor = System.Drawing.SystemColors.ControlDark;
                tableLayoutPanel1.Controls[i].Controls[0].Text = (beforLastDay.Day - temp) + "";
                tableLayoutPanel1.Controls[i].Controls[0].Tag = beforMoth[0] + "-" + beforMoth[1] + "-" + (beforLastDay.Day - temp);
                if (pick && pickLabel != null && (beforMoth[0] + "-" + beforMoth[1] + "-" + (beforLastDay.Day - temp)).Equals(picDate))
                {
                    pickLabel = (System.Windows.Forms.Label)tableLayoutPanel1.Controls[i].Controls[0];
                    if (this.BackColor.Equals(System.Drawing.SystemColors.Control))
                    {
                        pickLabel.Parent.BackColor = Color.White;
                    }
                    else
                    {
                        pickLabel.Parent.BackColor = System.Drawing.SystemColors.ControlDark;
                    }

                }
                temp--;
            }

            for (int i = week - 1; i < lastDay.Day + (week - 1); i++)
            {
                if (pick && pickLabel != null && (pickYear + "-" + pickMoth + "-" + day).Equals(picDate))
                {
                    pickLabel = (System.Windows.Forms.Label)tableLayoutPanel1.Controls[i].Controls[0];
                    if (this.BackColor.Equals(System.Drawing.SystemColors.Control))
                    {
                        pickLabel.Parent.BackColor = Color.White;
                    }
                    else
                    {
                        pickLabel.Parent.BackColor = System.Drawing.SystemColors.ControlDark;
                    }

                }

                if (pickYear == DateTime.Now.Year && pickMoth == DateTime.Now.Month&& day == DateTime.Now.Day)
                {
                   tableLayoutPanel1.Controls[i].Controls[0].BackColor = System.Drawing.SystemColors.ControlLight;
                }
                else
                {
                    tableLayoutPanel1.Controls[i].Controls[0].BackColor = this.BackColor;
                }
                tableLayoutPanel1.Controls[i].Controls[0].ForeColor = System.Drawing.SystemColors.ControlDarkDark; ;
                tableLayoutPanel1.Controls[i].Controls[0].Text = day + "";
                tableLayoutPanel1.Controls[i].Controls[0].Tag = pickYear + "-" + pickMoth + "-" + day;
                day++;
            }


            for (int i = lastDay.Day + week - 1; i < tableLayoutPanel1.Controls.Count; i++)
            {

               
                tableLayoutPanel1.Controls[i].Controls[0].Parent.BackColor = this.BackColor;
                tableLayoutPanel1.Controls[i].Controls[0].BackColor = this.BackColor;
                tableLayoutPanel1.Controls[i].Controls[0].ForeColor = System.Drawing.SystemColors.ControlDark;
                tableLayoutPanel1.Controls[i].Controls[0].Text = nextday + "";
                tableLayoutPanel1.Controls[i].Controls[0].Tag = nextMoth[0] + "-" + nextMoth[1] + "-" + nextday;
                if (pick && pickLabel != null && (nextMoth[0] + "-" + nextMoth[1] + "-" + nextday).Equals(picDate))
                {
                    pickLabel = (System.Windows.Forms.Label)tableLayoutPanel1.Controls[i].Controls[0];
                    if (this.BackColor.Equals(System.Drawing.SystemColors.Control))
                    {
                        pickLabel.Parent.BackColor = Color.White;
                    }
                    else
                    {
                        pickLabel.Parent.BackColor = System.Drawing.SystemColors.ControlDark;
                    }

                }
                nextday++;

            }
        }


        //获取下一个月 年月 xxxx-xx
        private int[] getNextDate()
        {
            int getMoth = pickMoth;
            int getYear = pickYear;
            if (pickMoth < 12)
            {
                getMoth++;
            }
            else
            {
                getMoth = 1;
                getYear++;
            }
            return new int[] { getYear, getMoth };
        }

        //获取上一个月 年月 xxxx-xx 
        private int[] getBeforDate()
        {
            int getMoth = pickMoth;
            int getYear = pickYear;
            if (pickMoth > 1)
            {
                getMoth--;
            }
            else
            {
                getMoth = 12;
                getYear--;
            }
            return new int[] { getYear, getMoth };
        }

        //获取下一个月 年月并加载视图
        private void nextMoth()
        {
            if (pickMoth < 12)
            {
                pickMoth++;
            }
            else
            {
                pickMoth = 1;
                pickYear++;
            }
            if (NextMonth != null)
            {
                NextMonth(this, pickYear + "-" + pickMoth + "-" + 1);
            }
            loadMoth();
        }

        //获取上一个月 年月并加载视图
        private void beforeMoth()
        {
            if (pickMoth > 1)
            {
                pickMoth--;
            }
            else
            {
                pickMoth = 12;
                pickYear--;
            }
            if (BeforMonth != null)
            {
                BeforMonth(this, pickYear + "-" + pickMoth + "-" + 1);
            }
            loadMoth();
        }

        //获取当前月 年月并加载视图
        private void nowMoth()
        {
            pickYear = DateTime.Now.Year;
            pickMoth = DateTime.Now.Month;
            pickDay = DateTime.Now.Day;
            if (NowMonth != null)
            {
                NowMonth(this, pickYear + "-" + pickMoth + "-" + pickDay);
            }
            loadMoth();
        }

        //秒钟刷新事件
        private void Timer_Elapsed(object sender, EventArgs e)
        {

            this.TimeLable.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        //鼠标移除事件 去掉显示白色选中框框
        private void Daylabe_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lable = (System.Windows.Forms.Label)sender;
            if (!pick || !lable.Equals(pickLabel))
            {
                lable.Parent.BackColor = this.BackColor;// System.Drawing.SystemColors.Control;
            }

        }
        //鼠标进入事件 显示白色选中框框
        private void Daylabe_MouseEnter(object sender, EventArgs e)
        {

            System.Windows.Forms.Label lable = (System.Windows.Forms.Label)sender;
            if (!lable.Text.Equals(""))
            {
                if ((pick && !lable.Equals(pickLabel)) || !pick)
                {
                    if (this.BackColor.Equals(System.Drawing.SystemColors.Control))
                    {
                        lable.Parent.BackColor = Color.White;
                    }
                    else
                    {
                        lable.Parent.BackColor = System.Drawing.SystemColors.ControlDark;
                    }

                }
            }

        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TimeLable = new System.Windows.Forms.Label();
            this.DateLable = new System.Windows.Forms.Label();
            this.MonthGoingProgressBar = new System.Windows.Forms.ProgressBar();
            this.DatePickPanel = new System.Windows.Forms.Panel();
            this.nowDateLabel = new System.Windows.Forms.Label();
            this.DatePickLabel = new System.Windows.Forms.Label();
            this.DatePickRightPic = new System.Windows.Forms.PictureBox();
            this.DatePickLeftPic = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new DatePicker.MyTableLayoutPanel();
            this.day1 = new System.Windows.Forms.Panel();
            this.daylabel1 = new System.Windows.Forms.Label();
            this.day2 = new System.Windows.Forms.Panel();
            this.daylabel2 = new System.Windows.Forms.Label();
            this.day3 = new System.Windows.Forms.Panel();
            this.daylabel3 = new System.Windows.Forms.Label();
            this.day4 = new System.Windows.Forms.Panel();
            this.daylabel4 = new System.Windows.Forms.Label();
            this.day5 = new System.Windows.Forms.Panel();
            this.daylabel5 = new System.Windows.Forms.Label();
            this.day6 = new System.Windows.Forms.Panel();
            this.daylabel6 = new System.Windows.Forms.Label();
            this.day7 = new System.Windows.Forms.Panel();
            this.daylabel7 = new System.Windows.Forms.Label();
            this.day8 = new System.Windows.Forms.Panel();
            this.daylabel8 = new System.Windows.Forms.Label();
            this.day9 = new System.Windows.Forms.Panel();
            this.daylabel9 = new System.Windows.Forms.Label();
            this.day10 = new System.Windows.Forms.Panel();
            this.daylabel10 = new System.Windows.Forms.Label();
            this.day11 = new System.Windows.Forms.Panel();
            this.daylabel11 = new System.Windows.Forms.Label();
            this.day12 = new System.Windows.Forms.Panel();
            this.daylabel12 = new System.Windows.Forms.Label();
            this.day13 = new System.Windows.Forms.Panel();
            this.daylabel13 = new System.Windows.Forms.Label();
            this.day14 = new System.Windows.Forms.Panel();
            this.daylabel14 = new System.Windows.Forms.Label();
            this.day15 = new System.Windows.Forms.Panel();
            this.daylabel15 = new System.Windows.Forms.Label();
            this.day16 = new System.Windows.Forms.Panel();
            this.daylabel16 = new System.Windows.Forms.Label();
            this.day17 = new System.Windows.Forms.Panel();
            this.daylabel17 = new System.Windows.Forms.Label();
            this.day18 = new System.Windows.Forms.Panel();
            this.daylabel18 = new System.Windows.Forms.Label();
            this.day19 = new System.Windows.Forms.Panel();
            this.daylabel19 = new System.Windows.Forms.Label();
            this.day20 = new System.Windows.Forms.Panel();
            this.daylabel20 = new System.Windows.Forms.Label();
            this.day21 = new System.Windows.Forms.Panel();
            this.daylabel21 = new System.Windows.Forms.Label();
            this.day22 = new System.Windows.Forms.Panel();
            this.daylabel22 = new System.Windows.Forms.Label();
            this.day23 = new System.Windows.Forms.Panel();
            this.daylabel23 = new System.Windows.Forms.Label();
            this.day24 = new System.Windows.Forms.Panel();
            this.daylabel24 = new System.Windows.Forms.Label();
            this.day25 = new System.Windows.Forms.Panel();
            this.daylabel25 = new System.Windows.Forms.Label();
            this.day26 = new System.Windows.Forms.Panel();
            this.daylabel26 = new System.Windows.Forms.Label();
            this.day27 = new System.Windows.Forms.Panel();
            this.daylabel27 = new System.Windows.Forms.Label();
            this.day28 = new System.Windows.Forms.Panel();
            this.daylabel28 = new System.Windows.Forms.Label();
            this.day29 = new System.Windows.Forms.Panel();
            this.daylabel29 = new System.Windows.Forms.Label();
            this.day30 = new System.Windows.Forms.Panel();
            this.daylabel30 = new System.Windows.Forms.Label();
            this.day31 = new System.Windows.Forms.Panel();
            this.daylabel31 = new System.Windows.Forms.Label();
            this.day32 = new System.Windows.Forms.Panel();
            this.daylabel32 = new System.Windows.Forms.Label();
            this.day33 = new System.Windows.Forms.Panel();
            this.daylabel33 = new System.Windows.Forms.Label();
            this.day34 = new System.Windows.Forms.Panel();
            this.daylabel34 = new System.Windows.Forms.Label();
            this.day35 = new System.Windows.Forms.Panel();
            this.daylabel35 = new System.Windows.Forms.Label();
            this.day36 = new System.Windows.Forms.Panel();
            this.daylabel36 = new System.Windows.Forms.Label();
            this.day37 = new System.Windows.Forms.Panel();
            this.daylabel37 = new System.Windows.Forms.Label();
            this.day38 = new System.Windows.Forms.Panel();
            this.daylabel38 = new System.Windows.Forms.Label();
            this.day39 = new System.Windows.Forms.Panel();
            this.daylabel39 = new System.Windows.Forms.Label();
            this.day40 = new System.Windows.Forms.Panel();
            this.daylabel40 = new System.Windows.Forms.Label();
            this.day41 = new System.Windows.Forms.Panel();
            this.daylabel41 = new System.Windows.Forms.Label();
            this.day42 = new System.Windows.Forms.Panel();
            this.daylabel42 = new System.Windows.Forms.Label();
            this.DatePickPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatePickRightPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatePickLeftPic)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.day1.SuspendLayout();
            this.day2.SuspendLayout();
            this.day3.SuspendLayout();
            this.day4.SuspendLayout();
            this.day5.SuspendLayout();
            this.day6.SuspendLayout();
            this.day7.SuspendLayout();
            this.day8.SuspendLayout();
            this.day9.SuspendLayout();
            this.day10.SuspendLayout();
            this.day11.SuspendLayout();
            this.day12.SuspendLayout();
            this.day13.SuspendLayout();
            this.day14.SuspendLayout();
            this.day15.SuspendLayout();
            this.day16.SuspendLayout();
            this.day17.SuspendLayout();
            this.day18.SuspendLayout();
            this.day19.SuspendLayout();
            this.day20.SuspendLayout();
            this.day21.SuspendLayout();
            this.day22.SuspendLayout();
            this.day23.SuspendLayout();
            this.day24.SuspendLayout();
            this.day25.SuspendLayout();
            this.day26.SuspendLayout();
            this.day27.SuspendLayout();
            this.day28.SuspendLayout();
            this.day29.SuspendLayout();
            this.day30.SuspendLayout();
            this.day31.SuspendLayout();
            this.day32.SuspendLayout();
            this.day33.SuspendLayout();
            this.day34.SuspendLayout();
            this.day35.SuspendLayout();
            this.day36.SuspendLayout();
            this.day37.SuspendLayout();
            this.day38.SuspendLayout();
            this.day39.SuspendLayout();
            this.day40.SuspendLayout();
            this.day41.SuspendLayout();
            this.day42.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.BackColor = System.Drawing.Color.Transparent;
            this.TimeLable.Font = new System.Drawing.Font("等线", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLable.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TimeLable.Location = new System.Drawing.Point(3, 18);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(162, 41);
            this.TimeLable.TabIndex = 0;
            this.TimeLable.Text = "00:00:00";
            // 
            // DateLable
            // 
            this.DateLable.AutoSize = true;
            this.DateLable.BackColor = System.Drawing.Color.Transparent;
            this.DateLable.Font = new System.Drawing.Font("等线 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateLable.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DateLable.Location = new System.Drawing.Point(7, 58);
            this.DateLable.Name = "DateLable";
            this.DateLable.Size = new System.Drawing.Size(112, 17);
            this.DateLable.TabIndex = 1;
            this.DateLable.Text = "2018年8月12日";
            // 
            // MonthGoingProgressBar
            // 
            this.MonthGoingProgressBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MonthGoingProgressBar.ForeColor = System.Drawing.Color.Transparent;
            this.MonthGoingProgressBar.Location = new System.Drawing.Point(0, 91);
            this.MonthGoingProgressBar.Maximum = 7;
            this.MonthGoingProgressBar.Name = "MonthGoingProgressBar";
            this.MonthGoingProgressBar.Size = new System.Drawing.Size(453, 3);
            this.MonthGoingProgressBar.TabIndex = 2;
            this.MonthGoingProgressBar.Value = 7;
            // 
            // DatePickPanel
            // 
            this.DatePickPanel.Controls.Add(this.nowDateLabel);
            this.DatePickPanel.Controls.Add(this.DatePickLabel);
            this.DatePickPanel.Controls.Add(this.DatePickRightPic);
            this.DatePickPanel.Controls.Add(this.DatePickLeftPic);
            this.DatePickPanel.Location = new System.Drawing.Point(10, 118);
            this.DatePickPanel.Name = "DatePickPanel";
            this.DatePickPanel.Size = new System.Drawing.Size(434, 30);
            this.DatePickPanel.TabIndex = 3;
            // 
            // nowDateLabel
            // 
            this.nowDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.nowDateLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nowDateLabel.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowDateLabel.ForeColor = System.Drawing.Color.DimGray;
            this.nowDateLabel.Location = new System.Drawing.Point(328, 0);
            this.nowDateLabel.Name = "nowDateLabel";
            this.nowDateLabel.Size = new System.Drawing.Size(85, 30);
            this.nowDateLabel.TabIndex = 3;
            this.nowDateLabel.Text = "现在";
            this.nowDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nowDateLabel.Click += new System.EventHandler(this.nowDateLabel_Click);
            // 
            // DatePickLabel
            // 
            this.DatePickLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DatePickLabel.Font = new System.Drawing.Font("等线", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DatePickLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DatePickLabel.Location = new System.Drawing.Point(76, 0);
            this.DatePickLabel.Name = "DatePickLabel";
            this.DatePickLabel.Size = new System.Drawing.Size(140, 30);
            this.DatePickLabel.TabIndex = 2;
            this.DatePickLabel.Text = "2108年8月";
            this.DatePickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DatePickLabel.Click += new System.EventHandler(this.DatePickLabel_Click);
            // 
            // DatePickRightPic
            // 
            this.DatePickRightPic.BackgroundImage = global::DatePicker.Properties.Resources.right;
            this.DatePickRightPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DatePickRightPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DatePickRightPic.Location = new System.Drawing.Point(222, 0);
            this.DatePickRightPic.Name = "DatePickRightPic";
            this.DatePickRightPic.Size = new System.Drawing.Size(30, 30);
            this.DatePickRightPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DatePickRightPic.TabIndex = 1;
            this.DatePickRightPic.TabStop = false;
            this.DatePickRightPic.Click += new System.EventHandler(this.DatePickRightPic_Click);
            // 
            // DatePickLeftPic
            // 
            this.DatePickLeftPic.BackgroundImage = global::DatePicker.Properties.Resources.left;
            this.DatePickLeftPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DatePickLeftPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DatePickLeftPic.Location = new System.Drawing.Point(40, 0);
            this.DatePickLeftPic.Name = "DatePickLeftPic";
            this.DatePickLeftPic.Size = new System.Drawing.Size(30, 30);
            this.DatePickLeftPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DatePickLeftPic.TabIndex = 0;
            this.DatePickLeftPic.TabStop = false;
            this.DatePickLeftPic.Click += new System.EventHandler(this.DatePickLeftPic_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 182);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(422, 27);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(364, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "日";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(304, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "六";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(244, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "五";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(184, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "四";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(124, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "三";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(64, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "二";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("等线 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "一";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.day1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.day2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.day3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.day4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.day5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.day6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.day7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.day8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.day9, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.day10, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.day11, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.day12, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.day13, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.day14, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.day15, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.day16, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.day17, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.day18, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.day19, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.day20, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.day21, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.day22, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.day23, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.day24, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.day25, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.day26, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.day27, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.day28, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.day29, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.day30, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.day31, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.day32, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.day33, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.day34, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.day35, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.day36, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.day37, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.day38, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.day39, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.day40, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.day41, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.day42, 6, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 215);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 362);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // day1
            // 
            this.day1.BackColor = System.Drawing.SystemColors.Control;
            this.day1.Controls.Add(this.daylabel1);
            this.day1.Location = new System.Drawing.Point(2, 2);
            this.day1.Margin = new System.Windows.Forms.Padding(1);
            this.day1.Name = "day1";
            this.day1.Size = new System.Drawing.Size(58, 58);
            this.day1.TabIndex = 39;
            // 
            // daylabel1
            // 
            this.daylabel1.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel1.Location = new System.Drawing.Point(2, 2);
            this.daylabel1.Name = "daylabel1";
            this.daylabel1.Size = new System.Drawing.Size(54, 54);
            this.daylabel1.TabIndex = 0;
            this.daylabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day2
            // 
            this.day2.Controls.Add(this.daylabel2);
            this.day2.Location = new System.Drawing.Point(62, 2);
            this.day2.Margin = new System.Windows.Forms.Padding(1);
            this.day2.Name = "day2";
            this.day2.Size = new System.Drawing.Size(58, 58);
            this.day2.TabIndex = 40;
            // 
            // daylabel2
            // 
            this.daylabel2.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel2.Location = new System.Drawing.Point(2, 2);
            this.daylabel2.Name = "daylabel2";
            this.daylabel2.Size = new System.Drawing.Size(54, 54);
            this.daylabel2.TabIndex = 1;
            this.daylabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day3
            // 
            this.day3.Controls.Add(this.daylabel3);
            this.day3.Location = new System.Drawing.Point(122, 2);
            this.day3.Margin = new System.Windows.Forms.Padding(1);
            this.day3.Name = "day3";
            this.day3.Size = new System.Drawing.Size(58, 58);
            this.day3.TabIndex = 40;
            // 
            // daylabel3
            // 
            this.daylabel3.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel3.Location = new System.Drawing.Point(2, 2);
            this.daylabel3.Name = "daylabel3";
            this.daylabel3.Size = new System.Drawing.Size(54, 54);
            this.daylabel3.TabIndex = 2;
            this.daylabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day4
            // 
            this.day4.Controls.Add(this.daylabel4);
            this.day4.Location = new System.Drawing.Point(182, 2);
            this.day4.Margin = new System.Windows.Forms.Padding(1);
            this.day4.Name = "day4";
            this.day4.Size = new System.Drawing.Size(58, 58);
            this.day4.TabIndex = 40;
            // 
            // daylabel4
            // 
            this.daylabel4.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel4.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel4.Location = new System.Drawing.Point(2, 2);
            this.daylabel4.Name = "daylabel4";
            this.daylabel4.Size = new System.Drawing.Size(54, 54);
            this.daylabel4.TabIndex = 2;
            this.daylabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day5
            // 
            this.day5.Controls.Add(this.daylabel5);
            this.day5.Location = new System.Drawing.Point(242, 2);
            this.day5.Margin = new System.Windows.Forms.Padding(1);
            this.day5.Name = "day5";
            this.day5.Size = new System.Drawing.Size(58, 58);
            this.day5.TabIndex = 40;
            // 
            // daylabel5
            // 
            this.daylabel5.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel5.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel5.Location = new System.Drawing.Point(2, 2);
            this.daylabel5.Name = "daylabel5";
            this.daylabel5.Size = new System.Drawing.Size(54, 54);
            this.daylabel5.TabIndex = 2;
            this.daylabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day6
            // 
            this.day6.Controls.Add(this.daylabel6);
            this.day6.Location = new System.Drawing.Point(302, 2);
            this.day6.Margin = new System.Windows.Forms.Padding(1);
            this.day6.Name = "day6";
            this.day6.Size = new System.Drawing.Size(58, 58);
            this.day6.TabIndex = 40;
            // 
            // daylabel6
            // 
            this.daylabel6.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel6.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel6.Location = new System.Drawing.Point(2, 2);
            this.daylabel6.Name = "daylabel6";
            this.daylabel6.Size = new System.Drawing.Size(54, 54);
            this.daylabel6.TabIndex = 2;
            this.daylabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day7
            // 
            this.day7.Controls.Add(this.daylabel7);
            this.day7.Location = new System.Drawing.Point(362, 2);
            this.day7.Margin = new System.Windows.Forms.Padding(1);
            this.day7.Name = "day7";
            this.day7.Size = new System.Drawing.Size(58, 58);
            this.day7.TabIndex = 40;
            // 
            // daylabel7
            // 
            this.daylabel7.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel7.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel7.Location = new System.Drawing.Point(2, 2);
            this.daylabel7.Name = "daylabel7";
            this.daylabel7.Size = new System.Drawing.Size(54, 54);
            this.daylabel7.TabIndex = 2;
            this.daylabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day8
            // 
            this.day8.Controls.Add(this.daylabel8);
            this.day8.Location = new System.Drawing.Point(2, 62);
            this.day8.Margin = new System.Windows.Forms.Padding(1);
            this.day8.Name = "day8";
            this.day8.Size = new System.Drawing.Size(58, 58);
            this.day8.TabIndex = 41;
            // 
            // daylabel8
            // 
            this.daylabel8.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel8.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel8.Location = new System.Drawing.Point(2, 2);
            this.daylabel8.Name = "daylabel8";
            this.daylabel8.Size = new System.Drawing.Size(54, 54);
            this.daylabel8.TabIndex = 2;
            this.daylabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day9
            // 
            this.day9.Controls.Add(this.daylabel9);
            this.day9.Location = new System.Drawing.Point(62, 62);
            this.day9.Margin = new System.Windows.Forms.Padding(1);
            this.day9.Name = "day9";
            this.day9.Size = new System.Drawing.Size(58, 58);
            this.day9.TabIndex = 40;
            // 
            // daylabel9
            // 
            this.daylabel9.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel9.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel9.Location = new System.Drawing.Point(2, 2);
            this.daylabel9.Name = "daylabel9";
            this.daylabel9.Size = new System.Drawing.Size(54, 54);
            this.daylabel9.TabIndex = 2;
            this.daylabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day10
            // 
            this.day10.Controls.Add(this.daylabel10);
            this.day10.Location = new System.Drawing.Point(122, 62);
            this.day10.Margin = new System.Windows.Forms.Padding(1);
            this.day10.Name = "day10";
            this.day10.Size = new System.Drawing.Size(58, 58);
            this.day10.TabIndex = 40;
            // 
            // daylabel10
            // 
            this.daylabel10.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel10.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel10.Location = new System.Drawing.Point(2, 2);
            this.daylabel10.Name = "daylabel10";
            this.daylabel10.Size = new System.Drawing.Size(54, 54);
            this.daylabel10.TabIndex = 2;
            this.daylabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day11
            // 
            this.day11.Controls.Add(this.daylabel11);
            this.day11.Location = new System.Drawing.Point(182, 62);
            this.day11.Margin = new System.Windows.Forms.Padding(1);
            this.day11.Name = "day11";
            this.day11.Size = new System.Drawing.Size(58, 58);
            this.day11.TabIndex = 40;
            // 
            // daylabel11
            // 
            this.daylabel11.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel11.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel11.Location = new System.Drawing.Point(2, 2);
            this.daylabel11.Name = "daylabel11";
            this.daylabel11.Size = new System.Drawing.Size(54, 54);
            this.daylabel11.TabIndex = 2;
            this.daylabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day12
            // 
            this.day12.Controls.Add(this.daylabel12);
            this.day12.Location = new System.Drawing.Point(242, 62);
            this.day12.Margin = new System.Windows.Forms.Padding(1);
            this.day12.Name = "day12";
            this.day12.Size = new System.Drawing.Size(58, 58);
            this.day12.TabIndex = 40;
            // 
            // daylabel12
            // 
            this.daylabel12.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel12.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel12.Location = new System.Drawing.Point(2, 2);
            this.daylabel12.Name = "daylabel12";
            this.daylabel12.Size = new System.Drawing.Size(54, 54);
            this.daylabel12.TabIndex = 2;
            this.daylabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day13
            // 
            this.day13.Controls.Add(this.daylabel13);
            this.day13.Location = new System.Drawing.Point(302, 62);
            this.day13.Margin = new System.Windows.Forms.Padding(1);
            this.day13.Name = "day13";
            this.day13.Size = new System.Drawing.Size(58, 58);
            this.day13.TabIndex = 40;
            // 
            // daylabel13
            // 
            this.daylabel13.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel13.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel13.Location = new System.Drawing.Point(2, 2);
            this.daylabel13.Name = "daylabel13";
            this.daylabel13.Size = new System.Drawing.Size(54, 54);
            this.daylabel13.TabIndex = 2;
            this.daylabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day14
            // 
            this.day14.Controls.Add(this.daylabel14);
            this.day14.Location = new System.Drawing.Point(362, 62);
            this.day14.Margin = new System.Windows.Forms.Padding(1);
            this.day14.Name = "day14";
            this.day14.Size = new System.Drawing.Size(58, 58);
            this.day14.TabIndex = 40;
            // 
            // daylabel14
            // 
            this.daylabel14.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel14.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel14.Location = new System.Drawing.Point(2, 2);
            this.daylabel14.Name = "daylabel14";
            this.daylabel14.Size = new System.Drawing.Size(54, 54);
            this.daylabel14.TabIndex = 2;
            this.daylabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day15
            // 
            this.day15.Controls.Add(this.daylabel15);
            this.day15.Location = new System.Drawing.Point(2, 122);
            this.day15.Margin = new System.Windows.Forms.Padding(1);
            this.day15.Name = "day15";
            this.day15.Size = new System.Drawing.Size(58, 58);
            this.day15.TabIndex = 40;
            // 
            // daylabel15
            // 
            this.daylabel15.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel15.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel15.Location = new System.Drawing.Point(2, 2);
            this.daylabel15.Name = "daylabel15";
            this.daylabel15.Size = new System.Drawing.Size(54, 54);
            this.daylabel15.TabIndex = 2;
            this.daylabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day16
            // 
            this.day16.Controls.Add(this.daylabel16);
            this.day16.Location = new System.Drawing.Point(62, 122);
            this.day16.Margin = new System.Windows.Forms.Padding(1);
            this.day16.Name = "day16";
            this.day16.Size = new System.Drawing.Size(58, 58);
            this.day16.TabIndex = 40;
            // 
            // daylabel16
            // 
            this.daylabel16.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel16.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel16.Location = new System.Drawing.Point(2, 2);
            this.daylabel16.Name = "daylabel16";
            this.daylabel16.Size = new System.Drawing.Size(54, 54);
            this.daylabel16.TabIndex = 2;
            this.daylabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day17
            // 
            this.day17.Controls.Add(this.daylabel17);
            this.day17.Location = new System.Drawing.Point(122, 122);
            this.day17.Margin = new System.Windows.Forms.Padding(1);
            this.day17.Name = "day17";
            this.day17.Size = new System.Drawing.Size(58, 58);
            this.day17.TabIndex = 40;
            // 
            // daylabel17
            // 
            this.daylabel17.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel17.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel17.Location = new System.Drawing.Point(2, 2);
            this.daylabel17.Name = "daylabel17";
            this.daylabel17.Size = new System.Drawing.Size(54, 54);
            this.daylabel17.TabIndex = 2;
            this.daylabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day18
            // 
            this.day18.Controls.Add(this.daylabel18);
            this.day18.Location = new System.Drawing.Point(182, 122);
            this.day18.Margin = new System.Windows.Forms.Padding(1);
            this.day18.Name = "day18";
            this.day18.Size = new System.Drawing.Size(58, 58);
            this.day18.TabIndex = 40;
            // 
            // daylabel18
            // 
            this.daylabel18.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel18.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel18.Location = new System.Drawing.Point(2, 2);
            this.daylabel18.Name = "daylabel18";
            this.daylabel18.Size = new System.Drawing.Size(54, 54);
            this.daylabel18.TabIndex = 2;
            this.daylabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day19
            // 
            this.day19.Controls.Add(this.daylabel19);
            this.day19.Location = new System.Drawing.Point(242, 122);
            this.day19.Margin = new System.Windows.Forms.Padding(1);
            this.day19.Name = "day19";
            this.day19.Size = new System.Drawing.Size(58, 58);
            this.day19.TabIndex = 40;
            // 
            // daylabel19
            // 
            this.daylabel19.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel19.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel19.Location = new System.Drawing.Point(2, 2);
            this.daylabel19.Name = "daylabel19";
            this.daylabel19.Size = new System.Drawing.Size(54, 54);
            this.daylabel19.TabIndex = 2;
            this.daylabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day20
            // 
            this.day20.Controls.Add(this.daylabel20);
            this.day20.Location = new System.Drawing.Point(302, 122);
            this.day20.Margin = new System.Windows.Forms.Padding(1);
            this.day20.Name = "day20";
            this.day20.Size = new System.Drawing.Size(58, 58);
            this.day20.TabIndex = 40;
            // 
            // daylabel20
            // 
            this.daylabel20.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel20.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel20.Location = new System.Drawing.Point(2, 2);
            this.daylabel20.Name = "daylabel20";
            this.daylabel20.Size = new System.Drawing.Size(54, 54);
            this.daylabel20.TabIndex = 2;
            this.daylabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day21
            // 
            this.day21.Controls.Add(this.daylabel21);
            this.day21.Location = new System.Drawing.Point(362, 122);
            this.day21.Margin = new System.Windows.Forms.Padding(1);
            this.day21.Name = "day21";
            this.day21.Size = new System.Drawing.Size(58, 58);
            this.day21.TabIndex = 40;
            // 
            // daylabel21
            // 
            this.daylabel21.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel21.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel21.Location = new System.Drawing.Point(2, 2);
            this.daylabel21.Name = "daylabel21";
            this.daylabel21.Size = new System.Drawing.Size(54, 54);
            this.daylabel21.TabIndex = 2;
            this.daylabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day22
            // 
            this.day22.Controls.Add(this.daylabel22);
            this.day22.Location = new System.Drawing.Point(2, 182);
            this.day22.Margin = new System.Windows.Forms.Padding(1);
            this.day22.Name = "day22";
            this.day22.Size = new System.Drawing.Size(58, 58);
            this.day22.TabIndex = 40;
            // 
            // daylabel22
            // 
            this.daylabel22.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel22.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel22.Location = new System.Drawing.Point(2, 2);
            this.daylabel22.Name = "daylabel22";
            this.daylabel22.Size = new System.Drawing.Size(54, 54);
            this.daylabel22.TabIndex = 2;
            this.daylabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day23
            // 
            this.day23.Controls.Add(this.daylabel23);
            this.day23.Location = new System.Drawing.Point(62, 182);
            this.day23.Margin = new System.Windows.Forms.Padding(1);
            this.day23.Name = "day23";
            this.day23.Size = new System.Drawing.Size(58, 58);
            this.day23.TabIndex = 40;
            // 
            // daylabel23
            // 
            this.daylabel23.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel23.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel23.Location = new System.Drawing.Point(2, 2);
            this.daylabel23.Name = "daylabel23";
            this.daylabel23.Size = new System.Drawing.Size(54, 54);
            this.daylabel23.TabIndex = 2;
            this.daylabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day24
            // 
            this.day24.Controls.Add(this.daylabel24);
            this.day24.Location = new System.Drawing.Point(122, 182);
            this.day24.Margin = new System.Windows.Forms.Padding(1);
            this.day24.Name = "day24";
            this.day24.Size = new System.Drawing.Size(58, 58);
            this.day24.TabIndex = 40;
            // 
            // daylabel24
            // 
            this.daylabel24.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel24.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel24.Location = new System.Drawing.Point(2, 2);
            this.daylabel24.Name = "daylabel24";
            this.daylabel24.Size = new System.Drawing.Size(54, 54);
            this.daylabel24.TabIndex = 2;
            this.daylabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day25
            // 
            this.day25.Controls.Add(this.daylabel25);
            this.day25.Location = new System.Drawing.Point(182, 182);
            this.day25.Margin = new System.Windows.Forms.Padding(1);
            this.day25.Name = "day25";
            this.day25.Size = new System.Drawing.Size(58, 58);
            this.day25.TabIndex = 40;
            // 
            // daylabel25
            // 
            this.daylabel25.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel25.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel25.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel25.Location = new System.Drawing.Point(2, 2);
            this.daylabel25.Name = "daylabel25";
            this.daylabel25.Size = new System.Drawing.Size(54, 54);
            this.daylabel25.TabIndex = 2;
            this.daylabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day26
            // 
            this.day26.Controls.Add(this.daylabel26);
            this.day26.Location = new System.Drawing.Point(242, 182);
            this.day26.Margin = new System.Windows.Forms.Padding(1);
            this.day26.Name = "day26";
            this.day26.Size = new System.Drawing.Size(58, 58);
            this.day26.TabIndex = 40;
            // 
            // daylabel26
            // 
            this.daylabel26.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel26.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel26.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel26.Location = new System.Drawing.Point(2, 2);
            this.daylabel26.Name = "daylabel26";
            this.daylabel26.Size = new System.Drawing.Size(54, 54);
            this.daylabel26.TabIndex = 2;
            this.daylabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day27
            // 
            this.day27.Controls.Add(this.daylabel27);
            this.day27.Location = new System.Drawing.Point(302, 182);
            this.day27.Margin = new System.Windows.Forms.Padding(1);
            this.day27.Name = "day27";
            this.day27.Size = new System.Drawing.Size(58, 58);
            this.day27.TabIndex = 40;
            // 
            // daylabel27
            // 
            this.daylabel27.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel27.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel27.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel27.Location = new System.Drawing.Point(2, 2);
            this.daylabel27.Name = "daylabel27";
            this.daylabel27.Size = new System.Drawing.Size(54, 54);
            this.daylabel27.TabIndex = 2;
            this.daylabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day28
            // 
            this.day28.Controls.Add(this.daylabel28);
            this.day28.Location = new System.Drawing.Point(362, 182);
            this.day28.Margin = new System.Windows.Forms.Padding(1);
            this.day28.Name = "day28";
            this.day28.Size = new System.Drawing.Size(58, 58);
            this.day28.TabIndex = 40;
            // 
            // daylabel28
            // 
            this.daylabel28.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel28.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel28.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel28.Location = new System.Drawing.Point(2, 2);
            this.daylabel28.Name = "daylabel28";
            this.daylabel28.Size = new System.Drawing.Size(54, 54);
            this.daylabel28.TabIndex = 2;
            this.daylabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day29
            // 
            this.day29.Controls.Add(this.daylabel29);
            this.day29.Location = new System.Drawing.Point(2, 242);
            this.day29.Margin = new System.Windows.Forms.Padding(1);
            this.day29.Name = "day29";
            this.day29.Size = new System.Drawing.Size(58, 58);
            this.day29.TabIndex = 41;
            // 
            // daylabel29
            // 
            this.daylabel29.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel29.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel29.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel29.Location = new System.Drawing.Point(2, 2);
            this.daylabel29.Name = "daylabel29";
            this.daylabel29.Size = new System.Drawing.Size(54, 54);
            this.daylabel29.TabIndex = 2;
            this.daylabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day30
            // 
            this.day30.Controls.Add(this.daylabel30);
            this.day30.Location = new System.Drawing.Point(62, 242);
            this.day30.Margin = new System.Windows.Forms.Padding(1);
            this.day30.Name = "day30";
            this.day30.Size = new System.Drawing.Size(58, 58);
            this.day30.TabIndex = 41;
            // 
            // daylabel30
            // 
            this.daylabel30.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel30.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel30.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel30.Location = new System.Drawing.Point(2, 2);
            this.daylabel30.Name = "daylabel30";
            this.daylabel30.Size = new System.Drawing.Size(54, 54);
            this.daylabel30.TabIndex = 2;
            this.daylabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day31
            // 
            this.day31.Controls.Add(this.daylabel31);
            this.day31.Location = new System.Drawing.Point(122, 242);
            this.day31.Margin = new System.Windows.Forms.Padding(1);
            this.day31.Name = "day31";
            this.day31.Size = new System.Drawing.Size(58, 58);
            this.day31.TabIndex = 41;
            // 
            // daylabel31
            // 
            this.daylabel31.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel31.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel31.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel31.Location = new System.Drawing.Point(2, 2);
            this.daylabel31.Name = "daylabel31";
            this.daylabel31.Size = new System.Drawing.Size(54, 54);
            this.daylabel31.TabIndex = 2;
            this.daylabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day32
            // 
            this.day32.Controls.Add(this.daylabel32);
            this.day32.Location = new System.Drawing.Point(182, 242);
            this.day32.Margin = new System.Windows.Forms.Padding(1);
            this.day32.Name = "day32";
            this.day32.Size = new System.Drawing.Size(58, 58);
            this.day32.TabIndex = 41;
            // 
            // daylabel32
            // 
            this.daylabel32.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel32.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel32.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel32.Location = new System.Drawing.Point(2, 2);
            this.daylabel32.Name = "daylabel32";
            this.daylabel32.Size = new System.Drawing.Size(54, 54);
            this.daylabel32.TabIndex = 2;
            this.daylabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day33
            // 
            this.day33.Controls.Add(this.daylabel33);
            this.day33.Location = new System.Drawing.Point(242, 242);
            this.day33.Margin = new System.Windows.Forms.Padding(1);
            this.day33.Name = "day33";
            this.day33.Size = new System.Drawing.Size(58, 58);
            this.day33.TabIndex = 41;
            // 
            // daylabel33
            // 
            this.daylabel33.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel33.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel33.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel33.Location = new System.Drawing.Point(2, 2);
            this.daylabel33.Name = "daylabel33";
            this.daylabel33.Size = new System.Drawing.Size(54, 54);
            this.daylabel33.TabIndex = 2;
            this.daylabel33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day34
            // 
            this.day34.Controls.Add(this.daylabel34);
            this.day34.Location = new System.Drawing.Point(302, 242);
            this.day34.Margin = new System.Windows.Forms.Padding(1);
            this.day34.Name = "day34";
            this.day34.Size = new System.Drawing.Size(58, 58);
            this.day34.TabIndex = 41;
            // 
            // daylabel34
            // 
            this.daylabel34.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel34.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel34.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel34.Location = new System.Drawing.Point(2, 2);
            this.daylabel34.Name = "daylabel34";
            this.daylabel34.Size = new System.Drawing.Size(54, 54);
            this.daylabel34.TabIndex = 2;
            this.daylabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day35
            // 
            this.day35.Controls.Add(this.daylabel35);
            this.day35.Location = new System.Drawing.Point(362, 242);
            this.day35.Margin = new System.Windows.Forms.Padding(1);
            this.day35.Name = "day35";
            this.day35.Size = new System.Drawing.Size(58, 58);
            this.day35.TabIndex = 41;
            // 
            // daylabel35
            // 
            this.daylabel35.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel35.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel35.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel35.Location = new System.Drawing.Point(2, 2);
            this.daylabel35.Name = "daylabel35";
            this.daylabel35.Size = new System.Drawing.Size(54, 54);
            this.daylabel35.TabIndex = 2;
            this.daylabel35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day36
            // 
            this.day36.Controls.Add(this.daylabel36);
            this.day36.Location = new System.Drawing.Point(2, 302);
            this.day36.Margin = new System.Windows.Forms.Padding(1);
            this.day36.Name = "day36";
            this.day36.Size = new System.Drawing.Size(58, 58);
            this.day36.TabIndex = 41;
            // 
            // daylabel36
            // 
            this.daylabel36.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel36.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel36.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel36.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel36.Location = new System.Drawing.Point(2, 2);
            this.daylabel36.Name = "daylabel36";
            this.daylabel36.Size = new System.Drawing.Size(54, 54);
            this.daylabel36.TabIndex = 2;
            this.daylabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day37
            // 
            this.day37.Controls.Add(this.daylabel37);
            this.day37.Location = new System.Drawing.Point(62, 302);
            this.day37.Margin = new System.Windows.Forms.Padding(1);
            this.day37.Name = "day37";
            this.day37.Size = new System.Drawing.Size(58, 58);
            this.day37.TabIndex = 41;
            // 
            // daylabel37
            // 
            this.daylabel37.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel37.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel37.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel37.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel37.Location = new System.Drawing.Point(2, 2);
            this.daylabel37.Name = "daylabel37";
            this.daylabel37.Size = new System.Drawing.Size(54, 54);
            this.daylabel37.TabIndex = 2;
            this.daylabel37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day38
            // 
            this.day38.Controls.Add(this.daylabel38);
            this.day38.Location = new System.Drawing.Point(122, 302);
            this.day38.Margin = new System.Windows.Forms.Padding(1);
            this.day38.Name = "day38";
            this.day38.Size = new System.Drawing.Size(58, 58);
            this.day38.TabIndex = 41;
            // 
            // daylabel38
            // 
            this.daylabel38.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel38.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel38.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel38.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel38.Location = new System.Drawing.Point(2, 2);
            this.daylabel38.Name = "daylabel38";
            this.daylabel38.Size = new System.Drawing.Size(54, 54);
            this.daylabel38.TabIndex = 2;
            this.daylabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day39
            // 
            this.day39.Controls.Add(this.daylabel39);
            this.day39.Location = new System.Drawing.Point(182, 302);
            this.day39.Margin = new System.Windows.Forms.Padding(1);
            this.day39.Name = "day39";
            this.day39.Size = new System.Drawing.Size(58, 58);
            this.day39.TabIndex = 41;
            // 
            // daylabel39
            // 
            this.daylabel39.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel39.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel39.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel39.Location = new System.Drawing.Point(2, 2);
            this.daylabel39.Name = "daylabel39";
            this.daylabel39.Size = new System.Drawing.Size(54, 54);
            this.daylabel39.TabIndex = 2;
            this.daylabel39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day40
            // 
            this.day40.Controls.Add(this.daylabel40);
            this.day40.Location = new System.Drawing.Point(242, 302);
            this.day40.Margin = new System.Windows.Forms.Padding(1);
            this.day40.Name = "day40";
            this.day40.Size = new System.Drawing.Size(58, 58);
            this.day40.TabIndex = 41;
            // 
            // daylabel40
            // 
            this.daylabel40.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel40.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel40.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel40.Location = new System.Drawing.Point(2, 2);
            this.daylabel40.Name = "daylabel40";
            this.daylabel40.Size = new System.Drawing.Size(54, 54);
            this.daylabel40.TabIndex = 2;
            this.daylabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day41
            // 
            this.day41.Controls.Add(this.daylabel41);
            this.day41.Location = new System.Drawing.Point(302, 302);
            this.day41.Margin = new System.Windows.Forms.Padding(1);
            this.day41.Name = "day41";
            this.day41.Size = new System.Drawing.Size(58, 58);
            this.day41.TabIndex = 41;
            // 
            // daylabel41
            // 
            this.daylabel41.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel41.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel41.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel41.Location = new System.Drawing.Point(2, 2);
            this.daylabel41.Name = "daylabel41";
            this.daylabel41.Size = new System.Drawing.Size(54, 54);
            this.daylabel41.TabIndex = 2;
            this.daylabel41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // day42
            // 
            this.day42.Controls.Add(this.daylabel42);
            this.day42.Location = new System.Drawing.Point(362, 302);
            this.day42.Margin = new System.Windows.Forms.Padding(1);
            this.day42.Name = "day42";
            this.day42.Size = new System.Drawing.Size(58, 58);
            this.day42.TabIndex = 41;
            // 
            // daylabel42
            // 
            this.daylabel42.BackColor = System.Drawing.SystemColors.Control;
            this.daylabel42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.daylabel42.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daylabel42.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.daylabel42.Location = new System.Drawing.Point(2, 2);
            this.daylabel42.Name = "daylabel42";
            this.daylabel42.Size = new System.Drawing.Size(54, 54);
            this.daylabel42.TabIndex = 2;
            this.daylabel42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DatePickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DatePickPanel);
            this.Controls.Add(this.MonthGoingProgressBar);
            this.Controls.Add(this.DateLable);
            this.Controls.Add(this.TimeLable);
            this.Name = "DatePickerControl";
            this.Size = new System.Drawing.Size(453, 596);
            this.Load += new System.EventHandler(this.MainControl_Load);
            this.DatePickPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DatePickRightPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatePickLeftPic)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.day1.ResumeLayout(false);
            this.day2.ResumeLayout(false);
            this.day3.ResumeLayout(false);
            this.day4.ResumeLayout(false);
            this.day5.ResumeLayout(false);
            this.day6.ResumeLayout(false);
            this.day7.ResumeLayout(false);
            this.day8.ResumeLayout(false);
            this.day9.ResumeLayout(false);
            this.day10.ResumeLayout(false);
            this.day11.ResumeLayout(false);
            this.day12.ResumeLayout(false);
            this.day13.ResumeLayout(false);
            this.day14.ResumeLayout(false);
            this.day15.ResumeLayout(false);
            this.day16.ResumeLayout(false);
            this.day17.ResumeLayout(false);
            this.day18.ResumeLayout(false);
            this.day19.ResumeLayout(false);
            this.day20.ResumeLayout(false);
            this.day21.ResumeLayout(false);
            this.day22.ResumeLayout(false);
            this.day23.ResumeLayout(false);
            this.day24.ResumeLayout(false);
            this.day25.ResumeLayout(false);
            this.day26.ResumeLayout(false);
            this.day27.ResumeLayout(false);
            this.day28.ResumeLayout(false);
            this.day29.ResumeLayout(false);
            this.day30.ResumeLayout(false);
            this.day31.ResumeLayout(false);
            this.day32.ResumeLayout(false);
            this.day33.ResumeLayout(false);
            this.day34.ResumeLayout(false);
            this.day35.ResumeLayout(false);
            this.day36.ResumeLayout(false);
            this.day37.ResumeLayout(false);
            this.day38.ResumeLayout(false);
            this.day39.ResumeLayout(false);
            this.day40.ResumeLayout(false);
            this.day41.ResumeLayout(false);
            this.day42.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label TimeLable;//时间
        private System.Windows.Forms.Label DateLable;//日期
        private System.Windows.Forms.ProgressBar MonthGoingProgressBar;//月份进度
        private System.Windows.Forms.Panel DatePickPanel;
        private System.Windows.Forms.PictureBox DatePickLeftPic;
        private System.Windows.Forms.PictureBox DatePickRightPic;
        private MyTableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DatePickLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nowDateLabel;



        private System.Windows.Forms.Panel day1;
        private System.Windows.Forms.Panel day7;
        private System.Windows.Forms.Panel day6;
        private System.Windows.Forms.Panel day5;
        private System.Windows.Forms.Panel day4;
        private System.Windows.Forms.Panel day3;
        private System.Windows.Forms.Panel day2;
        private System.Windows.Forms.Panel day42;
        private System.Windows.Forms.Panel day41;
        private System.Windows.Forms.Panel day40;
        private System.Windows.Forms.Panel day39;
        private System.Windows.Forms.Panel day38;
        private System.Windows.Forms.Panel day37;
        private System.Windows.Forms.Panel day36;
        private System.Windows.Forms.Panel day35;
        private System.Windows.Forms.Panel day34;
        private System.Windows.Forms.Panel day33;
        private System.Windows.Forms.Panel day32;
        private System.Windows.Forms.Panel day31;
        private System.Windows.Forms.Panel day30;
        private System.Windows.Forms.Panel day29;
        private System.Windows.Forms.Panel day28;
        private System.Windows.Forms.Panel day27;
        private System.Windows.Forms.Panel day26;
        private System.Windows.Forms.Panel day25;
        private System.Windows.Forms.Panel day24;
        private System.Windows.Forms.Panel day23;
        private System.Windows.Forms.Panel day22;
        private System.Windows.Forms.Panel day21;
        private System.Windows.Forms.Panel day20;
        private System.Windows.Forms.Panel day19;
        private System.Windows.Forms.Panel day18;
        private System.Windows.Forms.Panel day17;
        private System.Windows.Forms.Panel day16;
        private System.Windows.Forms.Panel day15;
        private System.Windows.Forms.Panel day14;
        private System.Windows.Forms.Panel day13;
        private System.Windows.Forms.Panel day12;
        private System.Windows.Forms.Panel day11;
        private System.Windows.Forms.Panel day10;
        private System.Windows.Forms.Panel day9;
        private System.Windows.Forms.Panel day8;
        private System.Windows.Forms.Label daylabel1;
        private System.Windows.Forms.Label daylabel2;
        private System.Windows.Forms.Label daylabel42;
        private System.Windows.Forms.Label daylabel41;
        private System.Windows.Forms.Label daylabel40;
        private System.Windows.Forms.Label daylabel39;
        private System.Windows.Forms.Label daylabel38;
        private System.Windows.Forms.Label daylabel37;
        private System.Windows.Forms.Label daylabel36;
        private System.Windows.Forms.Label daylabel35;
        private System.Windows.Forms.Label daylabel34;
        private System.Windows.Forms.Label daylabel33;
        private System.Windows.Forms.Label daylabel32;
        private System.Windows.Forms.Label daylabel31;
        private System.Windows.Forms.Label daylabel30;
        private System.Windows.Forms.Label daylabel29;
        private System.Windows.Forms.Label daylabel28;
        private System.Windows.Forms.Label daylabel27;
        private System.Windows.Forms.Label daylabel26;
        private System.Windows.Forms.Label daylabel25;
        private System.Windows.Forms.Label daylabel24;
        private System.Windows.Forms.Label daylabel23;
        private System.Windows.Forms.Label daylabel22;
        private System.Windows.Forms.Label daylabel21;
        private System.Windows.Forms.Label daylabel20;
        private System.Windows.Forms.Label daylabel19;
        private System.Windows.Forms.Label daylabel18;
        private System.Windows.Forms.Label daylabel17;
        private System.Windows.Forms.Label daylabel16;
        private System.Windows.Forms.Label daylabel15;
        private System.Windows.Forms.Label daylabel14;
        private System.Windows.Forms.Label daylabel13;
        private System.Windows.Forms.Label daylabel12;
        private System.Windows.Forms.Label daylabel11;
        private System.Windows.Forms.Label daylabel10;
        private System.Windows.Forms.Label daylabel9;
        private System.Windows.Forms.Label daylabel6;
        private System.Windows.Forms.Label daylabel5;
        private System.Windows.Forms.Label daylabel4;
        private System.Windows.Forms.Label daylabel3;
        private System.Windows.Forms.Label daylabel7;
        private System.Windows.Forms.Label daylabel8;
    }
}
