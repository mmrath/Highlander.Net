
using System;
using Orion.Util.Helpers;
using Orion.Util.NamedValues;
using FpML.V5r3.Reporting;
using Orion.ModelFramework;
using Orion.ModelFramework.MarketEnvironments;
using Orion.ModelFramework.PricingStructures;

namespace Orion.CurveEngine.Markets
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SimpleFxMarketEnvironment : SimpleMarketEnvironment, ISimpleFxMarketEnvironment
    {

        ///<summary>
        /// A simple market environment can only contain a maximum of 3 curves:
        /// A forecast curve, a discount curve and a volatility surface.
        /// This type is use in priceable asset valuations via the Evaluate method.
        ///</summary>
        public SimpleFxMarketEnvironment()
            : base("Unidentified")
        {}

        ///<summary>
        /// A simple market environment can only contain a maximum of 3 curves:
        /// A forecast curve, a discount curve and a volatility surface.
        /// This type is use in priceable asset valuations via the Evaluate method.
        ///</summary>
        ///<param name="id"></param>
        public SimpleFxMarketEnvironment(string id):base(id)
        {}


        ///<summary>
        /// A simple market environment can only contain a maximum of 3 curves:
        /// A forecast curve, a discount curve and a volatility surface.
        /// This type is use in priceable asset valuations via the Evaluate method.
        ///</summary>
        ///<param name="market">The market</param>
        public SimpleFxMarketEnvironment(Market market)//TODO implement a class factory conversion to IPricingStructure.
            : base(market.id)
        {
        }


        ///<summary>
        /// A simple market environment can only contain a maximum of 3 curves:
        /// A forecast curve, a discount curve and a volatility surface.
        /// This type is use in priceable asset valuations via the Evaluate method.
        ///</summary>
        ///<param name="market">The market. This market only contains one rate curves.</param>
        ///<param name="pricingStructureProperties">The properties order for each pricing structure.</param>
        public SimpleFxMarketEnvironment(Market market, NamedValueSet pricingStructureProperties)
            : base(market.id)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IRateCurve GetForecastRateCurve()
        {
            var curve = SearchForPricingStructureType("ForecastCurve");

            if (curve != null)
            {
                return (IRateCurve)curve;
            }
            return (IRateCurve)SearchForPricingStructureType("DiscountCurve");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IRateCurve GetDiscountRateCurve()
        {
            var curve = SearchForPricingStructureType("DiscountCurve");

            if (curve != null)
            {
                return (IRateCurve)curve;
            }
            return (IRateCurve)SearchForPricingStructureType("ForecastCurve");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IVolatilitySurface GetVolatilitySurface()
        {
            return (IVolatilitySurface)SearchForPricingStructureType("VolatilitySurface");
        }

        /// <summary>
        /// Gets the forecast rate curve.
        /// </summary>
        /// <returns></returns>
        public Pair<PricingStructure, PricingStructureValuation> GetForecastRateCurveFpML()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the discount rate curve.
        /// </summary>
        /// <returns></returns>
        public Pair<PricingStructure, PricingStructureValuation> GetDiscountRateCurveFpML()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the volatility surface. THis may need to be extended to cubes.
        /// </summary>
        /// <returns></returns>
        public Pair<PricingStructure, PricingStructureValuation> GetVolatilitySurfaceFpML()
        {
            throw new System.NotImplementedException();
        }

        #region Implementation of ISimpleFxMarketEnvironment

        /// <summary>
        /// Gets the pricing structure.
        /// </summary>
        /// <returns></returns>
        public IFxCurve GetFxCurve()
        {
            return (IFxCurve)PricingStructures[PricingStructureIdentifier];
        }

        /// <summary>
        /// Gets the pricing structure properties.
        /// </summary>
        /// <returns></returns>
        public NamedValueSet GetFxCurveProperties()
        {
            return TheProperties;
        }

        ///<summary>
        /// Returns an easy to use Pair<fpml> for constructors.</fpml>
        ///</summary>
        ///<returns></returns>
        public Pair<FxCurve, FxCurveValuation> GetFxCurveFpML()
        {
            return new Pair<FxCurve, FxCurveValuation>((FxCurve)TheMarket.Items[0], (FxCurveValuation)TheMarket.Items1[0]);
        }

        #endregion
    }
}