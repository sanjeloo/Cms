using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Manage.Products
{
   public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
