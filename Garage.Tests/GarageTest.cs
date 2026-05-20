using Garage.Application;
using Garage.Domain;
using Garage.Domain.Entities;
using Garage.Domain.Entities.Vehicles;

namespace Garage.Tests;

public class GarageTest
{
    [Fact]
    public void ParkVehicle_ShouldSucceed_WhenGarageHasEmptySpots()
    {
        // Arrange
        var garage = new Garage<Vehicle>("Globengaraget", 5);
        var handler = new GarageHandler<Vehicle>(garage);
        var car = new Car { LicencePlate = "ABC123", Brand = "Volvo", Model = "V70" };

        // Act
        var result = handler.ParkVehicle(car);

        // Assert
        Assert.True(result);
        Assert.Contains(car, handler.GetVehicles());
    }
}