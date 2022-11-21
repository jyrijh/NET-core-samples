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

    public Worker(ISample1 sample1, Func<ISample1> sample2, IAbstractFactory<ISample1> factory, IAbstractFactory<ISample2> factory2, IUserDataFactory userDataFactory)
    {
        _sample1 = sample1; // gets instance from DI
        _sample2 = sample2; // x.GetRequiredService<ISample1>()
        _factory1 = factory;
        _factory2 = factory2;
        _userDataFactory = userDataFactory;
    }

    public async Task RunAsync()
    {
        Console.WriteLine($"ISample1:          {_sample1.CurrentDateTime}");
        await OdotaAsync(1);
        Console.WriteLine($"Func<ISample1>:    {_sample2().CurrentDateTime}");
        await OdotaAsync(1);
        Console.WriteLine($"Func<ISample1>:    {_sample2().CurrentDateTime}");
        await OdotaAsync(1);
        Console.WriteLine($"_factory.Create(): {_factory1.Create().CurrentDateTime} {_factory2.Create().RandomValue}");
        await OdotaAsync(1);
        Console.WriteLine($"_factory.Create(): {_factory1.Create().CurrentDateTime} {_factory2.Create().RandomValue}");
        await OdotaAsync(1);
        Console.WriteLine($"_userDataFactory.Create(\"Mick\"): {_userDataFactory.Create("Mick").Name}");
    }

    private static async Task OdotaAsync(int sec)
    {
        await Task.Delay(sec * 1000);
    }
}