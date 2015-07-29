using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MangoEasy.Library.Models.Interfaces;

namespace MangoEasy.Library.Models
{
    public class Article : IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual Account Author { get; set; }
        public virtual ArticleType ArticleType { get; set; }
        /// <summary>
        /// 浏览记录
        /// </summary>
        public virtual ICollection<ViewHistory> ViewHistories { get; set; }
        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool Valid { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ArticleType 
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Article> Articles { get; set; } 
    }
    public class ViewHistory: IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 是否好评
        /// </summary>
        public bool Praise { get; set; }
        public virtual Account User { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
