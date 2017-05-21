using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Bean
{
    public class Cart
    {
        public List<ItemCart> ListItem = new List<ItemCart>();
        public void AddItem(int ID, String Name, double Price, int Amount)
        {
            bool Check = false;
            //nếu có rồi thì cộng số lượng
            foreach (var item in ListItem)
            {
                if (item.ID == ID)
                {
                    item.Amount += Amount;
                    Check = true;
                    break;
                }
            }
            //chưa có thì thêm mới
            if (!Check)
            {
                ItemCart itemcart = new ItemCart();
                itemcart.ID = ID;
                itemcart.Name = Name;
                itemcart.Price = Price;
                itemcart.Amount = Amount;
                ListItem.Add(itemcart);
            }
        }
        public void UpdateAmount(int ID, int Amount)
        {
            foreach (var item in ListItem)
            {
                if (item.ID == ID)
                    if (Amount > 0) item.Amount = Amount;
                    else ListItem.Remove(item);
                break;
            }
        }
        public void Delete(int ID)
        {
            foreach (var item in ListItem)
            {
                if (item.ID == ID)
                {
                    ListItem.Remove(item);
                    break;
                }
            }
        }
        public int GetAmountInCart()
        {
            int Number = 0;
            foreach (var item in ListItem)
            {
                Number += item.Amount;
            }
            return Number;
        }
        //tổng tiền
        public double getTotal()
        {
            double Total = 0;
            foreach (var item in ListItem)
            {
                Total += item.GetMoney();
            }
            return Total;
        }
        //danh sách hàng
        public List<ItemCart> getListItemCart()
        {
            return ListItem;
        }
    }
}