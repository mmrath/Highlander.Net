﻿using System;
using FpML.V5r10.Reporting.ModelFramework;

namespace FpML.V5r10.Reporting.Models.Rates.Stream
{
    public class CapFloorStreamAnalytic : ModelAnalyticBase<ICapFloorStreamParameters, CapFloorStreamInstrumentMetrics>, ICapFloorStreamInstrumentResults
    {
        /// <summary>
        /// Gets the break even strike.
        /// </summary>
        /// <value>The break even strike.</value>
        public Decimal BreakEvenStrike => EvaluateBreakEvenRate();

        ///// <summary>
        ///// Gets the discount factor at maturity.
        ///// </summary>
        ///// <value>The discount factor at maturity.</value>
        //public decimal DiscountFactorAtMaturity
        //{
        //    get { return 0.0m; }
        //}

        /// <summary>
        /// Gets the flat volatility.
        /// </summary>
        /// <value>The flat volatility.</value>
        public Decimal FlatVolatility => EvaluateBreakEvenSpread();

        /// <summary>
        /// Evaluates the break even rate without solver.
        /// </summary>
        /// <returns></returns>
        public virtual Decimal EvaluateBreakEvenRate()
        {
            return AnalyticParameters.FloatingNPV / AnalyticParameters.AccrualFactor / 10000;
        }

        /// <summary>
        /// Evaluates the break even rate without solver.
        /// </summary>
        /// <returns></returns>
        public virtual Decimal EvaluateBreakEvenSpread()
        {
            return (AnalyticParameters.NPV  - AnalyticParameters.FloatingNPV)/ AnalyticParameters.AccrualFactor / 10000;
        }

        ///// <summary>
        ///// Gets the accrual factor.
        ///// </summary>
        ///// <value>The accrual factor.</value>
        //public decimal AccrualFactor
        //{
        //    get { return AnalyticParameters.AccrualFactor; }
        //}

        ///// <summary>
        ///// Gets the npv.
        ///// </summary>
        ///// <value>The net present value of a floating coupon.</value>
        //public decimal FloatingNPV
        //{
        //    get { return AnalyticParameters.FloatingNPV; }
        //}

        /// <summary>
        /// Gets the implied quote.
        /// </summary>
        /// <value>The implied quote.</value>
        public decimal ImpliedQuote => BreakEvenStrike;

        ///// <summary>
        ///// Gets the market quote.
        ///// </summary>
        ///// <value>The market quote.</value>
        //public decimal MarketQuote
        //{
        //    get { return AnalyticParameters.MarketQuote; }
        //}
    }
}