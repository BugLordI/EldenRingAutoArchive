/*************************************************************************************
 *
 * 文 件 名:   BaseEntity.cs
 * 描    述:   数据库表实体类的基类
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/6/19 14:32:21
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoArchive.Entity
{
    /// <summary>
    /// 数据库表实体类的基类，提供一些通用的属性和操作，自定义实体类应当继承此类
    /// </summary>
    [Serializable]
    public class BaseEntity
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
    }
}
