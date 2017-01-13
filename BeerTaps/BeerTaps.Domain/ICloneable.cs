namespace BeerTaps.Domain
{
	public interface ICloneable<out T>
	{
		T Clone();
	}
}