using Entities.Entities.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities.NewsLetters
{
    public class NewsLetter : BaseClass
    {
     

        [StringLength(250)]
        public string Mobile { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
