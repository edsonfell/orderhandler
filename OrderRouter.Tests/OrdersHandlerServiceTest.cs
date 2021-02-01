using System;
using System.Collections.Generic;
using Models;
using services;
using Xunit;

namespace OrderRouter.Tests
{   
    public class OrdersHandlerServiceTest
    {
        // Global Arrange
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

        //Checking if the total of orders in the list were increased by one.
        [Fact]
        public void SendToKitchenTest()
        {
            //Arrange
            int totalBeforeNewOrder = OrdersHandlerService._orders.Count;
            
            //Act
            OrdersHandlerService.SendToKitchen(this.newOrder);
            int totalAfterNewOrder = OrdersHandlerService._orders.Count;

            //Assert            
            Assert.Equal(totalBeforeNewOrder + 1, totalAfterNewOrder);

        } 

        [Fact]
        public void UpdateOrderStatusTest()
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

            //Act
            OrdersHandlerService.UpdateOrderStatus(product);
            bool isReady = OrdersHandlerService._orders.Find(
                o => o.OrderId == product.OrderId).Products
                .Find(p => p.ProductId == product.ProductId).IsReady;

            //Assert            
            Assert.True(isReady);

        }

        [Fact]
        public void OrderIdGeratorTest()
        {
            //Arrange
            OrdersHandlerService.SendToKitchen(this.newOrder);
            int actualLastOrderId = OrdersHandlerService._orders.Count;

            //Act
            int newId = OrdersHandlerService.OrderIdGerator();

            //Assert     
            Assert.Equal(actualLastOrderId + 1, newId);

        } 
    }
}