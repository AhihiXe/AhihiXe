using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Bean
{
    public class ItemCart
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        //discount
        public double GetMoney()
        {
            return Amount * Price;
        }
    }
}