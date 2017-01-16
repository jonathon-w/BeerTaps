using BeerTaps.Model.Resources;
using IQ.Platform.Framework.WebApi;

namespace BeerTaps.ApiServices.Interfaces
{
	public interface IReplaceKegApiServices :
		IGetManyOfAResourceAsync<ReplaceKeg, int>,
		IUpdateAResourceAsync<ReplaceKeg, int>
	{
	}
}