using System.Runtime.CompilerServices;
using BeerTaps.Domain.Models;
using BeerTaps.Model.Resources;
using BeerTaps.Model.States;
using IQ.Platform.Framework.Common.Mapping;

namespace BeerTaps.ApiServices
{
	public class BeerTapMapper : IMapper<BeerTapDto, BeerTap>, IMapper<BeerTap, BeerTapDto>
	{
		/// <summary>
		/// toResourceMapper - Dto to Resource
		/// </summary>
		/// <param BeerTapDto="transport"></param>
		/// <returns></returns>
		public BeerTap Map(BeerTapDto transport)
		{
			if (transport == null)
			{
				return null;
			}
			
			var resource = new BeerTap()
			{
				Id = transport.Id,
				BeerName = transport.BeerName,
				OfficeId = transport.OfficeId,
				KegState = MapState(transport),
				TotalVolume = transport.TotalVolume,
				CurrentVolume = transport.CurrentVolume
			};
			return resource;
		}

		private static KegState MapState(BeerTapDto resource)
		{
			if (resource.CurrentVolume == resource.TotalVolume) // Full - 100%
				return KegState.Full;
			if (resource.CurrentVolume < resource.TotalVolume && resource.CurrentVolume > (resource.TotalVolume * 0.30)) // GoingDown - 99% -> 31%
				return KegState.GoingDown;
			if (resource.CurrentVolume <= (resource.TotalVolume * 0.30) && resource.CurrentVolume > 0) // NearlyEmpty - 30% -> 1%
				return KegState.NearlyEmpty;

			return KegState.Empty;
		}

		/// <summary>
		/// toTransportMapper - Resource to Dto
		/// </summary>
		/// <param BeerTap="resource"></param>
		/// <returns></returns>
		public BeerTapDto Map(BeerTap resource)
		{
			if (resource == null)
			{
				return null;
			}
			
			var transport = new BeerTapDto()
			{
				Id = resource.Id,
				BeerName = resource.BeerName,
				OfficeId = resource.OfficeId,
				TotalVolume = resource.TotalVolume,
				CurrentVolume = resource.CurrentVolume,
				IsFull = resource.KegState == KegState.Full,
				IsGoingDown = resource.KegState == KegState.GoingDown,
				IsNearlyEmpty = resource.KegState == KegState.NearlyEmpty,
				IsEmpty = resource.KegState == KegState.Empty
			};
			return transport;
		}
	}
}