

using Rest_Web_API.Context;
using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Services.Implementacao
{
    public class PersonServiceImplem : IPersonService
    {


        private MySqlContext _context;
        private volatile int count;

        public PersonServiceImplem(MySqlContext context)
        {
            _context = context;
        }



        public Person Create(Person person)
        {

            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }


        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            //List<Person> persons = new List<Person>();

            //for (int i = 0; i < 8; i++)
            //{
            //    Person person = MockPerson(i);
            //    persons.Add(person);

            //}
            //return persons;
            return _context.Persons.ToList();
        }

        private Person MockPerson(int i)
        {

            return new Person
            {
                Id = incrementAndGet(),
                FirstName = "Marcos" + i,
                LastName = "Silva" + i,
                Address = "Grajau - São Paulo" + i,
                Gender = "Male"

            };

        }

        private int incrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(int Id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Marcos",
                LastName = "Silva",
                Address = "Grajau - São Paulo",
                Gender = "Male"

            };
        }

        public Person Update(Person person)
        {
            return person;
        }


    }
}
