using System.Collections;
using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTaps.Model.Resources
{
    /// <summary>
    /// An Office with an Id and Location, links to BeerTaps
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
