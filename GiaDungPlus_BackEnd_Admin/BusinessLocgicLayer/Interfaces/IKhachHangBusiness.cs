﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IKhachHangBusiness
    {
        KhachHangModel GetDataByID(int id);
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        bool Delete(KhachHangModel model);
        public List<KhachHangModel> SearchKhachHang(int pageIndex, int pageSize, out long total, string nameKH, string diaChi);
    }
}
