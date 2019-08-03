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
using System.Collections.Generic;
using System.Linq;
using Orion.Analytics.Interpolations;
using Orion.Analytics.Interpolations.Points;
using Orion.Analytics.Interpolations.Spaces;
using Orion.ModelFramework;
using FpML.V5r3.Reporting;

#endregion

namespace Orion.CurveEngine.PricingStructures.Interpolators
{
    /// <summary>
    /// The vol surface interpolator
    /// </summary>
    public class VolCurveInterpolator : InterpolatedCurve
    {
        /// <summary>
        /// VolSurfaceInterpolator
        /// </summary>
        /// <param name="discreteCurve"></param>
        /// <param name="interpolation"></param>
        /// <param name="allowExtrapolation"></param>
        public VolCurveInterpolator(IDiscreteSpace discreteCurve, InterpolationMethod interpolation, bool allowExtrapolation)
            : base(discreteCurve, InterpolationFactory.Create(interpolation.Value), allowExtrapolation)
        {
        }

        /// <summary>
        /// Builds a raw volatility surface from basic data types.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="interpolation"></param>
        /// <param name="allowExtrapolation"></param>
        /// <param name="baseDate"></param>
        public VolCurveInterpolator(MultiDimensionalPricingData data, InterpolationMethod interpolation, bool allowExtrapolation, DateTime baseDate)
            : base(ProcessMultiDimensionalPricingData(data, baseDate), InterpolationFactory.Create(interpolation.Value), allowExtrapolation)
        {
        }

        /// <summary>
        /// Builds a raw volatility surface from basic data types.
        /// </summary>
        /// <param name="timesAndVolatilities">The volatility curve.</param>
        /// <param name="interpolation">The interpolation function.</param>
        /// <param name="allowExtrapolation">The extrapolation flag.</param>
        public VolCurveInterpolator(IList<Tuple<double, double>> timesAndVolatilities, InterpolationMethod interpolation, bool allowExtrapolation)
            : base(new DiscreteCurve(ProcessTupleListElement1(timesAndVolatilities), ProcessTupleListElement2(timesAndVolatilities)), InterpolationFactory.Create(interpolation.Value), allowExtrapolation)
        {
        }

        internal static double[] ProcessTupleListElement1(IList<Tuple<double, double>> timesAndVolatilities)
        {
            return timesAndVolatilities.Select(tuple => tuple.Item1).ToArray();
        }

        internal static double[] ProcessTupleListElement2(IList<Tuple<double, double>> timesAndVolatilities)
        {
            return timesAndVolatilities.Select(tuple => tuple.Item2).ToArray();
        }

        internal static DiscreteSurface ProcessMultiDimensionalPricingData(MultiDimensionalPricingData data, DateTime baseDate)
        {
            var points = data.point.Select(point => new PricingDataPoint2D(point, baseDate)).Cast<IPoint>().ToList();
            var result = new DiscreteSurface(points);
            return result;
        }
    }
}