using Microsoft.EntityFrameworkCore;
using Rest_Web_API_NET_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API.Context
{
    public class MySqlContext : DbContext

    {


        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {


        }

        public DbSet<Person> Persons {get; set;}
        public DbSet<Book> Books { get; set; }
    }
}
