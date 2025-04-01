/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoArchive.DataBase
{
    /// <summary>
    /// 数据库表实体类的基类，提供一些通用的属性和操作，自定义实体类应当继承此类
    /// </summary>
    [Serializable]
    public class BaseEntity: INotifyPropertyChanged
    {
        /// <summary>
        /// id
        /// </summary>
        private String id;

        /// <summary>
        /// id
        /// </summary>
        [Key]
        public String Id { get => id; set => id = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
