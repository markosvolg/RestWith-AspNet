using Rest_Web_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rest_Web_API.Services.Implementacao
{
    public class PersonServiceImplem : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {

                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;

        }

        private Person MockPerson(int i)
        {

            return new Person
            {
                Id = incrementAndGet(),
                FirstName = "Marcos" + i,
                LastName = "Silva" + i,
                Adress = "Grajau - São Paulo" + i,
                Genrer = "Male"

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
                Adress = "Grajau - São Paulo",
                Genrer = "Male"

            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
