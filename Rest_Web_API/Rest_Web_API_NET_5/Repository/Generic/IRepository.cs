
using Rest_Web_API_NET_5.Model;
using Rest_Web_API_NET_5.Model.Base;
using System.Collections.Generic;

namespace Rest_Web_API_NET_5.Repository
{
   public interface IRepository<T> where T : BaseEntity
    { 
        T Create(T item);
        T FindById(int Id);

        List<T>  FindAll();
        T Update(T item);

        void  Delete(int Id);

        bool Exists(int Id);

    }
}
