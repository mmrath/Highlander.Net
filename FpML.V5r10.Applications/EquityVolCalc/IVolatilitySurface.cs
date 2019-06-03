﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Orion.Analytics.Helpers;
using Orion.Analytics.Interpolations.Spaces;

namespace Orion.Equity.VolatilityCalculator
{
     /// <summary>
    /// Defines the basic attributes for a volatility surface
    /// </summary>
    public interface IVolatilitySurface
    {
        /// <summary>
        /// Gets a value indicating whether this surface is complete.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        Boolean IsComplete { get; }


        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        DateTime Date { get; set; }

        /// <summary>
        /// Gets the expiries.
        /// </summary>
        /// <value>The expiries.</value>
        [XmlArray("Expiries")]
        ForwardExpiry[] Expiries { get; }

         /// <summary>
         /// 
         /// </summary>
        ForwardExpiry[] NodalExpiries { get; }
      
        /// <summary>
        /// Adds the expiry.
        /// </summary>
        /// <param name="expiry">The expiry.</param>
        void AddExpiry(ForwardExpiry expiry);

        /// <summary>
        /// Removes the expiry.
        /// </summary>
        /// <param name="expiry">The expiry.</param>
        void RemoveExpiry(ForwardExpiry expiry);

        /// <summary>
        /// Calibrates this instance.
        /// </summary>
        void Calibrate();

         /// <summary>
         /// Values at.
         /// </summary>
         /// <param name="stock"></param>
         /// <param name="expiries">The expiries.</param>
         /// <param name="strikes">The strikes.</param>
         /// <param name="?">Cache to vol object</param>
         /// <param name="cache"></param>
         /// <returns></returns>
         List<ForwardExpiry> ValueAt(Stock stock, List<DateTime> expiries, List<Double> strikes, bool cache);

         /// <summary>
         /// Values at.
         /// </summary>
         /// <param name="stock"></param>
         /// <param name="expiry">The expiry.</param>
         /// <param name="strikes">The strikes.</param>
         /// <param name="parms">The parms.</param>
         /// <param name="oride"></param>
         /// <param name="cache">if set to <c>true</c> [cache].</param>
         /// <returns></returns>
         ForwardExpiry ValueAt(Stock stock, DateTime expiry, List<Double> strikes, OrcWingParameters parms, bool oride, bool cache);


        /// <summary>
        /// Sets the interpolated curve.
        /// </summary>
        void SetInterpolatedCurve();

        /// <summary>
        /// Gets the interpolated curve.
        /// </summary>
        ExtendedInterpolatedSurface GetInterpolatedCurve();


       

 

    



      

      


    }
}
