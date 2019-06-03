#region Using directives

using System;

#endregion

namespace Orion.Analytics.Distributions
{
    /// <summary>
    /// Abstract base for a basic random number generator.
    /// </summary>
    public abstract class BasicRng : IBasicRng
    {
        #region Implementation of ICloneable
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, 
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {}
        #endregion

        /// <summary>
        /// Draw a random sample for the generator.
        /// </summary>
        /// <remarks>
        /// Must be overridden by derived classes with a concrete RNG.
        /// </remarks>
        /// <returns>
        /// A double-precision floating point number greater than or equal to 0.0, 
        /// and less than 1.0.
        /// </returns>
        protected abstract double Sample();

        #region Implementation of IBasicRng

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>
        /// A double-precision floating point number greater than or equal to 0.0, 
        /// and less than 1.0.
        /// </returns>
        public virtual double NextDouble()
        {
            return Sample();
        }

        /// <summary>
        /// Returns an <see cref="Array"/> of random number between 0.0 and 1.0.
        /// </summary>
        /// <param name="r">
        /// A double-precision floating point <see cref="Array"/> to be filled
        /// with random numbers number greater than or equal to 0.0, and less than 1.0.
        /// </param>
        public void Next(double[] r)
        {
            Next(r, r.GetLowerBound(0), r.Length);
        }

        /// <summary>
        /// Returns an <see cref="Array"/> of random number between 0.0 and 1.0.
        /// </summary>
        /// <param name="r">
        /// A double-precision floating point <see cref="Array"/> to be filled
        /// with random numbers number greater than or equal to 0.0, and less than 1.0.
        /// </param>
        /// <param name="start">Index of the first elemnt to fill.</param>
        public void Next(double[] r, int start)
        {
            Next( r, start, r.GetUpperBound(0)-start+1);
        }

        /// <summary>
        /// Returns an <see cref="Array"/> of random number between 0.0 and 1.0.
        /// </summary>
        /// <param name="r">
        /// A double-precision floating point <see cref="Array"/> to be filled
        /// with random numbers number greater than or equal to 0.0, and less than 1.0.
        /// </param>
        /// <param name="start">Index of the first elemnt to fill.</param>
        /// <param name="length">Number of random numbers to generate.</param>
        public virtual void Next(double[] r, int start, int length)
        {
            for( length += start; start<length; start++)
                r[start] = Sample();
        }

        #endregion
    }
}