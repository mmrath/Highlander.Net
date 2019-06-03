﻿#region Usings

using System;
using System.Collections.Generic;
using Orion.Analytics.Options;
using Orion.ModelFramework;
using Orion.ModelFramework.PricingStructures;
using Orion.Models.ForeignExchange.FxOption;

#endregion

namespace Orion.Models.ForeignExchange.FxOptionLeg
{
    public class FxOptionLegAnalytic : ModelAnalyticBase<IFxOptionLegParameters, FxOptionLegInstrumentMetrics>, IFxOptionLegInstrumentResults
    {
        #region Propereties

        /// <summary>
        /// Gets or sets the forward fx rate.
        /// </summary>
        /// <value>The forward fx rate.</value>
        public Decimal ForwardFxRate { get; protected set; }

        /// <summary>
        /// Gets or sets the FxOptionType.
        /// </summary>
        /// <value>The FxOptionType.</value>
        public FxOptionType OptionType { get; protected set; }

        /// <summary>
        /// Gets or sets the strike.
        /// </summary>
        /// <value>The strike.</value>
        public List<Decimal> Strikes { get; protected set; }

        /// <summary>
        /// Gets or sets the discount factor.
        /// </summary>
        /// <value>The discount factor.</value>
        public List<Decimal> Volatilities { get; protected set; }

        /// <summary>
        /// Gets or sets the Time To Index.
        /// </summary>
        /// <value>The Time To Index.</value>
        public List<Decimal> TimeToIndices { get; protected set; }

        /// <summary>
        /// Gets or sets the Time To expiry.
        /// </summary>
        /// <value>The Time To expiry.</value>
        public List<Decimal> ExpiryTimes { get; protected set; }

        public bool GetIsCall()
        {
            return OptionType == FxOptionType.Call;
        }

        #endregion

        #region Constructor

        public FxOptionLegAnalytic()
        {
            //ToReportingCurrencyRate = 1.0m;
        }

        /// <summary>
        /// This assumes that the rest dates are consistent with the curve.
        /// </summary>
        /// <param name="valuationDate"></param>
        /// <param name="paymentDate"></param>
        /// <param name="indexCurve"></param>
        /// <param name="expiryTime">The expiry time. </param>
        /// <param name="timeToIndex">The time to reset or expiry. </param>
        /// <param name="strike">The strike. </param>
        /// <param name="indexVolatilitySurface">The index volatility surface. </param>
        /// <param name="fxOptionType">The option type. </param>
        public FxOptionLegAnalytic(DateTime valuationDate, DateTime paymentDate, IFxCurve indexCurve, decimal strike, decimal expiryTime, decimal timeToIndex
            , IVolatilitySurface indexVolatilitySurface, FxOptionType fxOptionType)
        {
            //ToReportingCurrencyRate = EvaluateReportingCurrencyFxRate(valuationDate, reportingCurrencyFxCurve);
            ForwardFxRate = (decimal)indexCurve.GetForward(valuationDate, paymentDate);
            OptionType = fxOptionType;
            Strikes = new List<decimal> { strike };
            ExpiryTimes = new List<decimal> { expiryTime };
            TimeToIndices = new List<decimal> { timeToIndex };
            Volatilities = new List<decimal> { (decimal)indexVolatilitySurface.GetValue((double)timeToIndex, (double)strike) };
        }

