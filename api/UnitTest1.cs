using Xunit;
using api.Data;
using Moq;
using api.Controllers;



namespace api;


public class GetALLTest
{
    private readonly Mock<ApplicationDBContext> _mockRepository;
    private readonly StockController _controller;

    public GetALLTest()
    {
        _mockRepository = new Mock<ApplicationDBContext>();
        _controller = new StockController(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllByController()
    {

    }


}


//устновка рсширегий
// dotnet add package xunit
// dotnet add package xunit.runner.visualstudio
// dotnet add package Microsoft.NET.Test.Sdk
