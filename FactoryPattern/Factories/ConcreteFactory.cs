using FactoryPattern.Samples;

namespace FactoryPattern.Factories;

public class GenerateClassWithDataFactory
{

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
