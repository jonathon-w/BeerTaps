using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTaps.ApiServices.Security
{

    public class BeerTapsApiUser : ApiUser<UserAuthData>
    {
        public BeerTapsApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class BeerTapsUserFactory : ApiUserFactory<BeerTapsApiUser, UserAuthData>
    {
        public BeerTapsUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override BeerTapsApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new BeerTapsApiUser("BeerTaps user", auth);
        }
    }

}
