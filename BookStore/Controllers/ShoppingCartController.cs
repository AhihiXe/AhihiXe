using BookStore.Models.Bean;
using BookStore.Models.DataAddObject;
using BookStore.Models.DataToObject;
using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ShoppingCartController : Controller
    { // GET: ShoppingCart
        public ActionResult Add(int ID)
        {
            Cart cart = (Cart)Session["cart"];
            if (cart == null)
                cart = new Cart();
            BookDAO dao = new BookDAO();
            Sach sach = dao.getByID(ID);
            if (sach != null)
                cart.AddItem(sach.ma, sach.ten, (double)sach.gia, 1);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
            //để get ra đường dẫn đến nó
        }
        public ActionResult List()
        {
            List<ItemCart> ls = new List<ItemCart>();
            Cart cart = (Cart)Session["cart"];
            if (cart != null)
            {
                ls = cart.ListItem;
            }
            return View(ls);
        }
        public ActionResult Delete(int ID)
        {
            Cart cart = (Cart)Session["cart"];
            if (cart != null)
                cart.Delete(ID);
            return Redirect(Request.UrlReferrer.ToString());
        }
        // [HttpPost]
        public ActionResult Buy(/*String taikhoan*/)
        {
            //if (taikhoan == null) return View("Login", "Login");
            Cart cart = (Cart)Session["cart"];
            List<ItemCart> ls;
            if (cart != null)
               ls = cart.ListItem;
            HoaDonDTO _hoadonDTO = (HoaDonDTO)Session["hoadon"];
            //Lưu tên, phone vào bảng hóa đơn
            //Lưu danh sách hàng hóa với (id của ItemCart vào bảng chi tiết hóa đơn)

            return View();
        }

    }
}