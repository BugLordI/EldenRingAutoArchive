using AutoArchive.DataBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoArchivePlus.Model
{
    [Table("Config")]
    public class Config : BaseEntity
    {
        private string content;
        private int type;

        public string Content { get => content; set => content = value; }
        public int Type { get => type; set => type = value; }
    }
}
