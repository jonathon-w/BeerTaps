namespace BeerTaps.Domain.Models
{
	public class ReplaceKegDto
	{
		public int KegId { get; set; }
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