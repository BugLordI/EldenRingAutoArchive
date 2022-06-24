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
            this.panel1 = new System.Windows.Forms.Panel();
            this.openProjectBtn = new System.Windows.Forms.Button();
            this.projectTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newProject = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.openProjectBtn);
            this.panel1.Controls.Add(this.projectTable);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 233);
            this.panel1.TabIndex = 0;
            // 
            // openProjectBtn
            // 
            this.openProjectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openProjectBtn.Enabled = false;
            this.openProjectBtn.Location = new System.Drawing.Point(341, 204);
            this.openProjectBtn.Name = "openProjectBtn";
            this.openProjectBtn.Size = new System.Drawing.Size(75, 23);
            this.openProjectBtn.TabIndex = 2;
            this.openProjectBtn.Text = "打开";
            this.openProjectBtn.UseVisualStyleBackColor = true;
            this.openProjectBtn.Click += new System.EventHandler(this.openProjectBtn_Click);
            // 
            // projectTable
            // 
            this.projectTable.AllowUserToAddRows = false;
            this.projectTable.AllowUserToResizeColumns = false;
            this.projectTable.AllowUserToResizeRows = false;
            this.projectTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectTable.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.projectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name});
            this.projectTable.Location = new System.Drawing.Point(0, 25);
            this.projectTable.Name = "projectTable";
            this.projectTable.ReadOnly = true;
            this.projectTable.RowHeadersVisible = false;
            this.projectTable.RowTemplate.Height = 25;
            this.projectTable.Size = new System.Drawing.Size(419, 171);
            this.projectTable.TabIndex = 0;
            this.projectTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectTable_CellClick);
            this.projectTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectTable_CellDoubleClick);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle1;
            this.name.HeaderText = "工程";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProject});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(419, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newProject
            // 
            this.newProject.Image = global::AutoArchive.Properties.Resources.新建;
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(60, 21);
            this.newProject.Text = "新建";
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // ProjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 233);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工程选择";
            this.Load += new System.EventHandler(this.ProjectDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView projectTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newProject;
        private System.Windows.Forms.Button openProjectBtn;
    }
}