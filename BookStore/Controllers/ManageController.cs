using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Models.DataAddObject;
using PagedList;
using BookStore.Models.DataToObject;
using BookStore.Models.Entities;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class ManageController : Controller
    {
        QuanLyBanSachEntities _database = new QuanLyBanSachEntities();
        BookDAO _bookdao = new BookDAO();
        ChudeDAO _chudedao = new ChudeDAO();
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult BookManager(int? page)
        {
            //List<Sach> lsSach = db.Sach.OrderBy(n => n.ma).ToList();
            //return View(lsSach);

            int pageNumber;
            pageNumber = (page ?? 1);
            int pagesize = 10;

            _bookdao = new BookDAO();
            IQueryable<BookDTO> ls = _bookdao.ListDTO_Sach();//.ToPagedList(pageNumber,pa);

            // List<SachDTO> ls1 = ls.ToList<SachDTO>().ToPagedList(pageNumber, pagesize);

            return View(ls.ToList<BookDTO>().ToPagedList(pageNumber, pagesize));
        }
        //-----------------------------------------------------------

        //SÁCH
        public PartialViewResult BookCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookCreate(Sach s)
        {
            if (s.ten.Trim().ToString() != "" )
            {
                _database.Saches.Add(s);
                _database.SaveChanges();
            }
            if (s.chudema == null) s.chudema = (new Random()).Next(1, _database.ChuDes.Count());
            return RedirectToAction("BookManager");
        }

        public ActionResult BookDelete(int ID = 0)
        {
            Sach s = _database.Saches.SingleOrDefault(n => n.ma == ID);
            if (s == null)
            {
                Response.StatusCode = 404;
            }
            _database.Saches.Remove(s);
            _database.SaveChanges();
            return RedirectToAction("BookManager");
        }

        public ActionResult BookUpdate(int ID)
        {
            return View(_database.Saches.Find(ID));
        }
        [HttpPost]
        public ActionResult BookUpdate(Sach s)
        {
           // s.chudema = _chudedao.get_Chude_ma(s.ChuDe.ten);

            _database.Entry(s).State = EntityState.Modified;
            _database.SaveChanges();
            
            return RedirectToAction("BookManager");
        }
        public ViewResult BookDetails(int ID)
        {
            Sach sach = _database.Saches.SingleOrDefault(n => n.ma == ID);
            if (sach == null) Response.StatusCode = 404;

            return View(sach);
        }
        //--------------------------------------------------------
        //Chủ đề
        public PartialViewResult getList_Chude()
        {
            var list = _database.ChuDes.ToList();
            return PartialView(list);
        }

        public PartialViewResult ChudeManager()
        {
            var list = _database.ChuDes.ToList();
            return PartialView(list);
        }

        public PartialViewResult ChudeCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ChudeCreate(ChuDe cd)
        {
            if (cd.ten.Trim().ToString() != "")
            {
                _database.ChuDes.Add(cd);
                _database.SaveChanges();
            }
            return RedirectToAction("ChudeManager");
        }

        public ActionResult ChudeDetail( int? page, int ID = 0)
        {
            int pageNumber;
            pageNumber = (page ?? 1);
            int pagesize = 10;

            _chudedao = new ChudeDAO();
            IQueryable<BookDTO> ls = _chudedao.ListDTO_Chude(ID);//.ToPagedList(pageNumber,pa);

            // List<SachDTO> ls1 = ls.ToList<SachDTO>().ToPagedList(pageNumber, pagesize);

             var cd = _database.ChuDes.Find(ID);
            ViewData["TenChuDe"] = cd.ten;
            return View(ls.ToList<BookDTO>().ToPagedList(pageNumber, pagesize));


            //int pageNumber;
            //pageNumber = (page ?? 1);
            //int pagesize = 10;

            //Sach sach = _database.Saches.SingleOrDefault(n => n.chudema == ID);
            //IQueryable<BookDTO> ls = _bookdao.ListDTO_Sach();//.ToPagedList(pageNumber,pa);

            //// List<SachDTO> ls1 = ls.ToList<SachDTO>().ToPagedList(pageNumber, pagesize);

            //return View(ls.ToList<BookDTO>().ToPagedList(pageNumber, pagesize));
        }
        public ActionResult ChudeDelete(int ID = 0)
        {
            ChuDe  cd = _database.ChuDes.SingleOrDefault(n => n.ma == ID);
            if (cd == null)
            {
                Response.StatusCode = 404;
            }
            _database.ChuDes.Remove(cd);
            _database.SaveChanges();
            return RedirectToAction("ChudeManager");
        }

        public ActionResult ChudeUpdate(int ID)
        {
            return View(_database.ChuDes.Find(ID));
        }
        [HttpPost]
        public ActionResult ChudeUpdate(ChuDe cd)
        {
                _database.Entry(cd).State = EntityState.Modified;
                _database.SaveChanges();
            return RedirectToAction("ChudeManager");
        }

        //public ActionResult BookUpdate(int ID)
        //{
        //    return View(db.Sach.Find(ID));
        //}
        //[HttpPost]
        //public ActionResult BookUpdate(Sach s)
        //{
        //    db.Entry(s).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("BookManager");
        //}
    }
}