﻿using DataAccess.UoW;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IRegisterBusiness: IDisposable
    {
        
        void AddRegister(Register model);
    }
}
