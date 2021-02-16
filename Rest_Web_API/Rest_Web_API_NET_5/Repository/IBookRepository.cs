using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Repository
{
    public interface IBookRepository
    {

        Book Create(Book book);

        List<Book> FindAll();

        Book Update(Book book);

        Book FindById(int Id);

        void Delete(int Id);

        bool Exists(int Id);



    }
}
