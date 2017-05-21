using BookStore.Models.DataToObject;
using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.DataAddObject
{
    public class ChudeDAO
    {
        QuanLyBanSachEntities model;

        public ChudeDAO()
        {
            model = new QuanLyBanSachEntities();
        }
        public IQueryable<BookDTO> ListDTO_Chude(int chudema)
        {
            var ls = from s in model.Saches
                     join cd in model.ChuDes on s.chudema equals cd.ma
                     where cd.ma == chudema
                     join tg in model.TacGias on s.tacgiama equals tg.ma

                     select new BookDTO
                     {
                         TenSach = s.ten,
                         GiaSach = s.gia,
                         MaSach = s.ma,
                         MoTaSach = s.mota,
                         TenChuDe = cd.ten,
                         TenTacGia = tg.ten
                     };
            return ls;
        }
        public int get_Chude_ma(String ChudeTen)
        {
            var list = from cd in model.ChuDes
                     where cd.ten == ChudeTen
                     select new ChudeDTO
                     {
                         MaChuDe = cd.ma,
                         TenChuDe = cd.ten
                     };
            if (list.Count() != 1) return 0;

            else return list.First().MaChuDe;
        }
    }
}