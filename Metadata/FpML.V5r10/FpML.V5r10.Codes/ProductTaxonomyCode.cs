﻿using System;
using System.Diagnostics;
using FpML.V5r3.Codelist;
using Orion.Util.NamedValues;

namespace FpML.V5r10.Codes
{
    public enum ProductTaxonomyEnum
    {
        Commodity_Agricultural_Dairy_Exotic,
        Commodity_Agricultural_Dairy_LoanLease_Cash,
        Commodity_Agricultural_Dairy_LoanLease_Physical,
        Commodity_Agricultural_Dairy_Option_Cash,
        Commodity_Agricultural_Dairy_Option_Physical,
        Commodity_Agricultural_Dairy_SpotFwd_Physical,
        Commodity_Agricultural_Dairy_Swap_Cash,
        Commodity_Agricultural_Forestry_Exotic,
        Commodity_Agricultural_Forestry_LoanLease_Cash,
        Commodity_Agricultural_Forestry_LoanLease_Physical,
        Commodity_Agricultural_Forestry_Option_Cash,
        Commodity_Agricultural_Forestry_Option_Physical,
        Commodity_Agricultural_Forestry_SpotFwd_Physical,
        Commodity_Agricultural_Forestry_Swap_Cash,
        Commodity_Agricultural_GrainsOilSeeds_Exotic,
        Commodity_Agricultural_GrainsOilSeeds_LoanLease_Cash,
        Commodity_Agricultural_GrainsOilSeeds_LoanLease_Physical,
        Commodity_Agricultural_GrainsOilSeeds_Option_Cash,
        Commodity_Agricultural_GrainsOilSeeds_Option_Physical,
        Commodity_Agricultural_GrainsOilSeeds_SpotFwd_Physical,
        Commodity_Agricultural_GrainsOilSeeds_Swap_Cash,
        Commodity_Agricultural_Livestock_Exotic,
        Commodity_Agricultural_Livestock_LoanLease_Cash,
        Commodity_Agricultural_Livestock_LoanLease_Physical,
        Commodity_Agricultural_Livestock_Option_Cash,
        Commodity_Agricultural_Livestock_Option_Physical,
        Commodity_Agricultural_Livestock_SpotFwd_Physical,
        Commodity_Agricultural_Livestock_Swap_Cash,
        Commodity_Agricultural_Softs_Exotic,
        Commodity_Agricultural_Softs_LoanLease_Cash,
        Commodity_Agricultural_Softs_LoanLease_Physical,
        Commodity_Agricultural_Softs_Option_Cash,
        Commodity_Agricultural_Softs_Option_Physical,
        Commodity_Agricultural_Softs_SpotFwd_Physical,
        Commodity_Agricultural_Softs_Swap_Cash,
        Commodity_Energy_Coal_Exotic,
        Commodity_Energy_Coal_LoanLease_Cash,
        Commodity_Energy_Coal_LoanLease_Physical,
        Commodity_Energy_Coal_Option_Cash,
        Commodity_Energy_Coal_Option_Physical,
        Commodity_Energy_Coal_SpotFwd_Physical,
        Commodity_Energy_Coal_Swap_Cash,
        Commodity_Energy_Elec_Exotic,
        Commodity_Energy_Elec_LoanLease_Cash,
        Commodity_Energy_Elec_LoanLease_Physical,
        Commodity_Energy_Elec_Option_Cash,
        Commodity_Energy_Elec_Option_Physical,
        Commodity_Energy_Elec_SpotFwd_Physical,
        Commodity_Energy_Elec_Swap_Cash,
        Commodity_Energy_Elec_Transmission,
        Commodity_Energy_InterEnergy_Exotic,
        Commodity_Energy_InterEnergy_LoanLease_Cash,
        Commodity_Energy_InterEnergy_LoanLease_Physical,
        Commodity_Energy_InterEnergy_Option_Cash,
        Commodity_Energy_InterEnergy_Option_Physical,
        Commodity_Energy_InterEnergy_SpotFwd_Physical,
        Commodity_Energy_InterEnergy_Swap_Cash,
        Commodity_Energy_NatGas_Exotic,
        Commodity_Energy_NatGas_LoanLease_Cash,
        Commodity_Energy_NatGas_LoanLease_Physical,
        Commodity_Energy_NatGas_Option_Cash,
        Commodity_Energy_NatGas_Option_Physical,
        Commodity_Energy_NatGas_SpotFwd_Physical,
        Commodity_Energy_NatGas_Swap_Cash,
        Commodity_Energy_NatGas_Transport,
        Commodity_Energy_Oil_Exotic,
        Commodity_Energy_Oil_LoanLease_Cash,
        Commodity_Energy_Oil_LoanLease_Physical,
        Commodity_Energy_Oil_Option_Cash,
        Commodity_Energy_Oil_Option_Physical,
        Commodity_Energy_Oil_SpotFwd_Physical,
        Commodity_Energy_Oil_Swap_Cash,
        Commodity_Environmental_Emissions_Exotic,
        Commodity_Environmental_Emissions_LoanLease_Cash,
        Commodity_Environmental_Emissions_LoanLease_Physical,
        Commodity_Environmental_Emissions_Option_Cash,
        Commodity_Environmental_Emissions_Option_Physical,
        Commodity_Environmental_Emissions_SpotFwd_Physical,
        Commodity_Environmental_Emissions_Swap_Cash,
        Commodity_Environmental_Weather_Exotic,
        Commodity_Environmental_Weather_LoanLease_Cash,
        Commodity_Environmental_Weather_Option_Cash,
        Commodity_Environmental_Weather_Swap_Cash,
        Commodity_Freight_Exotic,
        Commodity_Freight_LoanLease_Cash,
        Commodity_Freight_LoanLease_Physical,
        Commodity_Freight_Option_Cash,
        Commodity_Freight_Option_Physical,
        Commodity_Freight_SpotFwd_Physical,
        Commodity_Freight_Swap_Cash,
        Commodity_Index_Exotic,
        Commodity_Index_Option_Cash,
        Commodity_Index_Swap_Cash,
        Commodity_Metals_NonPrecious_Exotic,
        Commodity_Metals_NonPrecious_LoanLease_Cash,
        Commodity_Metals_NonPrecious_LoanLease_Physical,
        Commodity_Metals_NonPrecious_Option_Cash,
        Commodity_Metals_NonPrecious_Option_Physical,
        Commodity_Metals_NonPrecious_SpotFwd_Physical,
        Commodity_Metals_NonPrecious_Swap_Cash,
        Commodity_Metals_Precious_Exotic,
        Commodity_Metals_Precious_LoanLease_Cash,
        Commodity_Metals_Precious_LoanLease_Physical,
        Commodity_Metals_Precious_Option_Cash,
        Commodity_Metals_Precious_Option_Physical,
        Commodity_Metals_Precious_SpotFwd_Physical,
        Commodity_Metals_Precious_Swap_Cash,
        Commodity_MultiCommodityExotic,
        Credit_Exotic_Corporate_Refobonly,
        Credit_Exotic_Other,
        Credit_Exotic_StructuredCDS_ContingentCDS,
        Credit_Exotic_StructuredCDS_FirsttoDefaultNthtoDefault,
        Credit_Exotic_StructuredCDS_LongformBespoke,
        Credit_Exotic_StructuredCDS_StandardTermsBespoke,
        Credit_Index_ABX_ABXHE,
        Credit_Index_CDX_CDXEmergingMarkets,
        Credit_Index_CDX_CDXEmergingMarketsDiversified,
        Credit_Index_CDX_CDXHY,
        Credit_Index_CDX_CDXIG,
        Credit_Index_CDX_CDXXO,
        Credit_Index_CDX_StandardLCDXBullet,
        Credit_Index_CMBX_CMBX,
        Credit_Index_IOS_IOS,
        Credit_Index_iTraxx_iTraxxAsiaExJapan,
        Credit_Index_iTraxx_iTraxxAustralia,
        Credit_Index_iTraxx_iTraxxEurope,
        Credit_Index_iTraxx_iTraxxJapan,
        Credit_Index_iTraxx_iTraxxLevX,
        Credit_Index_iTraxx_ItraxxSDI,
        Credit_Index_iTraxx_iTraxxSovX,
        Credit_Index_LCDX_LCDX,
        Credit_Index_MBX_MBX,
        Credit_Index_MCDX_MCDX,
        Credit_Index_PO_PO,
        Credit_Index_PrimeX_PrimeX,
        Credit_Index_TRX_TRX,
        Credit_IndexTranche_ABX_ABXTranche,
        Credit_IndexTranche_CDX_CDXEmergingMarketsDiversifiedTranche,
        Credit_IndexTranche_CDX_CDXTrancheHY,
        Credit_IndexTranche_CDX_CDXTrancheIG,
        Credit_IndexTranche_CDX_CDXTrancheXO,
        Credit_IndexTranche_CDX_StandardCDXTrancheHY,
        Credit_IndexTranche_CDX_StandardCDXTrancheIG,
        Credit_IndexTranche_CDXStructuredTranche_CDXBlendedTranche,
        Credit_IndexTranche_CDXStructuredTranche_CDXRiskyZeroTranche,
        Credit_IndexTranche_iTraxx_iTraxxAsiaExJapanTranche,
        Credit_IndexTranche_iTraxx_iTraxxAustraliaTranche,
        Credit_IndexTranche_iTraxx_iTraxxEuropeTranche,
        Credit_IndexTranche_iTraxx_iTraxxJapanTranche,
        Credit_IndexTranche_iTraxx_StandardiTraxxEuropeTranche,
        Credit_IndexTranche_iTraxxStructuredTranche_iTraxxBlendedTranche,
        Credit_IndexTranche_iTraxxStructuredTranche_iTraxxRiskyZeroTranche,
        Credit_IndexTranche_LCDX_LCDXTranche,
        Credit_IndexTranche_LCDX_StandardLCDXBulletTranche,
        Credit_SingleName_ABS_CDSonCDO,
        Credit_SingleName_ABS_CMBS,
        Credit_SingleName_ABS_EuropeanCMBS,
        Credit_SingleName_ABS_EuropeanRMBS,
        Credit_SingleName_ABS_RMBS,
        Credit_SingleName_Corporate_AsiaCorporate,
        Credit_SingleName_Corporate_AustraliaCorporate,
        Credit_SingleName_Corporate_EmergingEuropeanCorporate,
        Credit_SingleName_Corporate_EmergingEuropeanCorporateLPN,
        Credit_SingleName_Corporate_EuropeanCorporate,
        Credit_SingleName_Corporate_JapanCorporate,
        Credit_SingleName_Corporate_LatinAmericaCorporate,
        Credit_SingleName_Corporate_LatinAmericaCorporateBond,
        Credit_SingleName_Corporate_LatinAmericaCorporateBondOrLoan,
        Credit_SingleName_Corporate_NewZealandCorporate,
        Credit_SingleName_Corporate_NorthAmericanCorporate,
        Credit_SingleName_Corporate_SingaporeCorporate,
        Credit_SingleName_Corporate_StandardAsiaCorporate,
        Credit_SingleName_Corporate_StandardAustraliaCorporate,
        Credit_SingleName_Corporate_StandardEmergingEuropeanCorporate,
        Credit_SingleName_Corporate_StandardEmergingEuropeanCorporateLPN,
        Credit_SingleName_Corporate_StandardEuropeanCorporate,
        Credit_SingleName_Corporate_StandardJapanCorporate,
        Credit_SingleName_Corporate_StandardLatinAmericaCorporateBond,
        Credit_SingleName_Corporate_StandardLatinAmericaCorporateBondOrLoan,
        Credit_SingleName_Corporate_StandardNewZealandCorporate,
        Credit_SingleName_Corporate_StandardNorthAmericanCorporate,
        Credit_SingleName_Corporate_StandardSingaporeCorporate,
        Credit_SingleName_Corporate_StandardSubordinatedEuropeanInsuranceCorporate,
        Credit_SingleName_Corporate_StandardSukukCorporate,
        Credit_SingleName_Corporate_SubordinatedEuropeanInsuranceCorporate,
        Credit_SingleName_Corporate_SukukCorporate,
        Credit_SingleName_Loans_ELCDS,
        Credit_SingleName_Loans_LCDS,
        Credit_SingleName_Loans_StandardLCDSBullet,
        Credit_SingleName_Muni_USMunicipalFullFaithAndCredit,
        Credit_SingleName_Muni_USMunicipalGeneralFund,
        Credit_SingleName_Muni_USMunicipalRevenue,
        Credit_SingleName_RecoveryCDS_FixedRecoverySwaps,
        Credit_SingleName_RecoveryCDS_RecoveryLocks,
        Credit_SingleName_Sovereign_AsiaSovereign,
        Credit_SingleName_Sovereign_AustraliaSovereign,
        Credit_SingleName_Sovereign_EmergingEuropeanAndMiddleEasternSovereign,
        Credit_SingleName_Sovereign_JapanSovereign,
        Credit_SingleName_Sovereign_LatinAmericaSovereign,
        Credit_SingleName_Sovereign_NewZealandSovereign,
        Credit_SingleName_Sovereign_SingaporeSovereign,
        Credit_SingleName_Sovereign_StandardAsiaSovereign,
        Credit_SingleName_Sovereign_StandardAustraliaSovereign,
        Credit_SingleName_Sovereign_StandardEmergingEuropeanAndMiddleEasternSovereign,
        Credit_SingleName_Sovereign_StandardJapanSovereign,
        Credit_SingleName_Sovereign_StandardLatinAmericaSovereign,
        Credit_SingleName_Sovereign_StandardNewZealandSovereign,
        Credit_SingleName_Sovereign_StandardSingaporeSovereign,
        Credit_SingleName_Sovereign_StandardSukukSovereign,
        Credit_SingleName_Sovereign_StandardWesternEuropeanSovereign,
        Credit_SingleName_Sovereign_SukukSovereign,
        Credit_SingleName_Sovereign_WesternEuropeanSovereign,
        Credit_Swaptions_CDX_CDXSwaption,
        Credit_Swaptions_Corporate_CDSSwaption,
        Credit_Swaptions_iTraxx_iTraxxAsiaExJapanSwaption,
        Credit_Swaptions_iTraxx_iTraxxAustraliaSwaption,
        Credit_Swaptions_iTraxx_iTraxxEuropeSwaption,
        Credit_Swaptions_iTraxx_iTraxxJapanSwaption,
        Credit_Swaptions_iTraxx_iTraxxSovXSwaption,
        Credit_Swaptions_Muni_CDSSwaption,
        Credit_Swaptions_Sovereign_CDSSwaption,
        Credit_TotalReturnSwap,
        Equity_ContractForDifference_PriceReturnBasicPerformance_Basket,
        Equity_ContractForDifference_PriceReturnBasicPerformance_SingleIndex,
        Equity_ContractForDifference_PriceReturnBasicPerformance_SingleName,
        Equity_Forward_PriceReturnBasicPerformance_Basket,
        Equity_Forward_PriceReturnBasicPerformance_SingleIndex,
        Equity_Forward_PriceReturnBasicPerformance_SingleName,
        Equity_Option_ParameterReturnDividend_Basket,
        Equity_Option_ParameterReturnDividend_SingleIndex,
        Equity_Option_ParameterReturnDividend_SingleName,
        Equity_Option_ParameterReturnVariance_Basket,
        Equity_Option_ParameterReturnVariance_SingleIndex,
        Equity_Option_ParameterReturnVariance_SingleName,
        Equity_Option_ParameterReturnVolatility_Basket,
        Equity_Option_ParameterReturnVolatility_SingleIndex,
        Equity_Option_ParameterReturnVolatility_SingleName,
        Equity_Option_PriceReturnBasicPerformance_Basket,
        Equity_Option_PriceReturnBasicPerformance_SingleIndex,
        Equity_Option_PriceReturnBasicPerformance_SingleName,
        Equity_Other,
        Equity_PortfolioSwap_PriceReturnBasicPerformance_Basket,
        Equity_PortfolioSwap_PriceReturnBasicPerformance_SingleIndex,
        Equity_PortfolioSwap_PriceReturnBasicPerformance_SingleName,
        Equity_Swap_ParameterReturnDividend_Basket,
        Equity_Swap_ParameterReturnDividend_SingleIndex,
        Equity_Swap_ParameterReturnDividend_SingleName,
        Equity_Swap_ParameterReturnVariance_Basket,
        Equity_Swap_ParameterReturnVariance_SingleIndex,
        Equity_Swap_ParameterReturnVariance_SingleName,
        Equity_Swap_ParameterReturnVolatility_Basket,
        Equity_Swap_ParameterReturnVolatility_SingleIndex,
        Equity_Swap_ParameterReturnVolatility_SingleName,
        Equity_Swap_PriceReturnBasicPerformance_Basket,
        Equity_Swap_PriceReturnBasicPerformance_SingleIndex,
        Equity_Swap_PriceReturnBasicPerformance_SingleName,
        ForeignExchange_ComplexExotic,
        ForeignExchange_Forward,
        ForeignExchange_NDF,
        ForeignExchange_NDO,
        ForeignExchange_SimpleExotic_Barrier,
        ForeignExchange_SimpleExotic_Digital,
        ForeignExchange_Spot,
        ForeignExchange_VanillaOption,
        InterestRate_CapFloor,
        InterestRate_CrossCurrency_Basis,
        InterestRate_CrossCurrency_FixedFixed,
        InterestRate_CrossCurrency_FixedFloat,
        InterestRate_Exotic,
        InterestRate_FRA,
        InterestRate_IRSwap_Basis,
        InterestRate_IRSwap_FixedFixed,
        InterestRate_IRSwap_FixedFloat,
        InterestRate_IRSwap_Inflation,
        InterestRate_IRSwap_OIS,
        InterestRate_Option_DebtOption,
        InterestRate_Option_Swaption,
        Undefined
    }

