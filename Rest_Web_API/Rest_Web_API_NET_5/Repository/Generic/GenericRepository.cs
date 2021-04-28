using Microsoft.EntityFrameworkCore;
using Rest_Web_API.Context;
using Rest_Web_API_NET_5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySqlContext _context;

        private DbSet<T> _dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return item;
        }



        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(int Id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(Id));
        }

        public T Update(T item)
        {

            var resut = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (resut != null)
            {
                try
                {
                    _context.Entry(resut).CurrentValues.SetValues(item);
                    _context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                return null;
            }
            return item;
        }


        public void Delete(int Id)
        {
            var resut = _dataset.SingleOrDefault(p => p.Id.Equals(Id));

            if (resut != null)
            {
                try
                {
                    _dataset.Remove(resut);
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
