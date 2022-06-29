/*************************************************************************************
 *
 * 文 件 名:   CreateProjectDialog.cs
 * 描    述:   CreateProjectDialog
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/6/18 17:06:28
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/

namespace AutoArchive.Forms
{
    partial class CreateProjectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProjectDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.selectDesFolder = new System.Windows.Forms.Button();
            this.desPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectSrcFolder = new System.Windows.Forms.Button();
            this.srcPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.selectDesFolder);
            this.panel1.Controls.Add(this.desPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.selectSrcFolder);
            this.panel1.Controls.Add(this.srcPath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.projectName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 175);
            this.panel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(10, 148);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 17);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "无法知道原始路径？";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // saveBtn
            // 
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(343, 142);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(83, 23);
            this.saveBtn.TabIndex = 19;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // selectDesFolder
            // 
            this.selectDesFolder.Location = new System.Drawing.Point(343, 96);
            this.selectDesFolder.Name = "selectDesFolder";
            this.selectDesFolder.Size = new System.Drawing.Size(83, 23);
            this.selectDesFolder.TabIndex = 17;
            this.selectDesFolder.Text = "选择文件夹";
            this.selectDesFolder.UseVisualStyleBackColor = true;
            this.selectDesFolder.Click += new System.EventHandler(this.selectDesFolder_Click);
            // 
            // desPath
            // 
            this.desPath.Location = new System.Drawing.Point(81, 96);
            this.desPath.Name = "desPath";
            this.desPath.ReadOnly = true;
            this.desPath.Size = new System.Drawing.Size(256, 23);
            this.desPath.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "备份路径：";
            // 
            // selectSrcFolder
            // 
            this.selectSrcFolder.Location = new System.Drawing.Point(343, 52);
            this.selectSrcFolder.Name = "selectSrcFolder";
            this.selectSrcFolder.Size = new System.Drawing.Size(83, 23);
            this.selectSrcFolder.TabIndex = 14;
            this.selectSrcFolder.Text = "选择文件夹";
            this.selectSrcFolder.UseVisualStyleBackColor = true;
            this.selectSrcFolder.Click += new System.EventHandler(this.selectSrcFolder_Click);
            // 
            // srcPath
            // 
            this.srcPath.Location = new System.Drawing.Point(81, 52);
            this.srcPath.Name = "srcPath";
            this.srcPath.ReadOnly = true;
            this.srcPath.Size = new System.Drawing.Size(256, 23);
            this.srcPath.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "原始路径：";
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(81, 9);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(256, 23);
            this.projectName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "游戏名：";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 50000;
            this.toolTip.InitialDelay = 50;
            this.toolTip.ReshowDelay = 10;
            // 
            // CreateProjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 175);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProjectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建工程";
            this.Load += new System.EventHandler(this.CreateProjectDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button selectDesFolder;
        private System.Windows.Forms.TextBox desPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectSrcFolder;
        private System.Windows.Forms.TextBox srcPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}