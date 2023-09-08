using AlternativesToAutoMapper.Models;

namespace AlternativesToAutoMapper.Dtos;

public class VehicleDto
{
    public string Plate { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public int Year { get; set; }

    public int VehicleAge { get; set; }

    public static VehicleDto FromVehicle(Vehicle vehicle)
    {
        return new VehicleDto
        {
            Brand = vehicle.Brand,
            Price = vehicle.Price,
            Year = vehicle.Year,
            Plate = vehicle.Plate,
        };
    }
}
