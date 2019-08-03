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

#region Using directives

using System;

#endregion

namespace Orion.ModelFramework.PricingStructures
{
    /// <summary>
    /// The Pricing Structure Interface
    /// </summary>
    public interface ISwaptionATMVolatilitySurface : IVolatilitySurface
    {
        /// <summary>
        /// Gets the volatility using a DateTime expiry and a tenor value.
        /// </summary>
        /// <param name="baseDate">The base date.</param>
        /// <param name="expirationAsDate">The expiration date.</param>
        /// <param name="tenor">The underlying tenor.</param>
        /// <returns>The interpolated value.</returns>
        Double GetValueByExpiryDateAndTenor(DateTime baseDate, DateTime expirationAsDate, String tenor);

        /// <summary>
        /// Gets the volatility using a DateTime expiry and a tenor value.
        /// </summary>
        /// <param name="expirationTerm">The expiration term.</param>
        /// <param name="tenor">The underlying tenor.</param>
        /// <returns>The interpolated value.</returns>
        Double GetValueByExpiryTermAndTenor(String expirationTerm, String tenor);
    }
}