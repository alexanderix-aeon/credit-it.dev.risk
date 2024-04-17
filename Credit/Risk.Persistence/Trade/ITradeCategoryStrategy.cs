namespace Risk.Persistence
{
    /// <summary>
    /// Defines a strategy to categorize trades based on specific rules.
    /// </summary>
    public interface ITradeCategoryStrategy
    {
        /// <summary>
        /// The risk category associated with the strategy.
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Determines if a specific trade matches the strategy.
        /// </summary>
        /// <param name="trade">The trade to be evaluated.</param>
        /// <returns>True if the trade matches the strategy; otherwise, false.</returns>
        bool IsMatch(ITrade trade);
    }
}
