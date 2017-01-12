using System.Web.Http;
using BeerTaps.WebApi.Infrastructure;

namespace BeerTaps.WebApi
{

    public class HttpServerFactory
    {
        public HttpServer Create()
        {
            return new HttpServer(GetHttpConfiguration());
        }

        private static HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            BootStrapper.Initialize(config);
            return config;
        }
    }
}