using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTaps.ApiServices;
using BeerTaps.ApiServices.Interfaces;
using BeerTaps.Domain.Models;
using BeerTaps.Domain.Services;
using BeerTaps.Model.Resources;
using BeerTaps.ApiServices.Interfaces;
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

		private static int EnsureOfficeIdIsSetInContext(IRequestContext context)
		{
			var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
			var beerTapId = context.UriParameters.GetByName<int>("BeerTapId").EnsureValue();
			var linkParameter = new ReplaceKegLinkParameter(officeId, beerTapId);
			context.LinkParameters.Set(linkParameter);

			return officeId;
		}

		public Task<ReplaceKeg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ReplaceKeg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
		{
			EnsureOfficeIdIsSetInContext(context);

			return Task.FromResult(_replaceKegService.GetAll().Select(_toResourceMapper.Map));
		}

		public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
		{
			throw new NotImplementedException();
		}

		// Remember to enter the ReplaceKeg parameters in question (OfficeId and Id in particular) into the "Body" tab in Postman
		public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
		{
			EnsureOfficeIdIsSetInContext(context);

			throw new NotImplementedException();
		}

		public Task DeleteAsync(ResourceOrIdentifier<ReplaceKeg, int> input, IRequestContext context, CancellationToken cancellation)
		{
			throw new NotImplementedException();
		}
	}
}