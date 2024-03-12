using AutoArchive.DataBase;
using AutoArchive.Tools;
using AutoArchivePlus.Command;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using AutoArchivePlus.WindowTools;
using SteamTool;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    internal class ProjectFormViewModel : BaseViewModel
    {
        private String gameName;

        private String gameNameErrorTip;

        private String gameInstallPath;

        private String gameInstallPathErrorTip;

        private String gameArchivePath;

        private String gameArchivePathErrorTip;

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
            if (_ is ProjectForm projectForm)
            {
                if (dataCheck())
                {
                    if (projectForm.isEditModel)
                    {
                        String projectId = projectForm.Tag as String;
                        using BaseContext<Project> baseContext = new DBContext<Project>();
                        var project = baseContext.Entity.FirstOrDefault(e => e.Id.Equals(projectId));
                        project.Name = GameName;
                        project.InstallPath = GameInstallPath;
                        project.ArchivePath = GameArchivePath;
                        project.BackupPath = GameBackupPath;
                        project.ImageLocation = extraIcon(GameInstallPath, GameName);
                        baseContext.SaveChanges();
                    }
                    else
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
                    }
                    App.GlobalMessage(LanguageManager.Instance["DataSavedSuccess"]);
                    projectForm.dataHasChanged = true;
                    projectForm.Close();
                }
            }
        });

        public ICommand ProjectSeletionChanged => new ControlCommand(selectedItem =>
        {
            GameNameErrorTip = String.Empty;
            GameInstallPath = null;
            GameArchivePath = null;
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
        });

        public ICommand UpdateGameInfoLibary => new ControlCommand(_ =>
        {
            MessageBoxResult ret = MessageBox.Show(LanguageManager.Instance["UpdateGameInfoLiabaryTip"], LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.Yes)
            {
                NetWorkTool.CrawlInformation("https://raw.githubusercontent.com/BugLordI/EldenRingAutoArchive/master/AutoArchive/SteamTool/GamesSaveDirectory.json"
                    , content =>
                    {
                        Steam.SaveGameInfos(content);
                        var result = MessageBox.Show(LanguageManager.Instance["SettingRestartTip"],
               LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
                            Application.Current.Shutdown();
                        }
                    });
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
            if (selected != null && selected.ArchivePath != null)
            {
                folderBrowser.SelectedPath = new DirectoryInfo(selected.ArchivePath).FullName;
            }
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

        public ICommand TextChanged => new ControlCommand(obj =>
        {
            TextBox textBox = obj as TextBox;
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Name == "gameArchivePath")
                {
                    GameArchivePathErrorTip = String.Empty;
                }
                else if (textBox.Name == "gameInstallPath")
                {
                    GameInstallPathErrorTip = String.Empty;
                    if (!File.Exists(textBox.Text))
                    {
                        GameInstallPathErrorTip = LanguageManager.Instance["GameInstallPathNotExistTip"];
                    }
                }
            }
        });


        public ICommand GameArchivePathHelp => new ControlCommand(_ =>
        {
            AppSetting appSetting = new AppSetting("AppConfig.json");
            String url = appSetting["GameArchivePathHelpUrl"];
            if (url != null)
            {
                try
                {
                    Process.Start("explorer.exe", url);
                }
                catch { }
            }
        });

        public ICommand CloseWindow => new ControlCommand(_ =>
        {
            if (_ is ProjectForm projectForm)
            {
                projectForm.Close();
            }
        });

        #endregion

        private String extraIcon(String installPath, String name)
        {
            if (installPath == null)
                return null;
            Icon icon = IconUtilities.ExtractIcon(installPath, IconSize.Jumbo);
            String iconLocation = App.ICON_PATH + $"\\{name}.Png";
            if (File.Exists(iconLocation))
            {
                File.Delete(iconLocation);
            }
            Bitmap originalImage = icon.ToBitmap();
            Bitmap resizedImage = new Bitmap(100, 100);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //resizedImage.SetResolution(300, 300);
                graphics.DrawImage(originalImage, 0, 0, 100, 100);
            }
            resizedImage.Save(iconLocation, System.Drawing.Imaging.ImageFormat.Png);
            return iconLocation;
        }

        private bool dataCheck()
        {
            bool result = true;
            if (string.IsNullOrEmpty(gameName))
            {
                GameNameErrorTip = LanguageManager.Instance["ProjectNameCannotEmpty"];
                result = false;
            }
            if (string.IsNullOrEmpty(gameInstallPath))
            {
                GameInstallPathErrorTip = LanguageManager.Instance["ProjectInstallPathCannotEmpty"];
                result = false;
            }
            if (string.IsNullOrEmpty(gameArchivePath))
            {
                GameArchivePathErrorTip = LanguageManager.Instance["ChooseDataSourcePath"];
                result = false;
            }
            return result;
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

        public string GameArchivePathErrorTip
        {
            get => gameArchivePathErrorTip;
            set
            {
                gameArchivePathErrorTip = value;
                OnPropertyChanged();
            }
        }

        public string GameInstallPathErrorTip
        {
            get => gameInstallPathErrorTip;
            set
            {
                gameInstallPathErrorTip = value;
                OnPropertyChanged();
            }
        }

        public string GameNameErrorTip
        {
            get => gameNameErrorTip;
            set
            {
                gameNameErrorTip = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
