/*************************************************************************************
 *
 * 文 件 名:   MainForm.cs
 * 描    述:   主界面
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/6/19 14:25:52
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using AutoArchive.Entity;
using AutoArchive.Mapper.DB;
using AutoArchive.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoArchive.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 所有项目
        /// </summary>
        private List<Source> projects;

        /// <summary>
        /// 当前打开的项目
        /// </summary>
        private Source selectedProject;

        /// <summary>
        /// 数据库相关
        /// </summary>
        private BaseMapper<Source> mapper;

        /// <summary>
        /// 备份数据表选中的行
        /// </summary>
        private Target selectedRow;

        /// <summary>
        /// 任务倒计时(分钟)
        /// </summary>
        private int min;

        public MainForm()
        {
            InitializeComponent();
            findProject();
        }

        /// <summary>
        /// 窗口打开时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            ProjectDialog projectDialog = new ProjectDialog(projects, openProject, newProject);
            projectDialog.ShowDialog(this);
            init();
        }

        /// <summary>
        /// 窗口关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存任务信息
            if (selectedProject != null && periodTextBox.Text.Length > 0)
            {
                var exist = mapper.Entity.Find(this.selectedProject.Id).Task;
                if (exist != null)
                {
                    exist.IsOn = openTask.Checked;
                    exist.TaskPeriod = Convert.ToInt32(periodTextBox.Text);
                }
                else
                {
                    Task task = new Task();
                    task.Id = Guid.NewGuid().ToString("N");
                    task.SourceId = selectedProject.Id;
                    task.TaskPeriod = Convert.ToInt32(periodTextBox.Text);
                    task.IsOn = openTask.Checked;
                    mapper.Entity.Find(this.selectedProject.Id).Task = task;
                }
                mapper.SaveChanges();
            }
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        private void init()
        {
            if (selectedProject != null)
            {
                projectName.Text = selectedProject.Name;
                toolTip.SetToolTip(projectName, projectName.Text);
                src.Text = selectedProject.SrcPath;
                toolTip.SetToolTip(src, src.Text);
                des.Text = selectedProject.TarPath;
                toolTip.SetToolTip(des, des.Text);
            }
        }

        /// <summary>
        /// 查询所有工程
        /// </summary>
        private void findProject()
        {
            mapper = new BaseMapper<Source>();
            projects = mapper.Entity.Include(e => e.Targets).Include(e => e.Task).ToList();
        }

        /// <summary>
        /// 打开工程
        /// </summary>
        /// <param name="source"></param>
        private void openProject(Source source)
        {
            selectedProject = source;
            initTask(selectedProject);
            initTable(selectedProject);
        }

        /// <summary>
        /// 新建工程
        /// </summary>
        /// <param name="source"></param>
        private List<Source> newProject(Source source)
        {
            source.Id = Guid.NewGuid().ToString("N");
            mapper.add(source);
            return mapper.Entity.Include(e => e.Targets).Include(e => e.Task).ToList();
        }

        /// <summary>
        /// 初始化任务
        /// </summary>
        private void initTask(Source source)
        {
            this.periodTextBox.Text = source.Task.TaskPeriod.ToString();
        }

        private void initTable(Source source)
        {
            //初始化表格
            List<Target> targets = source.Targets;
            int count = targets.Count;
            dataTable.Rows.Clear();
            if (count > 0)
            {
                dataTable.Rows.Add(count);
                for (int i = 0; i < count; i++)
                {
                    DataGridViewRow row = dataTable.Rows[i];
                    row.Tag = targets[i];
                    row.Cells["remarkCol"].Value = targets[i].Remark;
                    row.Cells["dateCol"].Value = DateUtil.getDateTime(targets[i].DateTimeStamp);
                    row.Cells["pathCol"].Value = targets[i].Path;
                }
            }
            dataTable.ClearSelection();
        }

        /// <summary>
        /// 修改工程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBtnClicked(object sender, EventArgs e)
        {
            CreateProjectDialog createProject = new CreateProjectDialog(this.selectedProject);
            if (createProject.ShowDialog(this) == DialogResult.OK)
            {
                this.selectedProject = createProject.NewProject;
                init();
            }
        }

        /// <summary>
        /// 打开/切换工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openProjectMenu_Click(object sender, EventArgs e)
        {
            ProjectDialog projectDialog = new ProjectDialog(projects, openProject, newProject);
            projectDialog.ShowDialog(this);
            init();
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openTask_CheckedChanged(object sender, EventArgs e)
        {
            periodTextBox.Enabled = !openTask.Checked;
            if (openTask.Checked)
            {
                min = Convert.ToInt32(periodTextBox.Text);
                if (min == 0 || min > 720)
                {
                    openTask.Checked = false;
                    closeTask.Checked = true;
                    periodTextBox.Enabled = true;
                    MessageBox.Show("时间需要大于0分钟并且小于720分钟", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                countDownLb.Text = $"还剩{min}分钟";
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }


        /// <summary>
        /// 备份
        /// </summary>
        private void backup(String remark, Boolean isAuto = false)
        {
            String src = this.selectedProject.SrcPath;
            String des = this.selectedProject.TarPath;
            DateTime now = DateTime.Now;
            String destinationPath = Path.Combine(des, this.selectedProject.Name,
                                                 now.ToString("yyyyMMddHHmmss"));
            if (FileUtil.copyDirectory(src, destinationPath))
            {
                Target target = new Target();
                target.Id = Guid.NewGuid().ToString("N");
                target.SourceId = this.selectedProject.Id;
                target.Remark = remark;
                target.DateTimeStamp = DateUtil.toUnixTimestamp(now);
                target.Path = destinationPath;
                mapper.Entity.Find(this.selectedProject.Id).Targets.Add(target);
                mapper.SaveChanges();
                initTable(mapper.Entity.Include(e => e.Targets).Include(e => e.Task).ToList().Find(
                    e => e.Id.Equals(this.selectedProject.Id)
                    ));
                if (!isAuto)
                {
                    MessageBox.Show("备份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("备份失败\n1.请检查存档目录是否存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            countDownLb.Text = $"还剩{--min}分钟";
            if (min == 0)
            {
                backup("自动备份", true);
                min = Convert.ToInt32(periodTextBox.Text);
                countDownLb.Text = $"还剩{min}分钟";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remarkeTextBox_TextChanged(object sender, EventArgs e)
        {
            backupBtn.Enabled = remarkeTextBox.Text.Length > 0;
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupBtn_Click(object sender, EventArgs e)
        {
            String remark = remarkeTextBox.Text;
            backup(remark);
            remarkeTextBox.Clear();
        }

        /// <summary>
        /// 单元格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean enabled = false;
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedRow = (Target)dataTable.Rows[index].Tag;
                enabled = selectedRow != null;
            }
            recoverBtn.Enabled = enabled;
            deleteBtn.Enabled = enabled;
            openFileBtn.Enabled = enabled;
        }

        /// <summary>
        /// 清除表格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            recoverBtn.Enabled = false;
            deleteBtn.Enabled = false;
            openFileBtn.Enabled = false;
        }

        /// <summary>
        /// 输入限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 恢复所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                DateTime dateTime = DateUtil.getDateTime(selectedRow.DateTimeStamp);
                DialogResult result = MessageBox.Show($"是否确认使用所选存档:\n({selectedRow.Remark}-{dateTime})\n进行恢复？", "警告",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //判断是否取消事件
                if (result == DialogResult.Yes)
                {
                    //备份的路径
                    String src = selectedRow.Path;
                    //存档所在路径
                    String des = selectedProject.SrcPath;
                    //将备份数据还原到存档所在路径
                    if (FileUtil.copyDirectory(src, des))
                    {
                        MessageBox.Show("还原存档成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("还原存档失败!\n请检查存档是否存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                recoverBtn.Enabled = false;
                deleteBtn.Enabled = false;
                openFileBtn.Enabled = false;
            }
        }

        /// <summary>
        /// 删除所选的备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateUtil.getDateTime(selectedRow.DateTimeStamp);
            DialogResult result = MessageBox.Show($"是否删除所选存档:\n({selectedRow.Remark}-{dateTime})？", "警告",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DirectoryInfo di = new DirectoryInfo(selectedRow.Path);
                di.Delete(true);
                BaseMapper<Target> baseMapper = new BaseMapper<Target>();
                baseMapper.Entity.Remove(selectedRow);
                baseMapper.SaveChanges();
                mapper = new BaseMapper<Source>();
                initTable(mapper.Entity.Include(e => e.Targets).Include(e => e.Task).ToList().Find(
                    e => e.Id.Equals(this.selectedProject.Id)
                    ));
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// 打开所在位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(selectedRow.Path))
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "explorer";
                //打开资源管理器
                proc.StartInfo.Arguments = @"/select," + selectedRow.Path;
                proc.Start();
            }
        }

        /// <summary>
        /// 选中行改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTable_SelectionChanged(object sender, EventArgs e)
        {
            var selected = dataTable.SelectedRows;
            if (selected.Count == 1)
            {
                if (selected[0] != null)
                {
                    this.selectedRow = (Target)selected[0].Tag;
                }
            }
            else
            {
                dataTable.ClearSelection();
            }
        }

        /// <summary>
        /// 隐藏到托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hideIntoTray_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3, "提示", "我在这里，双击图标恢复", ToolTipIcon.Info);
        }

        /// <summary>
        /// 托盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
