using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    internal class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public EducationLevel Education { get; set; } = 0;

        public Person()
        {
        }

        public Person(string firstName, string lastName, EducationLevel education)
        {
            FirstName = firstName;
            LastName = lastName;
            Education = education;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Education.ToString();
        }
    }

    public enum EducationLevel
    {
        podstawowe = 0,
        średnie = 1,
        wyższe = 2
    }

}
