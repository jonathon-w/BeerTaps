using System.Collections.Generic;
using BeerTaps.ApiServices;
using BeerTaps.ApiServices.LinkParameters;
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
		public static ResourceUriTemplate UriReplaceKeg = ResourceUriTemplate.Create("Offices({OfficeId})/Beertaps({BeerTapId})/ReplaceKeg({id})");

		public override string EntrypointRelation
		{
			get { return null; }
		}

		protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
		{
			yield return
				CreateLinkTemplate<ReplaceKegLinkParameter>(CommonLinkRelations.Self, UriReplaceKeg, c => c.Parameters.OfficeId, c => c.Parameters.BeerTapId, c => c.Resource.Id);
		}

		public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
		{
			get
			{
				return new SingleStateSpec<ReplaceKeg, int>()
				{
					Operations =
					{
						Post = ServiceOperations.Update
					},
					Links =
					{
						CreateLinkTemplate<ReplaceKegLinkParameter>(LinkRelations.BeerTap, BeerTapSpec.UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Parameters.BeerTapId)
					}
				};
			} 
		}
	}
}