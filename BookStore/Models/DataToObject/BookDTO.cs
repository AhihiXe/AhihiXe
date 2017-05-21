using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.DataToObject
{
    public class BookDTO
    {
        public int MaSach { get; set; }
        public String TenSach { get; set; }
        public Nullable<decimal> GiaSach { get; set; }
        public int SoLuong { get; set; }
        public String MoTaSach { get; set; }
        public String AnhBia { get; set; }
        public String TenChuDe { get; set; }
        public String TenTacGia { get; set; }
    }
}