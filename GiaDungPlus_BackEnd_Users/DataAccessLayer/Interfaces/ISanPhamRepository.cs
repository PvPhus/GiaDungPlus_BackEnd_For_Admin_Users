﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISanPhamRepository
    { 
        public List<DoGiaDungModel> SearchProducts(int pageIndex, int pageSize, out long total, string ten_sanpham);
        List<LoaiDoGiaDung> GetAllCategory();
        List<DoGiaDungModel> GetAllProducts();
    }
}
