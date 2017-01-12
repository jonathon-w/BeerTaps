namespace BeerTaps.ApiServices
{
	public class BeerTapLinkParameter
	{
		public BeerTapLinkParameter(int officeId)
		{
			OfficeId = officeId;
		}
		public int OfficeId { get; private set; }
	}
}
