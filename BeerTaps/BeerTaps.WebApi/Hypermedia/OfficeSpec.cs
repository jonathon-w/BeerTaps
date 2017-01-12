using System.Collections.Generic;
using BeerTaps.Model;
using BeerTaps.Model.Resources;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate UriOffice = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

	    protected override IEnumerable<ResourceLinkTemplate<Office>> Links()
	    {
		    yield return CreateLinkTemplate(CommonLinkRelations.Self, UriOffice, c => c.Id);
	    }

        // IResourceStateSpec is not required but can be overridden to define custom operations and links.
        // See example below...
        //
        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return 
					new SingleStateSpec<Office, int>
                    {
                        Links =
                        {
                            CreateLinkTemplate(LinkRelations.BeerTap, BeerTapSpec.UriBeerTapAtOffice.Many, r => r.Id),
                        },

                        Operations =
                        {
                            Get = ServiceOperations.Get
                        },
                    };
            }
        }

    }
}