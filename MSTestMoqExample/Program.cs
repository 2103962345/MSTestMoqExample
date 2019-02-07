using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestMoqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonHelper helper = new PersonHelper();
            Console.WriteLine(helper.getCurrentYear());

            Person teacher = new Person(Person.Gender.male);
            teacher.BirthYear = 1975;

            Console.WriteLine(helper.calculateAge(teacher));

            Console.WriteLine(helper.isMale(teacher));
        }
    }
}
