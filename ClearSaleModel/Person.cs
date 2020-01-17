using System;
using System.Collections.Generic;

namespace ClearSaleModel
{
    public class Person
    {
        
        public string ID { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }
      
        public Char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public List<Phone> Phones { get; set; }

    }

}