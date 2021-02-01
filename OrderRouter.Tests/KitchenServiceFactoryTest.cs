using System;
using Factory;
using services.Kitchen;
using Xunit;

namespace OrderRouter.Tests
{
    public class KitchenServiceFactoryTest
    {   
        //Global Arrange;
        int burguerId = 1;
        int friesId = 2;
        int dessertsId = 3;
        int invalidId = 0;

        [Fact]
        public void createBurguerKitchenTest()
        {
            //Act
            var kitchen = KitchenServiceFactory.createKitchenService(burguerId);

            //Assert
            Assert.IsType<KitchenBurguersService>(kitchen);
        }

        [Fact]
        public void createFriesKitchenTest()
        {
            //Act
            var kitchen = KitchenServiceFactory.createKitchenService(friesId);

            //Assert
            Assert.IsType<KitchenFriesService>(kitchen);
        }

        [Fact]
        public void createDessertKitchenTest()
        {
            //Act
            var kitchen = KitchenServiceFactory.createKitchenService(dessertsId);

            //Assert
            Assert.IsType<KitchenDessertsService>(kitchen);
        }

        [Fact]
        public void simulateWrongKitchenIdTest()
        {
            //Act and Assert
            Assert.Throws<Exception>(() => KitchenServiceFactory.createKitchenService(invalidId));
        }
    }
}