﻿/*
 Copyright (C) 2019 Alex Watt (alexwatt@hotmail.com)

 This file is part of Highlander Project https://github.com/alexanderwatt/Highlander.Net

 Highlander is free software: you can redistribute it and/or modify it
 under the terms of the Highlander license.  You should have received a
 copy of the license along with this program; if not, license is
 available at <https://github.com/alexanderwatt/Highlander.Net/blob/develop/LICENSE>.

 This program is distributed in the hope that it will be useful, but WITHOUT
 ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 FOR A PARTICULAR PURPOSE.  See the license for more details.
*/

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FpML.V5r3.Reporting.Helpers;
using Orion.Constants;
using FpML.V5r3.Reporting;
using Orion.Models.Rates;
using Orion.Models.Rates.Coupons;
using Orion.ModelFramework.Assets;
using Orion.ModelFramework;
using Orion.ModelFramework.Instruments;
using Orion.ModelFramework.MarketEnvironments;
using Orion.ModelFramework.PricingStructures;
using Orion.CurveEngine.Helpers;

#endregion

namespace Orion.ValuationEngine.Instruments
{
    public class PriceableFixedRateCoupon : PriceableRateCoupon, IPriceableFixedRateCoupon<IRateCouponParameters, IRateInstrumentResults>
    {
        #region Constructors

