using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DBStoreContext.Models;
using ModelsLayer.EFModels;
using System.Threading.Tasks;
using ModelsLayer.Models;
using System.Collections.Generic;
using System.Linq;
using OnlineStoreBusinessLayer.Interfaces;
using OnlineStoreUi.Controllers;

namespace OnlineStore.Tests
{
	public class UnitTest1
	{
		//public DbContextOptions<OnlineStoreDBContext> options { get; set; } = new DbContextOptionsBuilder<OnlineStoreDBContext>()
		//	.UseInMemoryDatabase(databaseName: "TestDb")
		//	.Options;

		//[Fact]
		//public async void OrderListReturnsCorrectList()
		//{
		//	// ARRANGE
		//	// create a mock of teh OrderRepository dependency
		//	IOrderRepository repoMock = new OrderRepositoryMock();

		//	// grab the logger service
		//	var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
		//	var factory = serviceProvider.GetService<ILoggerFactory>();
		//	var _logger = factory.CreateLogger<OrderController>();

		//	//send both the mock and service into the controller to instantiate it.
		//	OrderController cc = new OrderController(repoMock, _logger);

		//	// ACT
		//	List<ViewModelOrder> result = await cc.GetOrderList(result);

		//	// ASSERT
		//	Assert.Equal(1, result[0].OrderId);

		//}

	}
}
