using Rest_Web_API_NET_5.Data.Converter.Implement;
using Rest_Web_API_NET_5.Data.VO;
using Rest_Web_API_NET_5.Model;
using System.Collections.Generic;

namespace Rest_Web_API_NET_5.Repository.Implementacao
{
    public class PersonBusinessImplem : IPersonBusiness
    {

        private readonly IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplem(IRepository<Person> repository )
        {
            _repository = repository;
            _converter = new PersonConverter();
        }


        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public PersonVO Update(PersonVO person)
        {

            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

    }
}