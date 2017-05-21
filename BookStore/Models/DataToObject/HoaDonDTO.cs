using BookStore.Models.Bean;
using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.DataToObject
{
    public class HoaDonDTO
    {
        public String MaHoaDon { get; set; }
        public List<ItemCart> _list { get; set; }
        public String Email { get; set; }
        public String KhachHangTen { get; set; }
        public String KhachHangSDT { get; set; }
        public String DiaChiGiaoHang { get; set; }
        public String NgayGiaoHang { get; set; }
    }
}