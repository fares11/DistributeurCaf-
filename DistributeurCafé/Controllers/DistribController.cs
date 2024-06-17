using DistributeurCafé.Interface;
using DistributeurCafé.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistributeurCafé.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDistribService _drinkService;

        public DrinksController(IDistribService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public ActionResult<List<Drink>> Get()
        {
            return _drinkService.GetDrinks();
        }
    }
}
