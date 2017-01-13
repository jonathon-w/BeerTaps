using System;

namespace BeerTaps.Domain.Models
{
	public class BeerTapDto : ICloneable<BeerTapDto>
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
//		public KegState KegState { get; set; }
		/// <summary>
		/// ID for the office containing the BeerTap
		/// </summary>
		public int OfficeId { get; set; }

		/// <summary>
		/// Booleans to keep track of the keg's status
		/// </summary>
		public bool IsFull { get; set; }
		public bool IsGoingDown { get; set; }
		public bool IsNearlyEmpty { get; set; }
		public bool IsEmpty { get; set; }

		public BeerTapDto Clone()
		{
			var newBeerTap = new BeerTapDto()
			{
				Id = Id,
				BeerName = BeerName,
				OfficeId = OfficeId,
				TotalVolume = TotalVolume,
				CurrentVolume = CurrentVolume,
				IsFull = IsFull,
				IsGoingDown = IsGoingDown,
				IsNearlyEmpty = IsNearlyEmpty,
				IsEmpty = IsEmpty
			};

			return newBeerTap;
		}
	}
}