using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTaps.ApiServices;
using BeerTaps.ApiServices.Interfaces;
using BeerTaps.ApiServices.LinkParameters;
using BeerTaps.Domain.Models;
using BeerTaps.Domain.Services;
using BeerTaps.Model.Resources;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Mapping;

namespace BeerTaps.ApiServices.Services
{
	public class ReplaceKegApiService : IReplaceKegApiServices
	{
		private readonly IReplaceKegService _replaceKegService;
		private readonly IMapper<ReplaceKegDto, ReplaceKeg> _toResourceMapper;
		private readonly IMapper<ReplaceKeg, ReplaceKegDto> _toTransportMapper;

		public ReplaceKegApiService(IReplaceKegService replaceKegService, IMapperFactory mapperFactory)
		{
			_replaceKegService = replaceKegService;
			_toResourceMapper = mapperFactory.Create<ReplaceKegDto, ReplaceKeg>();
			_toTransportMapper = mapperFactory.Create<ReplaceKeg, ReplaceKegDto>();
		}

		private static int EnsureIdsAreSetInContext(IRequestContext context)
		{
			var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
			var beerTapId = context.UriParameters.GetByName<int>("BeerTapId").EnsureValue();
			var linkParameter = new ReplaceKegLinkParameter(officeId, beerTapId);
			context.LinkParameters.Set(linkParameter);

			return officeId;
		}

		private static int GetOfficeId(IRequestContext context)
		{
			return context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
		}

		private static int GetBeerTapId(IRequestContext context)
		{
			return context.UriParameters.GetByName<int>("BeerTapId").EnsureValue();
		}

		public Task<ReplaceKeg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
		{
			EnsureIdsAreSetInContext(context);

			return Task.FromResult(_toResourceMapper.Map(_replaceKegService.Get(id)));
		}

		public Task<IEnumerable<ReplaceKeg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
		{
			EnsureIdsAreSetInContext(context);

			return Task.FromResult(_replaceKegService.GetAll().Select(_toResourceMapper.Map));
		}

		// Remember to enter the ReplaceKeg parameters in question (the Id in particular) into the "Body" tab in Postman
		public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
		{
			EnsureIdsAreSetInContext(context);
			var officeId = GetOfficeId(context);
			var beerTapId = GetBeerTapId(context);

			_replaceKegService.ReplaceKeg(officeId, beerTapId, resource.Id);

			return Task.FromResult(_toResourceMapper.Map(_replaceKegService.Get(resource.Id)));
		}
	}
}