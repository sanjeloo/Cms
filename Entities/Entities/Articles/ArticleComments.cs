using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.Articles
{
    [Table("ArticleComments", Schema = "Article")]

    public class ArticleComments:BaseClasses.BaseClass
    {
  
        public string UserName { get; set; }
        public string Comment { get; set; }
        public string ReComment { get; set; }
        public bool Seen { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        public int? ArticleId { get; set; }
        public string Ip { get; set; }
        public string Mobile { get; set; }
        //[ForeignKey("LanguageId")]
        //public virtual Language Language { get; set; }
        //public int LanguageId { get; set; }
    }

}
