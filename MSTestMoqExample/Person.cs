using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestMoqExample
{
    public class Person : IPerson
    {
        public Person(Gender gender)
        {
            this.gender = gender;
        }

        private Gender gender;

        public int BirthYear { get; set; }
    

        public Gender GetGender()
        {
            return gender;
        }

        public enum Gender
        {
            male,
            female
        }
    }
}
