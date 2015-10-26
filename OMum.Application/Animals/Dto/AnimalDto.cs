using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace OMum.Animals.Dto
{
    [AutoMapFrom(typeof(Animal))]
    public class AnimalDto : CreationAuditedEntityDto
    {
        public string Name { get; set; }
        public string CreatorUserName { get; set; }
    }
}
