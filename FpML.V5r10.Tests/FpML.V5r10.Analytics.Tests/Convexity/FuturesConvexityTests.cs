#region Using Directives

using System;
using System.Diagnostics;
using Orion.Analytics.Rates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Orion.Analytics.Tests.Convexity
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class FuturesConvexityTests 
    {
        /// <summary>
        /// Testing the FuturesMarginConvexityAdjustment.
        /// </summary>
        [TestMethod]
        public void TestFuturesMarginConvexityAdjustment()
        {
            for (var i = 0; i < 10; i++)
            {
                var rate = (decimal)(50 + i);
                var cvt = FuturesAnalytics.FuturesMarginConvexityAdjustment(rate/1000, 3.0, .2);
                var result = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjusted(rate / 1000 - cvt, 3.0, .2);
                Debug.WriteLine(String.Format("rate : {0} convexity: {1} implied: {2}", rate / 1000, cvt * 10000, result));
            }
            decimal actual = FuturesAnalytics.FuturesMarginConvexityAdjustment(0.055m, 3d, 0.2);
            Assert.AreEqual(0.0004788059284411, (double)actual, 0.000000001);

            actual = FuturesAnalytics.FuturesMarginConvexityAdjustment(0.055m, 0, 0.2);
            Assert.AreEqual(0, actual);
        }

        /// <summary>
        /// Testing the FuturesArrearsConvexityAdjustment.
        /// </summary>
        [TestMethod]
        public void FuturesArrearsConvexityAdjustment()
        {
            for (var i = 0; i < 10; i++)
            {
                var rate = (decimal)(50 + i);
                var cvt = FuturesAnalytics.FuturesArrearsConvexityAdjustment(rate/1000, 0.25, 3.0, .2);
                var result = FuturesAnalytics.FuturesImpliedQuoteWithArrears(rate / 1000 - cvt, 0.25, 3.0, .2);
                Debug.WriteLine(String.Format("rate : {0} convexity: {1} implied: {2}", rate / 1000, cvt * 10000, result));
            }
            decimal actual = FuturesAnalytics.FuturesArrearsConvexityAdjustment(0.055m, 0.25, 3d, 0.2);
            Assert.AreEqual(9.47863772776E-05, (double)actual, 0.000000001);

            actual = FuturesAnalytics.FuturesArrearsConvexityAdjustment(0.055m, 0.25, 0, 0.2);
            Assert.AreEqual(0, actual);
        }

        /// <summary>
        /// Testing the FuturesImpliedQuoteFromAdjusted.
        /// </summary>
        [TestMethod]
        public void TestFuturesMarginWithArrearsConvexityAdjustment()
        {
            for (var i = 0; i < 10; i++)
            {
                var rate = (decimal)(50 + i);
                var cvt = FuturesAnalytics.FuturesMarginWithArrearsConvexityAdjustment(rate/1000, 0.25, 3.0, .2);
                var result = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjustedWithArrears(rate / 1000 - cvt, 0.25, 3.0, .2);
                Debug.WriteLine(String.Format("rate : {0} convexity: {1} implied: {2}", rate / 1000, cvt * 10000, result));
 
            }
            decimal actual = FuturesAnalytics.FuturesMarginWithArrearsConvexityAdjustment(0.055m, 0.25, 3d, 0.2);
            Assert.AreEqual(0.0005720703761657d, (double)actual, 0.000000001);

            actual = FuturesAnalytics.FuturesMarginWithArrearsConvexityAdjustment(0.055m, 0.25, 0, 0.2);
            Assert.AreEqual(0, actual);
        }

        /// <summary>
        /// Testing the FuturesImpliedQuoteFromAdjusted.
        /// </summary>
        [TestMethod]
        public void FuturesImpliedQuoteFromMarginAdjustedTest()
        {
            for (var i = 0; i < 10; i++)
            {
                decimal rate = 50 + i;
                decimal adjustedRate = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjusted(rate / 1000, 3.0, .2);
                decimal arrearsAdjustedRate = FuturesAnalytics.FuturesImpliedQuoteWithArrears(adjustedRate, 0.25, 3.0, .2);
                decimal cvt = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjustedWithArrears(arrearsAdjustedRate, 3.0, 0.25, .2);
                Assert.AreEqual((double)rate / 1000, (double)cvt, 0.01);
                Debug.WriteLine(String.Format("rate : {0} adjustedRate: {1} arrearsAdjustedRate: {2} cvt: {3}", rate / 1000, adjustedRate, arrearsAdjustedRate, cvt));
            }

            decimal actual = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjusted(0.055m, 3, 0.2);
            Assert.AreEqual(0.055486651d, (double)actual, 0.000000001);

            actual = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjusted(0.055m, 0, 0.2);
            Assert.AreEqual(0.055m, actual);
        }

        /// <summary>
        /// Testing the FuturesImpliedQuoteFromAdjusted.
        /// </summary>
        [TestMethod]
        public void FuturesImpliedQuoteFromMarginAdjustedWithArrearsTest()
        {
            decimal actual = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjustedWithArrears(0.055m, 3, 0.25, 0.2);
            Assert.AreEqual(0.0550820401094303d, (double)actual, 0.000000001);

            actual = FuturesAnalytics.FuturesImpliedQuoteFromMarginAdjustedWithArrears(0.055m, 3, 0, 0.2);
            Assert.AreEqual(0.055m, actual);
        }

        /// <summary>
        /// Testing the FuturesImpliedQuoteWithArrears.
        /// </summary>
        [TestMethod]
        public void FuturesImpliedQuoteWithArrearsTest()
        {
            decimal actual = FuturesAnalytics.FuturesImpliedQuoteWithArrears(0.055m, 3, 0.25, 0.2);
            Assert.AreEqual(0.0550782877822222d, (double)actual, 0.000000001);

            actual = FuturesAnalytics.FuturesImpliedQuoteWithArrears(0.055m, 3, 0, 0.2);
            Assert.AreEqual(0.055m, actual);
        }
    }
}