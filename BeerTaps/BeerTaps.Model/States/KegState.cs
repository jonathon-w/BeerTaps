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
        /// The keg has given a few pints
        /// Pour, CheckKegState
        /// </summary>
        GoingDown,
        /// <summary>
        /// The keg has given almost all it can
        /// Pour, CheckKegState, ReplaceKeg
        /// </summary>
        NearlyEmpty,
        /// <summary>
        /// Replace the poor bastard
        /// CheckKegState, ReplaceKeg
        /// </summary>
        BoneDry
    }
}