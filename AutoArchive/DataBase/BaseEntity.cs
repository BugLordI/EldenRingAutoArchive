/*************************************************************************************
 *
 * 文 件 名:   BaseEntity.cs
 * 描    述:   数据库表实体类的基类
 * 
 * 创 建 者：  BugLord 
 * 创建时间：  2022/6/19 14:32:21
*************************************************************************************/
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
