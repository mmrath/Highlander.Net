#region Using directives

using System;
using Core.Common;
using FpML.V5r10.Reporting;
using FpML.V5r10.Reporting.ModelFramework;
using FpML.V5r10.Reporting.ModelFramework.PricingStructures;
using Orion.Constants;
using Orion.Util.Helpers;
using Orion.Util.Logging;
using Orion.Util.NamedValues;

#endregion

namespace Orion.CurveEngine.PricingStructures.Curves
{
    ///<summary>
    ///</summary>
    public class SecuredRateCurve : RateCurve, ISecuredRateCurve
    {
        private Asset UnderlyingAsset { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecuredRateCurve"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="nameSpace">The client namespace</param>
        /// <param name="underlyingAsset">THe underlying asset used for security.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="instrumetData">The instrument data.</param>
        /// <param name="fixingCalendar">The fixingCalendar.</param>
        /// <param name="rollCalendar">The rollCalendar.</param>
        public SecuredRateCurve(ILogger logger, ICoreCache cache, string nameSpace, Asset underlyingAsset, NamedValueSet properties, 
            QuotedAssetSet instrumetData, IBusinessCalendar fixingCalendar, IBusinessCalendar rollCalendar)
            : base(logger, cache, nameSpace, properties, instrumetData, fixingCalendar, rollCalendar)
        {
            UnderlyingAsset = underlyingAsset;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecuredRateCurve"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="nameSpace">The client namespace</param>
        /// <param name="fpmlData">The FPML data.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="fixingCalendar">The fixingCalendar.</param>
        /// <param name="rollCalendar">The rollCalendar.</param>
        public SecuredRateCurve(ILogger logger, ICoreCache cache, string nameSpace, 
            Pair<PricingStructure, PricingStructureValuation> fpmlData, 
            NamedValueSet properties, IBusinessCalendar fixingCalendar, IBusinessCalendar rollCalendar)
            : base(logger, cache, nameSpace, fpmlData, properties, fixingCalendar, rollCalendar)
        {
            var refId = properties.GetValue<String>(BondProp.ReferenceBond, true);
            var refItem = cache.LoadItem<Bond>(nameSpace + '.' + "ReferenceData.FixedIncome." + refId);
            var refAsset = refItem.Data as Bond;
            UnderlyingAsset = refAsset; 
        }

        /// <summary>
        /// Returns the asst that the cash is secured against.
        /// </summary>
        /// <returns></returns>
        public Asset GetSecurity()
        {
            return UnderlyingAsset;
        }
    }
}