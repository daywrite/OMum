﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OMum.Animals.Dto
{
    public class AnimalDto : CreationAuditedEntityDto
    {
        public string Name { get; set; }
        public string CreatorUserName { get; set; }
    }
}