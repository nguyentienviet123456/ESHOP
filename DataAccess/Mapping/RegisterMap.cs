﻿using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class RegisterMap : EntityTypeConfiguration<Register>
    {
        public RegisterMap()
        {
            ToTable("Register");
            HasKey(o => o.Id);
        }
    }
}