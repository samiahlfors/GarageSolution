using Garage.Domain;

namespace Garage.Application.DTOs;

public class GarageDto
{
    public string Name { get; set; } = "";
    public int Capacity { get; set; }
    public ParkingSpotDto[] ParkingSpots { get; set; } = [];
}