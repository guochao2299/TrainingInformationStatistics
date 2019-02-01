namespace TrainingInformationStatistics
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbQuitWinTipSave = new System.Windows.Forms.RadioButton();
            this.rbSaveNow = new System.Windows.Forms.RadioButton();
            this.btnDeleteRecords = new System.Windows.Forms.Button();
            this.btnBrowseRecord = new System.Windows.Forms.Button();
            this.btnModifyRecord = new System.Windows.Forms.Button();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRecords);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnAbout);
            this.splitContainer1.Panel2.Controls.Add(this.btnQuit);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteRecords);
            this.splitContainer1.Panel2.Controls.Add(this.btnBrowseRecord);
            this.splitContainer1.Panel2.Controls.Add(this.btnModifyRecord);
            this.splitContainer1.Panel2.Controls.Add(this.btnNewRecord);
            this.splitContainer1.Size = new System.Drawing.Size(1050, 518);
            this.splitContainer1.SplitterDistance = 862;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column7});
            this.dgvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecords.Location = new System.Drawing.Point(0, 0);
            this.dgvRecords.MultiSelect = false;
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowHeadersWidth = 25;
            this.dgvRecords.RowTemplate.Height = 23;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(862, 518);
            this.dgvRecords.TabIndex = 0;
            this.dgvRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvRecords_MouseClick);
            this.dgvRecords.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRecords_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "培训日期";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "培训地点";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "主持人";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "培训主题";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "培训内容";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "学时（小时）";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "参加人员";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(17, 455);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(143, 27);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "退出程序";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbQuitWinTipSave);
            this.groupBox1.Controls.Add(this.rbSaveNow);
            this.groupBox1.Location = new System.Drawing.Point(17, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "记录保存方式";
            // 
            // rbQuitWinTipSave
            // 
            this.rbQuitWinTipSave.AutoSize = true;
            this.rbQuitWinTipSave.Location = new System.Drawing.Point(12, 42);
            this.rbQuitWinTipSave.Name = "rbQuitWinTipSave";
            this.rbQuitWinTipSave.Size = new System.Drawing.Size(131, 16);
            this.rbQuitWinTipSave.TabIndex = 0;
            this.rbQuitWinTipSave.TabStop = true;
            this.rbQuitWinTipSave.Text = "退出程序时提示保存";
            this.rbQuitWinTipSave.UseVisualStyleBackColor = true;
            // 
            // rbSaveNow
            // 
            this.rbSaveNow.AutoSize = true;
            this.rbSaveNow.Checked = true;
            this.rbSaveNow.Location = new System.Drawing.Point(12, 20);
            this.rbSaveNow.Name = "rbSaveNow";
            this.rbSaveNow.Size = new System.Drawing.Size(71, 16);
            this.rbSaveNow.TabIndex = 0;
            this.rbSaveNow.TabStop = true;
            this.rbSaveNow.Text = "实时保存";
            this.rbSaveNow.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRecords
            // 
            this.btnDeleteRecords.Location = new System.Drawing.Point(17, 111);
            this.btnDeleteRecords.Name = "btnDeleteRecords";
            this.btnDeleteRecords.Size = new System.Drawing.Size(143, 27);
            this.btnDeleteRecords.TabIndex = 0;
            this.btnDeleteRecords.Text = "删 除 培 训 记 录";
            this.btnDeleteRecords.UseVisualStyleBackColor = true;
            this.btnDeleteRecords.Click += new System.EventHandler(this.btnDeleteRecords_Click);
            // 
            // btnBrowseRecord
            // 
            this.btnBrowseRecord.Location = new System.Drawing.Point(17, 78);
            this.btnBrowseRecord.Name = "btnBrowseRecord";
            this.btnBrowseRecord.Size = new System.Drawing.Size(143, 27);
            this.btnBrowseRecord.TabIndex = 0;
            this.btnBrowseRecord.Text = "浏 览 培 训 记 录";
            this.btnBrowseRecord.UseVisualStyleBackColor = true;
            this.btnBrowseRecord.Click += new System.EventHandler(this.btnBrowseRecord_Click);
            // 
            // btnModifyRecord
            // 
            this.btnModifyRecord.Location = new System.Drawing.Point(17, 45);
            this.btnModifyRecord.Name = "btnModifyRecord";
            this.btnModifyRecord.Size = new System.Drawing.Size(143, 27);
            this.btnModifyRecord.TabIndex = 0;
            this.btnModifyRecord.Text = "修 改 培 训 记 录";
            this.btnModifyRecord.UseVisualStyleBackColor = true;
            this.btnModifyRecord.Click += new System.EventHandler(this.btnModifyRecord_Click);
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.Location = new System.Drawing.Point(17, 12);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(143, 27);
            this.btnNewRecord.TabIndex = 0;
            this.btnNewRecord.Text = "新 建 培 训 记 录";
            this.btnNewRecord.UseVisualStyleBackColor = true;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(26, 305);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(143, 27);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "关于本程序...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 518);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "培训信息统计";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Button btnDeleteRecords;
        private System.Windows.Forms.Button btnBrowseRecord;
        private System.Windows.Forms.Button btnModifyRecord;
        private System.Windows.Forms.Button btnNewRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbQuitWinTipSave;
        private System.Windows.Forms.RadioButton rbSaveNow;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnAbout;
    }
}

