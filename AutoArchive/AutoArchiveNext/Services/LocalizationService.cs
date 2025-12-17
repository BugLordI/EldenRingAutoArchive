using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace AutoArchiveNext.Services
{
    internal class LocalizationService : INotifyPropertyChanged
    {
        private static readonly Lazy<LocalizationService> _instance = new(() => new LocalizationService());
        public static LocalizationService Instance => _instance.Value;

        private readonly ResourceManager _resourceManager;

        private CultureInfo _currentCulture;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture != value)
                {
                    _currentCulture = value;
                    CultureInfo.CurrentCulture = value;
                    CultureInfo.CurrentUICulture = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Item"); // 通知索引器变化
                }
            }
        }

        public static Dictionary<String, CultureInfo> SupportedCultures { get; } =
        new()
        {
            { "English", new CultureInfo("en-US") },
            { "中文", new CultureInfo("zh-CN") },
        };


        private LocalizationService()
        {
            _resourceManager = new ResourceManager("AutoArchiveNext.Properties.Resources", typeof(App).Assembly);
            _currentCulture = CultureInfo.CurrentCulture;
            SetDefaultLanguage();
        }

        private void SetDefaultLanguage()
        {
            var systemCulture = CultureInfo.CurrentCulture;
            if (systemCulture.Name.StartsWith("zh"))
                CurrentCulture = new CultureInfo("zh-CN");
            else
                CurrentCulture = new CultureInfo("en-US");
        }


        public string GetString(string key)
        {
            try
            {
                return _resourceManager.GetString(key, _currentCulture) ?? $"[{key}]";
            }
            catch
            {
                return $"[{key}]";
            }
        }

        public void ChangeLanguage(string cultureName)
        {
            var culture = new CultureInfo(cultureName);
            CurrentCulture = culture;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
