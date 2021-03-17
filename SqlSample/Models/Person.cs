using System;

namespace SqlSample.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}