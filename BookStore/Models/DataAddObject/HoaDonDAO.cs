using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.DataAddObject
{
    public class HoaDonDAO
    {
        QuanLyBanSachEntities _model;

        public HoaDonDAO()
        {
            _model = new QuanLyBanSachEntities();
        }


    }
}