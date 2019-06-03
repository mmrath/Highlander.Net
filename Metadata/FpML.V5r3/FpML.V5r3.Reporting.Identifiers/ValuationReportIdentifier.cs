using System;
using System.Collections.Generic;
using FpML.V5r3.Codes;
using Orion.Constants;
using Orion.Util.NamedValues;
using FpML.V5r3.Reporting;
using Orion.ModelFramework;
using Orion.ModelFramework.Identifiers;

namespace Orion.Identifiers
{
    /// <summary>
    /// The RateCurveIdentifier.
    /// </summary>
    public class ValuationReportIdentifier : Identifier, IValuationReportIdentifier
    {
        /// <summary>
        /// Domain
        /// </summary>
        public String Domain { get; private set; }

        /// <summary>
        /// DataType
        /// </summary>
        public String DataType { get; private set; }

        /// <summary>
        /// CalculationDateTime
        /// </summary>
        public DateTime CalculationDateTime { get; set; }

        ///<summary>
        /// The Source System.
        ///</summary>
        public string SourceSystem { get; set; }

        ///<summary>
        /// The base party.
        ///</summary>
        public string BaseParty { get; set; }

        ///<summary>
        /// The parties.
        ///</summary>
        public List<Party> Parties { get; set; }

        ///<summary>
        /// The trades.
        ///</summary>
        public List<IIdentifier> TradeList { get; set; }

        /// <summary>
        /// Market
        /// </summary>
        public String Market { get; set; }

        /// <summary>
        /// Market
        /// </summary>
        public String MarketName { get; set; }//For backward compatability

        /// <summary>
        /// Market
        /// </summary>
        public DateTime? MarketDate { get; set; }

        /// <summary>
        /// Market
        /// </summary>
        public String MarketAndDate { get; set; }
       

        ///<summary>
        /// The Scenario.
        ///</summary>
        public string Scenario { get; set; }

        /// <summary>
        /// TradeId
        /// </summary>
        public String TradeId { get; set; }

        /// <summary>
        /// TradeType
        /// </summary>
        public String TradeType { get; set; }

        /// <summary>
        /// PortfolioId
        /// </summary>
        public String PortfolioId { get; set; }

        ///<summary>
        /// An id for a trade.
        ///</summary>
        ///<param name="properties">The properties. These need to include:
        /// SourceSystem, Id and Trade date.</param>
        public ValuationReportIdentifier(NamedValueSet properties)
            : base(properties)
        {
            try
            {
                SetProperties(properties);
            }
            catch (System.Exception)
            {
                throw new System.Exception("Invalid reportid.");
            }
        }

        private void SetProperties(NamedValueSet properties)
        {
            try
            {
                DataType = FunctionProp.ValuationReport.ToString();
                SourceSystem = PropertyHelper.ExtractSourceSystem(properties);
                PortfolioId = properties.GetValue<string>(ValueProp.PortfolioId, false);
                TradeId = properties.GetValue<string>(TradeProp.TradeId, true);
                TradeType = properties.GetValue<string>(TradeProp.TradeType, true);
                Id = SourceSystem + "." + TradeType + "." + TradeId;
                Market = PropertyHelper.ExtractMarket(Properties);
                MarketAndDate = PropertyHelper.ExtractMarketAndDate(Properties);
                MarketName = properties.GetValue<string>(ValueProp.MarketName, false) ?? MarketAndDate;
                DateTime? marketDate = PropertyHelper.ExtractMarketDate(Properties);
                MarketDate = marketDate ?? MarketDate;
                Domain = SourceSystem + '.' + DataType;
                CalculationDateTime = properties.GetValue<DateTime>(ValueProp.CalculationDateTime);
                BaseParty = properties.GetValue<string>(ValueProp.BaseParty);
                CalculationDateTime = properties.GetValue<DateTime>(ValueProp.CalculationDateTime);
                UniqueIdentifier = BuildUniqueId();
                if (properties.GetValue<string>(ValueProp.UniqueIdentifier)!=null)
                {
                    UniqueIdentifier = properties.GetValue<string>(ValueProp.UniqueIdentifier);
                }
                Scenario = properties.GetValue<string>(ValueProp.Scenario);
                PropertyHelper.Update(Properties, ValueProp.UniqueIdentifier, UniqueIdentifier);
                PropertyHelper.Update(Properties, "Domain", Domain);
            }
            catch
            {
                throw new System.Exception("Invalid tradeid.");
            }
        }

        /// <summary>
        /// Gets the build date string.
        /// </summary>
        /// <value>The build date string.</value>
        public string BuildDateString => CalculationDateTime.ToLongTimeString();

        /// <summary>
        /// Builds the id.
        /// </summary>
        /// <returns></returns>
        private string BuildUniqueId()
        {
            //TODO 
            //PortfolioId != "LOCAL_USER: i.e. the default
            if (Id == null)
            {
                return $"{DataType}.{PortfolioId}.{SourceSystem}.{TradeId}";
            }
            if (MarketName == null)
            {
                return $"{DataType}.{SourceSystem}.{Id}";//This is the old naming convention for backward compatibility.
            }
            if (Scenario != null)
            {
                return $"{DataType}.{PortfolioId}.{Id}.{MarketAndDate}.{Scenario}";
            }
            return $"{DataType}.{PortfolioId}.{Id}.{MarketAndDate}";
        }
    }
}