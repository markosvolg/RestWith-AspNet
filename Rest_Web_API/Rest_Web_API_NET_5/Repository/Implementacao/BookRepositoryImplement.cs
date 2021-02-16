using Rest_Web_API.Context;
using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Repository.Implementacao
{
    public class BookRepositoryImplement : IBookRepository
    {

        private MySqlContext _context;


        public BookRepositoryImplement(MySqlContext context)
        {
            _context = context;
        }


        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return book;

        }
        public Book FindById(int Id)
        {

            return  _context.Books.SingleOrDefault(p => p.Id.Equals(Id));
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();

        }


        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var resut = _context.Persons.SingleOrDefault(p => p.Id.Equals(book.Id));


            if (resut != null)
            {
                try
                {
                    _context.Entry(resut).CurrentValues.SetValues(book);
                    _context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }

            }
            return book;
        }

        public void Delete(int Id)
        {
            var resut = _context.Books.SingleOrDefault(p => p.Id.Equals(Id));

            if (resut != null)
            {
                try
                {
                    _context.Books.Remove(resut);
                    _context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }

            }

        }


        public bool Exists(int Id)
        {
            return _context.Books.Any(p => p.Id.Equals(Id));
        }
    }
}
