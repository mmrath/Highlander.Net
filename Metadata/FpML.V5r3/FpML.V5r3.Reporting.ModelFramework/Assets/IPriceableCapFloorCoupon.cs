﻿using System;
using FpML.V5r3.Reporting;

namespace Orion.ModelFramework.Assets
{
    ///<summary>
    ///</summary>
    ///<typeparam name="AMP"></typeparam>
    ///<typeparam name="AMR"></typeparam>
    public interface IPriceableCapFloorCoupon<AMP, AMR> : IPriceableFloatingRateCoupon<AMP, AMR> 
    {
        /// <summary>
        /// Gets or sets the cap strike.
        /// </summary>
        /// <value>The cap strike.</value>
        Decimal? CapStrike { get; set; }

        /// <summary>
        /// Gets or sets the floor strike.
        /// </summary>
        /// <value>The floor strike.</value>
        Decimal? FloorStrike { get; set; } 
    }
}