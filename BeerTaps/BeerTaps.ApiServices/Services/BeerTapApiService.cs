using System;
using System.Collections.Generic;
using System.Linq;
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

	    private static int EnsureOfficeIdIsSetInContext(IRequestContext context)
	    {
			var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
			var linkParameter = new BeerTapLinkParameter(officeId);
			context.LinkParameters.Set(linkParameter);

		    return officeId;
	    }

        public Task<BeerTap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
	        var officeId = EnsureOfficeIdIsSetInContext(context);
			
			// Grab and return the BeerTap associated with the officeId and id
	        BeerTap beerTapToReturn = _toResourceMapper.Map(_beerTapService.Get(officeId, id));

	        return Task.FromResult(beerTapToReturn);
        }

        public Task<IEnumerable<BeerTap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
			var officeId = EnsureOfficeIdIsSetInContext(context);

	        return Task.FromResult(_beerTapService.GetAllAtOfficeId(officeId).Select(_toResourceMapper.Map));

	        //return Task.FromResult(_beerTapService.GetAll().Select(_toResourceMapper.Map));
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