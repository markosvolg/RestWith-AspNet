using Rest_Web_API_NET_5.Model;
using Rest_Web_API_NET_5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Business.Implementacao
{
    public class BookBusinessImplement : IBookBusiness
    {

        private IRepository<Book> _repository;

        public BookBusinessImplement(IRepository<Book> repository)
        {
            _repository = repository;
        }


        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(int Id)
        {
            return _repository.FindById(Id);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

   

    }
}
