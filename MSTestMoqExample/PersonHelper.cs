using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestMoqExample
{
    public class PersonHelper
    {
        public int getCurrentYear()
        {
            return DateTime.Now.Year;
        }

        public int calculateAge(IPerson person)
        {
            return getCurrentYear() - person.BirthYear;
        }

        public bool isMale(IPerson person)
        {
            return person.GetGender() == Person.Gender.male;
        }
    }
}
