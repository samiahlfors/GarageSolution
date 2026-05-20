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

    [Fact]
    public void ParkVehicle_ShouldFail_WhenGarageIsFull()
    {
        // NOTE: See how these could be done better
        
        // Arrange
        var garage = new Garage<Vehicle>("Globengaraget", 3);
        var handler = new GarageHandler<Vehicle>(garage);
        var car1 = new Car { LicencePlate = $"ABC123", Brand = "Volvo", Model = "V40" };
        var car2 = new Car { LicencePlate = $"DEF456", Brand = "Volvo", Model = "V60" };
        var car3 = new Car { LicencePlate = $"GHI789", Brand = "Volvo", Model = "V70" };
        var car4 = new Car { LicencePlate = $"AAA111", Brand = "Volvo", Model = "V90" };
        
        // Act
        var success1 = handler.ParkVehicle(car1);
        var success2 = handler.ParkVehicle(car2);
        var success3 = handler.ParkVehicle(car3);
        
        var fail1 = handler.ParkVehicle(car4);
        
        // Assert
        Assert.True(success1, "First car, should park successfully");
        Assert.True(success2, "Second car, should park successfully");
        Assert.True(success3, "Third car, should park successfully");
    
        Assert.False(fail1, "Fourth car should fail to park because the garage is full");
    }
}