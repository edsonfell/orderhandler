using System;
using System.Collections.Generic;
using Models;
using services;
using services.Kitchen;
using Xunit;

namespace OrderRouter.Tests
{
    public class KitchenTest
    {
        //Global Arrange
        static List<Product> products = new List<Product>() 
            {
                new Product 
                {
                    ProductId = 1,
                    OrderId = 1,
                    IsReady = false,
                    KitchenAreaId = 1
                },
                new Product 
                {
                    ProductId = 2,
                    OrderId = 1,
                    IsReady = false,
                    KitchenAreaId = 2
                }

            };
            Order newOrder = new Order 
            {
                OrderId = 1,
                IsReady = false,
                Products = products,
            };

        //As I am just simulating the kitchens process, I will test
        //only one function because they are all the same for each kitchen area
        //and it just execute the function UpdateOrderStatus wich already was tested.
        [Fact]
        public void PrepareProductTest()
        {   
            //Arrange
            OrdersHandlerService.SendToKitchen(this.newOrder);
            Product product = new Product 
            {
                ProductId = 1,
                OrderId = 1,
                IsReady = false,
                KitchenAreaId = 1
            };
            KitchenBurguersService burguerKitchenService = new KitchenBurguersService();

            //Act
            burguerKitchenService.PrepareProduct(product);
            bool isReady = OrdersHandlerService._orders.Find(
                o => o.OrderId == product.OrderId).Products
                .Find(p => p.ProductId == product.ProductId).IsReady;

            //Assert            
            Assert.True(isReady);
        }
    }
}