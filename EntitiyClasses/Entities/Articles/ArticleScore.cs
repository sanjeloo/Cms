using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityClasses.Entities.Articles
{
    [Table("ArticleScore", Schema = "Article")]

    public class ArticleScore:BaseClasses.BaseClass
    {
      
        public int Score { get; set; }


        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        public int? ArticleId { get; set; }
        public string Ip { get; set; }

    }
}
