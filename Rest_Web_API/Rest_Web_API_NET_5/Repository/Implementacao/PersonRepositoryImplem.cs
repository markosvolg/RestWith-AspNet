

using Rest_Web_API.Context;
using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rest_Web_API_NET_5.Repository.Implementacao
{
    public class PersonRepositoryImplem : IPersonRepository
    {


        private MySqlContext _context;
        //private volatile int count;

        public PersonRepositoryImplem(MySqlContext context)
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
            catch (Exception)
            {

                throw;
            }

            return person;
        }


        public void Delete(int Id)
        {
            var resut = _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));

            if (resut != null)
            {
                try
                {
                    _context.Persons.Remove(resut);
                    _context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }

            }
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

        //private Person MockPerson(int i)
        //{

        //    return new Person
        //    {
        //        Id = incrementAndGet(),
        //        FirstName = "Marcos" + i,
        //        LastName = "Silva" + i,
        //        Address = "Grajau - São Paulo" + i,
        //        Gender = "Male"

        //    };

        //}

        //private int incrementAndGet()
        //{
        //    return Interlocked.Increment(ref count);
        //}

        public Person FindById(int Id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var resut = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));


            if (resut != null)
            {
                try
                {
                    _context.Entry(resut).CurrentValues.SetValues(person);
                    _context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }

            }
            return person;
        }

        public bool Exists(int Id)
        {
            return _context.Persons.Any(p => p.Id.Equals(Id));
        }
    }
}