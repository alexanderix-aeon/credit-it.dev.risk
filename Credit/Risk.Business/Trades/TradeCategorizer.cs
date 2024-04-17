using Risk.Persistence;

namespace Risk.Business
{
    /// <summary>
    /// Categorize trade operations based on defined strategies.
    /// </summary>
    public class TradeCategorizer
    {
        private readonly TradeCategoryStrategyFactory _strategyFactory;

        /// <summary>
        /// Initializes a new instance of the trade categorizer.
        /// </summary>
        public TradeCategorizer(TradeCategoryStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory ?? throw new ArgumentNullException(nameof(strategyFactory));
        }

        /// <summary>
        /// Categorizes a list of trades based on the available strategies.
        /// </summary>
        /// <param name="trades">The list of trades to be categorized.</param>
        /// <returns>A list of strings representing the categories of the trades.</returns>
        public List<string> CategorizeTrades(List<ITrade> trades)
        {
            var categories = new List<string>();

            foreach (var trade in trades)
            {
                var strategy = _strategyFactory.GetStrategy(trade);
                if (strategy != null)
                {
                    categories.Add(strategy.Category);
                }
                else
                {
                    // Handle trade operations that do not fit into any known category.
                    categories.Add("UNKNOWN");
                }
            }

            return categories;
        }
    }
}
