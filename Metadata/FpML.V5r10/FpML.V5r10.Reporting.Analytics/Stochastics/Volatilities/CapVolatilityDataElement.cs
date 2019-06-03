﻿
#region Using Directives

// Empty

#endregion

namespace Orion.Analytics.Stochastics.Volatilities
{
    /// <summary>
    /// Type of volatility.
    /// The enumerated type has been structured so that CapFloor > ETO.
    /// </summary>
    public enum VolatilityDataType
    {
        /// <summary>
        /// Excahnge traded.
        /// </summary>
        ETO,

        /// <summary>
        /// OTC cap/floor.
        /// </summary>
        CapFloor
    }

    /// <summary>
    /// Templated class that encapsulates all the fields that constitute an 
    /// element of market data for a Cap volatility.
    /// The fields that comprise the data element are:
    /// 1) Expiry;
    /// 2) Strike;
    /// 3) Volatility;
    /// 4) Volatility data type (ETO or Cap/Floor).
    /// No validation is performed by the class because the class is merely a
    /// container with no business logic.
    /// </summary>
    public class CapVolatilityDataElement<T>
    {
        #region Constructor

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="expiry">Cap expiry.</param>
        /// <param name="volatility">Cap volatility.</param>
        /// <param name="volatilityType">Type of volatility: ETO or Cap/Floor.
        /// </param>
        public CapVolatilityDataElement(T expiry,
                                        decimal volatility,
                                        VolatilityDataType volatilityType)
        {
            // Map all arguments to the appropriate private field.
            Expiry = expiry;
            Volatility = volatility;
            VolatilityType = volatilityType;
        }

        #endregion

        #region Accessor Methods

        /// <summary>
        /// Accessor methods for the Cap expiry.
        /// </summary>
        /// <value>Cap expiry.</value>
        public T Expiry { get; set; }

        /// <summary>
        /// Accessor methods for the Cap volatility.
        /// </summary>
        /// <value>Cap volatility.</value>
        public decimal Volatility { get; set; }

        /// <summary>
        /// Accessor method for the volatility type.
        /// </summary>
        /// <value>Volatility type, for example Cap/Floor.</value>
        public VolatilityDataType VolatilityType { get; set; }

        #endregion

        #region Private Fields

        #endregion
    }
}