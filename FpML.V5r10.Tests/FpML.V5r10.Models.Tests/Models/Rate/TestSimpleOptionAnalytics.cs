﻿using System;
using System.Diagnostics;
using FpML.V5r10.Reporting.Models.Rates.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Orion.V5r10.Models.Tests.Models.Rate
{
    [TestClass]
    public class TestSimpleOptionAnalytics
    {
        private readonly Decimal[] _paramRange = {0.0m, 0.25m, 0.5m, 0.75m,1.0m, 2.0m} ;

        [TestMethod]
        public void SimpleOption()
        {
            foreach (var val in _paramRange)
            {
                ISimpleOptionAssetParameters analyticModelParameters = new SimpleRateOptionAssetParameters
                                                                           {
                                                                               IsVolatiltiyQuote = true,
                                                                               NotionalAmount = 10000000.0m,
                                                                               Rate = .05m,
                                                                               IsDiscounted = false,
                                                                               IsPut = true,
                                                                               Volatility = val,
                                                                               Strike = .05m,
                                                                               PremiumPaymentDiscountFactor = 1.0m,
                                                                               TimeToExpiry = 0.25m,
                                                                               YearFraction = .25m
                                                                           };
                var model = new SimpleRateOptionAssetAnalytic
                                {
                                    AnalyticParameters = analyticModelParameters
                                };

                var result = model.NPV;
                var delta0 = model.Delta0;             
                Debug.Print("ExpectedValue1 : {0} Delta0 : {1} CurveYearFraction : {2} ", result, delta0, 
                            analyticModelParameters.TimeToExpiry);
                analyticModelParameters.Premium = result;
                var vol = model.VolatilityAtExpiry;
                Debug.Print("InputVol : {0} OutputVol : {1} ", analyticModelParameters.Volatility, vol);
            }
        }


        [TestMethod]
        public void SimpleOptionImpliedVol()
        {
            foreach (var val in _paramRange)
            {
                ISimpleOptionAssetParameters analyticModelParameters = new SimpleRateOptionAssetParameters
                                                                           {
                                                                               NotionalAmount = 10000000.0m,
                                                                               Rate = .05m,
                                                                               IsDiscounted = false,
                                                                               IsPut = true,
                                                                               Volatility = val,
                                                                               Strike = .05m,
                                                                               Premium = 0.001m,
                                                                               PremiumPaymentDiscountFactor = 1.0m,
                                                                               TimeToExpiry = 0.25m,
                                                                               YearFraction = .25m
                                                                           };
                var model = new SimpleRateOptionAssetAnalytic
                                {
                                    AnalyticParameters = analyticModelParameters
                                };
                var result = model.VolatilityAtExpiry;
                Debug.Print("VolatilityAtExpiry : {0}", result);
                analyticModelParameters.Volatility = result;
                var vol = model.NPV;
                Debug.Print("InputVol : {0} OutputVol : {1} ", analyticModelParameters.Volatility, vol);
            }
        }
    }
}