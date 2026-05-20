namespace Garage.Application.DTOs;

public class ParkingSpotDto
{
    public int SpotIndex { get; set; } = 0;
    public VehicleDto? Vehicle { get; set; } = null;
}