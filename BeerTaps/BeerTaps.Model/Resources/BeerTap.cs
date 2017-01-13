using BeerTaps.Model.Interfaces;
using BeerTaps.Model.States;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.Model.Resources
{
    /// <summary>
    /// BeerTap resource with four states - Full, GoingDown, NearlyEmpty, Empty
    /// </summary>
    public class BeerTap : IStatefulResource<KegState>, IIdentifiable<int>, IStatefulBeerTap
    {
        /// <summary>
        /// Unique Identifier for the BeerTap
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the beer
        /// </summary>
        public string BeerName { get; set; }
		/// <summary>
		/// Total volume in mL
		/// </summary>
		public int TotalVolume { get; set; }
		/// <summary>
		/// Current volume in mL (less than or equal to TotalVolume)
		/// </summary>
		public int CurrentVolume { get; set; }
        /// <summary>
        /// State of the keg
        /// </summary>
        public KegState KegState { get; set; }
        /// <summary>
        /// ID for the office containing the BeerTap
        /// </summary>
        public int OfficeId { get; set; }
    }
}
