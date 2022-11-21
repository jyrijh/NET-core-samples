using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parameter;

public static class ParameterFactoryExtensions
{
    public static void AddParameterFactory(this IServiceCollection services)
    {
        // registering is not necessary for these
        //services.AddTransient<ISomeService, SomeService1>();
        //services.AddTransient<ISomeService, SomeService2>();

        services.AddSingleton<IParameterFactory, ParameterFactory>();
    }
}

public interface IParameterFactory
{
    ISomeService Create(string servicetype, string name);
}

public class ParameterFactory : IParameterFactory
{
    IServiceProvider _provider;

    public ParameterFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ISomeService Create(string servicetype, string name) => servicetype switch
    {
        "1" => (ISomeService)ActivatorUtilities.CreateInstance(_provider, typeof(SomeService1), name),
        "2" => (ISomeService)ActivatorUtilities.CreateInstance(_provider, typeof(SomeService2), name),
        null => throw new ArgumentNullException(nameof(servicetype)),
        _ => throw new ArgumentException($"Unknown {servicetype}", nameof(servicetype))
    };
}

public interface ISomeService
{
    string Name { get; }
}

public class SomeService1 : ISomeService
{
    public string Name { get; }

    public SomeService1(string name)
    {
        Name = name;
    }

    ~SomeService1()
    {
        Console.WriteLine($"1 {Name}");
    }
}

public class SomeService2 : ISomeService
{
    public string Name { get; }

    public SomeService2(string name)
    {
        Name = name;
    }

    ~SomeService2()
    {
        Console.WriteLine($"2 {Name}");
    }
}