    public class ProductTaxonomyValue : IFpMLCodeValue
    {
        public ProductTaxonomyValue()
        { }

        public ProductTaxonomyValue(Row dataRow)
        {
            if ((dataRow != null) && (dataRow.Value != null))
            {
                //if ((dataRow.Value.Length > 0) && (dataRow.Value[0] != null))
                //    Code = dataRow.Value[0].SimpleValue.Value;
                //if ((dataRow.Value.Length > 1) && (dataRow.Value[1] != null))
                //    Source = dataRow.Value[1].SimpleValue.Value;
                //if ((dataRow.Value.Length > 2) && (dataRow.Value[2] != null))
                //    Description = dataRow.Value[2].SimpleValue.Value;
            }
        }

        public string GetPrimaryKey() { return "Non-impleemneted Scheme"; }//Code
    }
    public class ProductTaxonomyScheme : IFpMLCodeScheme
    {
        private static readonly string[] EnumStrings = 
        {
            null, // (0) Undefined
            "Commodity:Agricultural:Dairy:Exotic",
            "Commodity:Agricultural:Dairy:LoanLease:Cash",
            "Commodity:Agricultural:Dairy:LoanLease:Physical",
            "Commodity:Agricultural:Dairy:Option:Cash",
            "Commodity:Agricultural:Dairy:Option:Physical",
            "Commodity:Agricultural:Dairy:SpotFwd:Physical",
            "Commodity:Agricultural:Dairy:Swap:Cash",
            "Commodity:Agricultural:Forestry:Exotic",
            "Commodity:Agricultural:Forestry:LoanLease:Cash",
            "Commodity:Agricultural:Forestry:LoanLease:Physical",
            "Commodity:Agricultural:Forestry:Option:Cash",
            "Commodity:Agricultural:Forestry:Option:Physical",
            "Commodity:Agricultural:Forestry:SpotFwd:Physical",
            "Commodity:Agricultural:Forestry:Swap:Cash",
            "Commodity:Agricultural:GrainsOilSeeds:Exotic",
            "Commodity:Agricultural:GrainsOilSeeds:LoanLease:Cash",
            "Commodity:Agricultural:GrainsOilSeeds:LoanLease:Physical",
            "Commodity:Agricultural:GrainsOilSeeds:Option:Cash",
            "Commodity:Agricultural:GrainsOilSeeds:Option:Physical",
            "Commodity:Agricultural:GrainsOilSeeds:SpotFwd:Physical",
            "Commodity:Agricultural:GrainsOilSeeds:Swap:Cash",
            "Commodity:Agricultural:Livestock:Exotic",
            "Commodity:Agricultural:Livestock:LoanLease:Cash",
            "Commodity:Agricultural:Livestock:LoanLease:Physical",
            "Commodity:Agricultural:Livestock:Option:Cash",
            "Commodity:Agricultural:Livestock:Option:Physical",
            "Commodity:Agricultural:Livestock:SpotFwd:Physical",
            "Commodity:Agricultural:Livestock:Swap:Cash",
            "Commodity:Agricultural:Softs:Exotic",
            "Commodity:Agricultural:Softs:LoanLease:Cash",
            "Commodity:Agricultural:Softs:LoanLease:Physical",
            "Commodity:Agricultural:Softs:Option:Cash",
            "Commodity:Agricultural:Softs:Option:Physical",
            "Commodity:Agricultural:Softs:SpotFwd:Physical",
            "Commodity:Agricultural:Softs:Swap:Cash",
            "Commodity:Energy:Coal:Exotic",
            "Commodity:Energy:Coal:LoanLease:Cash",
            "Commodity:Energy:Coal:LoanLease:Physical",
            "Commodity:Energy:Coal:Option:Cash",
            "Commodity:Energy:Coal:Option:Physical",
            "Commodity:Energy:Coal:SpotFwd:Physical",
            "Commodity:Energy:Coal:Swap:Cash",
            "Commodity:Energy:Elec:Exotic",
            "Commodity:Energy:Elec:LoanLease:Cash",
            "Commodity:Energy:Elec:LoanLease:Physical",
            "Commodity:Energy:Elec:Option:Cash",
            "Commodity:Energy:Elec:Option:Physical",
            "Commodity:Energy:Elec:SpotFwd:Physical",
            "Commodity:Energy:Elec:Swap:Cash",
            "Commodity:Energy:Elec:Transmission",
            "Commodity:Energy:InterEnergy:Exotic",
            "Commodity:Energy:InterEnergy:LoanLease:Cash",
            "Commodity:Energy:InterEnergy:LoanLease:Physical",
            "Commodity:Energy:InterEnergy:Option:Cash",
            "Commodity:Energy:InterEnergy:Option:Physical",
            "Commodity:Energy:InterEnergy:SpotFwd:Physical",
            "Commodity:Energy:InterEnergy:Swap:Cash",
            "Commodity:Energy:NatGas:Exotic",
            "Commodity:Energy:NatGas:LoanLease:Cash",
            "Commodity:Energy:NatGas:LoanLease:Physical",
            "Commodity:Energy:NatGas:Option:Cash",
            "Commodity:Energy:NatGas:Option:Physical",
            "Commodity:Energy:NatGas:SpotFwd:Physical",
            "Commodity:Energy:NatGas:Swap:Cash",
            "Commodity:Energy:NatGas:Transport",
            "Commodity:Energy:Oil:Exotic",
            "Commodity:Energy:Oil:LoanLease:Cash",
            "Commodity:Energy:Oil:LoanLease:Physical",
            "Commodity:Energy:Oil:Option:Cash",
            "Commodity:Energy:Oil:Option:Physical",
            "Commodity:Energy:Oil:SpotFwd:Physical",
            "Commodity:Energy:Oil:Swap:Cash",
            "Commodity:Environmental:Emissions:Exotic",
            "Commodity:Environmental:Emissions:LoanLease:Cash",
            "Commodity:Environmental:Emissions:LoanLease:Physical",
            "Commodity:Environmental:Emissions:Option:Cash",
            "Commodity:Environmental:Emissions:Option:Physical",
            "Commodity:Environmental:Emissions:SpotFwd:Physical",
            "Commodity:Environmental:Emissions:Swap:Cash",
            "Commodity:Environmental:Weather:Exotic",
            "Commodity:Environmental:Weather:LoanLease:Cash",
            "Commodity:Environmental:Weather:Option:Cash",
            "Commodity:Environmental:Weather:Swap:Cash",
            "Commodity:Freight:Exotic",
            "Commodity:Freight:LoanLease:Cash",
            "Commodity:Freight:LoanLease:Physical",
            "Commodity:Freight:Option:Cash",
            "Commodity:Freight:Option:Physical",
            "Commodity:Freight:SpotFwd:Physical",
            "Commodity:Freight:Swap:Cash",
            "Commodity:Index:Exotic",
            "Commodity:Index:Option:Cash",
            "Commodity:Index:Swap:Cash",
            "Commodity:Metals:NonPrecious:Exotic",
            "Commodity:Metals:NonPrecious:LoanLease:Cash",
            "Commodity:Metals:NonPrecious:LoanLease:Physical",
            "Commodity:Metals:NonPrecious:Option:Cash",
            "Commodity:Metals:NonPrecious:Option:Physical",
            "Commodity:Metals:NonPrecious:SpotFwd:Physical",
            "Commodity:Metals:NonPrecious:Swap:Cash",
            "Commodity:Metals:Precious:Exotic",
            "Commodity:Metals:Precious:LoanLease:Cash",
            "Commodity:Metals:Precious:LoanLease:Physical",
            "Commodity:Metals:Precious:Option:Cash",
            "Commodity:Metals:Precious:Option:Physical",
            "Commodity:Metals:Precious:SpotFwd:Physical",
            "Commodity:Metals:Precious:Swap:Cash",
            "Commodity:MultiCommodityExotic",
            "Credit:Exotic:Corporate:Refobonly",
            "Credit:Exotic:Other",
            "Credit:Exotic:StructuredCDS:ContingentCDS",
            "Credit:Exotic:StructuredCDS:FirsttoDefaultNthtoDefault",
            "Credit:Exotic:StructuredCDS:LongformBespoke",
            "Credit:Exotic:StructuredCDS:StandardTermsBespoke",
            "Credit:Index:ABX:ABXHE",
            "Credit:Index:CDX:CDXEmergingMarkets",
            "Credit:Index:CDX:CDXEmergingMarketsDiversified",
            "Credit:Index:CDX:CDXHY",
            "Credit:Index:CDX:CDXIG",
            "Credit:Index:CDX:CDXXO",
            "Credit:Index:CDX:StandardLCDXBullet",
            "Credit:Index:CMBX:CMBX",
            "Credit:Index:IOS:IOS",
            "Credit:Index:iTraxx:iTraxxAsiaExJapan",
            "Credit:Index:iTraxx:iTraxxAustralia",
            "Credit:Index:iTraxx:iTraxxEurope",
            "Credit:Index:iTraxx:iTraxxJapan",
            "Credit:Index:iTraxx:iTraxxLevX",
            "Credit:Index:iTraxx:ItraxxSDI",
            "Credit:Index:iTraxx:iTraxxSovX",
            "Credit:Index:LCDX:LCDX",
            "Credit:Index:MBX:MBX",
            "Credit:Index:MCDX:MCDX",
            "Credit:Index:PO:PO",
            "Credit:Index:PrimeX:PrimeX",
            "Credit:Index:TRX:TRX",
            "Credit:IndexTranche:ABX:ABXTranche",
            "Credit:IndexTranche:CDX:CDXEmergingMarketsDiversifiedTranche",
            "Credit:IndexTranche:CDX:CDXTrancheHY",
            "Credit:IndexTranche:CDX:CDXTrancheIG",
            "Credit:IndexTranche:CDX:CDXTrancheXO",
            "Credit:IndexTranche:CDX:StandardCDXTrancheHY",
            "Credit:IndexTranche:CDX:StandardCDXTrancheIG",
            "Credit:IndexTranche:CDXStructuredTranche:CDXBlendedTranche",
            "Credit:IndexTranche:CDXStructuredTranche:CDXRiskyZeroTranche",
            "Credit:IndexTranche:iTraxx:iTraxxAsiaExJapanTranche",
            "Credit:IndexTranche:iTraxx:iTraxxAustraliaTranche",
            "Credit:IndexTranche:iTraxx:iTraxxEuropeTranche",
            "Credit:IndexTranche:iTraxx:iTraxxJapanTranche",
            "Credit:IndexTranche:iTraxx:StandardiTraxxEuropeTranche",
            "Credit:IndexTranche:iTraxxStructuredTranche:iTraxxBlendedTranche",
            "Credit:IndexTranche:iTraxxStructuredTranche:iTraxxRiskyZeroTranche",
            "Credit:IndexTranche:LCDX:LCDXTranche",
            "Credit:IndexTranche:LCDX:StandardLCDXBulletTranche",
            "Credit:SingleName:ABS:CDSonCDO",
            "Credit:SingleName:ABS:CMBS",
            "Credit:SingleName:ABS:EuropeanCMBS",
            "Credit:SingleName:ABS:EuropeanRMBS",
            "Credit:SingleName:ABS:RMBS",
            "Credit:SingleName:Corporate:AsiaCorporate",
            "Credit:SingleName:Corporate:AustraliaCorporate",
            "Credit:SingleName:Corporate:EmergingEuropeanCorporate",
            "Credit:SingleName:Corporate:EmergingEuropeanCorporateLPN",
            "Credit:SingleName:Corporate:EuropeanCorporate",
            "Credit:SingleName:Corporate:JapanCorporate",
            "Credit:SingleName:Corporate:LatinAmericaCorporate",
            "Credit:SingleName:Corporate:LatinAmericaCorporateBond",
            "Credit:SingleName:Corporate:LatinAmericaCorporateBondOrLoan",
            "Credit:SingleName:Corporate:NewZealandCorporate",
            "Credit:SingleName:Corporate:NorthAmericanCorporate",
            "Credit:SingleName:Corporate:SingaporeCorporate",
            "Credit:SingleName:Corporate:StandardAsiaCorporate",
            "Credit:SingleName:Corporate:StandardAustraliaCorporate",
            "Credit:SingleName:Corporate:StandardEmergingEuropeanCorporate",
            "Credit:SingleName:Corporate:StandardEmergingEuropeanCorporateLPN",
            "Credit:SingleName:Corporate:StandardEuropeanCorporate",
            "Credit:SingleName:Corporate:StandardJapanCorporate",
            "Credit:SingleName:Corporate:StandardLatinAmericaCorporateBond",
            "Credit:SingleName:Corporate:StandardLatinAmericaCorporateBondOrLoan",
            "Credit:SingleName:Corporate:StandardNewZealandCorporate",
            "Credit:SingleName:Corporate:StandardNorthAmericanCorporate",
            "Credit:SingleName:Corporate:StandardSingaporeCorporate",
            "Credit:SingleName:Corporate:StandardSubordinatedEuropeanInsuranceCorporate",
            "Credit:SingleName:Corporate:StandardSukukCorporate",
            "Credit:SingleName:Corporate:SubordinatedEuropeanInsuranceCorporate",
            "Credit:SingleName:Corporate:SukukCorporate",
            "Credit:SingleName:Loans:ELCDS",
            "Credit:SingleName:Loans:LCDS",
            "Credit:SingleName:Loans:StandardLCDSBullet",
            "Credit:SingleName:Muni:USMunicipalFullFaithAndCredit",
            "Credit:SingleName:Muni:USMunicipalGeneralFund",
            "Credit:SingleName:Muni:USMunicipalRevenue",
            "Credit:SingleName:RecoveryCDS:FixedRecoverySwaps",
            "Credit:SingleName:RecoveryCDS:RecoveryLocks",
            "Credit:SingleName:Sovereign:AsiaSovereign",
            "Credit:SingleName:Sovereign:AustraliaSovereign",
            "Credit:SingleName:Sovereign:EmergingEuropeanAndMiddleEasternSovereign",
            "Credit:SingleName:Sovereign:JapanSovereign",
            "Credit:SingleName:Sovereign:LatinAmericaSovereign",
            "Credit:SingleName:Sovereign:NewZealandSovereign",
            "Credit:SingleName:Sovereign:SingaporeSovereign",
            "Credit:SingleName:Sovereign:StandardAsiaSovereign",
            "Credit:SingleName:Sovereign:StandardAustraliaSovereign",
            "Credit:SingleName:Sovereign:StandardEmergingEuropeanAndMiddleEasternSovereign",
            "Credit:SingleName:Sovereign:StandardJapanSovereign",
            "Credit:SingleName:Sovereign:StandardLatinAmericaSovereign",
            "Credit:SingleName:Sovereign:StandardNewZealandSovereign",
            "Credit:SingleName:Sovereign:StandardSingaporeSovereign",
            "Credit:SingleName:Sovereign:StandardSukukSovereign",
            "Credit:SingleName:Sovereign:StandardWesternEuropeanSovereign",
            "Credit:SingleName:Sovereign:SukukSovereign",
            "Credit:SingleName:Sovereign:WesternEuropeanSovereign",
            "Credit:Swaptions:CDX:CDXSwaption",
            "Credit:Swaptions:Corporate:CDSSwaption",
            "Credit:Swaptions:iTraxx:iTraxxAsiaExJapanSwaption",
            "Credit:Swaptions:iTraxx:iTraxxAustraliaSwaption",
            "Credit:Swaptions:iTraxx:iTraxxEuropeSwaption",
            "Credit:Swaptions:iTraxx:iTraxxJapanSwaption",
            "Credit:Swaptions:iTraxx:iTraxxSovXSwaption",
            "Credit:Swaptions:Muni:CDSSwaption",
            "Credit:Swaptions:Sovereign:CDSSwaption",
            "Credit:TotalReturnSwap",
            "Equity:ContractForDifference:PriceReturnBasicPerformance:Basket",
            "Equity:ContractForDifference:PriceReturnBasicPerformance:SingleIndex",
            "Equity:ContractForDifference:PriceReturnBasicPerformance:SingleName",
            "Equity:Forward:PriceReturnBasicPerformance:Basket",
            "Equity:Forward:PriceReturnBasicPerformance:SingleIndex",
            "Equity:Forward:PriceReturnBasicPerformance:SingleName",
            "Equity:Option:ParameterReturnDividend:Basket",
            "Equity:Option:ParameterReturnDividend:SingleIndex",
            "Equity:Option:ParameterReturnDividend:SingleName",
            "Equity:Option:ParameterReturnVariance:Basket",
            "Equity:Option:ParameterReturnVariance:SingleIndex",
            "Equity:Option:ParameterReturnVariance:SingleName",
            "Equity:Option:ParameterReturnVolatility:Basket",
            "Equity:Option:ParameterReturnVolatility:SingleIndex",
            "Equity:Option:ParameterReturnVolatility:SingleName",
            "Equity:Option:PriceReturnBasicPerformance:Basket",
            "Equity:Option:PriceReturnBasicPerformance:SingleIndex",
            "Equity:Option:PriceReturnBasicPerformance:SingleName",
            "Equity:Other",
            "Equity:PortfolioSwap:PriceReturnBasicPerformance:Basket",
            "Equity:PortfolioSwap:PriceReturnBasicPerformance:SingleIndex",
            "Equity:PortfolioSwap:PriceReturnBasicPerformance:SingleName",
            "Equity:Swap:ParameterReturnDividend:Basket",
            "Equity:Swap:ParameterReturnDividend:SingleIndex",
            "Equity:Swap:ParameterReturnDividend:SingleName",
            "Equity:Swap:ParameterReturnVariance:Basket",
            "Equity:Swap:ParameterReturnVariance:SingleIndex",
            "Equity:Swap:ParameterReturnVariance:SingleName",
            "Equity:Swap:ParameterReturnVolatility:Basket",
            "Equity:Swap:ParameterReturnVolatility:SingleIndex",
            "Equity:Swap:ParameterReturnVolatility:SingleName",
            "Equity:Swap:PriceReturnBasicPerformance:Basket",
            "Equity:Swap:PriceReturnBasicPerformance:SingleIndex",
            "Equity:Swap:PriceReturnBasicPerformance:SingleName",
            "ForeignExchange:ComplexExotic",
            "ForeignExchange:Forward",
            "ForeignExchange:NDF",
            "ForeignExchange:NDO",
            "ForeignExchange:SimpleExotic:Barrier",
            "ForeignExchange:SimpleExotic:Digital",
            "ForeignExchange:Spot",
            "ForeignExchange:VanillaOption",
            "InterestRate:CapFloor",
            "InterestRate:CrossCurrency:Basis",
            "InterestRate:CrossCurrency:FixedFixed",
            "InterestRate:CrossCurrency:FixedFloat",
            "InterestRate:Exotic",
            "InterestRate:FRA",
            "InterestRate:IRSwap:Basis",
            "InterestRate:IRSwap:FixedFixed",
            "InterestRate:IRSwap:FixedFloat",
            "InterestRate:IRSwap:Inflation",
            "InterestRate:IRSwap:OIS",
            "InterestRate:Option:DebtOption",
            "InterestRate:Option:Swaption",
            null // (nn) _LAST_
        };

