using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMum.Animals.Dto;

namespace OMum.Animals
{
    public interface IAnimalAppService : IApplicationService
    {
        Task<int> QueryCount();
        Task CreateAnimal(CreateAnimalInput input);
        PagedResultOutput<AnimalDto> GetAnimals(GetAnimalsInput input);
    }
}
