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

namespace Orion.Analytics.Statistics
{
    /// <summary>
    /// Weighted sample.
    /// </summary>
    public struct Sample 
    {
        ///<summary>
        ///</summary>
        ///<param name="value"></param>
        public Sample(object value) : this(value, 1.0)
        {}
        ///<summary>
        ///</summary>
        ///<param name="value"></param>
        ///<param name="weight"></param>
        public Sample(object value, double weight)
        {
            Value = value;
            Weight = weight;
        }
        public double Weight;
        public object Value;
        ///<summary>
        ///</summary>
        ///<param name="sample"></param>
        ///<returns></returns>
        public static explicit operator double(Sample sample)
        {
            return (double)sample.Value;
        }
    }

    //! weighted sample
    /*! \ingroup mcarlo */
    public class Sample<T>
    {
        public T Value { get; set; }

        public double Weight { get; set; }

        public Sample(T value, double weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}