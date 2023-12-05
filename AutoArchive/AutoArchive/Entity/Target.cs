/*************************************************************************************
 *
 * 文 件 名:   Target.cs
 * 描    述:   Target.cs
 * 
 * 版    本：  V1.0
 * 创 建 者：  BugLord 
 * 创建时间：  2022/6/18 14:48:28
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using AutoArchive.DataBase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoArchive.Entity
{
    [Table("Target")]
    public class Target: BaseEntity
    {
        private String path;
        private String remark;
        private long dateTimeStamp;
        private String sourceId;

        public string Path { get => path; set => path = value; }
        public string Remark { get => remark; set => remark = value; }
        public long DateTimeStamp { get => dateTimeStamp; set => dateTimeStamp = value; }
        public string SourceId { get => sourceId; set => sourceId = value; }
    }
}
