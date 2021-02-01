using Models;

namespace services.Kitchen
{
    public class KitchenDessertsService : IKitchenService
    {
        public void PrepareProduct(Product product)
        {
            // This function is to simulate that cook in the kitchen system
            // would be communicate with the OrderHandler to
            // notify that the one product of the order is ready
            OrdersHandlerService.UpdateOrderStatus(product);
        }
    }
}