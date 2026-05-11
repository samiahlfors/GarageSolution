using Garage.Domain.Enums;

namespace Garage.Application.DTOs;

public class VehicleDto
{
    public string LicencePlate { get; set; } = "";
    public string Model { get; set; } = "";
    public string Brand { get; set; } = "";
    public VehicleColor Color { get; set; } = VehicleColor.Black;
    public VehicleType VehicleType { get; set; } = VehicleType.Car;
    public int NumberOfWheels { get; set; } = 0;
}