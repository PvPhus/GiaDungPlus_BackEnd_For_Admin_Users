﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IDoGiaDungRepository
    {
        DoGiaDungModel GetChiTietDoGiaDung(int id);
        bool Create(DoGiaDungModel model);
        bool Update(DoGiaDungModel model);
        bool Delete(DoGiaDungModel model);
    }

}