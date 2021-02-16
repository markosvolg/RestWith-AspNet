using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Business
{
   public interface IBookBusiness
    {
        Book Create(Book person);
        Book FindById(int Id);

        List<Book> FindAll();
        Book Update(Book person);

        void Delete(int Id);

    

    }
}
