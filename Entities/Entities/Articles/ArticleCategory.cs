using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Articles
{
    [Table("ArticleCategory", Schema = "Article")]
    public class ArticleCategory :  BaseClasses.BaseClass
    {


        [StringLength(250)]
        public string Title { get; set; }

        public int Order { get; set; }
        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public bool IsDelete { get; set; }


        [StringLength(100)]
        public string PageName { get; set; }

        #region seo
        [StringLength(100)]
        public string PageTitle { get; set; }


        [StringLength(100)]
        public string MetaKeyWord { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        [StringLength(50)]
        public string MetaImage { get; set; }

        #endregion

     
        //[ForeignKey("LanguageId")]
        //public virtual Language Language { get; set; }
        //public int LanguageId { get; set; }


    }
}
