namespace Weekly_List_Item
{
    partial class WorkListItem
    {
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.check = new System.Windows.Forms.CheckBox();
            this.workText = new System.Windows.Forms.Label();
            this.finish = new System.Windows.Forms.PictureBox();
            this.edit = new System.Windows.Forms.PictureBox();
            this.delete = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.finish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            this.SuspendLayout();
            // 
            // check
            // 
            this.check.AutoSize = true;
            this.check.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check.Location = new System.Drawing.Point(11, 13);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(15, 14);
            this.check.TabIndex = 0;
            this.check.UseVisualStyleBackColor = true;
            this.check.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // workText
            // 
            this.workText.AutoSize = true;
            this.workText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.workText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.workText.Location = new System.Drawing.Point(32, 13);
            this.workText.Name = "workText";
            this.workText.Size = new System.Drawing.Size(0, 14);
            this.workText.TabIndex = 1;
            // 
            // finish
            // 
            this.finish.BackgroundImage = global::Weekly_List_Item.Properties.Resources.完成0;
            this.finish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.finish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finish.Location = new System.Drawing.Point(351, 10);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(20, 20);
            this.finish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.finish.TabIndex = 4;
            this.finish.TabStop = false;
            this.toolTip1.SetToolTip(this.finish, "完成");
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // edit
            // 
            this.edit.BackgroundImage = global::Weekly_List_Item.Properties.Resources.编辑0;
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit.Location = new System.Drawing.Point(390, 10);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(20, 20);
            this.edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edit.TabIndex = 3;
            this.edit.TabStop = false;
            this.toolTip1.SetToolTip(this.edit, "编辑");
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            this.delete.BackgroundImage = global::Weekly_List_Item.Properties.Resources.删除0;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.Location = new System.Drawing.Point(428, 10);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(20, 20);
            this.delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delete.TabIndex = 2;
            this.delete.TabStop = false;
            this.toolTip1.SetToolTip(this.delete, "删除");
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 200;
            this.toolTip1.ShowAlways = true;
            // 
            // WorkListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.finish);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.workText);
            this.Controls.Add(this.check);
            this.Name = "WorkListItem";
            this.Size = new System.Drawing.Size(451, 38);
            ((System.ComponentModel.ISupportInitialize)(this.finish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox check;
        public System.Windows.Forms.Label workText;
        public System.Windows.Forms.PictureBox delete;
        public System.Windows.Forms.PictureBox edit;
        public System.Windows.Forms.PictureBox finish;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}
