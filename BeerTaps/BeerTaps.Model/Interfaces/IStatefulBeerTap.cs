using BeerTaps.Model.States;

namespace BeerTaps.Model.Interfaces
{
	/// <summary>
	/// Interface allowing state getter
	/// </summary>
    public interface IStatefulBeerTap
    {
        /// <summary>
        /// Interface allowing state getter
        /// </summary>
        KegState KegState { get; }
    }
}
