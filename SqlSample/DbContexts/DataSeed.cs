using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlSample.DbContexts
{
    public static class DataSeed
    {
        public static async Task SeedAsync()
        {
            var dbContext = new SqlDbContext();

            if (!await dbContext.Persons.AnyAsync())
            {
                Console.WriteLine("Seeding database started...");
                var persons = GenerateFakePersons();
                dbContext.Persons.AddRange(persons);
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Seeding database done.");
            }
        }

        private static List<Models.Person> GenerateFakePersons()
        {
            var persons = new List<Models.Person>();

            for (int i = 0; i < 1000; i++)
            {
                var person = new Faker<Models.Person>()
                    .RuleFor(p => p.Id, f => Guid.NewGuid())
                    .RuleFor(p => p.Name, f => f.Name.FirstName())
                    .RuleFor(p => p.DateOfBirth, f => f.Date.Past())
                    .Generate();
                persons.Add(person);
            }

            return persons;
        }
    }
}