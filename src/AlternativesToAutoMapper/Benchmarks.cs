using AlternativesToAutoMapper.Dtos;
using AlternativesToAutoMapper.Models;
using AutoMapper;
using BenchmarkDotNet.Attributes;

namespace AlternativesToAutoMapper;

public class Benchmarks
{
    private Vehicle[]? _vehicles;
    private IMapper? _mapper;

    [Params(10, 100, 1000)]

    public int NumberOfElements { get; set; }

    [GlobalSetup]
    public void Init()
    {
        var config = new MapperConfiguration(cfg
            => cfg.CreateMap<Vehicle, VehicleDto>()
            .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.VehicleAge, opt => opt.MapFrom(src => DateTime.UtcNow.Year - src.Year)));


        _mapper = config.CreateMapper();

        _vehicles = Enumerable.Range(1, NumberOfElements)
            .Select(n => new Vehicle
            {
                Id = new Guid(),
                Brand = "Huyndai",
                Color = "Black",
                Model = "HB20 Confort Plus",
                Plate = "AAA0101",
                Price = 60.99m,
                Year = 2019

            }).ToArray();
    }

    [Benchmark]
    public void With_AutoMapper()
    {
        ArgumentNullException.ThrowIfNull(_vehicles);
        ArgumentNullException.ThrowIfNull(_mapper);

        foreach (var vehicle in _vehicles)
        {
            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
        }
    }

    [Benchmark]
    public void Without_AutoMapper_Direct_Assignment()
    {
        ArgumentNullException.ThrowIfNull(_vehicles);

        foreach (var vehicle in _vehicles)
        {
            var vehicleDto = vehicle.ToVehicleDto();
        }
    }

    [Benchmark]
    public void Without_AutoMapper_With_Implicit_Operator()
    {
        ArgumentNullException.ThrowIfNull(_vehicles);

        foreach (var vehicle in _vehicles)
        {
            VehicleDto vehicleDto = vehicle;
        }
    }
}
