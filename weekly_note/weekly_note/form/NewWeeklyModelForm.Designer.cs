namespace nncqweekly.form
{
    partial class NewWeeklyModelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWeeklyModelForm));
            this.title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Label();
            this.interval = new System.Windows.Forms.Label();
            this.workContent = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.review = new System.Windows.Forms.TextBox();
            this.intervalContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeCheck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.title.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(12, 25);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(3);
            this.title.Size = new System.Drawing.Size(395, 20);
            this.title.TabIndex = 0;
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::nncqweekly.Properties.Resources.回退;
            this.pictureBox1.Location = new System.Drawing.Point(420, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.time);
            this.panel1.Controls.Add(this.interval);
            this.panel1.Controls.Add(this.workContent);
            this.panel1.Controls.Add(this.id);
            this.panel1.Location = new System.Drawing.Point(26, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 55);
            this.panel1.TabIndex = 2;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.SystemColors.Control;
            this.time.Cursor = System.Windows.Forms.Cursors.Hand;
            this.time.Location = new System.Drawing.Point(218, 15);
            this.time.Name = "time";
            this.time.Padding = new System.Windows.Forms.Padding(5);
            this.time.Size = new System.Drawing.Size(39, 22);
            this.time.TabIndex = 3;
            this.time.Text = "时间";
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // interval
            // 
            this.interval.AutoSize = true;
            this.interval.BackColor = System.Drawing.SystemColors.Control;
            this.interval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.interval.Location = new System.Drawing.Point(156, 15);
            this.interval.Name = "interval";
            this.interval.Padding = new System.Windows.Forms.Padding(5);
            this.interval.Size = new System.Drawing.Size(39, 22);
            this.interval.TabIndex = 2;
            this.interval.Text = "间隔";
            this.interval.Click += new System.EventHandler(this.interval_Click);
            // 
            // workContent
            // 
            this.workContent.AutoSize = true;
            this.workContent.BackColor = System.Drawing.SystemColors.Control;
            this.workContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.workContent.Location = new System.Drawing.Point(70, 15);
            this.workContent.Name = "workContent";
            this.workContent.Padding = new System.Windows.Forms.Padding(5);
            this.workContent.Size = new System.Drawing.Size(63, 22);
            this.workContent.TabIndex = 1;
            this.workContent.Text = "工作内容";
            this.workContent.Click += new System.EventHandler(this.workContent_Click);
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.BackColor = System.Drawing.SystemColors.Control;
            this.id.Cursor = System.Windows.Forms.Cursors.Hand;
            this.id.Location = new System.Drawing.Point(12, 15);
            this.id.Name = "id";
            this.id.Padding = new System.Windows.Forms.Padding(5);
            this.id.Size = new System.Drawing.Size(39, 22);
            this.id.TabIndex = 0;
            this.id.Text = "序号";
            this.id.Click += new System.EventHandler(this.id_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.review);
            this.panel2.Location = new System.Drawing.Point(26, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 190);
            this.panel2.TabIndex = 3;
            // 
            // review
            // 
            this.review.Enabled = false;
            this.review.Location = new System.Drawing.Point(14, 12);
            this.review.Multiline = true;
            this.review.Name = "review";
            this.review.Size = new System.Drawing.Size(384, 160);
            this.review.TabIndex = 0;
            // 
            // intervalContent
            // 
            this.intervalContent.Location = new System.Drawing.Point(99, 63);
            this.intervalContent.Name = "intervalContent";
            this.intervalContent.Size = new System.Drawing.Size(100, 21);
            this.intervalContent.TabIndex = 4;
            this.intervalContent.Text = "           ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "间隔内容 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(240, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "时间格式 :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeCheck
            // 
            this.timeCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeCheck.FormattingEnabled = true;
            this.timeCheck.Items.AddRange(new object[] {
            "D-H",
            "天-小时"});
            this.timeCheck.Location = new System.Drawing.Point(319, 63);
            this.timeCheck.Name = "timeCheck";
            this.timeCheck.Size = new System.Drawing.Size(121, 20);
            this.timeCheck.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择添加";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "预览";
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.BackColor = System.Drawing.SystemColors.Control;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.save.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.save.Location = new System.Drawing.Point(206, 440);
            this.save.Name = "save";
            this.save.Padding = new System.Windows.Forms.Padding(5);
            this.save.Size = new System.Drawing.Size(50, 27);
            this.save.TabIndex = 10;
            this.save.Text = "保存";
            this.save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // NewWeeklyModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(462, 476);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intervalContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewWeeklyModelForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label interval;
        private System.Windows.Forms.Label workContent;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox intervalContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox timeCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.TextBox review;
        private System.Windows.Forms.Label save;
    }
}