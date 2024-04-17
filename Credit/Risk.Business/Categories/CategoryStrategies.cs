using Risk.Persistence;

namespace Risk.Business
{
    /// <summary>
    /// Represents the category strategy with the validation of its rule.
    /// </summary>
    public class ExpiredStrategy : ITradeCategoryStrategy
    {
        /// <summary>
        /// Describes the risk category
        /// </summary>
        public string Category => "EXPIRED";

        /// <summary>
        /// Describes the risk category strategy.
        /// </summary>
        /// <param name="trade">The trade operation to be evaluated.</param>
        /// <returns></returns>
        public bool IsMatch(ITrade trade) => (trade.ReferenceDate - trade.NextPaymentDate).TotalDays > 30;
    }

    /// <summary>
    /// Represents the category strategy with the validation of its rule.
    /// </summary>
    public class HighRiskStrategy : ITradeCategoryStrategy
    {
        /// <summary>
        /// Describes the risk category
        /// </summary>
        public string Category => "HIGHRISK";

        /// <summary>
        /// Describes the risk category strategy.
        /// </summary>
        /// <param name="trade">The trade operation to be evaluated.</param>
        /// <returns></returns>
        public bool IsMatch(ITrade trade) => (trade.ReferenceDate - trade.NextPaymentDate).TotalDays <= 30 && trade.Value > 1_000_000 && trade.ClientSector == "Private";
    }

    /// <summary>
    /// Represents the category strategy with the validation of its rule.
    /// </summary>
    public class MediumRiskStrategy : ITradeCategoryStrategy
    {
        /// <summary>
        /// Describes the risk category
        /// </summary>
        public string Category => "MEDIUMRISK";

        /// <summary>
        /// Describes the risk category strategy.
        /// </summary>
        /// <param name="trade">The trade operation to be evaluated.</param>
        /// <returns></returns>
        public bool IsMatch(ITrade trade) => (trade.ReferenceDate - trade.NextPaymentDate).TotalDays <= 30 && trade.Value > 1_000_000 && trade.ClientSector == "Public";
    }
}
