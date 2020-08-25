using System;
using System.Threading.Tasks;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenesisBrew.Controllers
{
    [Route("v1/{Controller}")]
    public class WholesalerController : Controller
    {
        private IWholesalerService _wholesalerService;
        public WholesalerController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetWholesalers")]
        public async Task<IActionResult> GetWholesalersByItem()
        {
            return new OkObjectResult(await _wholesalerService.GetWholesalers());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{wholesalerId}")]
        public async Task<IActionResult> GetWholesalerStock(Guid wholesalerId)
        {
            return new OkObjectResult(await _wholesalerService.GetWholesalerStock(wholesalerId));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("StockItem/{itemId}")]
        public async Task<IActionResult> GetWholesalersByItem(Guid itemId)
        {
            return new OkObjectResult(await _wholesalerService.GetWholesalersByBeerId(itemId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateStockItem")]
        public async Task<IActionResult> CreateStockItem([FromBody] BeerStockItem stockItem)
        {
            return new OkObjectResult(await _wholesalerService.CreateStockItem(stockItem));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("UpdateStockItem")]
        public async Task<IActionResult> UpdateStockItem([FromBody] BeerStockItem stockItem)
        {
            return new OkObjectResult(await _wholesalerService.UpdateStockItem(stockItem));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetQuote")]
        public async Task<IActionResult> GetQuote([FromBody] QuoteRequest request)
        {
            return new OkObjectResult(await _wholesalerService.GenerateQuote(request));
        }
    }
}
