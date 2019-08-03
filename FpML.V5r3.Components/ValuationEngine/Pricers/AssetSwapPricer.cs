/*
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
using Core.Common;
using Orion.Util.Helpers;
using Orion.Util.Logging;
using FpML.V5r3.Reporting;
using Orion.Models.Rates.Swap;
using FpML.V5r3.Codes;
using Orion.ModelFramework;

#endregion

namespace Orion.ValuationEngine.Pricers
{
    public class AssetSwapPricer : InterestRateSwapPricer
    {
        /// <summary>
        /// 
        /// </summary>
        public Bond UnderlyingBond { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AssetSwapPricer()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cache"></param>
        /// <param name="nameSpace"></param>
        /// <param name="legCalendars"></param>
        /// <param name="swapFpML"></param>
        /// <param name="basePartyReference"></param>
        /// <param name="bondReference"></param>
        public AssetSwapPricer(ILogger logger, ICoreCache cache, String nameSpace,
            List<Pair<IBusinessCalendar, IBusinessCalendar>> legCalendars,
            Swap swapFpML, string basePartyReference, Bond bondReference)
            : base(logger, cache, nameSpace, legCalendars, swapFpML, basePartyReference, false)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cache"></param>
        /// <param name="nameSpace"></param>
        /// <param name="legCalendars"></param>
        /// <param name="swapFpML"></param>
        /// <param name="basePartyReference"></param>
        /// <param name="bondReference"></param>
        /// <param name="forecastRateInterpolation"></param>
        public AssetSwapPricer(ILogger logger, ICoreCache cache, String nameSpace,
            List<Pair<IBusinessCalendar, IBusinessCalendar>> legCalendars, 
            Swap swapFpML, string basePartyReference, Bond bondReference, Boolean forecastRateInterpolation)
            : base(logger, cache, nameSpace, legCalendars, swapFpML, basePartyReference, forecastRateInterpolation)
        {
            AnalyticsModel = new SimpleIRSwapInstrumentAnalytic();
            ProductType = ProductTypeSimpleEnum.AssetSwap;
            UnderlyingBond = bondReference;
        }
    }
}