        /// <summary>
        /// This assumes that the rest dates are consistent with the curve.
        /// </summary>
        /// <param name="valuationDate"></param>
        /// <param name="paymentDate">The payment date. The same rest period is assumed as with the spot date.</param>
        /// <param name="indexCurve">The index curve should be already in the correct form for the fx.</param>
        /// <param name="currency2">Normaly the foreign rate curve.</param>
        /// <param name="currency2PerCurrency1">The currency2PerCurrency1 flag. </param>
        /// <param name="currency1">Normally the domestic rate curve. </param>
        /// <param name="indexVolatilitySurface">The index volatility surface. </param>
        /// <param name="expiryTime">The expiry time. </param>
        /// <param name="timeToIndex">The time to reset or expiry. </param>
        /// <param name="strike">The strike. </param>
        /// <param name="fxOptionType">The option type. </param>
        public FxOptionLegAnalytic(DateTime valuationDate, DateTime paymentDate, IFxCurve indexCurve, IRateCurve currency1, IRateCurve currency2,
            bool currency2PerCurrency1, decimal strike, decimal expiryTime, decimal timeToIndex, IVolatilitySurface indexVolatilitySurface, FxOptionType fxOptionType)
        {
            //ToReportingCurrencyRate = EvaluateReportingCurrencyFxRate(valuationDate, reportingCurrencyFxCurve);
            var todayRate = indexCurve.GetForward(valuationDate, valuationDate); //TODO The spot rate may not be the same due to the carry effect, but the evolution works.
            var df1 = currency1.GetDiscountFactor(valuationDate, paymentDate);
            var df2 = currency2.GetDiscountFactor(valuationDate, paymentDate);
            var forward = df1 / df2;
            if (!currency2PerCurrency1)
            {
                forward = df2 / df1;
            }
            ForwardFxRate = (decimal)(todayRate * forward);
            OptionType = fxOptionType;
            Strikes = new List<decimal> { strike };
            ExpiryTimes = new List<decimal> { expiryTime };
            TimeToIndices = new List<decimal> { timeToIndex };
            Volatilities = new List<decimal> { (decimal)indexVolatilitySurface.GetValue((double)timeToIndex, (double)strike) };
        }

        #endregion

        #region Methods

        protected virtual Decimal CalculateOptionValue(decimal forwardRate)
        {
            var result = OptionAnalytics.Opt(GetIsCall(), (double)forwardRate, (double)GetStrike(),
                                             (double)GetVolatility(), (double)GetExpiry());
            return (decimal)result;
        }

        protected virtual Decimal CalculateOptionValue()
        {
            var result = OptionAnalytics.Opt(GetIsCall(), (double)ForwardFxRate, (double)GetStrike(),
                                             (double)GetVolatility(), (double)GetExpiry());
            return (decimal)result;
        }

        protected virtual Decimal CalculateOptionValue2()
        {
            var result = OptionAnalytics.Opt(GetIsCall(), (double)ForwardFxRate - 0.0001, (double)GetStrike(),
                                             (double)GetVolatility(), (double)GetExpiry());
            return (decimal)result;
        }

        protected Decimal CalculateOptionStrike()
        {
            var result = 0.0m;
            //if (AnalyticParameters.Premium != null)
            //{
            //    var premium = (decimal)AnalyticParameters.Premium / System.Math.Abs(AnalyticParameters.SwapAccrualFactor);
            //    result = (decimal)OptionAnalytics.OptSolveStrike(AnalyticParameters.IsCall, (double)AnalyticParameters.SwapBreakEvenRate, (double)Volatility,
            //                                    0.0, (double)AnalyticParameters.ExpiryYearFraction, (double)premium);
            //}
            return result;
        }

        protected virtual Decimal CalculateOptionDelta()
        {
            var result = OptionAnalytics.OptWithGreeks(GetIsCall(), (double)ForwardFxRate, (double)GetStrike(),
                                                       (double)GetVolatility(), (double)GetExpiry())[1];
            return (decimal)result;
        }

        public decimal GetStrike()
        {
            return Strikes[0];
        }

        public decimal GetVolatility()
        {
            return Volatilities[0];
        }

        public decimal GetExpiry()
        {
            return ExpiryTimes[0];
        }

        #endregion
 
        #region Implementation of IFxLegInstrumentResults

        /// <summary>
        /// Gets the implied fx rate.
        /// </summary>
        /// <value>The implied fx rate.</value>
        public decimal ImpliedQuote => BreakEvenIndex;

        /// <summary>
        /// Gets the market fx rate.
        /// </summary>
        /// <value>The market fx rate.</value>
        public decimal MarketQuote => AnalyticParameters.MarketQuote;//TODO This should be the premium -> get rid of it!

        /// <summary>
        /// Gets the break even index.
        /// </summary>
        /// <value>The break even index.</value>
        public decimal BreakEvenIndex => ForwardFxRate;

        #endregion
    }
}