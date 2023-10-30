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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProjectDialog));
            panel1 = new System.Windows.Forms.Panel();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            saveBtn = new System.Windows.Forms.Button();
            selectDesFolder = new System.Windows.Forms.Button();
            desPath = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            selectSrcFolder = new System.Windows.Forms.Button();
            srcPath = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            projectName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            toolTip = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(selectDesFolder);
            panel1.Controls.Add(desPath);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(selectSrcFolder);
            panel1.Controls.Add(srcPath);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(projectName);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(437, 175);
            panel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = System.Drawing.Color.FromArgb(64, 158, 255);
            linkLabel1.Location = new System.Drawing.Point(10, 148);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(116, 17);
            linkLabel1.TabIndex = 20;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "无法知道原始路径？";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // saveBtn
            // 
            saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            saveBtn.Enabled = false;
            saveBtn.Location = new System.Drawing.Point(343, 142);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size(83, 23);
            saveBtn.TabIndex = 19;
            saveBtn.Text = "保存";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // selectDesFolder
            // 
            selectDesFolder.Location = new System.Drawing.Point(343, 96);
            selectDesFolder.Name = "selectDesFolder";
            selectDesFolder.Size = new System.Drawing.Size(83, 23);
            selectDesFolder.TabIndex = 17;
            selectDesFolder.Text = "选择文件夹";
            selectDesFolder.UseVisualStyleBackColor = true;
            selectDesFolder.Click += selectDesFolder_Click;
            // 
            // desPath
            // 
            desPath.Location = new System.Drawing.Point(81, 96);
            desPath.Name = "desPath";
            desPath.ReadOnly = true;
            desPath.Size = new System.Drawing.Size(256, 23);
            desPath.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 102);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 17);
            label3.TabIndex = 15;
            label3.Text = "备份路径：";
            // 
            // selectSrcFolder
            // 
            selectSrcFolder.Location = new System.Drawing.Point(343, 52);
            selectSrcFolder.Name = "selectSrcFolder";
            selectSrcFolder.Size = new System.Drawing.Size(83, 23);
            selectSrcFolder.TabIndex = 14;
            selectSrcFolder.Text = "选择文件夹";
            selectSrcFolder.UseVisualStyleBackColor = true;
            selectSrcFolder.Click += selectSrcFolder_Click;
            // 
            // srcPath
            // 
            srcPath.Location = new System.Drawing.Point(81, 52);
            srcPath.Name = "srcPath";
            srcPath.ReadOnly = true;
            srcPath.Size = new System.Drawing.Size(256, 23);
            srcPath.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 17);
            label2.TabIndex = 12;
            label2.Text = "原始路径：";
            // 
            // projectName
            // 
            projectName.Location = new System.Drawing.Point(81, 9);
            projectName.Name = "projectName";
            projectName.Size = new System.Drawing.Size(256, 23);
            projectName.TabIndex = 11;
            projectName.TextChanged += projectName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 17);
            label1.TabIndex = 10;
            label1.Text = "游戏名：";
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 50000;
            toolTip.InitialDelay = 50;
            toolTip.ReshowDelay = 10;
            // 
            // CreateProjectDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(437, 175);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateProjectDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "新建游戏";
            Load += CreateProjectDialog_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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