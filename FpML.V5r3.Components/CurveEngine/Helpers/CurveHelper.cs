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
using Orion.Analytics.Interpolations.Points;
using Orion.Analytics.Interpolations.Spaces;
using Orion.ModelFramework;
using Orion.Util.NamedValues;
using FpML.V5r3.Reporting;

#endregion

namespace Orion.CurveEngine.Helpers
{
    /// <summary>
    /// Creates an interpolation class.
    /// </summary>
    public class CurveHelper //TODO convert this to an analytical model.
    {
        //public static NamedValueSet CombinePropertySets(NamedValueSet baseProperties, NamedValueSet additionalProperties)
        //{
        //    var properties = additionalProperties.ToDictionary();
        //    foreach (var nvs in properties.Keys)
        //    {
        //        var value = properties[nvs];
        //        baseProperties.Set(nvs, value);
        //    }
        //    return baseProperties;
        //}

        public static NamedValueSet CombinePropertySetsClone(NamedValueSet baseProperties, NamedValueSet additionalProperties)
        {
            var properties = additionalProperties.ToDictionary();
            var cloneProperties = baseProperties.Clone();
            foreach (var nvs in properties.Keys)
            {
                var value = properties[nvs];
                cloneProperties.Set(nvs, value);
            }
            return cloneProperties;
        }

        ///<summary>
        ///</summary>
        ///<param name="termCurve"></param>
        ///<param name="baseDate"></param>
        ///<param name="dayCounter"></param>
        ///<returns></returns>
        public static DiscreteCurve Converter(TermCurve termCurve, DateTime baseDate, IDayCounter dayCounter)
        {
            var curve = new DiscreteCurve(PointCurveHelper(termCurve, baseDate, dayCounter));
            return curve;
        }

        ///<summary>
        ///</summary>
        ///<param name="termCurve"></param>
        ///<param name="baseDate"></param>
        ///<param name="dayCounter"></param>
        ///<returns></returns>
        public static List<IPoint> PointCurveHelper(TermCurve termCurve, DateTime baseDate, IDayCounter dayCounter)
        {
            var points = new List<IPoint>();
            foreach (var termPoint in termCurve.point)
            {
                var dayCount = dayCounter.YearFraction(baseDate, (DateTime)termPoint.term.Items[0]);
                //TODO extend to check if term or dates.
                //
                var value = (double)termPoint.mid;
                IPoint point = new Point1D(dayCount, value); //TODO check terms and dates.
                points.Add(point);
            }
            return points;
        }

        ///<summary>
        ///</summary>
        ///<param name="termCurve"></param>
        ///<returns></returns>
        public static bool IsExtrapolationPermitted(TermCurve termCurve)
        {
            var isExtrapolationPermitted = termCurve.extrapolationPermittedSpecified && termCurve.extrapolationPermitted;
            return isExtrapolationPermitted;
        }
    }
}