/*************************************************************************************
 *
 * 文 件 名:   Task.cs
 * 描    述:   Task.cs
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/6/18 15:04:54
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoArchive.Entity
{
    public class Task: BaseEntity
    {
        private int taskPeriod;
        private String sourceId;
        private Boolean isOn;

        public int TaskPeriod { get => taskPeriod; set => taskPeriod = value; }
        public string SourceId { get => sourceId; set => sourceId = value; }
        public bool IsOn { get => isOn; set => isOn = value; }
    }
}
