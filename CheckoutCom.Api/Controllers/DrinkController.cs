using System.Web.Http;
using CheckoutCom.BusinessLogic.DTO;
using CheckoutCom.BusinessLogic.Services;
using CheckoutCom.DataAccess.Models;

namespace CheckoutCom.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class DrinkController : ApiController
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        [Route("drinks")]
        public IHttpActionResult GetAll()
        {
            var drinks = _drinkService.GetDrinks();
            return Ok(new DrinkList { Drinks = drinks });
        }

        [HttpGet]
        [Route("drink/{name}")]
        public IHttpActionResult Get(string name)
        {
            var drink = _drinkService.GetDrinkByName(name);
            return Ok(drink);
        }

        [HttpDelete]
        [Route("drink/{name}")]
        public IHttpActionResult Delete(string name)
        {
            _drinkService.RemoveDrink(name);
            return Ok();
        }

        [HttpPost]
        [Route("drinks")]
        public IHttpActionResult Add(DrinkDTO drink)
        {
            _drinkService.AddDrink(drink);
            return Ok();
        }

        [HttpPut]
        [Route("drink/{name}")]
        public IHttpActionResult Update(string name, DrinkDTO drink)
        {
            _drinkService.UpdateDrinkQuantity(name, drink.Quantity);
            return Ok();
        }
    }
}