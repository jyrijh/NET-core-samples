using FactoryPattern.Samples;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryPattern.Factories;

public static class GenerateClassWithDataFactory
{
    public static void AddGenericClassWithDataFactory(this IServiceCollection services)
    {
        services.AddTransient<IUserData, UserData>();
        services.AddSingleton<Func<IUserData>>(x => () => x.GetRequiredService<IUserData>());
        services.AddSingleton<IUserDataFactory, UserDataFactory>();
    }
}

public interface IUserDataFactory
{
    IUserData Create(string name);
}

public class UserDataFactory : IUserDataFactory
{
    private readonly Func<IUserData> _factory;

    public UserDataFactory(Func<IUserData> factory)
    {
        _factory = factory;
    }

    public IUserData Create(string name)
    {
        var userData = _factory();
        userData.Name = name;
        return userData;
    }
}
