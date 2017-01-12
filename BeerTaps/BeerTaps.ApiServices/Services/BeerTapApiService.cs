using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTaps.ApiServices.Interfaces;
using BeerTaps.ApiServices.Security;
using BeerTaps.Domain.Models;
using BeerTaps.Domain.Services;
using BeerTaps.Model.Resources;
using BeerTaps.Model.States;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTaps.ApiServices.Services
{
    public class BeerTapApiService : IBeerTapApiService
    {
//        readonly IApiUserProvider<BeerTapsApiUser> _userProvider;
	    private readonly IBeerTapService _beerTapService;
	    private readonly IMapper<BeerTapDto, BeerTap> _toResourceMapper;
//	    private readonly IMapper<BeerTap, BeerTapDto> _toTransportMapper;

        public BeerTapApiService(IBeerTapService beerTapService, IMapperFactory mapperFactory)
        {
	        _beerTapService = beerTapService;
	        _toResourceMapper = mapperFactory.Create<BeerTapDto, BeerTap>();
//	        _toTransportMapper = mapperFactory.Create<BeerTap, BeerTapDto>();
        }

        public Task<BeerTap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
	        var linkParameter = new BeerTapLinkParameter(officeId);
	        context.LinkParameters.Set(linkParameter);

			// Implement get using OfficeId and Id
	        BeerTap beerTapToReturn = _toResourceMapper.Map(_beerTapService.Get(officeId, id));

	        return Task.FromResult(beerTapToReturn);

//	        BeerTap b;
//	        if (id == 1)
//	        {
//				b = new BeerTap
//				{
//					Id = id,
//					BeerName = "Granville Island Pale Ale",
//					OfficeId = officeId,
//					KegState = KegState.Full
//				};
//			}
//	        else
//	        {
//				b = new BeerTap
//				{
//					Id = id,
//					BeerName = "Rebellion Stout",
//					OfficeId = officeId,
//					KegState = KegState.GoingDown
//				};
//			}
//			
//            return Task.FromResult(b);
        }

        public Task<IEnumerable<BeerTap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
			// Implement ViewAllKegs
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<BeerTap, int>> CreateAsync(BeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<BeerTap> UpdateAsync(BeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<BeerTap, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}