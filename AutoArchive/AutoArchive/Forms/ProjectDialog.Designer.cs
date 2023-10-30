/*************************************************************************************
 *
 * 文 件 名:   ProjectDialog.cs
 * 描    述:   ProjectDialog
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/6/18 15:42:55
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/

namespace AutoArchive.Forms
{
    partial class ProjectDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectDialog));
            panel1 = new System.Windows.Forms.Panel();
            openProjectBtn = new System.Windows.Forms.Button();
            projectTable = new System.Windows.Forms.DataGridView();
            name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            newProject = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)projectTable).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Controls.Add(openProjectBtn);
            panel1.Controls.Add(projectTable);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(419, 233);
            panel1.TabIndex = 0;
            // 
            // openProjectBtn
            // 
            openProjectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            openProjectBtn.Enabled = false;
            openProjectBtn.Location = new System.Drawing.Point(341, 204);
            openProjectBtn.Name = "openProjectBtn";
            openProjectBtn.Size = new System.Drawing.Size(75, 23);
            openProjectBtn.TabIndex = 2;
            openProjectBtn.Text = "打开";
            openProjectBtn.UseVisualStyleBackColor = true;
            openProjectBtn.Click += openProjectBtn_Click;
            // 
            // projectTable
            // 
            projectTable.AllowUserToAddRows = false;
            projectTable.AllowUserToResizeColumns = false;
            projectTable.AllowUserToResizeRows = false;
            projectTable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectTable.BackgroundColor = System.Drawing.Color.Gainsboro;
            projectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            projectTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { name });
            projectTable.Location = new System.Drawing.Point(0, 25);
            projectTable.Name = "projectTable";
            projectTable.ReadOnly = true;
            projectTable.RowHeadersVisible = false;
            projectTable.RowTemplate.Height = 25;
            projectTable.Size = new System.Drawing.Size(419, 171);
            projectTable.TabIndex = 0;
            projectTable.CellClick += projectTable_CellClick;
            projectTable.CellDoubleClick += projectTable_CellDoubleClick;
            // 
            // name
            // 
            name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            name.DefaultCellStyle = dataGridViewCellStyle1;
            name.HeaderText = "游戏";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { newProject });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(419, 25);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // newProject
            // 
            newProject.Image = Properties.Resources.新建;
            newProject.Name = "newProject";
            newProject.Size = new System.Drawing.Size(60, 21);
            newProject.Text = "新建";
            newProject.Click += newProject_Click;
            // 
            // ProjectDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(419, 233);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProjectDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "游戏选择";
            Load += ProjectDialog_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)projectTable).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView projectTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newProject;
        private System.Windows.Forms.Button openProjectBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}