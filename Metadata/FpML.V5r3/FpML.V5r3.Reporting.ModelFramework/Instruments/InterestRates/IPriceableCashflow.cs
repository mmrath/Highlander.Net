﻿using System;
using FpML.V5r3.Reporting;

namespace Orion.ModelFramework.Instruments.InterestRates
{
    /// <summary>
    /// Base interface for all priceable cashflows
    /// </summary>
    public interface IPriceableCashflow<AMP, AMR> : IMetricsCalculation<AMP, AMR>
    {
        /// <summary>
        /// Gets the payment type.
        /// </summary>
        /// <value>The payment type.</value>
        PaymentType PaymentType { get; set; }

        /// <summary>
        /// Gets the cash flow type.
        /// </summary>
        /// <value>The cash flow type.</value>
        CashflowType CashflowType { get; set; }

        /// <summary>
        /// Gets boolean flag indicating if the cash flow is realised.
        /// </summary>
        /// <value>The boolean flag indicating if the cash flow is realised.</value>
        Boolean IsRealised { get; }

        /// <summary>
        /// Gets the boolean flag indicating whether the payment date is included in npv.
        /// </summary>
        /// <value>The boolean flag indicating whether the payment date is included in npv.</value>
        Boolean PaymentDateIncluded { get; set; }

        /// <summary>
        /// Gets the payment date.
        /// </summary>
        /// <value>The payment date.</value>
        DateTime PaymentDate { get; }

        /// <summary>
        /// Gets the adjustable unadjusted payment date.
        /// </summary>
        /// <value>The adjustable unadjusted payment date.</value>
        AdjustableDate AdjustableUnadjustedPaymentDate { get; }

        /// <summary>
        /// Gets the unadjusted payment date.
        /// </summary>
        /// <value>The unadjusted payment date.</value>
        DateTime UnadjustedPaymentDate { get; }

        /// <summary>
        /// Gets the notional amount.
        /// </summary>
        /// <value>The notional amount.</value>
        Money NotionalAmount { get; }

        /// <summary>
        /// Gets the notional.
        /// </summary>
        /// <value>The notional.</value>
        Decimal Notional { get; }

        /// <summary>
        /// Gets the name of the discount curve.
        /// </summary>
        /// <value>The name of the discount curve.</value>
        string DiscountCurveName { get; }
    }
}