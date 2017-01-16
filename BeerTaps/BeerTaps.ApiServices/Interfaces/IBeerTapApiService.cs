using BeerTaps.Model.Resources;
using IQ.Platform.Framework.WebApi;

namespace BeerTaps.ApiServices.Interfaces
{
    public interface IBeerTapApiService :
        IGetAResourceAsync<BeerTap, int>,
        IGetManyOfAResourceAsync<BeerTap, int>,
        IUpdateAResourceAsync<BeerTap, int>
    {
    }
}