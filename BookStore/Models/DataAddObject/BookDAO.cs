using BookStore.Models.DataToObject;
using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.DataAddObject
{
    public class BookDAO
    {
        QuanLyBanSachEntities model;
        public BookDAO()
        {
            model = new QuanLyBanSachEntities();
        }
        public IQueryable<Sach> List()
        {
            var sach = from s in model.Saches select s;
            return sach;
        }
        public IQueryable<BookDTO> ListDTO_Sach()
        {
            var ls = from s in model.Saches
                     join cd in model.ChuDes on s.chudema equals cd.ma
                     join tg in model.TacGias on s.tacgiama equals tg.ma
                     select new BookDTO
                     {
                         TenSach = s.ten,
                         GiaSach = s.gia,
                         MaSach = s.ma,
                         SoLuong =(int)s.soluongton,
                         MoTaSach = s.mota,
                         TenChuDe = cd.ten,
                         TenTacGia = tg.ten
                     };
            return ls;

        }
        public Sach getByID(int id)
        {
            return model.Saches.Find(id);
        }
    }
}