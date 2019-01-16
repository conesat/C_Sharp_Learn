using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weekly_List_Item
{
    public partial class ItemOne: UserControl
    {
        public String ID = "";
        public ItemOne()
        {
            InitializeComponent();
            initData();
        }
        public ItemOne(String id)
        {
            this.ID = id;

            InitializeComponent();

            initData();
        }

        private void initData() {
            this.finish.MouseEnter += PIC_MouseEnter;
            this.finish.MouseLeave += PIC_MouseLeave;

            this.edit.MouseEnter += PIC_MouseEnter;
            this.edit.MouseLeave += PIC_MouseLeave;

            this.delete.MouseEnter += PIC_MouseEnter;
            this.delete.MouseLeave += PIC_MouseLeave;

            this.delete.Location = new Point(this.Width - 30, 10);

            this.edit.Location = new Point(this.Width - 60, 10);

            this.finish.Location = new Point(this.Width - 90, 10);
        }

        private void PIC_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox pic = (System.Windows.Forms.PictureBox)sender;
            switch (pic.Name) {
                case "finish":
                    pic.BackgroundImage = global::Weekly_List_Item.Properties.Resources.完成0;
                    break;
                case "edit":
                    pic.BackgroundImage = global::Weekly_List_Item.Properties.Resources.编辑0;
                    break;
                case "delete":
                    pic.BackgroundImage = global::Weekly_List_Item.Properties.Resources.删除0;
                    break;
            }
          
        }

        private void PIC_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox pic = (System.Windows.Forms.PictureBox)sender;
            switch (pic.Name)
            {
                case "finish":
                    pic.BackgroundImage = global::Weekly_List_Item.Properties.Resources.完成;
                    break;
                case "edit":
                    pic.BackgroundImage = global::Weekly_List_Item.Properties.Resources.编辑;
                    break;
                case "delete":
                    pic.BackgroundImage = global::Weekly_List_Item.Properties.Resources.删除;
                    break;
            }
        }
        
        public delegate void FinishHandler(object sender, String id);
        public event FinishHandler FinishWork;

        public delegate void EditHandler(object sender, String id);
        public event EditHandler EditWork;

        public delegate void DeleteHandler(object sender, String id);
        public event DeleteHandler DeleteWork;

        public delegate void CheckHandler(object sender, Boolean check,String id);
        public event CheckHandler CheckChange;

        private void finish_Click(object sender, EventArgs e)
        {
            if (FinishWork!=null) {
                FinishWork(this, ID);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (EditWork != null)
            {
                EditWork(this, ID);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (DeleteWork != null)
            {
                DeleteWork(this, ID);
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckChange != null)
            {
                CheckChange(this, this.check.Checked, ID);
            }
        }
    }
}
