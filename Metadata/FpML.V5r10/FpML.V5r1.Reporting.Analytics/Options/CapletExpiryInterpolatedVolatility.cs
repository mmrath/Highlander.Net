﻿#region Using Directives

using System;
using System.Collections.Generic;
using National.QRSC.Analytics.Interpolations;
using National.QRSC.Analytics.PricingEngines;
using National.QRSC.Analytics.Utilities;
using National.QRSC.Business.DayCounters;
using National.QRSC.ModelFramework;

#endregion

namespace National.QRSC.Analytics.Options
{
    /// <summary>
    /// Enum for the various interpolation types available to clients
    /// to compute the expiry interpolated Caplet volatility.
    /// </summary>
    public enum ExpiryInterpolationType
    {        
        ///<summary>
        /// cubic Hermite spline interpolation 
        ///</summary>
        CubicHermiteSpline = 0,
       
        ///<summary>
        /// linear interpolation
        ///</summary>
        Linear = 1  
    }

    /// <summary>
    /// Class that encapsulates the business logic to compute by one dimensional
    /// interpolation a Caplet volatility from a set of known bootstrap Caplet
    /// volatilities. The bootstrap Caplet volatilities form the nodal (knot) 
    /// points for the interpolation.
    /// An enumerated list of one dimensional interpolation schemes are
    /// available to clients of the class.
    /// </summary>
    public class CapletExpiryInterpolatedVolatility
    {
        #region Constructor

        /// <summary>
        /// Constructor for <see cref="CapletExpiryInterpolatedVolatility"/>
        /// class.
        /// </summary>
        /// <param name="capletBootstrapEngine">The Caplet Bootstrap Engine
        /// that contains the results of the bootstrap.
        /// Precondition: IsCapletBootstrapSuccessful method applied to the
        /// Caplet bootstrap engine returns "true".</param>
        /// <param name="expiryInterpolationType">Type of one dimensional
        /// interpolation that will be applied to the expiry.</param>
        public CapletExpiryInterpolatedVolatility
            (CapletBootstrapEngine capletBootstrapEngine,
             ExpiryInterpolationType expiryInterpolationType)
        {
            ValidateConstructorArguments(capletBootstrapEngine);
            InitialisePrivateFields
                (capletBootstrapEngine, expiryInterpolationType);
        }

        #endregion

        #region Public Business Logic Methods

        /// <summary>
        /// Computes the expiry interpolated Caplet volatility.
        /// </summary>
        /// <param name="expiry">The expiry date.
        /// Postcondition: expiry cannot be before the Calculation date.</param>
        /// <returns>Expiry interpolated Caplet volatility.</returns>
        public decimal ComputeCapletVolatility(DateTime expiry)
        {
            // Convert the expiry into a corresponding time in ACT/365
            // day count.
            IDayCounter dayCountObj = new Actual365();
            var target =
                dayCountObj.YearFraction
                              (_calculationDate, expiry);

            // Validate the time equivalent to the expiry date.
            var TargetErrorMessage =
                "Expiry cannot be before: " + _calculationDate;
            DataQualityValidator.ValidateMinimum
                (target, 0.0d, TargetErrorMessage, true);

            // Compute and return the Caplet volatility: flat line extrapolate
            // at each end.
            decimal capletVolatility;
            if (target < 0.0d)
            {
                const string ErrorMessage =
                    "Date cannot be before the Calculation Date";

                throw new ArgumentException(ErrorMessage);
            }
            if (target >= 0.0d && target < decimal.ToDouble(_firstExpiry))
            {
                capletVolatility = _firstCapletVolatility;
            }
            else capletVolatility = target > decimal.ToDouble(_lastExpiry) ? _lastCapletVolatility : (decimal)_expiryInterpolationObj.ValueAt(target, true);

            return capletVolatility;
        }

        #endregion

        #region Private Data Initialisation and Validation Methods

