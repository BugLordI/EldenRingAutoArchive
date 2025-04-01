/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoArchive.Forms
{
    public partial class ProjectDialog : Form
    {
        private Action<Source> openProjectCallBack;
        private Func<Source, List<Source>> newProjectCallBack;
        private Source selected;

        /// <summary>
        /// 选择工程
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="openProjectCallBack">打开工程回调</param>
        /// <param name="newProjectCallBack">新建工程回调</param>
        public ProjectDialog(List<Source> sources, Action<Source> openProjectCallBack, Func<Source, List<Source>> newProjectCallBack)
        {
            this.openProjectCallBack = openProjectCallBack;
            this.newProjectCallBack = newProjectCallBack;
            InitializeComponent();
            initData(sources);
        }

        private void ProjectDialog_Load(object sender, EventArgs e)
        {
            this.projectTable.ClearSelection();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sources"></param>
        private void initData(List<Source> sources)
        {
            this.projectTable.Rows.Clear();
            for (int i = 0; i < sources.Count; i++)
            {
                int rowIndex = projectTable.Rows.Add();
                DataGridViewRow row = projectTable.Rows[rowIndex];
                row.Cells["name"].Value = sources[i].Name;
                row.Cells["name"].Tag = sources[i];
                row.Selected = false;
            }
        }

        /// <summary>
        /// 双击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (openProjectCallBack != null && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                Source source = (Source)projectTable.Rows[rowIndex].Cells["name"].Tag;
                openProjectCallBack.Invoke(source);
                this.Close();
            }
        }

        /// <summary>
        /// 选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                selected = (Source)projectTable.Rows[rowIndex].Cells["name"].Tag;
            }
            else
            {
                selected = null;
                this.projectTable.ClearSelection();
            }
            this.openProjectBtn.Enabled = selected != null;
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openProjectBtn_Click(object sender, EventArgs e)
        {
            if (openProjectCallBack != null && selected != null)
            {
                openProjectCallBack.Invoke(selected);
            }
            this.Close();
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newProject_Click(object sender, EventArgs e)
        {
            CreateProjectDialog createProject = new CreateProjectDialog();
            if (createProject.ShowDialog(this) == DialogResult.OK)
            {
                Source newProject = createProject.NewProject;
                initData(newProjectCallBack?.Invoke(newProject));
            }
        }
    }
}
