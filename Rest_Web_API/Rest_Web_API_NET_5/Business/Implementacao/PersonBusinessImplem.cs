

using Rest_Web_API.Context;
using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rest_Web_API_NET_5.Repository.Implementacao
{
    public class PersonBusinessImplem : IPersonBusiness
    {

        private IPersonRepository _repository;

        public PersonBusinessImplem(IPersonRepository repository)
        {
            _repository = repository;
        }


        public Person Create(Person person)
        {

            return _repository.Create(person);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(int Id)
        {
            return _repository.FindById(Id);
        }

        public Person Update(Person person)
        {

            return _repository.Update(person);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

    }
}