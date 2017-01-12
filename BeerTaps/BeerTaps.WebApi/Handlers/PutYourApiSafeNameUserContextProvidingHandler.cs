using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTaps.ApiServices.Security;

namespace BeerTaps.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<BeerTapsApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<BeerTapsApiUser> apiUserInRequestStore)
            : base(new BeerTapsUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<BeerTapsApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<BeerTapsApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}