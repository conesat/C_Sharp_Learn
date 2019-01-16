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
using weekly_note;

namespace nncqweekly.form
{
    public partial class NewWorkPlanForm : Form
    {
        private int itemI = -1;
        
        private String date;
        private MainForm mainForm;

        public NewWorkPlanForm(Work work, String date, MainForm mainForm,int i)
        {
            InitializeComponent();

            this.comboBox.SelectedIndex = DateTime.Now.Hour-1;
            if (work != null) { 
                itemI = i;
                this.planContent.Text = work.content;
                this.comboBox.SelectedIndex = work.startTime.Hour-1;
            }

            this.mainForm = mainForm;
            this.date = date;
            this.Text = date + " 工作安排";

            initData();
            this.ShowDialog();
        }

        public void initData()
        {
            this.comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox.SelectedIndex < DateTime.Now.Hour)
            {
                this.comboBox.SelectedIndex = DateTime.Now.Hour;
                this.msgtip.Visible = true;
            }
            else
            {
                this.msgtip.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.planContent.Text.Equals(""))
            {
                MessageBox.Show("内容不能为空!", "信息");
                return;
            }
             Work work=new Work();
                work.content = this.planContent.Text;
            work.startTime = Convert.ToDateTime(date + " " + this.comboBox.Text);
            if (File.Exists(Program.modelPath + "\\" + date + ".bat") == false)
            {
                WorkList workList = new WorkList();
               
                workList.todo.Add(work);
                FileStream fs = new FileStream(Program.modelPath + "\\" + date + ".bat", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, workList);
                fs.Close();
                mainForm.loadWorkPlan(date);
            }
            else
            {
                if (itemI > -1)
                {
                    mainForm.workListEntity.todo[itemI] = work;
                    mainForm.save();
                    this.Close();
                }
                else {
                    mainForm.workListEntity.todo.Add(work);
                    mainForm.save();
                    this.planContent.Text = "";
                    this.comboBox.SelectedIndex = DateTime.Now.Hour;
                }
            }
           
        }
    }
}
