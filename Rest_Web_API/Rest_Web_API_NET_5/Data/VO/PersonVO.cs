using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_Web_API_NET_5.Data.VO
{
    [Table("persons")]
    public class PersonVO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
