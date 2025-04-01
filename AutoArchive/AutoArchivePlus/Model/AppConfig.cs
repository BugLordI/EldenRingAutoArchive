/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
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
        private int quickBackupKeyCode;
        private String quickBackupKeyString;
        private int quickBackupModifierKeyCode;

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

        public int QuickBackupKeyCode
        {
            get => quickBackupKeyCode;
            set
            {
                quickBackupKeyCode = value;
                OnPropertyChanged();
            }
        }

        public String QuickBackupKeyString
        {
            get => quickBackupKeyString;
            set
            {
                quickBackupKeyString = value;
                OnPropertyChanged();
            }
        }

        public int QuickBackupModifierKeyCode
        {
            get => quickBackupModifierKeyCode;
            set
            {
                quickBackupModifierKeyCode = value;
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
                    && that.enableQuickBackup == this.enableQuickBackup
                    && that.quickBackupKeyCode==this.quickBackupKeyCode
                    && that.quickBackupKeyString==this.quickBackupKeyString)
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
