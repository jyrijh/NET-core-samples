namespace FactoryPattern.Samples;

public interface ISample2
{
	int RandomValue { get; init; }
}

public class Sample2 : ISample2
{
	public int RandomValue { get; init; }
	public Sample2()
	{
		RandomValue = Random.Shared.Next(1, 101);
	}
}
