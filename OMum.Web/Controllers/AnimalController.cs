using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using OMum.Animals;
using OMum.Animals.Dto;

namespace OMum.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AnimalController : Controller
    {
        private readonly IAnimalAppService _animalAppService;
        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }
        public ActionResult Index()
        {
            //AddAnimal();
            //QueryAnimalCount();
            GetAnimals();
            return View();
        }

        public void AddAnimal()
        {
            _animalAppService.CreateAnimal(new CreateAnimalInput { Name = "猫" });
        }

        public async Task<int> QueryAnimalCount()
        {
            int x = await _animalAppService.QueryCount();
            return x;
        }

        public PagedResultOutput<AnimalDto> GetAnimals()
        {
            PagedResultOutput<AnimalDto> r = _animalAppService.GetAnimals(new GetAnimalsInput { MaxResultCount = 10, SkipCount = 0, Sorting = "Name DESC" });
            return r;
        }
    }
}