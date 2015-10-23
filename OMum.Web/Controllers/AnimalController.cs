using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMum.Animals;
using OMum.Animals.Dto;

namespace OMum.Web.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalAppService _animalAppService;
        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }
        public ActionResult Index()
        {
            AddAnimal();
            return View();
        }

        public void AddAnimal()
        {
            _animalAppService.CreateAnimal(new CreateAnimalInput { Name = "猫" });
        }
    }
}