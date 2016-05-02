using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vjezba_5
{
    static class PersonRepository
    {
        private static List<Person> persons = new List<Person>();

        public static void savePerson(Person p) 
        {
            persons.Add(p);
        }

        public static Person getPersonByNameAndLastName(Person p)
        { 
            // Find first person with given first and last name
            return persons.Find(person => (person.Name == p.Name && person.LastName == p.LastName));
        }

        public static List<Person> getAllPersons()
        {
            return persons;
        }
    }
}
