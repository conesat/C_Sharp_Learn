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

namespace nncqweekly.form
{
    public partial class WeeklyModeForm : Form
    {
        private Control last;
        public List<MyModel> models=new List<MyModel>();
        private ItemTow choice = new ItemTow();
        private int choiceIndex =0;
        public WeeklyModeForm()
        {
            InitializeComponent();
            try
            {
                //读取model
                FileStream fs = new FileStream(Program.modelPath + "\\modle.bat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                models = bf.Deserialize(fs) as List<MyModel>;
                fs.Close();
            }
            catch (Exception e) { }
            loadData();
            this.FormClosing += WeeklyModeForm_FormClosing;
            ShowDialog();
        }

        private void WeeklyModeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(Program.modelPath + "\\modle.bat", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, models);
                fs.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败文件被占用!", "失败");
            }
        }

        private void loadData() {
            this.modelList.Controls.Clear();
            for (int i=0;i<models.Count;i++) {
                ItemTow item = new ItemTow(i+"");
                if (this.modelList.Controls.Count >= 1)
                {
                    last = this.modelList.Controls[this.modelList.Controls.Count - 1];
                    item.Location = new Point(0, last.Location.Y + last.Height);
                }
                item.workText.Text = models[i].title;
                if (models[i].used)
                {
                    item.BackColor=Color.LightBlue;
                    choice = item;
                    choiceIndex = i;
                }
                item.UseThis += Item_UseThis;
                item.EditWork += Item_EditWork;
                item.DeleteWork += Item_DeleteWork;
                this.modelList.Controls.Add(item);
            }

        }

        private void Item_DeleteWork(object sender, string id)
        {
            this.modelList.Controls.RemoveAt(int.Parse(id));
            models.RemoveAt(int.Parse(id));
            save();
        }

        private void Item_UseThis(object sender, string id)
        {
            choice.BackColor = this.BackColor;
            ItemTow item = (ItemTow)sender;
            choice = item;
            models[choiceIndex].used = false;
            models[int.Parse(id)].used = true;
            save();
        }

        private void Item_EditWork(object sender, string id)
        {
            new NewWeeklyModelForm(this, int.Parse(id));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new NewWeeklyModelForm(this,-1);
        }

        public void save() {
            loadData();
        }
    }
}
