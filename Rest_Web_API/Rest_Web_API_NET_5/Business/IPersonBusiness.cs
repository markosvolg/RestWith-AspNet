
using Rest_Web_API_NET_5.Data.VO;
using Rest_Web_API_NET_5.Model;
using System.Collections.Generic;

namespace Rest_Web_API_NET_5.Repository
{
   public interface IPersonBusiness
    {

        PersonVO Create(PersonVO person);
        PersonVO FindById(int Id);

        List<PersonVO>  FindAll();
        PersonVO Update(PersonVO person);

        void  Delete(int Id);



    }
}
