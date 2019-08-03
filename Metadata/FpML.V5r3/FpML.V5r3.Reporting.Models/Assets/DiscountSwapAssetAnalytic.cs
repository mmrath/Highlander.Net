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

using System;

namespace Orion.Models.Assets
{
    /// <summary>
    /// Base Rate Asset Analytic
    /// </summary>
    public class DiscountSwapAssetAnalytic : SwapAssetAnalytic
    {
        /// <summary>
        /// Evaluates the implied quote.
        /// </summary>
        /// <returns></returns>
        protected override Decimal EvaluateAccrualFactor()
        {
            var totalDfsCount = AnalyticParameters.DiscountFactors.Length;
            var accrualFactorTotal = 0.0m;
            for (var index = 1; index < totalDfsCount; index++)
            {
                accrualFactorTotal += AnalyticParameters.DiscountFactors[index] *
                                      AnalyticParameters.YearFractions[index - COne] *
                                      AnalyticParameters.Weightings[index - COne] *
                                      EvaluatePrice(AnalyticParameters.YearFractions[index - COne]);
            }
            return accrualFactorTotal;
        }

        /// <summary>
        /// Gets the discount price.
        /// </summary>
        /// <returns></returns>
        private Decimal EvaluatePrice(decimal yearFraction)
        {
            return 1 / (1 + yearFraction * AnalyticParameters.Rate);
        }
    }
}