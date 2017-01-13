namespace BeerTaps.Model.States
{
    public enum KegState
    {
        /// <summary>
        /// The keg is fresh and full
        /// Pour, CheckKegState
        /// </summary>
        Full,
        /// <summary>
        /// She's shared a few pints
        /// Pour, CheckKegState
        /// </summary>
        GoingDown,
        /// <summary>
        /// She's given almost all she can
        /// Pour, CheckKegState, ReplaceKeg
        /// </summary>
        NearlyEmpty,
        /// <summary>
        /// She's done
        /// CheckKegState, ReplaceKeg
        /// </summary>
        Empty
    }
}