


using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace api;


public class GetAllTests : IClassFixture<WebApplicationFactory<Program>>
{

}






// public class GetALLTest
// {
//     private readonly Mock<ApplicationDBContext> _mockRepository;
//     private readonly StockController _controller;

//     public GetALLTest()
//     {
//         _mockRepository = new Mock<ApplicationDBContext>();
//         _controller = new StockController(_mockRepository.Object);
//     }

//     [Fact]
//     public async Task GetAllByController()
//     {
//         var stock = new StockDto{
//             Id = 2, 
//             CompanyName = "Tesla",
//             Industry = "Auto",
//             Symbol = "TSLA",
//             Purchase = 32,
//             LastDiv = 33,
//             MarketCap = 232342
//             };
//             _controller.GetById();

//     }


// }


//устновка рсширегий
// dotnet add package xunit
// dotnet add package xunit.runner.visualstudio
// dotnet add package Microsoft.NET.Test.Sdk
