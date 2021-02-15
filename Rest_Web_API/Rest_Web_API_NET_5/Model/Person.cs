using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Model
{
    [Table("persons")]
    public class Person
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

      //  [Column("Address")]
        public string Address { get; set; }

        //[Column("Gender")]
        public string Gender { get; set; }
    }
}
