using System;
using System.Collections.Generic;
using System.Linq;
using Factory;
using Models;

namespace services
{
    public static class OrdersHandlerService
    {
        public static List<Order> _orders = new List<Order>();

        // Generate an ID to the order based on the list size;
        public static int OrderIdGerator()
        {
            return _orders.Count + 1;
        }

        // Distribute the order's products to it respective area in the kitchen
        public static void SendToKitchen(Order newOrder)
        {
            //Add to the global list representing the database/orders queue.
            _orders.Add(newOrder);

            DistributeProductsToKitchenArea(newOrder);
        }

        public static void UpdateOrderStatus(Product product)
        {
            try
            {

                //Updating the "IsReady" property of the product
                _orders.Find(
                    o => o.OrderId == product.OrderId).Products
                    .Find(p => p.ProductId == product.ProductId).IsReady = true;

                // Searching how many products aren't ready yet
                int totalNotReady = _orders.Find(
                    o => o.OrderId == product.OrderId).Products
                    .FindAll(p => p.IsReady == false).Count();

                // If all products are ready, we set IsReady for the Order object as true
                if (totalNotReady == 0)
                    _orders.Find(
                    o => o.OrderId == product.OrderId).IsReady = true;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Error while updating order's status.");
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected Exception while updating order's status. Detail: +" + ex.Message);
            }
        
        }

        // Won't be tested since it's a private function
        private static void DistributeProductsToKitchenArea(Order newOrder)
        {
            try
            {
                foreach (Product product in newOrder.Products)
                {
                    var kitchenArea = KitchenServiceFactory.createKitchenService(product.KitchenAreaId);
                    kitchenArea.PrepareProduct(product);
                }
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Error while distributing the order");
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected Exception while distributing the order. Detail: +" + ex.Message);
            }
        }
    }
}