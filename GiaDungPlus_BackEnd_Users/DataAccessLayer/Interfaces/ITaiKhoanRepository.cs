﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ITaiKhoanRepository
    {
        TaiKhoanModel Login(string taikhoan, string matkhau);        
    }
}
