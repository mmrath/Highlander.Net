﻿using System;
using System.Collections.Generic;

namespace FpML.V5r10.Reporting.Models.Assets.Swaps
{
    public interface IIRSwapAssetParameters
    {
        /// <summary>
        /// Gets or sets the start discount factor.
        /// </summary>
        /// <value>The start discount factor.</value>
        double StartDiscountFactor { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        double Rate { get; set; }

        /// <summary>
        /// Gets or sets the base NPV.
        /// </summary>
        /// <value>The notional.</value>
        Decimal BaseNPV { get; set; }

        /// <summary>
        /// Gets or sets the isDiscounted flags.
        /// </summary>
        /// <value>The isDiscounted flag.</value>
        List<Boolean> IsDiscounted { get; set; }

        /// <summary>
        /// Gets or sets the notionals.
        /// </summary>
        /// <value>The notional.</value>
        List<double> Leg1Notionals { get; set; }

        /// <summary>
        /// Gets or sets the notionals.
        /// </summary>
        /// <value>The notional.</value>
        List<double> Leg2Notionals { get; set; }

        /// <summary>
        /// Gets or sets the upfront payment.
        /// </summary>
        /// <value>The upfront payment.</value>
        double Leg1UpFrontPayment { get; set; }

        /// <summary>
        /// Gets or sets the upfront payment.
        /// </summary>
        /// <value>The upfront payment.</value>
        double Leg2UpFrontPayment { get; set; }
        /// <summary>
        /// Gets or sets the discount factors.
        /// </summary>
        /// <value>The discount factors.</value>
        List<double> Leg1PaymentDiscountFactors { get; set; }

        /// <summary>
        /// Gets or sets the forecast factors.
        /// </summary>
        /// <value>The forecast factors.</value>
        List<double> Leg1ForecastDiscountFactors { get; set; }

        /// <summary>
        /// Gets or sets the forward rates.
        /// </summary>
        /// <value>The forward rates.</value>
        List<double> Leg1ForwardRates { get; set; }

        /// <summary>
        /// Gets or sets the forward rates.
        /// </summary>
        /// <value>The forward rates.</value>
        List<double> Leg2ForwardRates { get; set; }

        /// <summary>
        /// Gets or sets the discount factors.
        /// </summary>
        /// <value>The discount factors.</value>
        List<double> Leg2PaymentDiscountFactors { get; set; }

        /// <summary>
        /// Gets or sets the forecast factors.
        /// </summary>
        /// <value>The forecast factors.</value>
        List<double> Leg2ForecastDiscountFactors { get; set; }

        /// <summary>
        /// Gets or sets the year fractions.
        /// </summary>
        /// <value>The year fractions.</value>
        List<double> Leg1YearFractions { get; set; }

        /// <summary>
        /// Gets or sets the year fractions.
        /// </summary>
        /// <value>The year fractions.</value>
        List<double> Leg2YearFractions { get; set; }

        /// <summary>
        /// Gets or sets the spreads.
        /// </summary>
        /// <value>The spreads.</value>
        List<double> Leg1Spreads { get; set; }

        /// <summary>
        /// Gets or sets the spreads.
        /// </summary>
        /// <value>The spreads.</value>
        List<double> Leg2Spreads { get; set; }
    }
}