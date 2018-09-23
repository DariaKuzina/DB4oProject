using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Title { get; set; }

        public Person(string firstName, string lastName, byte age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName, byte age, string title)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Title = title;
        }

        public override string ToString()
        {
            return Title + " " + FirstName + " " + LastName + ": " + Age;
        }
    }
}
