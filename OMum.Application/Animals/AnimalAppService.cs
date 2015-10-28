using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using OMum.Animals.Dto;

using Abp.Configuration;
using System.Data.Entity;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using OMum.Configuration;
using Abp.Authorization;

namespace OMum.Animals
{
    [AbpAuthorize]
    public class AnimalAppService : ApplicationService, IAnimalAppService
    {
        private readonly IRepository<Animal> _animalRepository;
        public AnimalAppService(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }
        [AbpAuthorize("CanQueryCount")]
        public Task<int> QueryCount()
        {
            return _animalRepository.CountAsync();
        }
        public async Task CreateAnimal(CreateAnimalInput input)
        {
            await _animalRepository.InsertAsync(new Animal { Name = input.Name });
        }

        public PagedResultOutput<AnimalDto> GetAnimals(GetAnimalsInput input)
        {
            if (input.MaxResultCount <= 0)
            {
                input.MaxResultCount = SettingManager.GetSettingValue<int>(MySettingProvider.AnimalsDefaultPageSize);
            }

            var animalCount = _animalRepository.Count();
            var animals=_animalRepository.GetAll()
                    .Include(q => q.CreatorUser)
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToList();

            return new PagedResultOutput<AnimalDto>
            {
                TotalCount = animalCount,
                Items = animals.MapTo<List<AnimalDto>>()
            };
        }
    }
}
