using System.Collections.Generic;
using BeerTaps.ApiServices;
using BeerTaps.Model;
using BeerTaps.Model.Resources;
using BeerTaps.Model.States;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.WebApi.Hypermedia
{
	public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
	{
		public static ResourceUriTemplate UriReplaceKeg = ResourceUriTemplate.Create("Offices({OfficeId})/Beertaps({BeerTapId})/ReplaceKeg");

		public override string EntrypointRelation
		{
			get { return LinkRelations.BeerTaps.ReplaceKeg; }
		}

		protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
		{
			yield return
				CreateLinkTemplate<ReplaceKegLinkParameter>(CommonLinkRelations.Self, UriReplaceKeg, c => c.Parameters.OfficeId,
					c => c.Parameters.BeerTapId);
		}

		public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
		{
			get
			{
				return new SingleStateSpec<ReplaceKeg, int>()
				{
					Operations =
					{
						Get = ServiceOperations.Get,
						Post = ServiceOperations.Update
					},
					Links =
					{
						CreateLinkTemplate<ReplaceKegLinkParameter>(LinkRelations.BeerTaps.ReplaceKeg, UriReplaceKeg, c => c.Parameters.OfficeId, 
						c => c.Parameters.BeerTapId)
					}
				};
			} 
		}
	}
}