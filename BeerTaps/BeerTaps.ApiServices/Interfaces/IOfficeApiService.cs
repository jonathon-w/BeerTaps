using BeerTaps.Model.Resources;
using IQ.Platform.Framework.WebApi;

namespace BeerTaps.ApiServices.Interfaces
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>,
        ICreateAResourceAsync<Office, int>,
        IUpdateAResourceAsync<Office, int>,
        IDeleteResourceAsync<Office, int>
    {
    }
}
