using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OMum.Animals.Dto
{
     public class CreateAnimalInput : IInputDto
    {
        [Required]
        public string Name { get; set; }
    }
}
