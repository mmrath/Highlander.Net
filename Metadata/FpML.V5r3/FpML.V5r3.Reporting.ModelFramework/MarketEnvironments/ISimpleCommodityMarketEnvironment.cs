﻿
using Orion.Util.Helpers;
using Orion.Util.NamedValues;
using FpML.V5r3.Reporting;
using Orion.ModelFramework.PricingStructures;

namespace Orion.ModelFramework.MarketEnvironments
{
    /// <summary>
    /// The base market environment interface
    /// </summary>
    public interface ISimpleCommodityMarketEnvironment : IMarketEnvironment
    {
        /// <summary>
        /// Gets the pricing structure.
        /// </summary>
        /// <returns></returns>
        ICommodityCurve GetCommodityCurve();

        /// <summary>
        /// Gets the pricing structure properties.
        /// </summary>
        /// <returns></returns>
        NamedValueSet GetCommodityCurveProperties();

        ///<summary>
        /// Returns an easy to use Pair<fpml> for constructors.</fpml>
        ///</summary>
        ///<returns></returns>
        Pair<FxCurve, FxCurveValuation> GetCommodityCurveFpML();
    }
}