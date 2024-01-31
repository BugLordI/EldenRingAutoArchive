using AutoArchive.DataBase;
using AutoArchivePlus.Command;
using AutoArchivePlus.Common;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using AutoArchivePlus.WindowTools;
using SteamTool;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoArchivePlus.ViewModel
{
    internal class ProjectFormViewModel : BaseViewModel
    {
        private String gameName;

        private String gameInstallPath;

        private String gameArchivePath;

        private String gameBackupPath;

        private ObservableCollection<String> dataList;

        private SteamAppInfo selected;

        public ProjectFormViewModel()
        {
            DataList = new ObservableCollection<String>(App.InstalledApps.Select(e=>e.Name));
        }

        #region Commands

        public ICommand SaveProject => new ControlCommand(_ =>
        {
            if (dataCheck())
            {
                using BaseContext<Project> baseContext = new DBContext<Project>();
                Project project = new Project()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = gameName,
                    InstallPath = gameInstallPath,
                    ArchivePath = gameArchivePath,
                    BackupPath = gameBackupPath,
                    ImageLocation = extraIcon(gameInstallPath, gameName)
                };
                baseContext.Entity.Add(project);
                baseContext.SaveChanges();
                App.GlobalMessage(LanguageManager.Instance["DataSavedSuccess"]);
                ((ProjectForm)_).dataHasChanged = true;
                ((ProjectForm)_).Close();
            }
        });

        public ICommand ProjectSeletionChanged => new ControlCommand(selectedItem =>
        {
            if (selectedItem is String item)
            {
                selected = App.InstalledApps.Where(e => e.Name.Contains(item)).FirstOrDefault();
                if (File.Exists(selected.ExecutablePath))
                {
                    GameInstallPath = new FileInfo(selected.ExecutablePath).FullName;
                }
                if (Directory.Exists(selected.ArchivePath))
                {
                    GameArchivePath = new DirectoryInfo(selected.ArchivePath).FullName;
                }
            }
            else
            {
                GameInstallPath = null;
                GameArchivePath = null;
            }
        });


        public ICommand ChooseGamePath => new ControlCommand(obj =>
        {
            Window window = obj as Window;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = $"{LanguageManager.Instance["RunnableProgram"]}|*.exe";
            if (selected != null)
            {
                openFileDialog.InitialDirectory = new DirectoryInfo(selected.Installdir).FullName;
                openFileDialog.FileName = new FileInfo(selected.ExecutablePath).Name;
            }
            var result = openFileDialog.ShowDialog(window.GetIWin32Window());
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                GameInstallPath = openFileDialog.FileName;
            }
        });

        public ICommand ChooseArchivePath => new ControlCommand(obj =>
        {
            Window window = obj as Window;
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowser.SelectedPath = new DirectoryInfo(selected.ArchivePath).FullName;
            var result = folderBrowser.ShowDialog(window.GetIWin32Window());
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                GameArchivePath = folderBrowser.SelectedPath;
            }
        });

        public ICommand ChooseBackupPath => new ControlCommand(obj =>
        {
            Window window = obj as Window;
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderBrowser.ShowDialog(window.GetIWin32Window());
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                GameBackupPath = folderBrowser.SelectedPath;
            }
        });


        #endregion


        private String extraIcon(String installPath, String name)
        {
            if (installPath == null)
                return null;
            Icon icon = IconUtilities.ExtractIcon(installPath, IconSize.Jumbo);
            String iconLocation = App.ICON_PATH + $"\\{name}.ico";
            using (FileStream fs = new FileStream(iconLocation, FileMode.Create))
                icon.Save(fs);
            return iconLocation;
        }

        private bool dataCheck()
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(gameName))
            {
                msg.Append(LanguageManager.Instance["ProjectNameCannotEmpty"]).Append("\n");
            }
            if (string.IsNullOrEmpty(gameInstallPath))
            {
                msg.Append(LanguageManager.Instance["ProjectInstallPathCannotEmpty"]).Append("\n");
            }
            if (string.IsNullOrEmpty(gameArchivePath))
            {
                msg.Append(LanguageManager.Instance["ChooseDataSourcePath"]).Append("\n");
            }
            if (String.IsNullOrEmpty(gameBackupPath))
            {
                msg.Append(LanguageManager.Instance["ChooseBackupSavePath"]).Append("\n");
            }
            if (msg.Length > 0)
            {
                App.GlobalMessage(msg.ToString(), MessageTypeEnum.ERROR);
            }
            return msg.Length == 0;
        }

        #region Propertites

        public String GameName
        {
            get
            {
                return gameName;
            }
            set
            {
                gameName = value;
                OnPropertyChanged();
            }
        }

        public string GameInstallPath
        {
            get => gameInstallPath;
            set
            {
                gameInstallPath = value; 
                OnPropertyChanged();
            }
        }

        public string GameArchivePath
        {
            get => gameArchivePath; 
            set
            {
                gameArchivePath = value; 
                OnPropertyChanged();
            }
        }

        public string GameBackupPath
        {
            get => gameBackupPath;
            set
            {
                gameBackupPath = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> DataList
        {
            get => dataList;
            set
            {
                dataList = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
