
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Mappers;
using api.Dtos.Stock;
using System.IO.Compression;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Repository;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDBContext applicationDBContext, IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _applicationDBContext = applicationDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();

            var stockDto = stocks.Select(a => a.ToStockDto());

            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock.ToStockDto());
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStockFromDto([FromBody] CreateStockRequestDto stockDtoRequest)
        {
            var stockModel = stockDtoRequest.ToStockFromCreateDTO();
            await _applicationDBContext.Stocks.AddAsync(stockModel);
            await _applicationDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockRequestDto)
        {
            var stockModel = await _applicationDBContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateStockRequestDto.Symbol;
            stockModel.CompanyName = updateStockRequestDto.CompanyName;
            stockModel.Purchase = updateStockRequestDto.Purchase;
            stockModel.LastDiv = updateStockRequestDto.LastDiv;
            stockModel.Industry = updateStockRequestDto.Industry;
            stockModel.MarketCap = updateStockRequestDto.MarketCap;
            await _applicationDBContext.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _applicationDBContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }
            _applicationDBContext.Stocks.Remove(stockModel);
            await _applicationDBContext.SaveChangesAsync();
            return NoContent(); //fordi etter å slette noe, vår result det er ingenting.
        }
    }
}

//The ControllerBase class is a base class for controllers in ASP.NET Core that handles HTTP requests. It provides a set of common properties and methods controllers use to handle HTTP requests and generate HTTP responses.
