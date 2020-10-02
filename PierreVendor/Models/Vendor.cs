using System;
using System.Collections.Generic;
namespace Pierre.Models {
    public class Vendor 
    {
        private static List<Vendor> _instances = new List<Vendor>{};
        public string Name { get; set; }
        public string description { get; set; }
        
        public Vendor()
        {
           
        }

    }
}