namespace BeerTaps.ApiServices.LinkParameters
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
