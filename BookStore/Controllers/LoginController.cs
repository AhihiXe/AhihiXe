using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }

            return RedirectToAction("HomePageContent", "Home");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            /* public ActionResult Add(int ID)
        {
            Cart cart = (Cart)Session["cart"];
            if (cart == null)
                cart = new Cart();
            SachDAO dao = new SachDAO();
            Sach sach = dao.getByID(ID);
            if (sach != null)
                cart.AddItem(sach.ma, sach.ten, (double)sach.gia, 1);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
            //để get ra đường dẫn đến nó
        }*/
            String taikhoan = frm["username"].ToString();
            String matkhau = frm["password"].ToString();

            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.taikhoan == taikhoan && n.matkhau == matkhau);
            if (kh != null)
            {
                Session["user"] = kh;

                if (taikhoan == "admin" && matkhau == "admin")
                {
                    return RedirectToAction("HomePage", "Manage");
                }
                return RedirectToAction("HomePageContent", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không hợp lệ";
                return View();
            }
        }
    }
}