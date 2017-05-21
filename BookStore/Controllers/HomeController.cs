using BookStore.Models.DataAddObject;
using BookStore.Models.DataToObject;
using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        BookDAO sachDAO = new BookDAO();

        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult HomePageContent()
        {

            return View();
        }
        public ActionResult BestSeller()
        {
            return View();
        }
        public ActionResult CommingSoon()
        {
            return View();
        }
        public ActionResult HighLights()
        {
            return View();
        }
        public PartialViewResult getListBook1()
        {
            var list = db.Saches.ToList();
            return PartialView(list);
        }


        public ActionResult BookDetails(int ID, String Name, String AutherName, String Image, String Sale, String Details, Double cost)
        {
            Book book = new Book();
            book.ID = ID;
            book.Name = Name;
            book.AutherName = AutherName;
            book.Image = Image;
            book.Details = Details;
            book.Cost = cost;
            ViewData["book"] = book;
            return View(book);
        }
        public ViewResult BookDetails1(int ID)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.ma == ID);
            if (sach == null) Response.StatusCode = 404;
            return View(sach);
        }
        public PartialViewResult BookCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookCreate(Sach s)
        {
            db.Saches.Add(s);
            db.SaveChanges();
            return RedirectToAction("BookManager");
        }

        public ActionResult BookDelete(int ID = 0)
        {
            Sach s = db.Saches.SingleOrDefault(n => n.ma == ID);
            if (s == null)
            {
                Response.StatusCode = 404;
            }
            db.Saches.Remove(s);
            db.SaveChanges();
            return RedirectToAction("BookManager");
        }

        public ActionResult BookUpdate(int ID)
        {
            return View(db.Saches.Find(ID));
        }
        [HttpPost]
        public ActionResult BookUpdate(Sach s)
        {
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("BookManager");
        }
        public NhaXuatBan FindNXB(int ma)
        {
            var nxb = db.NhaXuatBans.Find(ma);
            if (nxb != null) return nxb;
            else return new NhaXuatBan();
        }
        public ActionResult BookManager(int? page)
        {
            //List<Sach> lsSach = db.Sach.OrderBy(n => n.ma).ToList();
            //return View(lsSach);

            int pageNumber;
            pageNumber = (page ?? 1);
            int pagesize = 10;

            sachDAO = new BookDAO();
            IQueryable<BookDTO> ls = sachDAO.ListDTO_Sach();//.ToPagedList(pageNumber,pa);

            // List<SachDTO> ls1 = ls.ToList<SachDTO>().ToPagedList(pageNumber, pagesize);

            return View(ls.ToList<BookDTO>().ToPagedList(pageNumber, pagesize));
        }
        public PartialViewResult getListCategory()
        {
            var list = db.ChuDes.ToList();

            return PartialView(list);
        }
        public PartialViewResult getListBookByCategory(int chudema, String tenchude)
        {
            var list = db.Saches.ToList();
            var listResult = new List<Sach>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].chudema == chudema) listResult.Add(list[i]);
            }
            ViewData["TenChuDe"] = tenchude;
            return PartialView(listResult);
        }

        public PartialViewResult getListBookManager()
        {
            var list = db.Saches.ToList();
            var listResult = new List<Sach>();

            for (int i = 0; i < list.Count; i++)
            {
                listResult.Add(list[i]);
            }
            return PartialView(listResult);
        }
        public ViewResult AddItem(int ma, String ten, String mota, String anhbia, DateTime ngaycapnhat, int soluongton,
            int nhaxuatbanma, int chudema)
        {
            //ma- int, ten- string, gia- nullable<decimal>, mota- string, anhbia-string, ngaycapnhat <nullable<system.datetime>, 
            //soluongton nullable<int>- nhaxuatbanma nullable<int>, chudema - nullable<int>, moi- nullable<int>
            Sach sach = new Sach();
            sach.ma = ma;
            sach.ten = ten;
            sach.mota = mota;
            sach.anhbia = anhbia;
            sach.ngaycapnhat = ngaycapnhat;
            sach.soluongton = soluongton;
            sach.nhaxuatbanma = nhaxuatbanma;
            sach.chudema = chudema;

            db.Saches.Add(sach);

            return View(sach);
        }

    }
}