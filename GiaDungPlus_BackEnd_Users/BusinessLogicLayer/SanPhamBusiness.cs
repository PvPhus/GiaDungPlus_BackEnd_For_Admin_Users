﻿using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataModel;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public List<DoGiaDungModel> SearchProducts(int pageIndex, int pageSize, out long total, string ten_sanpham)
        {        
            return _res.SearchProducts(pageIndex,pageSize,out total,ten_sanpham);
        }
        public List<DoGiaDungModel> GetAllProducts()
        {
            return _res.GetAllProducts();
        }
        public List<LoaiDoGiaDung> GetAllCategory()
        {
            return _res.GetAllCategory();
        }

    }
}