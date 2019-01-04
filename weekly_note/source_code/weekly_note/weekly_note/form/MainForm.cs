using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace nncqweekly.form
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm=null;
        public static MainPointForm mainPointForm = null;
        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (mainPointForm == null)
            {
                mainPointForm = new MainPointForm();
                mainPointForm.ShowDialog();
            }
            
        }
    }
}
