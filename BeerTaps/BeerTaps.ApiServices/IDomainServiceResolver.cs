using System;
using BeerTaps.Domain;
using BeerTaps.Services;
using IQ.Platform.Framework.Common;

namespace BeerTaps.ApiServices
{
    public interface IDomainServiceResolver : IResolve<IBeerTapsService>
	{
        IDomainService Resolve(Type requestedServiceType);

        TService Resolve<TService>()
            where TService : IDomainService;
    }
}

namespace BeerTaps.Services
{
    /// <summary> 
    /// Represents a specific domain service / repository used in IApiApplicationService implementations 
    /// </summary> 
    public interface IDomainService
    {
    }
}
