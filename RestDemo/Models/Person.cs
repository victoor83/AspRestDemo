using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestDemo.Models
{
    public class Person
    {
        //[Json("name")]
        public string Name;
        public string City;
        public int Zip;
    }   
}