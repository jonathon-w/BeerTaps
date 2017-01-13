using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.Model.Resources
{
	/// <summary>
	/// ReplaceKeg resource, for offering choices on different beers
	/// </summary>
	public class ReplaceKeg : IStatelessResource, IIdentifiable<int>
	{
		public int Id { get; set; }
		/// <summary>
		/// BeerName of the beer in this keg
		/// </summary>
		public string BeerName { get; set; }
		/// <summary>
		/// TotalVolume of this keg
		/// </summary>
		public int TotalVolume { get; set; }
		/// <summary>
		/// CurrentVolume on a new keg always equals TotalVolume
		/// </summary>
		public int CurrentVolume { get; set; }
	}
}
