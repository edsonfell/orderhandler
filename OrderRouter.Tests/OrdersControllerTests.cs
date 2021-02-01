using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Xunit;

namespace OrderRouter.Tests
{
    public class OrdersControllerTests
    {

        [Fact]
        public void HttpPostTestSuccess()
        {
            //Arrange
            List<Product> products = new List<Product>() 
            {
                new Product 
                {
                    ProductId = 1,
                    KitchenAreaId = 1
                },
                new Product 
                {
                    ProductId = 2,
                    KitchenAreaId = 2
                }

            };
            Order newOrder = new Order 
            {
                Products = products,
            };
            var ordersController = new OrdersController();

            //Act
            var response = ordersController.Post(newOrder);

            //Assert
            Assert.IsType<Task<ActionResult<Order>>>(response);
        }
    }
}