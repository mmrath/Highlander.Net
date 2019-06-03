﻿using System;

namespace FpML.V5r10.Reporting.ModelFramework.Assets
{
    /// <summary>
    /// Base rate asset controller interface
    /// </summary>
    public interface IPriceableCreditAssetController : IPriceableAssetController
    {

        /// <summary>
        /// Gets the survival probability at maturity.
        /// </summary>
        /// <value>The survival probability at maturity.</value>
        Decimal SurvivalProbabilityAtMaturity { get; }
    }
}