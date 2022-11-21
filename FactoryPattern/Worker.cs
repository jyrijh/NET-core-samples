using FactoryPattern.Factories;
using FactoryPattern.Samples;

namespace FactoryPattern;

public class Worker
{
    ISample1 _sample1;
    Func<ISample1> _sample2;
    IAbstractFactory<ISample1> _factory1;
    IAbstractFactory<ISample2> _factory2;
    IUserDataFactory _userDataFactory;
    IVehicleFactory _vehicleFactory;
    IParameterFactory _parameterFactory;

    public Worker(ISample1 sample1, Func<ISample1> sample2, IAbstractFactory<ISample1> factory, IAbstractFactory<ISample2> factory2, IUserDataFactory userDataFactory, IVehicleFactory vehicleFactory, IParameterFactory parameterFactory)
    {
        _sample1 = sample1; // gets instance from DI
        _sample2 = sample2; // x.GetRequiredService<ISample1>()
        _factory1 = factory;
        _factory2 = factory2;
        _userDataFactory = userDataFactory;
        _vehicleFactory = vehicleFactory;
        _parameterFactory = parameterFactory;
    }

    public async Task RunAsync()
    {
        Console.WriteLine($"ISample1:          {_sample1.CurrentDateTime}");
        await OdotaAsync(1);
        Console.WriteLine($"Func<ISample1>:    {_sample2().CurrentDateTime}");
        await OdotaAsync(1);
        Console.WriteLine($"Func<ISample1>:    {_sample2().CurrentDateTime}");

        Console.WriteLine($"_factory.Create(): {_factory1.Create().CurrentDateTime} {_factory2.Create().RandomValue}");
        await OdotaAsync(1);
        Console.WriteLine($"_factory.Create(): {_factory1.Create().CurrentDateTime} {_factory2.Create().RandomValue}");

        Console.WriteLine($"_userDataFactory.Create(\"Mick\"): {_userDataFactory.Create("Mick").Name}");

        Console.WriteLine($"_vehicleFactory.Create(\"Car\"): {_vehicleFactory.Create("Car").Start()}");

        using var t = _parameterFactory.Create("1", "One");
        Console.WriteLine($"_parameterFactory.Create: {t.Name}");
        var t2 = _parameterFactory.Create("2", "two");
        Console.WriteLine($"_parameterFactory.Create: {t2}");
        t2 = null;
    }

    private static async Task OdotaAsync(int sec)
    {
        await Task.Delay(sec * 1000);
    }
}