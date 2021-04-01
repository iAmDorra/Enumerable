using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PersonModel
{
    public class PersonModelContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=PersonModel.db");
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Animal> Animals { get; set; }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
