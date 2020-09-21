using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Manage.Products
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage ="فیلد {0} الزامی است")]
        [Display(Name = "نام" )]
        
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی است")]
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
    }
}
