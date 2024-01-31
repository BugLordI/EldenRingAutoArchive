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

        public override bool Equals(object obj)
        {
            if (obj != null && obj is AppConfig that)
            {
                if (that.AutoCheckStartProgram == this.AutoCheckStartProgram
                    && that.AlwaysAskWhenExits == this.AlwaysAskWhenExits
                    && that.showEffectShadow == this.ShowEffectShadow)
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
