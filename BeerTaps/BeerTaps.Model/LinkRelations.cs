namespace BeerTaps.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Office resource.
        /// </summary>
        public const string Office = "iq:Office";

        /// <summary>
        /// link relation to describe the BeerTap resource
        /// </summary>
        public const string BeerTap = "iq:BeerTap";

        public static class BeerTaps
        {
			/// <summary>
			/// Link to describe multiple beer taps
			/// </summary>
	        public const string PluralBeerTaps = "iq:BeerTaps";
            /// <summary>
            /// Action link to describe replacing a keg
            /// </summary>
            public const string ReplaceKeg = "iq:ReplaceKeg";
            /// <summary>
            /// Action link to describe pour a pint
            /// </summary>
            public const string Pour = "iq:Pour";
        }

    }
}
