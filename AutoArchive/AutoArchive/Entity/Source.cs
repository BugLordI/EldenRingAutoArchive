/*************************************************************************************
 *
 * 文 件 名:   Source.cs
 * 描    述:   Source.cs
 * 
 * 版    本：  V1.0
 * 创 建 者：  BugLord 
 * 创建时间：  2022/6/18 14:45:38
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using AutoArchive.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoArchive.Entity
{
    [Table("Resource")]
    public class Source : BaseEntity
    {
        private String name;
        private String srcPath;
        private String tarPath;
        private List<Target> targets;
        private Task task;

        public string Name { get => name; set => name = value; }
        public string SrcPath { get => srcPath; set => srcPath = value; }
        public string TarPath { get => tarPath; set => tarPath = value; }
        public List<Target> Targets { get => targets; set => targets = value; }
        public Task Task { get => task; set => task = value; }
    }
}
