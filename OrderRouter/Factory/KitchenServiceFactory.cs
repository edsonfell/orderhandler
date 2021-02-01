using services.Kitchen;

namespace Factory
{
    public static class KitchenServiceFactory
    {
        public static IKitchenService createKitchenService(int kitchenArea)
        {   
            switch(kitchenArea)
            {
                case 1: 
                    return new KitchenBurguersService();
                case 2:
                    return new KitchenFriesService();
                case 3:
                    return new KitchenDessertsService();
                default:
                    // Throwing an exception in case the id is not valid;
                    throw new System.Exception("Invalid KitchenAreaId");
            }
        }
    }
}