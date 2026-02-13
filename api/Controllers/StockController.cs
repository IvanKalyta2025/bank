
using Microsoft.AspNetCore.Mvc;
using api.Data;

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
            var stocks = _applicationDBContext.Stocks.ToList();

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
                return Ok(stock);
            }
        }
    }
}

//The ControllerBase class is a base class for controllers in ASP.NET Core that handles HTTP requests. It provides a set of common properties and methods controllers use to handle HTTP requests and generate HTTP responses.
