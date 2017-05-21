using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BookStore.Models.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String AutherName { get; set; }
        public String Details { get; set; }
        public Double Cost { get; set; }
        public String Image { get; set; }
        public String Sale { get; set; }
       
    }
}