﻿
#region Using Directives

using Orion.Analytics.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

#endregion

namespace Orion.Analytics.Tests.CapFloorAnalytics
{
    /// <summary>
    /// Unit tests for the class CapletBootstrapResults. 
    /// </summary>
    [TestClass]
    public class CapletBootstrapResultsTests
    {
        #region Private Fields

        VolCurveBootstrapResults _resultsObj; // container for bootstrap results        

        // Sample results data.        
        readonly decimal[] _capletVolatilities = {0.0820m, 0.09096m, 0.09407m};

        readonly DateTime[] _expiries = {DateTime.Parse("2007-11-30"), 
                                DateTime.Parse("2008-02-29"),
                                DateTime.Parse("2008-05-30")};
        decimal _actual;
        decimal _expected;

        #endregion

        #region SetUp

        [TestInitialize]
        public void Initialisation()
        {
            _resultsObj = new VolCurveBootstrapResults();
        }

        #endregion

        #region Test Add and Get Results Methods

        /// <summary>
        /// Tests the methods AddResult and GetResult.
        /// </summary>
        [TestMethod]
        public void TestAddGetResults()
        {
            #region Fill the Results Container with the Sample Results Data

            Assert.AreEqual(_capletVolatilities.Length, _expiries.Length);
            int numData = _capletVolatilities.Length;

            for (int i = 0; i < numData; ++i)
            {
                _resultsObj.AddResult(_expiries[i], _capletVolatilities[i]);
            }

            #endregion

            #region Test that Results are Correctly Retrieved

            SortedList<DateTime, decimal> results = _resultsObj.Results;

            int idx = 0;
            foreach (DateTime expiry in results.Keys)
            {
                decimal capletVolatility = results[expiry];
                Assert.AreEqual(_capletVolatilities[idx], capletVolatility);
                ++idx;
            }

            // Test retrieval of result at an expiry date.
            _actual = _resultsObj.GetResult(_expiries[1]);
            _expected = _capletVolatilities[1];
            Assert.AreEqual(_expected, _actual);

            // Test retrieval of result at a date that is not an expiry.
            _actual =
                _resultsObj.GetResult(_expiries[1].AddYears(1));
            _expected = -1.0m;
            Assert.AreEqual(_expected, _actual);

            #endregion
        }

        #endregion
    }
}