using AutoArchive.DataBase;
using System;

namespace AutoArchivePlus.Model
{
    [Serializable]
    public class AppConfig: BaseEntity
    {
        private bool autoCheckStartProgram;
        private bool alwaysAskWhenExits;
        private bool showEffectShadow;
        private bool enableQuickBackup;

        public bool AutoCheckStartProgram
        {
            get => autoCheckStartProgram;
            set
            {
                autoCheckStartProgram = value;
                OnPropertyChanged();
            }
        }

        public bool AlwaysAskWhenExits
        {
            get => alwaysAskWhenExits;
            set
            {
                alwaysAskWhenExits = value;
                OnPropertyChanged();
            }
        }

        public bool ShowEffectShadow
        {
            get => showEffectShadow;
            set
            {
                showEffectShadow = value;
                OnPropertyChanged();
            }
        }

        public bool EnableQuickBackup
        {
            get => enableQuickBackup;
            set
            {
                enableQuickBackup = value;
                OnPropertyChanged();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is AppConfig that)
            {
                if (that.autoCheckStartProgram == this.autoCheckStartProgram
                    && that.alwaysAskWhenExits == this.alwaysAskWhenExits
                    && that.showEffectShadow == this.showEffectShadow
                    && that.enableQuickBackup == this.enableQuickBackup)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return autoCheckStartProgram.GetHashCode()| alwaysAskWhenExits.GetHashCode() | showEffectShadow.GetHashCode();
        }
    }
}
