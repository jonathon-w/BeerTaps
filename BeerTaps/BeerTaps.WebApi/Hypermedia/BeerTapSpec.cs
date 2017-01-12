using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTaps.ApiServices;
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
            get { return LinkRelations.BeerTap; }
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
        ///     BoneDry		- CheckKegStatus, ReplaceKeg;
        /// </returns>
        protected override IEnumerable<IResourceStateSpec<BeerTap, KegState, int>> GetStateSpecs()
        {
            // KegState <= Full
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.Full)
            {
                Links =
                {
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTap, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id), // Not terribly important...
					CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.Pour, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
//					CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.CheckKegStatus, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,		// CheckKegStatus
                    Post = ServiceOperations.Update		// Pour
                }
            };
           // KegState <= GoingDown
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.GoingDown)
            {
                Links =
                {
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.Pour, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
//                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.CheckKegStatus, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,		// CheckKegStatus
                    Post = ServiceOperations.Update		// Pour
                }
            };
            // KegState <= NearlyEmpty
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.NearlyEmpty)
            {
                Links =
                {
                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.Pour, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
//                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.CheckKegStatus, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
//                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.ReplaceKeg, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,		// CheckKegStatus
                    Post = ServiceOperations.Update		// Pour or ReplaceKeg
                }
            };
            // KegState <= BoneDry
            yield return new ResourceStateSpec<BeerTap, KegState, int>(KegState.BoneDry)
            {
                Links =
                {
					CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTap, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id), // Not terribly important...
//                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.CheckKegStatus, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id),
//                    CreateLinkTemplate<BeerTapLinkParameter>(LinkRelations.BeerTaps.ReplaceKeg, UriBeerTapAtOffice, c => c.Parameters.OfficeId, c => c.Resource.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,		// CheckKegStatus
                    Post = ServiceOperations.Update,	// ReplaceKeg
                }
            };
        }
    }
}