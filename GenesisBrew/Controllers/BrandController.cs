using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GenesisBrew.Controllers
{
    [Route("v1/{Controller}")]
    public class BrandController : Controller
    {
        private IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetBreweries")]
        public async Task<IActionResult> GetBreweries()
        {
            return new OkObjectResult(await _brandService.GetBreweries());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Brewery/{breweryId}/beers")]
        public async Task<IActionResult> GetBreweryBeers(Guid breweryId)
        {
            return new OkObjectResult(await _brandService.GetBeers(breweryId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateBeer")]
        public async Task<IActionResult> CreateBeer([FromBody] Beer beer)
        {
            return new OkObjectResult(await _brandService.CreateBeer(beer));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("MarkBeerAsObsolete/{beerId}")]
        public async Task<IActionResult> MarkBeerAsObsolete(Guid beerId)
        {
            return new OkObjectResult(await _brandService.MarkBeerAsObsolete(beerId));
        }
    }
}
