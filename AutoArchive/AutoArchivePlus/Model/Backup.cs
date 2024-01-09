using AutoArchive.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoArchivePlus.Model
{
    [Table("Backups")]
    public class Backup : BaseEntity
    {
        private String path;
        private String remark;
        private long dateTimeStamp;
        private String projectId;

        public String Path { get => path; set => path = value; }
        public String Remark { get => remark; set => remark = value; }
        public long DateTimeStamp { get => dateTimeStamp; set => dateTimeStamp = value; }
        public String ProjectId { get => projectId; set => projectId = value; }
    }
}
