using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vjezba_5
{
    public class Person
    {
        public Person() { }

        public Person(string n, string ln, string c, int a)
        {
            Name = n;
            LastName = ln;
            City = c;
            Age = a;
        }

        private string _name;
        private string _lastName;
        private string _city;
        private int _age;
        
        /**
         * Get/set first name for Person
         */
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /**
         * Get/set last name for Person
         */
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        /**
        * Get/set city for Person
        */
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        /**
        * Get/set Age for Person
        */
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
    }
}