using AppInstaller.Language;

namespace AppInstaller.Forms
{
    partial class License
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            mainPanel = new Panel();
            licenseAgreementTipLabel = new Label();
            licenseAgreementLabel = new Label();
            licenseTipLabel = new Label();
            richTextBox1 = new RichTextBox();
            preBtn = new Button();
            cancelBtn = new Button();
            nextBtn = new Button();
            agreeRadioBtn = new RadioButton();
            disagreeRadioBtn = new RadioButton();
            panel1 = new Panel();
            mainPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(licenseAgreementTipLabel);
            mainPanel.Controls.Add(licenseAgreementLabel);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(738, 81);
            mainPanel.TabIndex = 20;
            // 
            // licenseAgreementTipLabel
            // 
            licenseAgreementTipLabel.AutoEllipsis = true;
            licenseAgreementTipLabel.Font = new Font("Microsoft YaHei UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            licenseAgreementTipLabel.Location = new Point(30, 37);
            licenseAgreementTipLabel.Name = "licenseAgreementTipLabel";
            licenseAgreementTipLabel.Size = new Size(200, 43);
            licenseAgreementTipLabel.TabIndex = 8;
            licenseAgreementTipLabel.Text = "License_Agreement";
            // 
            // licenseAgreementLabel
            // 
            licenseAgreementLabel.AutoEllipsis = true;
            licenseAgreementLabel.Font = new Font("Microsoft YaHei UI", 10F);
            licenseAgreementLabel.Location = new Point(12, 9);
            licenseAgreementLabel.Name = "licenseAgreementLabel";
            licenseAgreementLabel.Size = new Size(200, 43);
            licenseAgreementLabel.TabIndex = 9;
            licenseAgreementLabel.Text = "License_Agreement";
            // 
            // licenseTipLabel
            // 
            licenseTipLabel.AutoEllipsis = true;
            licenseTipLabel.AutoSize = true;
            licenseTipLabel.Font = new Font("Microsoft YaHei UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            licenseTipLabel.Location = new Point(30, 95);
            licenseTipLabel.Name = "licenseTipLabel";
            licenseTipLabel.Size = new Size(169, 24);
            licenseTipLabel.TabIndex = 7;
            licenseTipLabel.Text = "License_Agreement";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(30, 126);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(660, 257);
            richTextBox1.TabIndex = 60;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // preBtn
            // 
            preBtn.Location = new Point(370, 18);
            preBtn.Name = "preBtn";
            preBtn.Size = new Size(112, 36);
            preBtn.TabIndex = 0;
            preBtn.UseVisualStyleBackColor = true;
            preBtn.Click += preBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(617, 18);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(112, 36);
            cancelBtn.TabIndex = 3;
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click_1;
            // 
            // nextBtn
            // 
            nextBtn.Enabled = false;
            nextBtn.Location = new Point(484, 18);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(112, 36);
            nextBtn.TabIndex = 2;
            nextBtn.UseVisualStyleBackColor = true;
            // 
            // agreeRadioBtn
            // 
            agreeRadioBtn.AutoSize = true;
            agreeRadioBtn.Location = new Point(509, 394);
            agreeRadioBtn.Name = "agreeRadioBtn";
            agreeRadioBtn.Size = new Size(87, 28);
            agreeRadioBtn.TabIndex = 4;
            agreeRadioBtn.Text = "Agree";
            agreeRadioBtn.UseVisualStyleBackColor = true;
            agreeRadioBtn.CheckedChanged += agreeRadioBtn_CheckedChanged;
            // 
            // disagreeRadioBtn
            // 
            disagreeRadioBtn.AutoSize = true;
            disagreeRadioBtn.Checked = true;
            disagreeRadioBtn.Location = new Point(596, 394);
            disagreeRadioBtn.Name = "disagreeRadioBtn";
            disagreeRadioBtn.Size = new Size(89, 28);
            disagreeRadioBtn.TabIndex = 5;
            disagreeRadioBtn.TabStop = true;
            disagreeRadioBtn.Text = "不同意";
            disagreeRadioBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(preBtn);
            panel1.Controls.Add(nextBtn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 436);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 75);
            panel1.TabIndex = 7;
            // 
            // License
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 511);
            Controls.Add(panel1);
            Controls.Add(disagreeRadioBtn);
            Controls.Add(agreeRadioBtn);
            Controls.Add(richTextBox1);
            Controls.Add(licenseTipLabel);
            Controls.Add(mainPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "License";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += License_FormClosing;
            mainPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel mainPanel;
        private Label licenseAgreementLabel;
        private Label licenseAgreementTipLabel;
        private Label licenseTipLabel;
        private RichTextBox richTextBox1;
        private RadioButton agreeRadioBtn;
        private RadioButton disagreeRadioBtn;
        private Button cancelBtn;
        private Button nextBtn;
        private Button preBtn;
        private Panel panel1;
    }
}