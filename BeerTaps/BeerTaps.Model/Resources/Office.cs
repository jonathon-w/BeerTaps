using System.Collections;
using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.Model.Resources
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Office : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the Office
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Location string for the Office
        /// </summary>
        public string Location { get; set; }
    }
}
