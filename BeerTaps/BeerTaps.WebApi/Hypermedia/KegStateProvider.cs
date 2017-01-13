using System.Collections;
using System.Collections.Generic;
using BeerTaps.Model.Interfaces;
using BeerTaps.Model.Resources;
using BeerTaps.Model.States;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.WebApi.Hypermedia
{
	public class KegStateProvider : KegStateProvider<BeerTap>
	{ 
	}

	public abstract class KegStateProvider<TBeerTapResource> : ResourceStateProviderBase<TBeerTapResource, KegState>
		where TBeerTapResource : IStatefulResource<KegState>, IStatefulBeerTap
	{
		public override KegState GetFor(TBeerTapResource resource)
		{
			return resource.KegState;
		}

		protected override IDictionary<KegState, IEnumerable<KegState>> GetTransitions()
		{
			return new Dictionary<KegState, IEnumerable<KegState>>
			{
				// from, to
				{
					KegState.Full, new[]
					{
						KegState.GoingDown
					}
				},
				{
					KegState.GoingDown, new[]
					{
						KegState.NearlyEmpty
					}
				},
				{
					KegState.NearlyEmpty, new[]
					{
						KegState.Full,
						KegState.Empty
					}
				},
				{
					KegState.Empty, new[]
					{
						KegState.Full
					}
				},
			};
		}

		public override IEnumerable<KegState> All
		{
			get { return EnumEx.GetValuesFor<KegState>(); }
		}
	} 
}