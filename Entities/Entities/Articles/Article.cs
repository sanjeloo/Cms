using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.Articles
{
    [Table("Article", Schema = "Article")]
    public class Article:BaseClasses.BaseClass
    {
       

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Abstract { get; set; }


        //[AllowHtml]
        public string Description { get; set; }


        [StringLength(50)]
        public string Photo { get; set; }

        [StringLength(50)]
        public string PhotoBanner { get; set; }


        [StringLength(100)]
        public string PageName { get; set; }

        #region Seo
        [StringLength(100)]
        public string PageTitle { get; set; }
      


        [StringLength(100)]
        public string MetaKeyWord { get; set; }


        [StringLength(50)]
        public string MetaImage { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }
        #endregion


        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }
        public int Score { get; set; }


        [ForeignKey("ArticleCategoryId")]
        public virtual ArticleCategory ArticleCategory { get; set; }

        public int? ArticleCategoryId { get; set; }

        public virtual ICollection<ArticleComments> ArticleCommentses { get; set; }
        public virtual ICollection<ArticleScore> ArticleScores { get; set; }

        //[ForeignKey("LanguageId")]
        //public virtual Language Language { get; set; }
        //public int LanguageId { get; set; }

        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
    }
}
