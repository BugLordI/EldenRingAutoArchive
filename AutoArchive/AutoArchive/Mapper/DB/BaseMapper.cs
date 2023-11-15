/*************************************************************************************
 *
 * 文 件 名:   BaseMapper.cs
 * 描    述:   提供通用的数据操作方法
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/5/29 14:22:16
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoArchive.Entity;

namespace AutoArchive.Mapper.DB
{
    /// <summary>
    ///  实体类Mapper,通用CRUD等操作
    /// </summary>
    /// <typeparam name="T">任意数据库表对应的实体类</typeparam>
    public class BaseMapper<T> : BaseContext<T> where T : BaseEntity
    {
        /// <summary>
        /// 查询相关的数据库表，或者向相关数据库表添加数据
        /// </summary>
        public override DbSet<T> Entity { set; get; }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="entity">数据库表实体类</param>
        /// <returns>受影响的行数</returns>
        public int add(T entity)
        {
            int effectRows = 0;
            T one = Entity.Find(entity.Id);
            if (one == null)
            {
                Entity.Add(entity);
                effectRows = SaveChanges();
            }
            return effectRows;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="size"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<T> select(int size, int page)
        {
            int limit = (page - 1) * size;
            var result = Entity.Skip(limit).Take(size);
            return result.ToList();
        }
    }
}
