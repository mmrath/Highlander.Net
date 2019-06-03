#region Using directives

using System;
using FpML.V5r3.Reporting;

#endregion

namespace Orion.Analytics.Helpers
{
    ///<summary>
    /// PropertyNameValueType
    ///</summary>
    public class PropertyNameValueType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name;
        public object Value;
        public string Type;
    }

    ///<summary>
    /// MarketEnvironementRangeItem
    ///</summary>
    public class MarketEnvironementRangeItem
    {
        public string IndexName;
        public string CurveId;
    }

    /// <summary>
    /// ValuationRange
    /// </summary>
    public class ValuationRange
    {
        public string BaseParty;
        public DateTime ValuationDate;
        //public string ReportingCurrency;
        //public List<string> Metrics;
        //public IDictionary<string, string> CurveMapping;
    }

    /// <summary>
    /// TradeRange
    /// </summary>
    public class TradeRange
    {
        public string Id;
        public DateTime TradeDate;
    }

    /// <summary>
    /// DateTimeDoubleRangeItem
    /// </summary>
    public class DateTimeDoubleRangeItem
    {
        ///<summary>
        /// Creates a DateTimeDoubleRangeItem.
        ///</summary>
        ///<param name="dateTime"></param>
        ///<param name="value"></param>
        ///<returns></returns>
        public static DateTimeDoubleRangeItem Create(DateTime dateTime, double value)
        {
            var result = new DateTimeDoubleRangeItem { DateTime = dateTime, Value = value };
            return result;
        }

        public DateTime DateTime;
        public double Value;
    }

    ///<summary>
    /// DetailedCashflowRangeItem
    ///</summary>
    [Serializable]
    public class InputCashflowRangeItem
    {
        public DateTime FixingDate;
        public DateTime StartDate;
        public DateTime EndDate;
        public DateTime PaymentDate;
        public double NotionalAmount;
        public string CouponType;//Float,Fixed,PrincipalExchange?,Cap,Floor
        public double Rate;
        public double Spread;
        public double StrikeRate;//for cap/floor
    }

    ///<summary>
    /// DetailedCashflowRangeItem
    ///</summary>
    [Serializable]
    public class DetailedCashflowRangeItem : InputCashflowRangeItem
    {
        public string Currency;
        public int NumberOfDays;
        public double FutureValue;
        public double PresentValue;
        public double DiscountFactor;
    }

    /// <summary>
    /// InputPrincipalExchangeCashflowRangeItem
    /// </summary>
    public class InputPrincipalExchangeCashflowRangeItem
    {
        public DateTime PaymentDate;
        public string Currency;
        public double Amount;
    }

    /// <summary>
    /// DetailedCashflowRangeItem
    /// </summary>
    public class PrincipalExchangeCashflowRangeItem : InputPrincipalExchangeCashflowRangeItem
    {
        //public int      PeriodNumber;
        //public DateTime PaymentDate;
        //public string Currency;
        //public double Amount;
        public double PresentValueAmount;
        public double DiscountFactor;
        //public double  OutstandingNotionalAmount;
    }

    /// <summary>
    /// AdditionalPaymentRangeItem
    /// </summary>
    public class AdditionalPaymentRangeItem
    {
        //public int      PeriodNumber;
        public DateTime PaymentDate;
        public double Amount;
        public string Currency;
    }

    /// <summary>
    /// FilenameRange
    /// </summary>
    public class FilenameRange
    {
        public string Filename;
    }

    /// <summary>
    /// FraInputRange
    /// </summary>
    public class FraInputRange2
    {
        public string TradeId;
        public string Party1;
        public string Party2;
        public string IsParty1Buyer;
        public DateTime TradeDate;
        public DateTime AdjustedEffectiveDate;
        public DateTime AdjustedTerminationDate;
        public DateTime UnadjustedPaymentDate;
        public string PaymentDateBusinessDayConvention;
        public string PaymentDateBusinessCenters;
        public string FixingDayOffsetPeriod;
        public string FixingDayOffsetDayType;
        public string FixingDayOffsetBusinessDayConvention;
        public string FixingDayOffsetBusinessCenters;
        public string FixingDayOffsetDateRelativeTo;
        public string DayCountFraction;
        public double NotionalAmount;
        public string NotionalCurrency;
        public double FixedRate;
        public string FloatingRateIndex;
        public string IndexTenor;
        public FraDiscountingEnum FraDiscounting;
    }

    /// <summary>
    /// FraInputRange
    /// </summary>
    public class FraInputRange
    {
        public DateTime AdjustedEffectiveDate;
        public DateTime AdjustedTerminationDate;
        public DateTime UnadjustedPaymentDate;
        public string PaymentDateBusinessDayConvention;
        public string PaymentDateBusinessCenters;
        public string FixingDayOffsetPeriod;
        public string FixingDayOffsetDayType;
        public string FixingDayOffsetBusinessDayConvention;
        public string FixingDayOffsetBusinessCenters;
        public string FixingDayOffsetDateRelativeTo;
        public string DayCountFraction;
        public double NotionalAmount;
        public string NotionalCurrency;
        public double FixedRate;
        public string FloatingRateIndex;
        public string IndexTenor;
        public FraDiscountingEnum FraDiscounting;
        public string Sell;
        public string ForwardCurveId;
        public string DiscountingCurveId;
        public DateTime ValuationDate;
    }

    /// <summary>
    /// RateCurveTermsRange
    /// </summary>
    public class RateCurveTermsRange
    {
        public DateTime BuildDateTime;
        public DateTime ReferenceDateTime;
        public string TimeState;
        public string Owner;
        public string Validity;
        public string IndexName;
        public string IndexTenor;
        public string Algorithm;
    }

    /// <summary>
    /// DateTimeRangeItem
    /// </summary>
    public class DateTimeRangeItem
    {
        public DateTime Value;
    }

    /// <summary>
    /// DateTimePairRangeItem
    /// </summary>
    public class DateTimePairRangeItem
    {
        public DateTime Value1;
        public DateTime Value2;
    }

    /// <summary>
    /// InstrumentIdAndQuoteRangeItem
    /// </summary>
    public class InstrumentIdAndQuoteRangeItem
    {
        public string InstrumentId;
        public double Quote;
    }

    /// <summary>
    /// FuturesCodeAndConvexityAdjustmentRangeItem
    /// </summary>
    public class FuturesCodeAndConvexityAdjustmentRangeItem
    {
        public string FuturesCode;
        public double ConvexityAdjustment;
    }

    /// <summary>
    /// DoubleRangeItem
    /// </summary>
    public class DoubleRangeItem
    {
        public double Value;
    }

    /// <summary>
    /// StringRangeItem
    /// </summary>
    public class StringRangeItem
    {
        public string Value;
    }

    /// <summary>
    /// StringDoubleRangeItem
    /// </summary>
    public class StringDoubleRangeItem
    {
        public string StringValue;
        public double DoubleValue;
    }

    /// <summary>
    /// StringObjectRangeItem
    /// </summary>
    public class StringObjectRangeItem
    {
        public string StringValue;
        public object ObjectValue;
    }

    /// <summary>
    /// ValuationInfoRangeItem
    /// </summary>
    public class ValuationInfoRangeItem
    {
        public string Description;
        public string Id;
    }

    /// <summary>
    /// PartyIdRangeItem
    /// </summary>
    public class PartyIdRangeItem
    {
        public string PartyId;
        public string IdOrRole;
    }

    /// <summary>
    /// OtherPartyPaymentRangeItem
    /// </summary>
    public class OtherPartyPaymentRangeItem
    {
        public DateTime PaymentDate;
        public string PaymentType;
        public decimal Amount;//try decimal
        public string Payer;
        public string Receiver;
    }

    /// <summary>
    /// FeePaymentRangeItem
    /// </summary>
    public class FeePaymentRangeItem
    {
        public DateTime PaymentDate;
        public string Currency;
        public decimal Amount;
        public string Payer;
        public string Receiver;
    }

    /// <summary>
    /// ThreeStringsRangeItem
    /// </summary>
    public class ThreeStringsRangeItem
    {
        public string Value1;
        public string Value2;
        public string Value3;
    }
}