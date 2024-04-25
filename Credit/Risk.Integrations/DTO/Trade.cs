using Risk.Persistence;

namespace Risk.Integrations
{
    /// <summary>
    /// Data class for storing trades.
    /// </summary>
    public class Trade : ITrade
    {
        /// <summary>
        /// The monetary value of the negotiation in dollars.
        /// </summary>
        public required double Value { get; set; }

        /// <summary>
        /// The client's sector involved in the negotiation, which can be either "Public" or "Private".
        /// </summary>
        public required string ClientSector { get; set; }

        /// <summary>
        /// The reference date for the start of the pending payment involved in the negotiation.
        /// </summary>
        public required DateTime ReferenceDate { get; set; }

        /// <summary>
        /// The date of the pending payment involved in the negotiation.
        /// </summary>
        public required DateTime NextPaymentDate { get; set; }

        /// <summary>
        /// The date of the pending payment involved in the negotiation.
        /// </summary>
        public required Boolean PoliitcalExpose { get; set; }
    }
}
