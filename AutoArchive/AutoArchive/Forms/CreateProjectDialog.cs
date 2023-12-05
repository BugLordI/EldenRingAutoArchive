/*************************************************************************************
 *
 * 文 件 名:   CreateProjectDialog.cs
 * 描    述:   CreateProjectDialog
 * 
 * 版    本：  V1.0
 * 创 建 者：  BugLord 
 * 创建时间：  2022/6/18 17:06:28
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using AutoArchive.Entity;
using AutoArchive.Tools;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoArchive.Forms
{
    public partial class CreateProjectDialog : Form
    {
        /// <summary>
        /// 新建的工程信息
        /// </summary>
        private Source newProject;

        /// <summary>
        /// 新建或修改的工程信息
        /// </summary>
        public Source NewProject { get => newProject; }

        public CreateProjectDialog()
        {
            this.Text = "新建工程";
            InitializeComponent();
        }

        public CreateProjectDialog(Source source) : this()
        {
            this.Text = "修改工程";
            srcPath.Text = source.SrcPath;
            desPath.Text = source.TarPath;
            projectName.Text = source.Name;
            newProject = source;
        }

        private void CreateProjectDialog_Load(object sender, EventArgs e)
        {
            if (newProject == null)
            {
                String des = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AutoArchive");
                desPath.Text = des;
            }
            this.toolTip.SetToolTip(this.desPath, desPath.Text);
            this.toolTip.SetToolTip(this.srcPath, srcPath.Text);
        }

        /// <summary>
        /// 选择源目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectSrcFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择工程目录";
            String appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            folder.SelectedPath = appData;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                srcPath.Text = folder.SelectedPath;
                this.toolTip.SetToolTip(this.srcPath, folder.SelectedPath);
            }
            checkEnable();
        }

        /// <summary>
        /// 选择备份目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectDesFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择工程目录";
            folder.SelectedPath = desPath.Text;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                desPath.Text = folder.SelectedPath;
                this.toolTip.SetToolTip(this.desPath, folder.SelectedPath);
            }
            checkEnable();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // bug fix
            newProject ??= new Source();
            newProject.Name = projectName.Text;
            newProject.SrcPath = srcPath.Text;
            newProject.TarPath = desPath.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 保存按钮是否可用
        /// </summary>
        private void checkEnable()
        {
            if (!String.IsNullOrEmpty(projectName.Text) && !String.IsNullOrEmpty(srcPath.Text) && !String.IsNullOrEmpty(desPath.Text))
            {
                this.saveBtn.Enabled = true;
            }
            else
            {
                this.saveBtn.Enabled = false;
            }
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String path = Path.Combine(Application.StartupPath, "appsettings.json");
            AppSetting appSetting = new AppSetting(path);
            String url = appSetting["Help:Url"];
            System.Diagnostics.Process.Start("explorer.exe", url);
        }

        private void projectName_TextChanged(object sender, EventArgs e)
        {
            checkEnable();
        }
    }
}
