
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rest_Web_API_NET_5.Data.VO
{
    [Table("persons")]
    public class PersonVO
    {
        //NewtonsoftJson não funciona mais apartir do Core 3.1
      //  [JsonPropertyName("codigo")]
        public int Id { get; set; }

        [JsonPropertyName("Nome")]
        public string FirstName { get; set; }

        //[JsonPropertyName("Sobrenome")]
        public string LastName { get; set; }

        //[JsonPropertyName("Endereço")]
        public string Address { get; set; }

        //[JsonIgnore]
        public string Gender { get; set; }
    }
}
