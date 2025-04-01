/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppInstaller.Forms
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.Text = Language.LanguageManager.Instance["Title_Welcome"];
            welcomeTitleLabel.Text = Language.LanguageManager.Instance["Default_Welcome_Statement"];
            welcomeContentLabel.Text = Language.LanguageManager.Instance["Default_Welcome_Content_Statement"];
            nextBtn.Text = Language.LanguageManager.Instance["Btn_Next"];
            cancelBtn.Text = Language.LanguageManager.Instance["Btn_Cancel"];
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            License license = new License(this);
            license.ShowDialog(this);
        }
    }
}
