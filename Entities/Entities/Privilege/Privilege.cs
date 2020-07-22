using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.Privilege
{
    [Table("Privilege", Schema = "Privilege")]
    public class Privilege:BaseClasses.BaseClass
    {
        public bool Status { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public int ParentId { get; set; }
        public int SubGroupId { get; set; }
    }
}