        public static string GetEnumString(ProductTaxonomyEnum id) { return EnumStrings[(int)id]; }

        public static bool TryParseEnumString(string idString, out ProductTaxonomyEnum id)
        {
            // note: we cannot use Enum.Parse() here, hence the loop...
            foreach (ProductTaxonomyEnum tempId in Enum.GetValues(typeof(ProductTaxonomyEnum)))
            {
                if (String.Compare(idString, EnumStrings[(int)tempId], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    id = tempId;
                    return true;
                }
            }
            id = ProductTaxonomyEnum.Undefined;
            return false;
        }
        public static ProductTaxonomyEnum ParseEnumString(string idString)
        {
            ProductTaxonomyEnum result;
            if (!TryParseEnumString(idString, out result))
                throw new ArgumentException(String.Format("Cannot convert '{0}' to ProductTaxonomyEnum", idString));
            return result;
        }

        public string GetItemName(string suffix)
        {
            return "Orion.Configuration.FpMLCodeScheme." + "ProductTaxonomyScheme"
            + ((suffix == null) ? null : ("." + suffix));
        }
        public NamedValueSet GetItemProps()
        {
            var result = new NamedValueSet();
            result.Set("Type", "FpMLCodeScheme");
            result.Set("FpMLCodeScheme", "ProductTaxonomyScheme");
            return result;
        }
        public IFpMLCodeValue CreateCodeValue(Row dataRow) { return new ProductTaxonomyValue(dataRow); }

        public string GetFpMLSource() { return "product-taxonomy-2-0"; }

        public void AddCodeValue(IFpMLCodeValue codeValue)
        {
            try
            {
                if (codeValue.GetType() != typeof(ProductTaxonomyValue))
                    throw new ApplicationException(
                        String.Format("Cannot convert type '{0}' to '{1}'!", codeValue.GetType().Name, typeof(ProductTaxonomyValue).Name));
                int newLength = 1;
                //if (schemeValuesField != null)
                //    newLength = schemeValuesField.Length + 1;
                //var newValues = new ProductTaxonomyValue[newLength];
                //if (schemeValuesField != null)
                //    schemeValuesField.CopyTo(newValues, 0);
                //newValues[newLength - 1] = (ProductTaxonomyValue)codeValue;
                //schemeValuesField = newValues;
            }
            catch (Exception excp)
            {
                Trace.WriteLine(String.Format("ProductTypeSimpleScheme.AddCodeValue failed: {0}", excp));
            }
        }
    }
}
