using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTaps.ApiServices.Interfaces;
using BeerTaps.ApiServices.LinkParameters;
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
	    private readonly IMapper<BeerTap, BeerTapDto> _toTransportMapper;

        public BeerTapApiService(IBeerTapService beerTapService,
			IMapper<BeerTapDto, BeerTap> toResourceMapper,
			IMapper<BeerTap, BeerTapDto> toTransportMapper
			)
        {
	        _beerTapService = beerTapService;
	        _toResourceMapper = toResourceMapper;
	        _toTransportMapper = toTransportMapper;
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
			
	        return Task.FromResult(_toResourceMapper.Map(_beerTapService.Get(officeId, id)));
        }

        public Task<IEnumerable<BeerTap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
			var officeId = EnsureOfficeIdIsSetInContext(context);

	        return Task.FromResult(_beerTapService.GetAllAtOfficeId(officeId).Select(_toResourceMapper.Map));
        }

		// Remember to enter the BeerTap parameters in question (OfficeId and Id in particular) into the "Body" tab in Postman
        public Task<BeerTap> UpdateAsync(BeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
			EnsureOfficeIdIsSetInContext(context);

	        _beerTapService.Pour(resource.OfficeId, resource.Id);

	        return Task.FromResult(_toResourceMapper.Map(_beerTapService.Get(resource.OfficeId, resource.Id)));
        }
    }
}