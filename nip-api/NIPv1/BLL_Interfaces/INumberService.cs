﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIPv1.Models;

namespace NIPv1.BLL_Interfaces
{
    public interface INumberService
    {
        CompanyModel GetById(string id);
    }
}
