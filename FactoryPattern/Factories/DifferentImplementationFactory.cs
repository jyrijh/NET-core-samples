using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories;

public static class DifferentImplementationFactoryExtensions
{
    public static void AddVehicleFactory(this IServiceCollection services)
    {
        services.AddTransient<IVehicle, Car>();
        services.AddTransient<IVehicle, Truck>();
        services.AddTransient<IVehicle, Van>();

        services.AddSingleton<Func<IEnumerable<IVehicle>>>(x => () => x.GetService<IEnumerable<IVehicle>>()!);
        
        services.AddSingleton<IVehicleFactory, VehicleFactory>();
    }
}

public interface IVehicleFactory
{
    IVehicle Create(string name);
}

public class VehicleFactory : IVehicleFactory
{
    private readonly Func<IEnumerable<IVehicle>> _factory;

    public VehicleFactory(Func<IEnumerable<IVehicle>> factory)
    {
        _factory = factory;
    }

    public IVehicle Create(string name)
    {
        var set = _factory();
        IVehicle output = set.Where(x => x.VehicleType == name).First();
        return output;
    }
}


public interface IVehicle
{
    string VehicleType { get; set; }

    string Start();
}

public class Car : IVehicle
{
    public string VehicleType { get; set; } = "Car";
    public string Start()
    {
        return "The car has been started";
    }
}

public class Truck : IVehicle
{
    public string VehicleType { get; set; } = "Truck";
    public string Start()
    {
        return "The truck has been started";
    }
}

public class Van : IVehicle
{
    public string VehicleType { get; set; } = "Van";
    public string Start()
    {
        return "The van has been started";
    }
}