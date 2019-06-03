﻿using System;
using System.Collections.Generic;
using FpML.V5r10.Reporting.ModelFramework;
using FpML.V5r10.Reporting.Models.Generic.Cashflows;

namespace FpML.V5r10.Reporting.Models.Generic.Coupons
{
    public class CouponParameters : CashflowParameters, ICouponParameters
    {
        /// <summary>
        /// Gets or sets the accrual factor.
        /// </summary>
        /// <value>The accrual factor.</value>
        public decimal AccrualFactor { get; set; }


        /// <summary>
        /// Gets or sets the discount curves for calculating Delta0PDH metrics.
        /// </summary>
        /// <value>The discount curves.</value>
        public ICollection<IPricingStructure> Delta0PDHCurves { get; set; }

        /// <summary>
        /// Gets or sets the perturbation for the Delta0PDH metrics.
        /// </summary>
        /// <value>The discount curves.</value>
        public Decimal Delta0PDHPerturbation { get; set; }

        /// <summary>
        /// Gets or sets the discounting flag.
        /// </summary>
        /// <value>The isDiscounted flag.</value>
        public bool HasReset { get; set; }

        /// <summary>
        /// Gets or sets the expected amount.
        /// </summary>
        /// <value>The expected amount.</value>
        public Decimal? ExpectedAmount { get; set; }

        /// <summary>
        /// Gets or sets the spread.
        /// </summary>
        /// <value>The spread.</value>
        public Decimal Spread { get; set; }

        /// <summary>
        /// Gets or sets the year fraction.
        /// </summary>
        /// <value>The year fraction.</value>
        public decimal YearFraction { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        public decimal Index { get; set; }

    }
}