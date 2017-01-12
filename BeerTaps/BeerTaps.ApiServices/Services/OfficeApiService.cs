using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTaps.ApiServices.Interfaces;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTaps.ApiServices.Security;
using BeerTaps.Domain.Models;
using BeerTaps.Model.Resources;
using IQ.Platform.Framework.WebApi;
using BeerTaps.Domain.Services;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi.Services.Mapping;

namespace BeerTaps.ApiServices.Services
{
    public class OfficeApiService : IOfficeApiService
    {

        //readonly IApiUserProvider<BeerTapsApiUser> _userProvider;
	    private readonly IOfficeService _officeService;
	    private readonly IMapper<OfficeDto, Office> _toResourceMapper;
//	    private readonly IMapper<Office, OfficeDto> _toTransportMapper;

        public OfficeApiService(IOfficeService officeService, IMapperFactory mapperFactory)
        {
	        _officeService = officeService;
	        _toResourceMapper = mapperFactory.Create<OfficeDto, Office>();
//	        _toTransportMapper = mapperFactory.Create<Office, OfficeDto>();
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
	        Office officeToReturn =_toResourceMapper.Map(_officeService.Get(id));

	        return Task.FromResult(officeToReturn);
//	        Office officeToReturn;
//	        if (id == 1)
//	        {
//		        officeToReturn = new Office()
//		        {
//			        Id = id,
//			        Location = "Vancouver, British Columbia"
//		        };
//		        return Task.FromResult(officeToReturn);
//	        }
//	        else
//	        {
//				officeToReturn = new Office()
//				{
//					Id = id,
//					Location = "Regina, Saskatchewan"
//				};
//				return Task.FromResult(officeToReturn);
//			}
	        
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
//	        return Task.FromResult(_officeService.GetAll().Select(_toResourceMapper.Map));
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
