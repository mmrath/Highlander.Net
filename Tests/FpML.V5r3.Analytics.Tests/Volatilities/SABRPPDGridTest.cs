﻿using System;
using System.IO;
using System.Xml.Serialization;
using Orion.Analytics.Stochastics.Volatilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Orion.Analytics.Tests.Volatilities
{
    /// <summary>
    ///This is a test class for SABRPPDGridTest and is intended
    ///to contain all SABRPPDGridTest Unit Tests
    ///</summary>
    [TestClass]
    public class SABRPPDGridTest
    {
        /// <summary>
        ///A test for GetPPD
        ///</summary>
        [TestMethod]
        public void GetPPDTest()
        {
            string[] rows = new string[] { "1 MONTH", "2 MONTH", "3 MONTH", "6 MONTH", "1 YEAR", "2 YEAR", "3 YEAR", "5 YEAR", "7 YEAR", "10 YEAR" };
            string[] cols = new string[] { "1YEAR", "2 YEAR", "3 YEAR", "4 YEAR", "5 YEAR", "6 YEAR", "7 YEAR", "8 YEAR", "9 YEAR", "10 YEAR" };

            object[][] data = new object[][]
                        {
                            new object[] { 6.4M, 6.4M, 6.6M, 7M, 7M, 7M, 6.9M, 6.9M, 6.9M, 6.8M },
                            new object[] { 6.4M, 6.4M, 6.6M, 7M, 7M, 7M, 6.9M, 6.9M, 6.9M, 6.8M },
                            new object[] { 6.5M, 6.6M, 6.7M, 6.8M, 6.8M, 6.8M, 6.7M, 6.7M, 6.7M, 6.6M },
                            new object[] { 6.5M, 6.6M, 6.7M, 6.8M, 6.8M, 6.8M, 6.7M, 6.7M, 6.7M, 6.5M },
                            new object[] { 6.5M, 6.5M, 6.4M, 6.35M, 6.4M, 6.4M, 6.3M, 6.3M, 6.3M, 6.2M },
                            new object[] { 6.4M, 6.4M, 6.2M, 6.15M, 6.1M, 6.1M, 6M, 6M, 6M, 5.9M },
                            new object[] { 6.1M, 6.25M, 5.8M, 5.55M, 5.3M, 5.3M, 5.2M, 5.2M, 5.2M, 5.1M },
                            new object[] { 5.7M, 5.4M, 5.2M, 5M, 4.9M, 4.9M, 4.85M, 4.85M, 4.85M, 4.75M },
                            new object[] { 5.7M, 5.4M, 5.2M, 5M, 4.9M, 4.9M, 4.85M, 4.85M, 4.85M, 4.75M },
                            new object[] { 5.7M, 5.4M, 5.2M, 5M, 4.9M, 4.9M, 4.85M, 4.85M, 4.85M, 4.75M }
                        };

            SwaptionPPDGrid target = new SwaptionPPDGrid(rows, cols, data);

            string expiry = "3M";
            string tenor = "3Y";
            decimal expected = 6.7m;
            decimal actual = target.GetPPD(expiry, tenor);
            Assert.AreEqual(expected, actual);

            expiry = "2Y";
            tenor = "5Y";
            expected = 6.1m;
            actual = target.GetPPD(expiry, tenor);
            Assert.AreEqual(expected, actual);
        }
    }
}