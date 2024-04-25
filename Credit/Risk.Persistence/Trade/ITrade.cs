namespace Risk.Persistence
{
    /// <summary>
    /// Represents a trade, which is a commercial negotiation between the bank and a client.
    /// </summary>
    public interface ITrade
    {
        /// <value>
        /// The monetary value of the negotiation in dollars
        /// </value>
        double Value { get; }

        /// <value>
        /// The client's sector involved in the negotiation, which can be either "Public" or "Private".
        /// </value>
        string ClientSector { get; }

        /// <summary>
        /// The reference date for the start of the pending payment involved in the negotiation.
        /// </summary>
        DateTime ReferenceDate { get; }

        /// <value>
        /// The next pending payment date involved in the negotiation.
        /// </value>
        DateTime NextPaymentDate { get; }

        /// <value>
        /// The next pending payment date involved in the negotiation.
        /// </value>
        Boolean PoliitcalExpose { get; }
    }
}
