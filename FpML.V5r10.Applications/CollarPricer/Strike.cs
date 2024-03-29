using System;
using Orion.EquityCollarPricer.Helpers;

namespace Orion.EquityCollarPricer
{
    /// <summary>
    /// Option Type
    /// </summary>
    public enum OptionType
    {
        /// <summary>Unknown (Not Specified)</summary>
        NotSpecified = 0,
        /// <summary>Call</summary>
        Call = 1,
        /// <summary>Put</summary>
        Put = 2,
    }

    /// <summary>
    /// The Strike (either call or put)
    /// </summary>
    public class Strike
    {
        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public OptionType Style { get; private set; }

        /// <summary>
        /// Gets or sets the strike price.
        /// </summary>
        /// <value>The strike price.</value>
        public double StrikePrice { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Strike"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <param name="strikePrice">The strike price.</param>
        public Strike(OptionType style, Double strikePrice)
        {
            InputValidator.EnumTypeNotSpecified("Option Type", style, true);
            InputValidator.NotZero("Strike Price", strikePrice, true);

            Style = style;
            StrikePrice = strikePrice;
        }
    }
}
