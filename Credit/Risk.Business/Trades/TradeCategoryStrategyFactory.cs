using Risk.Persistence;

namespace Risk.Business
{
    /// <summary>
    /// Factory to create and manage trade categorization strategies.
    /// </summary>
    public class TradeCategoryStrategyFactory
    {
        private readonly Dictionary<string, ITradeCategoryStrategy> _strategies;

        /// <summary>
        /// Initializes a new instance of the trade category strategy factory.
        /// </summary>
        public TradeCategoryStrategyFactory()
        {
            _strategies = new Dictionary<string, ITradeCategoryStrategy>();

            // Inicialize with default strategies.
            AddStrategy(new ExpiredStrategy());
            AddStrategy(new MediumRiskStrategy());
            AddStrategy(new HighRiskStrategy());
        }

        /// <summary>
        /// Adds or updates a categorization strategy in the factory.
        /// </summary>
        /// <param name="strategy">The strategy to be added or updated.</param>
        public void AddStrategy(ITradeCategoryStrategy strategy)
        {
            _strategies[strategy.Category] = strategy;
        }

        /// <summary>
        /// "Delete a categorization strategy based on its category."
        /// </summary>
        /// <param name="category">Teh strategy category to be deleted.</param>
        /// <returns>True if the strategy was successfully deleted; otherwise, false.</returns>
        public bool RemoveStrategy(string category)
        {
            return _strategies.Remove(category);
        }

        /// <summary>
        /// Updates a categorization strategy in the factory.
        /// </summary>
        /// <param name="newStrategy">The strategy to be updated.</param>
        /// <returns></returns>
        public bool UpdateStrategy(ITradeCategoryStrategy newStrategy)
        {
            var categoryExists = _strategies.ContainsKey(newStrategy.Category);

            _strategies[newStrategy.Category] = newStrategy;

            return categoryExists;
        }

        /// <summary>
        /// Gets the appropriate categorization strategy for a specific trade.
        /// </summary>
        /// <param name="trade">The trade operation to be categorized.</param>
        /// <returns>The corresponding categorization strategy; null if none is found.</returns>
        public ITradeCategoryStrategy? GetStrategy(ITrade trade)
        {
            foreach (var strategy in _strategies.Values)
            {
                if (strategy.IsMatch(trade))
                {
                    return strategy;
                }
            }
            return null; // No matching strategy
        }
    }
}
