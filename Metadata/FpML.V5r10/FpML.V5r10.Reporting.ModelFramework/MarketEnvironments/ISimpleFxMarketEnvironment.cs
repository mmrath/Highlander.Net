﻿
using Orion.Util.Helpers;
using Orion.Util.NamedValues;
using FpML.V5r10.Reporting.ModelFramework.PricingStructures;

namespace FpML.V5r10.Reporting.ModelFramework.MarketEnvironments
{
    /// <summary>
    /// The base market environment interface
    /// </summary>
    public interface ISimpleFxMarketEnvironment : IMarketEnvironment
    {
        /// <summary>
        /// Gets the pricing structure.
        /// </summary>
        /// <returns></returns>
        IFxCurve GetFxCurve();

        /// <summary>
        /// Gets the pricing structure properties.
        /// </summary>
        /// <returns></returns>
        NamedValueSet GetFxCurveProperties();

        ///<summary>
        /// Returns an easy to use Pair<fpml> for constructors.</fpml>
        ///</summary>
        ///<returns></returns>
        Pair<FxCurve, FxCurveValuation> GetFxCurveFpML();
    }
}