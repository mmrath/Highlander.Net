#region Usings

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Orion.Util.NamedValues;
using FpML.V5r10.Codes;
using FpML.V5r10.Reporting;
using FpML.V5r10.Reporting.ModelFramework.Instruments;
using FpML.V5r10.Reporting.ModelFramework.Reports;
using Orion.ValuationEngine.Helpers;
using Orion.ValuationEngine.Instruments;
using Orion.ValuationEngine.Pricers.Assets;

#endregion

namespace Orion.ValuationEngine.Reports
{
    public class BondTransactionReporter : ReporterBase
    {
        public override object DoReport(InstrumentControllerBase priceable)
        {
            if (priceable is BondTransactionPricer bond)
            {
                Debug.Print("Bond {0} coupons", bond.GetChildren().Count);
                foreach (var cashflow in bond.GetChildren())
                {
                    var flow = (PriceableCashflow)cashflow;
                    var forecast = flow.ForecastAmount ?? new Money();
                    Debug.Print("Cashflow type: {0}, payment date: {1}, payment amount: {2}, forecast amount:  {3}",
                        flow.CashflowType, flow.PaymentDate, flow.PaymentAmount, forecast);
                }
            }
            return null;
        }

        public override object[,] DoXLReport(InstrumentControllerBase pricer)
        {
            if (pricer is BondTransactionPricer bond)
            {
                var result = new object[bond.GetChildren().Count, 5];
                var index = 0;
                foreach (var cashflow in bond.GetChildren())
                {
                    var flow = (PriceableCashflow)cashflow;
                    result[index, 0] = flow.CashflowType.Value;
                    result[index, 1] = flow.PaymentDate;
                    result[index, 2] = flow.PaymentAmount.currency.Value;
                    if (flow.ForecastAmount != null)
                    {
                        result[index, 3] = flow.ForecastAmount.amount;
                    }
                    else
                    {
                        result[index, 3] = flow.PaymentAmount.amount;
                    }
                    result[index, 4] = flow.ProductType.ToString();
                    //result[index, 5] = flow.;
                    index++;
                }
                return result;
            }
            return null;
        }

        public override List<object[]> DoExpectedCashflowReport(InstrumentControllerBase pricer)
        {
            if (pricer is BondTransactionPricer bond)
            {
                return (from PriceableCashflow flow in bond.GetChildren() select CashflowReportHelper.DoCashflowReport(pricer.Id, flow)).ToList();
            }
            return null;
        }

        public override object[,] DoReport(Product product, NamedValueSet properties)
        {
            if (product is BondTransaction bondTransaction)
            {
                var party1 = properties.GetValue<string>(TradeProp.Party1, true);
                var party2 = properties.GetValue<string>(TradeProp.Party2, true);
                var result = new object[12, 2];
                result[0, 0] = "buyerPartyReference";
                result[1, 0] = "sellerPartyReference";
                result[2, 0] = "amount";
                result[3, 0] = "currency";
                result[4, 0] = "maturityDate";
                result[5, 0] = "coupon";
                result[6, 0] = "couponRate";
                result[7, 0] = "dayCountFraction";
                result[8, 0] = "paymentFrequency";
                result[9, 0] = "paryt1";
                result[10, 0] = "party2";
                result[11, 0] = "description";
                var temp = bondTransaction.bond;
                result[0, 1] = bondTransaction.buyerPartyReference.href;
                result[1, 1] = bondTransaction.sellerPartyReference.href;
                result[2, 1] = bondTransaction.notionalAmount.amount;
                result[3, 1] = bondTransaction.notionalAmount.currency.Value;
                result[4, 1] = temp.maturity;
                result[5, 1] = temp.couponType.Value;
                result[6, 1] = temp.couponRate;
                result[7, 1] = temp.dayCountFraction.Value;
                result[8, 1] = temp.paymentFrequency.ToString();
                result[9, 1] = party1;
                result[10, 1] = party2;
                result[11, 1] = temp.description;
                return result;
            }
            return null;
        }
    }
}