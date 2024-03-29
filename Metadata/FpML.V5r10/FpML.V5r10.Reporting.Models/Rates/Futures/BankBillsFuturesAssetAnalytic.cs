﻿/*
 Copyright (C) 2019 Alex Watt (alexwatt@hotmail.com)

 This file is part of Highlander Project https://github.com/alexanderwatt/Hghlander.Net

 Highlander is free software: you can redistribute it and/or modify it
 under the terms of the Highlander license.  You should have received a
 copy of the license along with this program; if not, license is
 available at <https://github.com/alexanderwatt/Hghlander.Net/blob/develop/LICENSE>.

 This program is distributed in the hope that it will be useful, but WITHOUT
 ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 FOR A PARTICULAR PURPOSE.  See the license for more details.
*/

using System;
using FpML.V5r10.Reporting.ModelFramework;
using FpML.V5r10.Reporting.Models.Assets;
using Highlander.Numerics.Rates;

namespace FpML.V5r10.Reporting.Models.Rates.Futures
{
    public class BankBillsFuturesAssetAnalytic : ModelAnalyticBase<IRateFuturesAssetParameters, RateMetrics>, IRateAssetResults
    {
        private const Decimal COne = 1.0m;

        /// <summary>
        /// Gets the NPV.
        /// </summary>
        /// <value>The NPV.</value>
        public Decimal NPV => EvaluateNPV();

        /// <summary>
        /// Gets the npv change form a base NPV.
        /// </summary>
        /// <value>The npv change.</value>
        public Decimal NPVChange => EvaluateNPVChange();

        /// <summary>
        /// Gets the implied quote.
        /// </summary>
        /// <value>The quote.</value>
        public Decimal ImpliedQuote => EvaluateImpliedQuote();

        /// <summary>
        /// Gets the delta wrt the fixed rate R.
        /// </summary>
        public decimal DeltaR => EvaluateDeltaR();

        /// <summary>
        /// Gets the convexity adjustment.
        /// </summary>
        public Decimal AccrualFactor => EvaluateAccrualFactor();

        /// <summary>
        /// Gets the convexity adjustment.
        /// </summary>
        public Decimal ConvexityAdjustment => EvaluateConvexityAdjustment();

        /// <summary>
        /// Gets the adjusted rate.
        /// </summary>
        /// <value>The rate.</value>
        public Decimal AdjustedRate => EvaluateAdjustedRate();

        /// <summary>
        /// Gets the discount factor at maturity.
        /// </summary>
        /// <value>The discount factor at maturity.</value>
        public Decimal DiscountFactorAtMaturity => EvaluateDiscountFactorAtMaturity();

        /// <summary>
        /// Gets the market quote.
        /// </summary>
        /// <value>The market quote.</value>
        public Decimal MarketQuote => EvaluateMarketRate();

        /// <summary>
        /// Gets the Index At Maturity.
        /// </summary>
        public decimal IndexAtMaturity => EvaluateMarketRate();

        /// <summary>
        /// Gets the PandL.
        /// </summary>
        /// <value>The market quote.</value>
        public decimal PandL => 0.0m;

        /// <summary>
        /// Gets the intial margin.
        /// </summary>
        /// <value>The inital margin.</value>
        public decimal InitialMargin => 0.0m;

        /// <summary>
        /// Gets the variation margin.
        /// </summary>
        /// <value>The variation margin.</value>
        public decimal VariationMargin => 0.0m;

        /// <summary>
        /// Evaluates the implied quote.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateImpliedQuote()
        {
            var impliedRate = EvaluateImpliedRate();
            var result = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjusted(impliedRate,
                (double)AnalyticParameters.TimeToExpiry, (double)AnalyticParameters.Volatility);
            return result;
        }

        /// <summary>
        /// Evaluates the npv.
        /// </summary>
        /// <returns></returns>
        protected virtual Decimal EvaluateNPVChange()
        {
            return EvaluateNPV() - AnalyticParameters.BaseNPV;
        }

        /// <summary>
        /// Evaluates the implied quote.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateConvexityAdjustment()
        {
            return FuturesAnalytics.FuturesMarginConvexityAdjustment(AnalyticParameters.Rate,
                                                                     (double)AnalyticParameters.TimeToExpiry, (double)AnalyticParameters.Volatility);
        }

        /// <summary>
        /// Evaluates the discount factor at maturity.
        /// </summary>
        /// <returns></returns>
        public virtual Decimal EvaluateDiscountFactorAtMaturity()
        {
            return AnalyticParameters.StartDiscountFactor / (COne + AnalyticParameters.YearFraction * EvaluateAdjustedRate());
        }

        /// <summary>
        /// Evaluates the npv.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateNPV()
        {
            return AnalyticParameters.NumberOfContracts * 1000000 * (EvaluateMarketBillPrice() - EvaluateImpliedBillPrice());

        }

        /// <summary>
        /// Evaluates the delta wrt the fixed rate R.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateAdjustedRate()
        {
            return EvaluateMarketRate() - EvaluateConvexityAdjustment();
        }

        /// <summary>
        /// Evaluates the delta wrt the fixed rate R.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateDeltaR()
        {
            return EvaluateAccrualFactor() / (1 + EvaluateAccrualFactor() * AnalyticParameters.Rate) * 100 * EvaluateMarketBillPrice();
        }

        /// <summary>
        /// Evaluates the delta wrt the fixed rate R.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateMarketRate()
        {
            return AnalyticParameters.Rate;
        }

        /// <summary>
        /// Evaluates the accrual factor
        /// </summary>
        /// <returns></returns>
        public Decimal EvaluateAccrualFactor()
        {
            return 90.0m/365.0m;//Based on a 90 day bill.
        }

        /// <summary>
        /// Evaluates the discount factor at maturity.
        /// </summary>
        /// <returns></returns>
        public Decimal EvaluateImpliedRate()
        {
            var rate = (AnalyticParameters.StartDiscountFactor / AnalyticParameters.EndDiscountFactor - COne) / AnalyticParameters.YearFraction;
            return rate;
        }

        /// <summary>
        /// Evaluates the bill price underlying the future.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateMarketBillPrice()
        {
            return COne / (COne + EvaluateMarketRate() * AnalyticParameters.YearFraction);
        }

        /// <summary>
        /// Evaluates the bill price from the curve.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluateImpliedBillPrice()
        {
            return COne / (COne + ImpliedQuote * AnalyticParameters.YearFraction);
        }
    }
}