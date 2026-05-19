using Garage.Domain.Enums;

namespace Garage.Application;

public class VehicleFilter
{
    public List<VehicleColor> Colors { get; set; } = [];
    public List<string> Brands { get; set; } = [];

    public void Clear()
    {
        Colors.Clear();
        Brands.Clear();
    }
}