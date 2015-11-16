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
using Castle.Core.Logging;

namespace OMum.Animals
{
    [AbpAuthorize]
    public class AnimalAppService : ApplicationService, IAnimalAppService
    {
        public ILogger Logger { get; set; }
        private readonly IRepository<Animal> _animalRepository;
        public AnimalAppService(IRepository<Animal> animalRepository)
        {
            Logger = NullLogger.Instance;
            _animalRepository = animalRepository;
        }
        [AbpAuthorize("CanQueryCount")]
        public Task<int> QueryCount()
        {
            if (PermissionChecker.IsGranted("GetAnimals"))
            { }
            return _animalRepository.CountAsync();
        }
        public async Task CreateAnimal(CreateAnimalInput input)
        {
            Logger.Info("创建动物" + input.Name);
            await _animalRepository.InsertAsync(new Animal { Name = input.Name });
        }
        [AbpAuthorize("GetAnimals")]
        public PagedResultOutput<AnimalDto> GetAnimals(GetAnimalsInput input)
        {
            if (input.MaxResultCount <= 0)
            {
                input.MaxResultCount = SettingManager.GetSettingValue<int>(MySettingProvider.AnimalsDefaultPageSize);
            }

            var animalCount = _animalRepository.Count();
            var animals = _animalRepository.GetAll()
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

        public async Task DeleteAnimal(int animalId)
        {
            //using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            //{
            var animal = (await _animalRepository.FirstOrDefaultAsync(animalId));
            await _animalRepository.DeleteAsync(animal);
            //await this.CurrentUnitOfWork.SaveChangesAsync();
            //}
        }
    }
}
