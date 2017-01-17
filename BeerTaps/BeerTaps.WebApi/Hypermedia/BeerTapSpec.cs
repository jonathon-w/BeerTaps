using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTaps.ApiServices;
using BeerTaps.ApiServices.LinkParameters;
using BeerTaps.Model;
using BeerTaps.Model.Resources;
using BeerTaps.Model.States;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.WebApi.Hypermedia
{
    public class BeerTapSpec : ResourceSpec<BeerTap, KegState, int>
    {
        public static ResourceUriTemplate UriBeerTapAtOffice = ResourceUriTemplate.Create("Offices({OfficeId})/Beertaps({id})");

        public override string EntrypointRelation
        {
            get { return null; /*LinkRelations.BeerTap;*/ }
        }

	    protected override IEnumerable<ResourceLinkTemplate<BeerTap>> Links()
	    {
		    yield return
			    CreateLinkTemplate<BeerTapLinkParameter>(CommonLinkRelations.Self, UriBeerTapAtOffice, c => c.Parameters.OfficeId,
				    c => c.Resource.Id);
	    }

        /// <summary>
        /// Operations and links available for each keg state
        /// </summary>
        /// <returns>
        ///     Full		- Pour, CheckKegStatus;
        ///     GoingDown	- Pour, CheckKegStatus;
        ///     NearlyEmpty - Pour, CheckKegStatus, ReplaceKeg;
        ///     Empty		- CheckKegStatus, ReplaceKeg;
        /// </returns>
        protected override IEnumerable<IResourceStateSpec<BeerTap, KegState, int>> GetStateSpecs()
        {
            // KegState <= Full
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.Full)
            {
                Links =
                {
					CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.Pour, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
                },
                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update
                }
            };
           // KegState <= GoingDown
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.GoingDown)
            {
                Links =
                {
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.Pour, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
                },
                Operations =
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update
                }
            };
            // KegState <= NearlyEmpty
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.NearlyEmpty)
            {
                Links =
                {
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.Pour, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.ReplaceKeg, ReplaceKegSpec.UriReplaceKeg.Many, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update
                }
            };
            // KegState <= Empty
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.Empty)
            {
                Links =
                {
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.ReplaceKeg, ReplaceKegSpec.UriReplaceKeg.Many, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                }
            };
        }
    }
}