        public PriceableFixedRateCoupon()
        {
            PriceableCouponType = CouponType.FixedRate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceableRateCoupon"/> class.
        /// </summary>
        /// <param name="cashflowId">The stream id.</param>
        /// <param name="accrualStartDate">The accrual start date. If adjusted, the adjustCalculationDatesIndicator should be false.</param>
        /// <param name="accrualEndDate">The accrual end date. If adjusted, the adjustCalculationDatesIndicator should be false.</param>
        /// <param name="fixedRate">The fixed rate.</param>
        /// <param name="payerIsBase">The payer is base flag.</param>
        /// <param name="notionalAmount">The notional amount.</param>
        /// <param name="dayCountFraction">Type of day Count fraction.</param>
        /// <param name="expectedAmount">The expected amount. This is normally null, unless a calculated amount is overwritten.</param>
        /// <param name="paymentDate">The payment date.</param>
        /// <param name="discountingType">The swap discounting type.</param>
        /// <param name="discountRate">The discount rate.</param>
        /// <param name="fraDiscounting">Determines whether the coupon is discounted or not. If this parameter is null, 
        /// then it is assumed that there is no fra discounting</param>
        /// <param name="paymentCalendar">The paymentCalendar.</param>
        public PriceableFixedRateCoupon
            (
            string cashflowId
            , bool payerIsBase
            , DateTime accrualStartDate
            , DateTime accrualEndDate
            , DayCountFraction dayCountFraction
            , Decimal fixedRate
            , Money notionalAmount
            , Money expectedAmount
            , DateTime paymentDate
            , DiscountingTypeEnum? discountingType
            , Decimal? discountRate
            , FraDiscountingEnum? fraDiscounting
            , IBusinessCalendar paymentCalendar)
            : base(cashflowId, CouponType.FixedRate, payerIsBase, accrualStartDate, accrualEndDate,
            notionalAmount, dayCountFraction, fixedRate, paymentDate, discountingType, discountRate, 
            fraDiscounting, paymentCalendar)
        {
            ForecastAmount = expectedAmount;
            Id = cashflowId;
            CalculatePaymentAmount(0);
            ForecastAmount = PaymentAmount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceableRateCoupon"/> class.
        /// </summary>
        /// <param name="cashflowId">The stream id.</param>
        /// <param name="payerIsBase">The payer is base flag.</param>
        /// <param name="accrualStartDate">The accrual start date. If adjusted, the adjustCalculationDatesIndicator should be false.</param>
        /// <param name="accrualEndDate">The accrual end date. If adjusted, the adjustCalculationDatesIndicator should be false.</param>
        /// <param name="adjustCalculationDatesIndicator">if set to <c>true</c> [adjust calculation dates indicator].</param>
        /// <param name="accrualBusinessCenters">The accrual business centers.</param>
        /// <param name="fixedRate">The fixed rate.</param>
        /// <param name="notionalAmount">The notional amount.</param>
        /// <param name="dayCountFraction">Type of day Count fraction.</param>
        /// <param name="paymentDate">The payment date.</param>
        /// <param name="accrualRollConvention">The accrual roll convention.</param>
        /// <param name="discountingType">The swap discounting type.</param>
        /// <param name="discountRate">The discount rate.</param>
        /// <param name="fraDiscounting">Determines whether the coupon is discounted or not. If this parameter is null, 
        /// then it is assumed that there is no fra discounting</param>
        /// <param name="paymentCalendar">The paymentCalendar.</param>
        public PriceableFixedRateCoupon
            (
            string cashflowId
            , bool payerIsBase
            , DateTime accrualStartDate
            , DateTime accrualEndDate
            , Boolean adjustCalculationDatesIndicator
            , BusinessCenters accrualBusinessCenters
            , BusinessDayConventionEnum accrualRollConvention
            , DayCountFraction dayCountFraction
            , Decimal fixedRate
            , Money notionalAmount
            , AdjustableOrAdjustedDate paymentDate
            , DiscountingTypeEnum? discountingType
            , Decimal? discountRate
            , FraDiscountingEnum? fraDiscounting
            , IBusinessCalendar paymentCalendar)
            : base(cashflowId, CouponType.FixedRate, payerIsBase, accrualStartDate, accrualEndDate, adjustCalculationDatesIndicator,
                     accrualBusinessCenters, accrualRollConvention, dayCountFraction, fixedRate, notionalAmount, paymentDate, 
                    discountingType, discountRate, fraDiscounting, paymentCalendar)
        {
            Id = cashflowId;
            CalculatePaymentAmount(0);
            ForecastAmount = PaymentAmount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceableFixedRateCoupon"/> class.
        /// </summary>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="payerIsBase">The payer is base flag.</param>
        /// <param name="accrualStartDate">The accrual start date. If they are adjusted then set <c>adjustCalculationDatesIndicator</c> to <c>false</c> [adjust calculation dates indicator].</param>
        /// <param name="accrualEndDate">The accrual end date. If they are adjusted then set <c>adjustCalculationDatesIndicator</c> to <c>false</c> [adjust calculation dates indicator].</param>
        /// <param name="adjustCalculationDatesIndicator">if set to <c>true</c> [adjust calculation dates indicator].</param>
        /// <param name="accrualDayAdjustments">The accrual business day adjustments.</param>
        /// <param  name="paymentDate">The payment date.</param>
        /// <param name="calculation">The fixed rate calculation.</param>
        /// <param name="notionalAmount">The notional amount.</param>
        /// <param name="paymentCalendar">The paymentCalendar.</param>
        public PriceableFixedRateCoupon
            (
            string uniqueId
            , bool payerIsBase
            , DateTime accrualStartDate
            , DateTime accrualEndDate
            , Boolean adjustCalculationDatesIndicator
            , BusinessDayAdjustments accrualDayAdjustments
            , AdjustableOrAdjustedDate paymentDate
            , Calculation calculation
            , Money notionalAmount
            , IBusinessCalendar paymentCalendar)
            : base
                (uniqueId
                 , CouponType.FixedRate
                 , payerIsBase
                 , accrualStartDate
                 , accrualEndDate
                 , adjustCalculationDatesIndicator
                 , accrualDayAdjustments
                 , calculation
                 , notionalAmount
                 , paymentDate
                 , paymentCalendar)
        {
            Id = uniqueId;
        }

        #endregion

        #region InstrumentControllerBase

        public override AssetValuation Calculate(IInstrumentControllerData modelData)
        {
            ModelData = modelData;
            AnalyticModelParameters = null;
            AnalyticsModel = new FixedRateCouponAnalytic();
            IsRealised = HasBeenRealised(ModelData.ValuationDate);
            YearFractionToCashFlowPayment = GetPaymentYearFraction(ModelData.ValuationDate, PaymentDate);
            //Make sure there are some bucket dates even if not set previously.
            if (BucketedDates.Length < 1)
            {
                UpdateBucketingInterval(ModelData.ValuationDate, PeriodHelper.Parse(CDefaultBucketingInterval));
            } 
            IFxCurve fxCurve = null;
            if (Metrics != null)
            {
                //Add the extra metrics required
                var quotes = ModelData.AssetValuation.quote.ToList();
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.BreakEvenRate.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.BreakEvenRate.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.AccrualFactor.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.AccrualFactor.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.FloatingNPV.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.FloatingNPV.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.NPV.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.NPV.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.RiskNPV.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.RiskNPV.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.LocalCurrencyNPV.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.LocalCurrencyNPV.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                if (AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.LocalCurrencyExpectedValue.ToString()) == null)
                {
                    var quote = QuotationHelper.Create(0.0m, InstrumentMetrics.LocalCurrencyExpectedValue.ToString(), "DecimalValue", ModelData.ValuationDate);
                    quotes.Add(quote);
                }
                //Check if risk calc are required.
                bool delta1PDH = AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.LocalCurrencyDelta1PDH.ToString()) != null
                    || AssetValuationHelper.GetQuotationByMeasureType(ModelData.AssetValuation, InstrumentMetrics.Delta1PDH.ToString()) != null;
                ModelData.AssetValuation.quote = quotes.ToArray();
                var metrics = ResolveModelMetrics(AnalyticsModel.Metrics);
                //// Determine if DFAM has been requested - if so that is all we evaluate - every other metric is ignored
                //if (metrics.Contains(InstrumentMetrics.DiscountFactorAtMaturity))
                //{
                //    metrics.RemoveAll(metricItem => metricItem != InstrumentMetrics.DiscountFactorAtMaturity);
                //}
                //A list of IRateInstrumentResults
                if (metrics.Count > 0)
                {
                    var reportingCurrency = ModelData.ReportingCurrency == null ? PaymentCurrency.Value : ModelData.ReportingCurrency.Value;
                    IRateCouponParameters analyticModelParameters = new RateCouponParameters
                                                                        {
                                                                            Multiplier = Multiplier,
                                                                            ValuationDate = modelData.ValuationDate,
                                                                            PaymentDate = PaymentDate,
                                                                            DiscountType = DiscountType,
                                                                            Rate = GetRate(),
                                                                            Currency = PaymentCurrency.Value,
                                                                            ReportingCurrency = reportingCurrency,
                                                                            IsRealised = IsRealised,
                                                                            NotionalAmount = NotionalAmount.amount,
                                                                            YearFraction = GetAccrualYearFraction(),
                                                                            CurveYearFraction = YearFractionToCashFlowPayment
                                                                        };
                    FixedRateCouponAnalytic analyticsModel = null;
                    // Curve Related
                    IRateCurve discountCurve;
                    if (modelData.MarketEnvironment is ISwapLegEnvironment environment)
                    {
                        var streamMarketEnvironment = environment;
                        IRateCurve forecastCurve = streamMarketEnvironment.GetForecastRateCurve();
                        forecastCurve.PricingStructureEvolutionType = PricingStructureEvolutionType;
                        analyticModelParameters.ForecastCurve = forecastCurve;
                        discountCurve = streamMarketEnvironment.GetDiscountRateCurve();
                        discountCurve.PricingStructureEvolutionType = PricingStructureEvolutionType;
                        analyticModelParameters.DiscountCurve = discountCurve;
                        DiscountCurveName = discountCurve.GetPricingStructureId().UniqueIdentifier;
                        // Bucketed Delta
                        if (BucketedDates.Length > 1)
                        {
                            analyticModelParameters.PeriodAsTimesPerYear = GetPaymentYearFraction(BucketedDates[0], BucketedDates[1]);
                            analyticModelParameters.BucketedDiscountFactors =
                                GetBucketedDiscountFactors(discountCurve, ModelData.ValuationDate, BucketedDates);
                        }
                        //Check for currency.
                        if (ModelData.ReportingCurrency != null)
                        {
                            if (ModelData.ReportingCurrency.Value != PaymentCurrency.Value)
                            {
                                fxCurve = streamMarketEnvironment.GetReportingCurrencyFxCurve();
                                fxCurve.PricingStructureEvolutionType = PricingStructureEvolutionType;
                                analyticModelParameters.ReportingCurrencyFxCurve = fxCurve;
                            }
                        }
                        analyticsModel = new FixedRateCouponAnalytic(ModelData.ValuationDate, AccrualStartDate, AccrualEndDate, PaymentDate,
                            DiscountRate, analyticModelParameters.YearFraction, DiscountType, fxCurve, discountCurve, forecastCurve);
                    }
                    else if (modelData.MarketEnvironment.GetType() == typeof(MarketEnvironment))
                    {
                        var market = (MarketEnvironment)modelData.MarketEnvironment;
                        discountCurve = (IRateCurve)market.SearchForPricingStructureType(DiscountCurveName);
                        discountCurve.PricingStructureEvolutionType = PricingStructureEvolutionType;
                        analyticModelParameters.DiscountCurve = discountCurve;
                        // Bucketed Delta
                        if (BucketedDates.Length > 1)
                        {
                            analyticModelParameters.PeriodAsTimesPerYear = GetPaymentYearFraction(BucketedDates[0], BucketedDates[1]);
                            analyticModelParameters.BucketedDiscountFactors =
                                GetBucketedDiscountFactors(discountCurve, ModelData.ValuationDate, BucketedDates);
                        }
                        if (delta1PDH)
                        {
                            var riskMarket = market.SearchForPerturbedPricingStructures(DiscountCurveName, "delta1PDH");
                            analyticModelParameters.Delta1PDHCurves = riskMarket;
                            analyticModelParameters.Delta1PDHPerturbation = 10;
                        }
                        //Check for currency.
                        if (ModelData.ReportingCurrency != null)
                        {
                            if (ModelData.ReportingCurrency.Value != PaymentCurrency.Value)
                            {
                                string curveName = MarketEnvironmentHelper.ResolveFxCurveNames(PaymentCurrency.Value, modelData.ReportingCurrency.Value);
                                fxCurve = (IFxCurve)market.SearchForPricingStructureType(curveName);
                                fxCurve.PricingStructureEvolutionType = PricingStructureEvolutionType;
                                analyticModelParameters.ReportingCurrencyFxCurve = fxCurve;
                            }
                        }
                        analyticsModel = new FixedRateCouponAnalytic(ModelData.ValuationDate, AccrualStartDate, AccrualEndDate, PaymentDate,
                            DiscountRate, fxCurve, discountCurve);
                    }
                    AnalyticModelParameters = analyticModelParameters;                   
                    AnalyticsModel = analyticsModel;
                    if (AnalyticsModel != null)
                        CalculationResults = AnalyticsModel.Calculate<IRateInstrumentResults, RateInstrumentResults>(AnalyticModelParameters, metrics.ToArray());
                    CalculationPerformedIndicator = true;
                    if (analyticsModel != null) PaymentDiscountFactor = analyticsModel.PaymentDiscountFactor;
                    ForecastAmount = MoneyHelper.GetAmount(CalculationResults.LocalCurrencyExpectedValue, PaymentAmount.currency);
                    NPV = MoneyHelper.GetAmount(CalculationResults.LocalCurrencyNPV, PaymentAmount.currency);
                }
            }
            AssetValuation valuation = GetValue(CalculationResults, modelData.ValuationDate);
            valuation.id = Id;
            return valuation;
        }

        /// <summary>
        /// Builds the product with the calculated data.
        /// </summary>
        /// <returns></returns>
        public override Product BuildTheProduct()
        {
            return null;
        }

        #endregion

        #region FpML Representation

        /// <summary>
        /// Accrued amount at the given date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public override Money GetAccruedAmount(DateTime date)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Forecast amount at the given date.
        /// </summary>
        /// <returns></returns>
        public override Money GetForecastAmount()
        {
            return GetPaymentCalculationPeriod().forecastPaymentAmount;
        }

        /// <summary>
        /// Builds the calculation period.
        /// </summary>
        /// <returns></returns>
        protected override CalculationPeriod BuildCalculationPeriod()
        {
            CalculationPeriod cp = base.BuildCalculationPeriod();
            cp.Item1 = GetRate();
            return cp;
        }

        #endregion

        #region Implementation of IPriceableFixedRateCoupon<IRateCouponParameters,IRateInstrumentResults>

        /// <summary>
        /// Gets the fixed rate.
        /// </summary>
        /// <value>The rate.</value>
        public new decimal Rate
        {
            get
            {
                var rate = base.Rate;
                if (rate != null) return (Decimal)rate;
                return 0;
            }
            set => base.Rate = value;
        }

        #endregion

        #region Overrides of InstrumentControllerBase

        ///<summary>
        /// Gets all the child controllers.
        ///</summary>
        ///<returns></returns>
        public override IList<InstrumentControllerBase> GetChildren()
        {
            return null;
        }

        #endregion
    }
}