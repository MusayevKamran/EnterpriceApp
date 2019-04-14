using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class Student : Entity
    {
        public Student() { }
        public Student(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
