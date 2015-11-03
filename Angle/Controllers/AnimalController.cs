using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OMum.Animals;

namespace Angle.Controllers
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
            QueryAnimalCount();
            return View();
        }
        public async Task<int> QueryAnimalCount()
        {
            int x = await _animalAppService.QueryCount();
            return x;
        }
	}
}