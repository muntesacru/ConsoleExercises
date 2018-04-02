using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Person
    {
        public Person(string email, string telephone)
        {
            this.email = email;
            this.telephone = telephone;
        }

        public string telephone { get; set; }
        public string email { get; set; }
        public override string ToString()
        {
            return this.email + " (" + this.telephone + ")";
        }
    }
}
