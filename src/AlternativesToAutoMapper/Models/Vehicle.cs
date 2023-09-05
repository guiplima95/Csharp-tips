using AlternativesToAutoMapper.Dtos;

namespace AlternativesToAutoMapper.Models;

public class Vehicle
{
    public Guid Id { get; set; }

    public string Plate { get; set; } = null!;

    public string? Color { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public decimal Price { get; set; }

    public VehicleDto ToVehicleDto()
    {
        return new VehicleDto
        {
            Brand = Brand,
            Plate = Plate,
            Price = Price,
            Year = Year,
        };
    }

    public static implicit operator VehicleDto(Vehicle vehicle)
    {
        return new VehicleDto
        {
            Brand = vehicle.Brand,
            Plate = vehicle.Plate,
            Price = vehicle.Price,
            Year = vehicle.Year,
        };
    }
}
