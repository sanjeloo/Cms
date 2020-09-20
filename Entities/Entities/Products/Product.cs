using Entities.Entities.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities.Products
{
    public class Product :BaseClass
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
