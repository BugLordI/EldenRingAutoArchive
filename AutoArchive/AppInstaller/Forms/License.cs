/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.Collections;
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
    public partial class License : Form
    {
        private Form parent;
        private bool isBack;

        public License(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            Init();
        }

        private void License_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isBack)
            {
                Environment.Exit(0);
            }
        }

        private void Init()
        {
            this.Text = Language.LanguageManager.Instance["Title_Setup"];
            licenseAgreementLabel.Text = Language.LanguageManager.Instance["Label_License_Agreement"];
            licenseAgreementTipLabel.Text = Language.LanguageManager.Instance["Label_License_Agreement_Tip"];
            licenseTipLabel.Text = Language.LanguageManager.Instance["License_Tip"];
            agreeRadioBtn.Text = Language.LanguageManager.Instance["RadioBtn_Agree"];
            disagreeRadioBtn.Text = Language.LanguageManager.Instance["RadioBtn_Disagree"];
            preBtn.Text = Language.LanguageManager.Instance["Btn_Pre"];
            nextBtn.Text = Language.LanguageManager.Instance["Btn_Next"];
            cancelBtn.Text = Language.LanguageManager.Instance["Btn_Cancel"];
        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agreeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            nextBtn.Enabled = radioButton.Checked;
        }

        private void preBtn_Click(object sender, EventArgs e)
        {
            isBack = true;
            parent?.Show();
            this.Close();
        }

    }
}
