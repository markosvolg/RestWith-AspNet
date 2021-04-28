using Rest_Web_API_NET_5.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_Web_API_NET_5.Model
{
    [Table("persons")]
    public class Person : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        //[Column("Gender")]
        public string Gender { get; set; }
    }
}
