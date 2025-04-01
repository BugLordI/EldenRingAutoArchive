using AppInstaller.Language;

namespace AppInstaller.Forms
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            mainPanel = new Panel();
            welcomeContentLabel = new Label();
            welcomeTitleLabel = new Label();
            logoPanel = new Panel();
            footPanel = new Panel();
            cancelBtn = new Button();
            nextBtn = new Button();
            mainPanel.SuspendLayout();
            footPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(welcomeContentLabel);
            mainPanel.Controls.Add(welcomeTitleLabel);
            mainPanel.Controls.Add(logoPanel);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(738, 435);
            mainPanel.TabIndex = 0;
            // 
            // welcomeContentLabel
            // 
            welcomeContentLabel.AutoEllipsis = true;
            welcomeContentLabel.Font = new Font("微软雅黑 Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            welcomeContentLabel.Location = new Point(248, 155);
            welcomeContentLabel.Name = "welcomeContentLabel";
            welcomeContentLabel.Size = new Size(462, 260);
            welcomeContentLabel.TabIndex = 2;
            // 
            // welcomeTitleLabel
            // 
            welcomeTitleLabel.AutoEllipsis = true;
            welcomeTitleLabel.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point, 134);
            welcomeTitleLabel.Location = new Point(248, 41);
            welcomeTitleLabel.Name = "welcomeTitleLabel";
            welcomeTitleLabel.Size = new Size(462, 104);
            welcomeTitleLabel.TabIndex = 1;
            // 
            // logoPanel
            // 
            logoPanel.BackgroundImage = (Image)resources.GetObject("logoPanel.BackgroundImage");
            logoPanel.Dock = DockStyle.Left;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(225, 435);
            logoPanel.TabIndex = 0;
            // 
            // footPanel
            // 
            footPanel.BorderStyle = BorderStyle.FixedSingle;
            footPanel.Controls.Add(cancelBtn);
            footPanel.Controls.Add(nextBtn);
            footPanel.Dock = DockStyle.Fill;
            footPanel.Location = new Point(0, 435);
            footPanel.Name = "footPanel";
            footPanel.Size = new Size(738, 76);
            footPanel.TabIndex = 1;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(598, 21);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(112, 36);
            cancelBtn.TabIndex = 1;
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(461, 21);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(112, 36);
            nextBtn.TabIndex = 0;
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 511);
            Controls.Add(footPanel);
            Controls.Add(mainPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Welcome";
            StartPosition = FormStartPosition.CenterScreen;
            mainPanel.ResumeLayout(false);
            footPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel footPanel;
        private Panel logoPanel;
        private Label welcomeTitleLabel;
        private Label welcomeContentLabel;
        private Button cancelBtn;
        private Button nextBtn;
    }
}