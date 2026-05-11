using System.Text.Json;
using System.Text.Json.Serialization;
using Garage.Application;
using Garage.Application.DTOs;
using Garage.Application.Services;
using Garage.Domain;
using Garage.Domain.Enums;
using Garage.Domain.Vehicles;
using Garage.Views;

namespace Garage;

class Program
{
    static void Main(string[] args)
    {
        var appState = new AppState();
        var navigation = new Navigation();
        
        Initialize(appState);
        
        navigation.NavigateTo(new MainMenuView(appState, navigation));

        while (navigation.CurrentView != null)
        {
            navigation.CurrentView.Render();
        }
    }

    private static void Initialize(AppState appState)
    {
        var json = StorageService.Load();
        
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        var data = JsonSerializer.Deserialize<AppStateDto>(json, options)
                   ?? new AppStateDto();

        foreach (var garageDto in data.Garages)
        {
            var name = garageDto.Name;
            var capacity = garageDto.Capacity;

            var garage = new Domain.Garage(name, capacity);
            appState.Garages.Add(garage);

            foreach (var parkingSpot in garageDto.ParkingSpots)
            {
                var vehicleDto = parkingSpot.Vehicle;
                if (vehicleDto == null) continue;
                
                var type = vehicleDto.VehicleType;
                var vehicle = Vehicle.CreateVehicle((int)type);
                vehicle.LicencePlate = vehicleDto.LicencePlate;
                vehicle.Brand = vehicleDto.Brand;
                vehicle.Model = vehicleDto.Model;
                vehicle.Color = vehicleDto.Color;
                    
                garage.ParkVehicle(vehicle);
            }
        }
    }
}