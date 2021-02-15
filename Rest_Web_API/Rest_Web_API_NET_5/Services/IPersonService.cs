
using Rest_Web_API_NET_5.Model;
using System.Collections.Generic;

namespace Rest_Web_API_NET_5.Services
{
   public interface IPersonService
    {

        Person Create(Person person);
        Person FindById(int Id);

        List<Person>  FindAll();
        Person Update(Person person);

        void  Delete(int Id);



    }
}
