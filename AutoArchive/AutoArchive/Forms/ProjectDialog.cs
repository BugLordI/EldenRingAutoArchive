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
using AutoArchive.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace AutoArchive.Forms
{
    public partial class ProjectDialog : Form
    {
        private Action<Source> openProjectCallBack;
        private Func<Source,List<Source>> newProjectCallBack;
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
