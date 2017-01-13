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
			if (transport != null)
			{
				var resource = new BeerTap()
				{
					Id = transport.Id,
					BeerName = transport.BeerName,
					OfficeId = transport.OfficeId
				};
				return resource;
			}
			return null;
		}

//		static KegState MapState(BeerTapDto transport)
//		{
//			if (transport.IsFull)
//				return KegState.Full;
//			if (transport.IsGoingDown)
//				return KegState.GoingDown;
//			if (transport.IsNearlyEmpty)
//				return KegState.NearlyEmpty;
//			if (transport.IsEmpty)
//				return KegState.Empty;
//
//			return KegState.Empty;
//		}

		static KegState MapState(BeerTap resource)
		{
			if ((resource.CurrentVolume/resource.TotalVolume*100) == 100)
				return KegState.Full;
			if ((resource.CurrentVolume / resource.TotalVolume * 100) < 100 && (resource.CurrentVolume / resource.TotalVolume * 100) >= 30)
				return KegState.GoingDown;
			if ((resource.CurrentVolume / resource.TotalVolume * 100) < 30 && (resource.CurrentVolume / resource.TotalVolume * 100) > 0)
				return KegState.NearlyEmpty;
			if ((resource.CurrentVolume / resource.TotalVolume * 100) <= 0)
				return KegState.Empty;

			return KegState.Empty;
		}

		/// <summary>
		/// toTransportMapper - Resource to Dto
		/// </summary>
		/// <param BeerTap="resource"></param>
		/// <returns></returns>
		public BeerTapDto Map(BeerTap resource)
		{
			if (resource != null)
			{
				var transport = new BeerTapDto()
				{
					Id = resource.Id,
					BeerName = resource.BeerName,
					OfficeId = resource.OfficeId,
					IsFull = resource.KegState == KegState.Full,
					IsGoingDown = resource.KegState == KegState.GoingDown,
					IsNearlyEmpty = resource.KegState == KegState.NearlyEmpty,
					IsEmpty = resource.KegState == KegState.Empty
				};
				return transport;
			}
			return null;
		}
	}
}