
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Mappers;
using api.Dtos.Stock;
using System.IO.Compression;
using api.Models;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public StockController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _applicationDBContext.Stocks.ToList()
            .Select(a => a.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _applicationDBContext.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock.ToStockDto());
            }
        }
        [HttpGet("bymarker/{marker}")]
        public IActionResult GetByMarker([FromRoute] string marker)
        {
            var stock = _applicationDBContext.Stocks.Find(marker);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock.ToStockDtoWithMarkerIndificator());
            }
        }
        [HttpPost]
        public IActionResult CreateStockFromDto([FromBody] CreateStockRequestDto stockDtoRequest)
        {
            var stockModel = stockDtoRequest.ToStockFromCreateDTO();
            _applicationDBContext.Stocks.Add(stockModel);
            _applicationDBContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());

        }
        // [HttpPut]
        // [Route("{id}")]
        // public IActionResult  Update([FromRoute] int id, [FromBody]UpdateStockRequestDto updateStockRequestDto)

        // {
        //     var stockModel = _applicationDBContext.Stocks.FirstOrDefault(x => x.Id == id);
        //     if (stockModel == null)
        //     {
        //         return  NotFound();
        //     }
        //     stockModel.Symbol = updateStockRequestDto 
        // }
    }
}

//The ControllerBase class is a base class for controllers in ASP.NET Core that handles HTTP requests. It provides a set of common properties and methods controllers use to handle HTTP requests and generate HTTP responses.
