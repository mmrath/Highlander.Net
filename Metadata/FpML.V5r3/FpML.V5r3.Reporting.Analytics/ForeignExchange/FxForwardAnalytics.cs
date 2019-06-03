﻿/*
 Copyright (C) 2019 Alex Watt (alexwatt@hotmail.com)

 This file is part of Highlander Project https://github.com/awatt/highlander

 Highlander is free software: you can redistribute it and/or modify it
 under the terms of the Highlander license.  You should have received a
 copy of the license along with this program; if not, license is
 available at <https://github.com/awatt/highlander/blob/develop/LICENSE>.

 This program is distributed in the hope that it will be useful, but WITHOUT
 ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 FOR A PARTICULAR PURPOSE.  See the license for more details.
*/

using Orion.Analytics.Rates;

namespace Orion.Analytics.ForeignExchange
{
    ///<summary>
    ///</summary>
    public class FxForwardAnalytics : BasicRateAnalytics
    {
        ///<summary>
        ///</summary>
        ///<param name="spotRate"></param>
        ///<param name="baseStartDiscountfactor"></param>
        ///<param name="baseEndDiscountFactor"></param>
        ///<param name="crossStartDiscountFactor"></param>
        ///<param name="crossEndDiscountFactor"></param>
        ///<returns></returns>
        public static decimal EvaluateForwardRate(decimal spotRate, 
                                                  decimal baseStartDiscountfactor, decimal baseEndDiscountFactor,
                                                  decimal crossStartDiscountFactor, decimal crossEndDiscountFactor)
        {
            return (spotRate*baseStartDiscountfactor*crossEndDiscountFactor)/
                   (crossStartDiscountFactor*baseEndDiscountFactor);
        }
    }
}