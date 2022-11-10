namespace FactoryPattern.Samples;

public interface ISample1
{
    string CurrentDateTime { get; init; }
}

public class Sample1 : ISample1
{
    public string CurrentDateTime { get; init; } = DateTime.Now.ToString();
}
