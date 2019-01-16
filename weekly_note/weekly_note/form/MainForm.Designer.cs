using System.Windows.Forms;

namespace nncqweekly.form
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ttpSettings = new System.Windows.Forms.ToolTip(this.components);
            this.editModel = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.builder = new System.Windows.Forms.PictureBox();
            this.hide = new System.Windows.Forms.PictureBox();
            this.addWork = new System.Windows.Forms.PictureBox();
            this.finishSelect = new System.Windows.Forms.PictureBox();
            this.deleteSelect = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.workList = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.workTitle = new System.Windows.Forms.Label();
            this.datePickerControl1 = new DatePicker.DatePickerControl();
            this.aboutPanel = new nncqweekly.view.AboutPanel();
            this.aboutContentPanle = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.builder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteSelect)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.aboutPanel.SuspendLayout();
            this.aboutContentPanle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpSettings
            // 
            this.ttpSettings.AutoPopDelay = 5000;
            this.ttpSettings.InitialDelay = 200;
            this.ttpSettings.ReshowDelay = 200;
            this.ttpSettings.ShowAlways = true;
            // 
            // editModel
            // 
            this.editModel.AutoSize = true;
            this.editModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editModel.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editModel.Location = new System.Drawing.Point(23, 21);
            this.editModel.Name = "editModel";
            this.editModel.Size = new System.Drawing.Size(63, 14);
            this.editModel.TabIndex = 4;
            this.editModel.Text = "周报模板";
            this.editModel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ttpSettings.SetToolTip(this.editModel, "编辑周报模板");
            this.editModel.Click += new System.EventHandler(this.editModel_Click);
            // 
            // about
            // 
            this.about.AutoSize = true;
            this.about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.about.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.about.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.about.Location = new System.Drawing.Point(202, 21);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(35, 14);
            this.about.TabIndex = 5;
            this.about.Text = "关于";
            this.about.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ttpSettings.SetToolTip(this.about, "关于周报便签");
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(92, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "工作时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ttpSettings.SetToolTip(this.label1, "调整工作时间");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(161, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "设置";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ttpSettings.SetToolTip(this.label2, "相关设置");
            // 
            // builder
            // 
            this.builder.BackgroundImage = global::nncqweekly.Properties.Resources.生成;
            this.builder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.builder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.builder.Location = new System.Drawing.Point(888, 13);
            this.builder.Margin = new System.Windows.Forms.Padding(5);
            this.builder.Name = "builder";
            this.builder.Size = new System.Drawing.Size(25, 25);
            this.builder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.builder.TabIndex = 3;
            this.builder.TabStop = false;
            this.ttpSettings.SetToolTip(this.builder, "获取本周工作内容");
            // 
            // hide
            // 
            this.hide.BackgroundImage = global::nncqweekly.Properties.Resources.收起;
            this.hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide.Location = new System.Drawing.Point(923, 13);
            this.hide.Margin = new System.Windows.Forms.Padding(5);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(25, 25);
            this.hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.hide.TabIndex = 2;
            this.hide.TabStop = false;
            this.ttpSettings.SetToolTip(this.hide, "隐藏到屏幕顶部");
            this.hide.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // addWork
            // 
            this.addWork.BackgroundImage = global::nncqweekly.Properties.Resources.添加;
            this.addWork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addWork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addWork.Location = new System.Drawing.Point(3, 3);
            this.addWork.Name = "addWork";
            this.addWork.Size = new System.Drawing.Size(20, 20);
            this.addWork.TabIndex = 2;
            this.addWork.TabStop = false;
            this.ttpSettings.SetToolTip(this.addWork, "添加工作安排");
            this.addWork.Click += new System.EventHandler(this.addWork_Click);
            // 
            // finishSelect
            // 
            this.finishSelect.BackgroundImage = global::nncqweekly.Properties.Resources.完成10;
            this.finishSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.finishSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishSelect.Location = new System.Drawing.Point(42, 3);
            this.finishSelect.Name = "finishSelect";
            this.finishSelect.Size = new System.Drawing.Size(20, 20);
            this.finishSelect.TabIndex = 1;
            this.finishSelect.TabStop = false;
            this.ttpSettings.SetToolTip(this.finishSelect, "批量完成");
            this.finishSelect.Click += new System.EventHandler(this.finishSelect_Click);
            // 
            // deleteSelect
            // 
            this.deleteSelect.BackgroundImage = global::nncqweekly.Properties.Resources.删除0;
            this.deleteSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteSelect.Location = new System.Drawing.Point(82, 3);
            this.deleteSelect.Name = "deleteSelect";
            this.deleteSelect.Size = new System.Drawing.Size(20, 20);
            this.deleteSelect.TabIndex = 0;
            this.deleteSelect.TabStop = false;
            this.ttpSettings.SetToolTip(this.deleteSelect, "批量删除");
            this.deleteSelect.Click += new System.EventHandler(this.deleteSelect_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.about);
            this.panel1.Controls.Add(this.editModel);
            this.panel1.Controls.Add(this.builder);
            this.panel1.Controls.Add(this.hide);
            this.panel1.Location = new System.Drawing.Point(-12, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.datePickerControl1);
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 605);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.workList);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.workTitle);
            this.panel3.Location = new System.Drawing.Point(469, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 597);
            this.panel3.TabIndex = 1;
            // 
            // workList
            // 
            this.workList.AutoScroll = true;
            this.workList.Location = new System.Drawing.Point(0, 29);
            this.workList.Name = "workList";
            this.workList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.workList.Size = new System.Drawing.Size(477, 568);
            this.workList.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.addWork);
            this.panel4.Controls.Add(this.finishSelect);
            this.panel4.Controls.Add(this.deleteSelect);
            this.panel4.Location = new System.Drawing.Point(367, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 26);
            this.panel4.TabIndex = 2;
            // 
            // workTitle
            // 
            this.workTitle.AutoSize = true;
            this.workTitle.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.workTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.workTitle.Location = new System.Drawing.Point(3, 5);
            this.workTitle.Name = "workTitle";
            this.workTitle.Size = new System.Drawing.Size(240, 16);
            this.workTitle.TabIndex = 0;
            this.workTitle.Text = "2019年1月14日 星期一 工作内容";
            this.workTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datePickerControl1
            // 
            this.datePickerControl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.datePickerControl1.Location = new System.Drawing.Point(10, 3);
            this.datePickerControl1.Name = "datePickerControl1";
            this.datePickerControl1.Size = new System.Drawing.Size(456, 594);
            this.datePickerControl1.TabIndex = 0;
            // 
            // aboutPanel
            // 
            this.aboutPanel.Controls.Add(this.aboutContentPanle);
            this.aboutPanel.Location = new System.Drawing.Point(0, -5);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(953, 666);
            this.aboutPanel.TabIndex = 1;
            this.aboutPanel.Visible = false;
            // 
            // aboutContentPanle
            // 
            this.aboutContentPanle.BackColor = System.Drawing.SystemColors.Control;
            this.aboutContentPanle.Controls.Add(this.label5);
            this.aboutContentPanle.Controls.Add(this.label4);
            this.aboutContentPanle.Controls.Add(this.linkLabel2);
            this.aboutContentPanle.Controls.Add(this.linkLabel1);
            this.aboutContentPanle.Controls.Add(this.pictureBox3);
            this.aboutContentPanle.Controls.Add(this.pictureBox2);
            this.aboutContentPanle.Controls.Add(this.pictureBox1);
            this.aboutContentPanle.Controls.Add(this.label3);
            this.aboutContentPanle.Location = new System.Drawing.Point(0, 3);
            this.aboutContentPanle.Name = "aboutContentPanle";
            this.aboutContentPanle.Size = new System.Drawing.Size(953, 660);
            this.aboutContentPanle.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::nncqweekly.Properties.Resources.github;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(390, 302);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::nncqweekly.Properties.Resources.码云;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(548, 302);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::nncqweekly.Properties.Resources.便签;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(441, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(903, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "关闭";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(362, 366);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 44);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/conesat/C_Sharp_Learn";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(523, 366);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(100, 44);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://gitee.com/conesat/C_Sharp_Learn";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(423, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "名称:周报便签";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(423, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "版本:null";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(953, 646);
            this.Controls.Add(this.aboutPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "周报便签";
            ((System.ComponentModel.ISupportInitialize)(this.builder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteSelect)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.aboutPanel.ResumeLayout(false);
            this.aboutContentPanle.ResumeLayout(false);
            this.aboutContentPanle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox hide;
        private DatePicker.DatePickerControl datePickerControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label workTitle;
        private System.Windows.Forms.PictureBox builder;
        private ToolTip ttpSettings;
        private Panel panel4;
        private PictureBox deleteSelect;
        private PictureBox finishSelect;
        private Panel workList;
        private PictureBox addWork;
        private Label editModel;
        private Label about;
        private Label label2;
        private Label label1;
        private view.AboutPanel aboutPanel;
        private Panel aboutContentPanle;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel1;
        private Label label5;
        private Label label4;
        private LinkLabel linkLabel2;
    }
}