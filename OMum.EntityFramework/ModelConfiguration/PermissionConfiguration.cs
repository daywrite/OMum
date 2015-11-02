﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using OMum.Initialize;

namespace OMum.ModelConfiguration
{
     public class PermissionConfiguration : EntityConfigurationBase<PermissionSetting, long>
    {
         public PermissionConfiguration()
        {
            ToTable("a_permission");
        }
    }
}
