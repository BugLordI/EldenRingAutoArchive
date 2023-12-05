/*************************************************************************************
 *
 * 文 件 名:   MainForm.cs
 * 描    述:   主界面
 * 
 * 版    本：  V1.0
 * 创 建 者：  BugLord 
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new System.Windows.Forms.Panel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            backupBtn = new System.Windows.Forms.Button();
            remarkeTextBox = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            countDownLb = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            closeTask = new System.Windows.Forms.RadioButton();
            openTask = new System.Windows.Forms.RadioButton();
            periodTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            updateBtn = new System.Windows.Forms.Button();
            des = new System.Windows.Forms.Label();
            src = new System.Windows.Forms.Label();
            projectName = new System.Windows.Forms.Label();
            desLab = new System.Windows.Forms.Label();
            srcLab = new System.Windows.Forms.Label();
            projectNameLab = new System.Windows.Forms.Label();
            toolTip = new System.Windows.Forms.ToolTip(components);
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            openProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            hideIntoTray = new System.Windows.Forms.ToolStripMenuItem();
            timer = new System.Windows.Forms.Timer(components);
            panel2 = new System.Windows.Forms.Panel();
            groupBox4 = new System.Windows.Forms.GroupBox();
            dataTable = new System.Windows.Forms.DataGridView();
            remarkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            recoverMenu = new System.Windows.Forms.ToolStripMenuItem();
            deleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            openMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            recoverBtn = new System.Windows.Forms.ToolStripButton();
            deleteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            openFileBtn = new System.Windows.Forms.ToolStripButton();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            taskBarContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataTable).BeginInit();
            tableContextMenuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            taskBarContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new System.Drawing.Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(946, 149);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(backupBtn);
            groupBox3.Controls.Add(remarkeTextBox);
            groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox3.Location = new System.Drawing.Point(464, 84);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(478, 62);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "操作";
            // 
            // backupBtn
            // 
            backupBtn.BackColor = System.Drawing.SystemColors.Control;
            backupBtn.Enabled = false;
            backupBtn.Location = new System.Drawing.Point(275, 25);
            backupBtn.Name = "backupBtn";
            backupBtn.Size = new System.Drawing.Size(62, 29);
            backupBtn.TabIndex = 13;
            backupBtn.Text = "备份";
            backupBtn.UseVisualStyleBackColor = false;
            backupBtn.Click += backupBtn_Click;
            // 
            // remarkeTextBox
            // 
            remarkeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            remarkeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            remarkeTextBox.Enabled = false;
            remarkeTextBox.Location = new System.Drawing.Point(14, 28);
            remarkeTextBox.Name = "remarkeTextBox";
            remarkeTextBox.PlaceholderText = "输入备注后点击\"备份\"按钮进行备份";
            remarkeTextBox.Size = new System.Drawing.Size(239, 24);
            remarkeTextBox.TabIndex = 22;
            remarkeTextBox.TextChanged += remarkeTextBox_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(countDownLb);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(closeTask);
            groupBox2.Controls.Add(openTask);
            groupBox2.Controls.Add(periodTextBox);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(464, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(478, 77);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "任务";
            // 
            // countDownLb
            // 
            countDownLb.AutoSize = true;
            countDownLb.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            countDownLb.ForeColor = System.Drawing.Color.Red;
            countDownLb.Location = new System.Drawing.Point(116, 52);
            countDownLb.Name = "countDownLb";
            countDownLb.Size = new System.Drawing.Size(0, 17);
            countDownLb.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(10, 52);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 17);
            label2.TabIndex = 17;
            label2.Text = "距离下一次备份：";
            // 
            // closeTask
            // 
            closeTask.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            closeTask.AutoSize = true;
            closeTask.Checked = true;
            closeTask.Cursor = System.Windows.Forms.Cursors.Hand;
            closeTask.Location = new System.Drawing.Point(412, 47);
            closeTask.Name = "closeTask";
            closeTask.Size = new System.Drawing.Size(55, 24);
            closeTask.TabIndex = 16;
            closeTask.TabStop = true;
            closeTask.Text = "关闭";
            closeTask.UseVisualStyleBackColor = true;
            // 
            // openTask
            // 
            openTask.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            openTask.AutoSize = true;
            openTask.Cursor = System.Windows.Forms.Cursors.Hand;
            openTask.Enabled = false;
            openTask.Location = new System.Drawing.Point(354, 47);
            openTask.Name = "openTask";
            openTask.Size = new System.Drawing.Size(55, 24);
            openTask.TabIndex = 15;
            openTask.TabStop = true;
            openTask.Text = "开启";
            openTask.UseVisualStyleBackColor = true;
            openTask.CheckedChanged += openTask_CheckedChanged;
            // 
            // periodTextBox
            // 
            periodTextBox.Enabled = false;
            periodTextBox.Location = new System.Drawing.Point(119, 19);
            periodTextBox.Name = "periodTextBox";
            periodTextBox.Size = new System.Drawing.Size(62, 24);
            periodTextBox.TabIndex = 14;
            periodTextBox.Text = "10";
            periodTextBox.KeyPress += periodTextBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(10, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 17);
            label1.TabIndex = 13;
            label1.Text = "定时备份(分钟)：";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox1.BackColor = System.Drawing.Color.White;
            groupBox1.Controls.Add(updateBtn);
            groupBox1.Controls.Add(des);
            groupBox1.Controls.Add(src);
            groupBox1.Controls.Add(projectName);
            groupBox1.Controls.Add(desLab);
            groupBox1.Controls.Add(srcLab);
            groupBox1.Controls.Add(projectNameLab);
            groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(456, 144);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "信息";
            // 
            // updateBtn
            // 
            updateBtn.BackColor = System.Drawing.SystemColors.Control;
            updateBtn.Enabled = false;
            updateBtn.Location = new System.Drawing.Point(386, 107);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new System.Drawing.Size(62, 29);
            updateBtn.TabIndex = 12;
            updateBtn.Text = "修改";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtnClicked;
            // 
            // des
            // 
            des.AutoEllipsis = true;
            des.AutoSize = true;
            des.BackColor = System.Drawing.Color.White;
            des.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            des.ForeColor = System.Drawing.Color.Black;
            des.Location = new System.Drawing.Point(98, 83);
            des.Name = "des";
            des.Size = new System.Drawing.Size(0, 17);
            des.TabIndex = 11;
            // 
            // src
            // 
            src.AutoEllipsis = true;
            src.AutoSize = true;
            src.BackColor = System.Drawing.Color.White;
            src.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            src.ForeColor = System.Drawing.Color.Black;
            src.Location = new System.Drawing.Point(98, 55);
            src.Name = "src";
            src.Size = new System.Drawing.Size(0, 17);
            src.TabIndex = 10;
            // 
            // projectName
            // 
            projectName.AutoEllipsis = true;
            projectName.AutoSize = true;
            projectName.BackColor = System.Drawing.Color.White;
            projectName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            projectName.ForeColor = System.Drawing.Color.Black;
            projectName.Location = new System.Drawing.Point(98, 27);
            projectName.Name = "projectName";
            projectName.Size = new System.Drawing.Size(0, 17);
            projectName.TabIndex = 9;
            // 
            // desLab
            // 
            desLab.AutoSize = true;
            desLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            desLab.ForeColor = System.Drawing.Color.Black;
            desLab.Location = new System.Drawing.Point(10, 82);
            desLab.Name = "desLab";
            desLab.Size = new System.Drawing.Size(68, 17);
            desLab.TabIndex = 8;
            desLab.Text = "备份路径：";
            // 
            // srcLab
            // 
            srcLab.AutoSize = true;
            srcLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            srcLab.ForeColor = System.Drawing.Color.Black;
            srcLab.Location = new System.Drawing.Point(10, 54);
            srcLab.Name = "srcLab";
            srcLab.Size = new System.Drawing.Size(68, 17);
            srcLab.TabIndex = 7;
            srcLab.Text = "存档路径：";
            // 
            // projectNameLab
            // 
            projectNameLab.AutoSize = true;
            projectNameLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            projectNameLab.ForeColor = System.Drawing.Color.Black;
            projectNameLab.Location = new System.Drawing.Point(10, 26);
            projectNameLab.Name = "projectNameLab";
            projectNameLab.Size = new System.Drawing.Size(44, 17);
            projectNameLab.TabIndex = 6;
            projectNameLab.Text = "游戏：";
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 50000;
            toolTip.InitialDelay = 50;
            toolTip.ReshowDelay = 10;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openProjectMenu, hideIntoTray });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(946, 25);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // openProjectMenu
            // 
            openProjectMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            openProjectMenu.Name = "openProjectMenu";
            openProjectMenu.Size = new System.Drawing.Size(44, 21);
            openProjectMenu.Text = "打开";
            openProjectMenu.Click += openProjectMenu_Click;
            // 
            // hideIntoTray
            // 
            hideIntoTray.Name = "hideIntoTray";
            hideIntoTray.Size = new System.Drawing.Size(80, 21);
            hideIntoTray.Text = "隐藏到托盘";
            hideIntoTray.Click += hideIntoTray_Click;
            // 
            // timer
            // 
            timer.Interval = 60000;
            timer.Tick += timer_Tick;
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel2.Controls.Add(groupBox4);
            panel2.Location = new System.Drawing.Point(0, 173);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(946, 361);
            panel2.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(dataTable);
            groupBox4.Controls.Add(toolStrip1);
            groupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox4.Location = new System.Drawing.Point(2, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(940, 361);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "备份数据";
            // 
            // dataTable
            // 
            dataTable.AllowUserToAddRows = false;
            dataTable.BackgroundColor = System.Drawing.Color.White;
            dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { remarkCol, dateCol, pathCol });
            dataTable.ContextMenuStrip = tableContextMenuStrip;
            dataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            dataTable.Location = new System.Drawing.Point(3, 45);
            dataTable.MultiSelect = false;
            dataTable.Name = "dataTable";
            dataTable.ReadOnly = true;
            dataTable.RowHeadersVisible = false;
            dataTable.RowTemplate.Height = 25;
            dataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataTable.Size = new System.Drawing.Size(934, 313);
            dataTable.TabIndex = 1;
            dataTable.CellClick += dataTable_CellClick;
            dataTable.RowsRemoved += dataTable_RowsRemoved;
            dataTable.SelectionChanged += dataTable_SelectionChanged;
            // 
            // remarkCol
            // 
            remarkCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            remarkCol.HeaderText = "备注";
            remarkCol.Name = "remarkCol";
            remarkCol.ReadOnly = true;
            // 
            // dateCol
            // 
            dateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dateCol.HeaderText = "日期";
            dateCol.Name = "dateCol";
            dateCol.ReadOnly = true;
            // 
            // pathCol
            // 
            pathCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            pathCol.HeaderText = "所在路径";
            pathCol.Name = "pathCol";
            pathCol.ReadOnly = true;
            // 
            // tableContextMenuStrip
            // 
            tableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { recoverMenu, deleteMenu, openMenu });
            tableContextMenuStrip.Name = "tableContextMenuStrip";
            tableContextMenuStrip.Size = new System.Drawing.Size(149, 70);
            tableContextMenuStrip.Opening += tableContextMenuStrip_Opening;
            // 
            // recoverMenu
            // 
            recoverMenu.Image = Properties.Resources.恢复;
            recoverMenu.Name = "recoverMenu";
            recoverMenu.Size = new System.Drawing.Size(148, 22);
            recoverMenu.Text = "恢复所选";
            recoverMenu.Click += recoverMenu_Click;
            // 
            // deleteMenu
            // 
            deleteMenu.Image = Properties.Resources.删除;
            deleteMenu.Name = "deleteMenu";
            deleteMenu.Size = new System.Drawing.Size(148, 22);
            deleteMenu.Text = "删除所选";
            deleteMenu.Click += deleteMenu_Click;
            // 
            // openMenu
            // 
            openMenu.Image = Properties.Resources.打开文件夹;
            openMenu.Name = "openMenu";
            openMenu.Size = new System.Drawing.Size(148, 22);
            openMenu.Text = "打开所在位置";
            openMenu.Click += openMenu_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { recoverBtn, deleteBtn, toolStripSeparator1, openFileBtn });
            toolStrip1.Location = new System.Drawing.Point(3, 20);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(934, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // recoverBtn
            // 
            recoverBtn.Enabled = false;
            recoverBtn.Image = Properties.Resources.恢复;
            recoverBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            recoverBtn.Name = "recoverBtn";
            recoverBtn.Size = new System.Drawing.Size(76, 22);
            recoverBtn.Text = "恢复所选";
            recoverBtn.ToolTipText = "使用选中的存档进行恢复";
            recoverBtn.Click += recoverBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Enabled = false;
            deleteBtn.Image = Properties.Resources.删除;
            deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new System.Drawing.Size(52, 22);
            deleteBtn.Text = "删除";
            deleteBtn.ToolTipText = "删除选中的存档";
            deleteBtn.Click += deleteBtn_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openFileBtn
            // 
            openFileBtn.Enabled = false;
            openFileBtn.Image = Properties.Resources.打开文件夹;
            openFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new System.Drawing.Size(100, 22);
            openFileBtn.Text = "打开所在位置";
            openFileBtn.ToolTipText = "打开存档所在位置";
            openFileBtn.Click += openFileBtn_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = taskBarContextMenuStrip;
            notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "备份工具";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // taskBarContextMenuStrip
            // 
            taskBarContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { exitMenu });
            taskBarContextMenuStrip.Name = "contextMenuStrip";
            taskBarContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.Size = new System.Drawing.Size(124, 22);
            exitMenu.Text = "退出程序";
            exitMenu.Click += exitMenu_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(946, 534);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "老贼盒子";
            FormClosing += MainForm_FormClosing;
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataTable).EndInit();
            tableContextMenuStrip.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            taskBarContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip taskBarContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ContextMenuStrip tableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem recoverMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
    }
}