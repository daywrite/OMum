using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using OMum.Animals.Dto;

namespace OMum.Animals
{
    public class AnimalAppService : ApplicationService, IAnimalAppService
    {
        private readonly IRepository<Animal> _animalRepository;
        public AnimalAppService(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task CreateAnimal(CreateAnimalInput input)
        {
            await _animalRepository.InsertAsync(new Animal { Name = input.Name });
        }
    }
}
