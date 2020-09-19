using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ViewModels.Manage.Articles
{
    public class CreateArticleViewModel
    {
       [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

       
        [Display(Name = "شماره تلفن ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Abstract { get; set; }

        public string Photo { get; set; }
    }
}
