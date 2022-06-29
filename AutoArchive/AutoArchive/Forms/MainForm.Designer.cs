/*************************************************************************************
 *
 * 文 件 名:   MainForm.cs
 * 描    述:   主界面
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/6/19 14:25:52
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/

namespace AutoArchive.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backupBtn = new System.Windows.Forms.Button();
            this.remarkeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.countDownLb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closeTask = new System.Windows.Forms.RadioButton();
            this.openTask = new System.Windows.Forms.RadioButton();
            this.periodTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.des = new System.Windows.Forms.Label();
            this.src = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.Label();
            this.desLab = new System.Windows.Forms.Label();
            this.srcLab = new System.Windows.Forms.Label();
            this.projectNameLab = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.hideIntoTray = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.remarkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.recoverBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileBtn = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 149);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.backupBtn);
            this.groupBox3.Controls.Add(this.remarkeTextBox);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(464, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 62);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // backupBtn
            // 
            this.backupBtn.BackColor = System.Drawing.SystemColors.Control;
            this.backupBtn.Enabled = false;
            this.backupBtn.Location = new System.Drawing.Point(275, 25);
            this.backupBtn.Name = "backupBtn";
            this.backupBtn.Size = new System.Drawing.Size(62, 29);
            this.backupBtn.TabIndex = 13;
            this.backupBtn.Text = "备份";
            this.backupBtn.UseVisualStyleBackColor = false;
            this.backupBtn.Click += new System.EventHandler(this.backupBtn_Click);
            // 
            // remarkeTextBox
            // 
            this.remarkeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.remarkeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remarkeTextBox.Location = new System.Drawing.Point(14, 28);
            this.remarkeTextBox.Name = "remarkeTextBox";
            this.remarkeTextBox.PlaceholderText = "输入备注后点击\"备份\"按钮进行备份";
            this.remarkeTextBox.Size = new System.Drawing.Size(239, 24);
            this.remarkeTextBox.TabIndex = 22;
            this.remarkeTextBox.TextChanged += new System.EventHandler(this.remarkeTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.countDownLb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.closeTask);
            this.groupBox2.Controls.Add(this.openTask);
            this.groupBox2.Controls.Add(this.periodTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(464, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务";
            // 
            // countDownLb
            // 
            this.countDownLb.AutoSize = true;
            this.countDownLb.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countDownLb.ForeColor = System.Drawing.Color.Red;
            this.countDownLb.Location = new System.Drawing.Point(116, 52);
            this.countDownLb.Name = "countDownLb";
            this.countDownLb.Size = new System.Drawing.Size(0, 17);
            this.countDownLb.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "距离下一次备份：";
            // 
            // closeTask
            // 
            this.closeTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTask.AutoSize = true;
            this.closeTask.Checked = true;
            this.closeTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeTask.Location = new System.Drawing.Point(412, 47);
            this.closeTask.Name = "closeTask";
            this.closeTask.Size = new System.Drawing.Size(55, 24);
            this.closeTask.TabIndex = 16;
            this.closeTask.TabStop = true;
            this.closeTask.Text = "关闭";
            this.closeTask.UseVisualStyleBackColor = true;
            // 
            // openTask
            // 
            this.openTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openTask.AutoSize = true;
            this.openTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openTask.Location = new System.Drawing.Point(354, 47);
            this.openTask.Name = "openTask";
            this.openTask.Size = new System.Drawing.Size(55, 24);
            this.openTask.TabIndex = 15;
            this.openTask.TabStop = true;
            this.openTask.Text = "开启";
            this.openTask.UseVisualStyleBackColor = true;
            this.openTask.CheckedChanged += new System.EventHandler(this.openTask_CheckedChanged);
            // 
            // periodTextBox
            // 
            this.periodTextBox.Location = new System.Drawing.Point(119, 19);
            this.periodTextBox.Name = "periodTextBox";
            this.periodTextBox.Size = new System.Drawing.Size(62, 24);
            this.periodTextBox.TabIndex = 14;
            this.periodTextBox.Text = "10";
            this.periodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.periodTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "定时备份(分钟)：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.updateBtn);
            this.groupBox1.Controls.Add(this.des);
            this.groupBox1.Controls.Add(this.src);
            this.groupBox1.Controls.Add(this.projectName);
            this.groupBox1.Controls.Add(this.desLab);
            this.groupBox1.Controls.Add(this.srcLab);
            this.groupBox1.Controls.Add(this.projectNameLab);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.SystemColors.Control;
            this.updateBtn.Location = new System.Drawing.Point(386, 107);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(62, 29);
            this.updateBtn.TabIndex = 12;
            this.updateBtn.Text = "修改";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtnClicked);
            // 
            // des
            // 
            this.des.AutoEllipsis = true;
            this.des.AutoSize = true;
            this.des.BackColor = System.Drawing.Color.White;
            this.des.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.des.ForeColor = System.Drawing.Color.Black;
            this.des.Location = new System.Drawing.Point(98, 83);
            this.des.Name = "des";
            this.des.Size = new System.Drawing.Size(0, 17);
            this.des.TabIndex = 11;
            // 
            // src
            // 
            this.src.AutoEllipsis = true;
            this.src.AutoSize = true;
            this.src.BackColor = System.Drawing.Color.White;
            this.src.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.src.ForeColor = System.Drawing.Color.Black;
            this.src.Location = new System.Drawing.Point(98, 55);
            this.src.Name = "src";
            this.src.Size = new System.Drawing.Size(0, 17);
            this.src.TabIndex = 10;
            // 
            // projectName
            // 
            this.projectName.AutoEllipsis = true;
            this.projectName.AutoSize = true;
            this.projectName.BackColor = System.Drawing.Color.White;
            this.projectName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.projectName.ForeColor = System.Drawing.Color.Black;
            this.projectName.Location = new System.Drawing.Point(98, 27);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(0, 17);
            this.projectName.TabIndex = 9;
            // 
            // desLab
            // 
            this.desLab.AutoSize = true;
            this.desLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.desLab.ForeColor = System.Drawing.Color.Black;
            this.desLab.Location = new System.Drawing.Point(10, 82);
            this.desLab.Name = "desLab";
            this.desLab.Size = new System.Drawing.Size(68, 17);
            this.desLab.TabIndex = 8;
            this.desLab.Text = "备份路径：";
            // 
            // srcLab
            // 
            this.srcLab.AutoSize = true;
            this.srcLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.srcLab.ForeColor = System.Drawing.Color.Black;
            this.srcLab.Location = new System.Drawing.Point(10, 54);
            this.srcLab.Name = "srcLab";
            this.srcLab.Size = new System.Drawing.Size(68, 17);
            this.srcLab.TabIndex = 7;
            this.srcLab.Text = "存档路径：";
            // 
            // projectNameLab
            // 
            this.projectNameLab.AutoSize = true;
            this.projectNameLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.projectNameLab.ForeColor = System.Drawing.Color.Black;
            this.projectNameLab.Location = new System.Drawing.Point(10, 26);
            this.projectNameLab.Name = "projectNameLab";
            this.projectNameLab.Size = new System.Drawing.Size(44, 17);
            this.projectNameLab.TabIndex = 6;
            this.projectNameLab.Text = "游戏：";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 50000;
            this.toolTip.InitialDelay = 50;
            this.toolTip.ReshowDelay = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectMenu,
            this.hideIntoTray});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(946, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openProjectMenu
            // 
            this.openProjectMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openProjectMenu.Name = "openProjectMenu";
            this.openProjectMenu.Size = new System.Drawing.Size(44, 21);
            this.openProjectMenu.Text = "打开";
            this.openProjectMenu.Click += new System.EventHandler(this.openProjectMenu_Click);
            // 
            // hideIntoTray
            // 
            this.hideIntoTray.Name = "hideIntoTray";
            this.hideIntoTray.Size = new System.Drawing.Size(80, 21);
            this.hideIntoTray.Text = "隐藏到托盘";
            this.hideIntoTray.Click += new System.EventHandler(this.hideIntoTray_Click);
            // 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(0, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 361);
            this.panel2.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataTable);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(2, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(940, 361);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "备份数据";
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToAddRows = false;
            this.dataTable.BackgroundColor = System.Drawing.Color.White;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remarkCol,
            this.dateCol,
            this.pathCol});
            this.dataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTable.Location = new System.Drawing.Point(3, 45);
            this.dataTable.MultiSelect = false;
            this.dataTable.Name = "dataTable";
            this.dataTable.ReadOnly = true;
            this.dataTable.RowHeadersVisible = false;
            this.dataTable.RowTemplate.Height = 25;
            this.dataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTable.Size = new System.Drawing.Size(934, 313);
            this.dataTable.TabIndex = 1;
            this.dataTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellClick);
            this.dataTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataTable_RowsRemoved);
            this.dataTable.SelectionChanged += new System.EventHandler(this.dataTable_SelectionChanged);
            // 
            // remarkCol
            // 
            this.remarkCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remarkCol.HeaderText = "备注";
            this.remarkCol.Name = "remarkCol";
            this.remarkCol.ReadOnly = true;
            // 
            // dateCol
            // 
            this.dateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCol.HeaderText = "日期";
            this.dateCol.Name = "dateCol";
            this.dateCol.ReadOnly = true;
            // 
            // pathCol
            // 
            this.pathCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathCol.HeaderText = "所在路径";
            this.pathCol.Name = "pathCol";
            this.pathCol.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recoverBtn,
            this.deleteBtn,
            this.toolStripSeparator1,
            this.openFileBtn});
            this.toolStrip1.Location = new System.Drawing.Point(3, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(934, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // recoverBtn
            // 
            this.recoverBtn.Enabled = false;
            this.recoverBtn.Image = global::AutoArchive.Properties.Resources.恢复;
            this.recoverBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(76, 22);
            this.recoverBtn.Text = "恢复所选";
            this.recoverBtn.ToolTipText = "使用选中的存档进行恢复";
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Image = global::AutoArchive.Properties.Resources.删除;
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(52, 22);
            this.deleteBtn.Text = "删除";
            this.deleteBtn.ToolTipText = "删除选中的存档";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openFileBtn
            // 
            this.openFileBtn.Enabled = false;
            this.openFileBtn.Image = global::AutoArchive.Properties.Resources.打开文件夹;
            this.openFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(100, 22);
            this.openFileBtn.Text = "打开所在位置";
            this.openFileBtn.ToolTipText = "打开存档所在位置";
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "备份工具";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenu});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(124, 22);
            this.exitMenu.Text = "退出程序";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label des;
        private System.Windows.Forms.Label src;
        private System.Windows.Forms.Label projectName;
        private System.Windows.Forms.Label desLab;
        private System.Windows.Forms.Label srcLab;
        private System.Windows.Forms.Label projectNameLab;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openProjectMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox periodTextBox;
        private System.Windows.Forms.RadioButton openTask;
        private System.Windows.Forms.RadioButton closeTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label countDownLb;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox remarkeTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton recoverBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openFileBtn;
        private System.Windows.Forms.Button backupBtn;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathCol;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem hideIntoTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
    }
}