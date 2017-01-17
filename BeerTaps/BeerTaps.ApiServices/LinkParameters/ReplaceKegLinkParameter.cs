namespace BeerTaps.ApiServices.LinkParameters
{
	public class ReplaceKegLinkParameter
	{
		public ReplaceKegLinkParameter(int officeId, int beerTapId)
		{
			OfficeId = officeId;
			BeerTapId = beerTapId;
		}

		public int OfficeId { get; set; }
		public int BeerTapId { get; set; }
	}
}