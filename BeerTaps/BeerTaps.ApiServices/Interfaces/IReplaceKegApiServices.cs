using BeerTaps.Model.Resources;
using IQ.Platform.Framework.WebApi;

namespace BeerTaps.ApiServices.Interfaces
{
	public interface IReplaceKegApiServices :
		IGetAResourceAsync<ReplaceKeg, int>,
		IGetManyOfAResourceAsync<ReplaceKeg, int>,
		IUpdateAResourceAsync<ReplaceKeg, int>
	{
	}
}