using API.Controllers.Base;
using Application.Interfaces;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ExampleController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService) : base()
        {
            _cityService = cityService;
        }


        [Route("[action]")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CityModel))]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetCities()
        {
            var cities = await _cityService.GetAll();

            return Ok(cities);
        }
    }
}