        /// <summary>
        /// Helper function used to initialise the private fields.
        /// </summary>
        /// <param name="capletBootstrapEngine">The Caplet Bootstrap engine
        /// that contains the results of the bootstrap.</param>
        /// <param name="expiryInterpolationType">Type of the expiry
        /// interpolation.
        /// Example: Linear interpolation.</param>
        private void InitialisePrivateFields
            (CapletBootstrapEngine capletBootstrapEngine,
             ExpiryInterpolationType expiryInterpolationType)
        {
            // Initialise the Calculation Date.
            _calculationDate =
                capletBootstrapEngine.CapletBootstrapSettings.CalculationDate;

            // Set the x and y arrays for the one dimensional interpolation.            
            var results
                = capletBootstrapEngine.CapletBootstrapResults.Results;

            IDayCounter dayCountObj = new Actual365();
            var tempXArray = new List<double>();
            var tempYArray = new List<double>();

            var count = 1;
            foreach (var expiry in results.Keys)
            {
                var timeToExpiry = dayCountObj.YearFraction
                                                    (_calculationDate, expiry);
                tempXArray.Add(timeToExpiry);
                tempYArray.Add(decimal.ToDouble(results[expiry]));

                // Record the first and last time to expiry and available 
                // bootstrap Caplet volatility.
                if (count == 1)
                {
                    _firstExpiry = (decimal)timeToExpiry;
                    _firstCapletVolatility = results[expiry];
                }
                _lastCapletVolatility = results[expiry];
                _lastExpiry = (decimal)timeToExpiry;
                ++count;
            }

            double[] xArray = tempXArray.ToArray();
            double[] yArray = tempYArray.ToArray();
    
            // Initialise the one dimensional interpolation object.
            switch (expiryInterpolationType)
            {
                case ExpiryInterpolationType.CubicHermiteSpline:
                    _expiryInterpolationObj =
                        new CubicHermiteSplineInterpolation();
                    _expiryInterpolationObj.Initialize(xArray, yArray);
                    break;

                default: // Linear interpolation                    
                    _expiryInterpolationObj = new Interpolations.LinearInterpolation();
                    _expiryInterpolationObj.Initialize(xArray, yArray);
                    break;
            }
        }

        /// <summary>
        /// Helper function used to validate the arguments to the constructor.
        /// Exception: ArgumentException.
        /// </summary>
        /// <param name="capletBootstrapEngine">The Caplet bootstrap engine
        /// that contains the results of the bootstrap.
        /// Precondition: IsCapletBootstrapSuccessful method applied to the
        /// Caplet bootstrap engine returns "true".</param>
        private static void ValidateConstructorArguments
            (CapletBootstrapEngine capletBootstrapEngine)
        {
            // Check for a valid Caplet Bootstrap Engine.
            if (capletBootstrapEngine == null)
            {
                const string ErrorMessage =
                    "Caplet expiry interpolation found a NULL calibration engine";

                throw new ArgumentException(ErrorMessage);
            }

            if (capletBootstrapEngine.IsCapletBootstrapSuccessful)
            {
            }
            else
            {
                const string ErrorMessage =
                    "Caplet expiry interpolation requires a successful bootstrap";

                throw new ArgumentException(ErrorMessage);
            }
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// Reference date for all cashflows.
        /// </summary>
        private DateTime _calculationDate;
        
        /// <summary>
        /// One dimensional interpolation object that will perform the
        /// expiry interpolation.
        /// </summary>
        private IInterpolation _expiryInterpolationObj;

        /// <summary>
        /// First available bootstrap Caplet volatility.
        /// </summary>
        private decimal _firstCapletVolatility;

        /// <summary>
        /// First expiry for which a bootstrap Caplet volatility is available.
        /// </summary>
        private decimal _firstExpiry;

        /// <summary>
        /// Last available bootstrap Caplet volatility.
        /// </summary>
        private decimal _lastCapletVolatility;

        /// <summary>
        /// Last expiry for which a bootstrap Caplet volatility is available.
        /// </summary>
        private decimal _lastExpiry;

        #endregion

    }
}