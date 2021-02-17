using Rest_Web_API_NET_5.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Model
{

    [Table("books")]
    public class Book : BaseEntity
    {
        
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
