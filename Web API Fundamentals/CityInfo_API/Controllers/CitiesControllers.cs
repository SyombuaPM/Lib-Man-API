using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc; // Add this using directive

namespace CityInfo_API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
         
        }

        [HttpGet("{id}")]

        public ActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }


        //public JsonResult GetCity(int id)
        //{
           // return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        //}
    }
}