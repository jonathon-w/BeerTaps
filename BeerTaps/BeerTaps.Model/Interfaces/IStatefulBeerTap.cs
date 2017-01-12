using BeerTaps.Model.States;

namespace BeerTaps.Model.Interfaces
{
    public interface IStatefulBeerTap
    {
        /// <summary>
        /// Interface allowing state getter
        /// </summary>
        KegState KegState { get; }
    }
}
