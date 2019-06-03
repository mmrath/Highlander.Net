﻿#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Core.Common;
using FpML.V5r10.Codelist;
using FpML.V5r10.Codes;
using FpML.V5r10.Reporting;
using Metadata.Common;
using Orion.Constants;
using Orion.Util.Helpers;
using Orion.Util.Logging;
using Orion.Util.NamedValues;
using Orion.Util.Serialisation;

#endregion

namespace FpML.V5r10.ConfigData
{
    public static class ConfigDataLoader
    {
        private class ItemInfo
        {
            public string ItemName;
            public NamedValueSet ItemProps;
        }

        private static ItemInfo StandardConfigProps(string type, string idSuffix, string nameSpace)
        {
            var itemProps = new NamedValueSet();
            itemProps.Set(EnvironmentProp.DataGroup, "Orion.V5r10.Reporting.Configuration." + type);
            itemProps.Set(EnvironmentProp.SourceSystem, "Orion");
            itemProps.Set(EnvironmentProp.Function, FunctionProp.Configuration.ToString());
            itemProps.Set(EnvironmentProp.Type, type);
            itemProps.Set(EnvironmentProp.Schema, "V5r10.Reporting");
            itemProps.Set(EnvironmentProp.NameSpace, nameSpace);
            var identifier = "Configuration." + type + (idSuffix != null ? "." + idSuffix : null);
            string itemName = nameSpace + "." + identifier;
            itemProps.Set(CurveProp.UniqueIdentifier, identifier);
            return new ItemInfo { ItemName = itemName, ItemProps = itemProps };
        }

        public static void LoadInstrumentsConfig(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            string xml = GetXml("FpML.V5r10.ConfigData.Config.Instruments.xml");
            var assetSet = XmlSerializerHelper.DeserializeFromString<AssetSetConfiguration>(xml);
            foreach (Instrument instrument in assetSet.Instruments)
            {
                string id = instrument.Currency.Value;
                if (instrument.ExtraItem != null)
                    id = id + "." + instrument.ExtraItem;
                ItemInfo itemInfo = StandardConfigProps("Instrument", instrument.AssetType + '.' + id, nameSpace);
                itemInfo.ItemProps.Set(CurveProp.Currency1, instrument.Currency.Value);
                itemInfo.ItemProps.Set("AssetType", instrument.AssetType);
                itemInfo.ItemProps.Set("AssetId", id);
                itemInfo.ItemProps.Set("Schema", "FpML.V5r10");
                if (instrument.ExtraItem != null)
                    itemInfo.ItemProps.Set("ExtraItem", instrument.ExtraItem);
                targetClient.SaveObject(instrument, itemInfo.ItemName, itemInfo.ItemProps);
            }
            logger.LogDebug("Loaded instrument configs.");
        }

        private static ItemInfo HolidayDatesConfigProps(LocationCalendarYear locationCalendarYear, string nameSpace)
        {
            var itemProps = new NamedValueSet();
            itemProps.Set("Year", locationCalendarYear.Year);
            itemProps.Set("BusinessCenter", locationCalendarYear.BusinessCenter);
            itemProps.Set("RDMLocation", locationCalendarYear.RDMLocation);
            itemProps.Set(EnvironmentProp.DataGroup, "Orion.V5r10.Reporting.ReferenceData.RDMHolidays");
            itemProps.Set(EnvironmentProp.SourceSystem, "Orion");
            itemProps.Set(EnvironmentProp.Function, FunctionProp.Configuration.ToString());
            itemProps.Set(EnvironmentProp.Type, "LocationCalendarYear");
            itemProps.Set(EnvironmentProp.Schema, "V5r10.Reporting");
            itemProps.Set(EnvironmentProp.NameSpace, nameSpace);
            var identifier =
                $"ReferenceData.RDMHolidays.{locationCalendarYear.BusinessCenter}.{locationCalendarYear.Year}";
            string itemName = nameSpace + "." + identifier;
            itemProps.Set(CurveProp.UniqueIdentifier, identifier);
            return new ItemInfo { ItemName = itemName, ItemProps = itemProps };

        }

        private static ItemInfo BusinessCenterHolidayConfigProps(BusinessCenterCalendar locationCalendarYear, string nameSpace)
        {
            var itemProps = new NamedValueSet();
            itemProps.Set("BusinessCenter", locationCalendarYear.BusinessCenter);
            itemProps.Set("Location", locationCalendarYear.Location);
            itemProps.Set(EnvironmentProp.DataGroup, "Orion.V5r10.Reporting.ReferenceData.BusinessCenterHolidays");
            itemProps.Set(EnvironmentProp.SourceSystem, "Orion");
            itemProps.Set(EnvironmentProp.Function, FunctionProp.ReferenceData.ToString());
            itemProps.Set(EnvironmentProp.Type, "BusinessCenterHolidays");
            itemProps.Set(EnvironmentProp.Schema, "V5r10.Reporting");
            itemProps.Set(EnvironmentProp.NameSpace, nameSpace);
            string identifier = $"ReferenceData.BusinessCenterHolidays.{locationCalendarYear.BusinessCenter}";
            string itemName = nameSpace + "." + identifier;
            itemProps.Set(CurveProp.UniqueIdentifier, identifier);
            return new ItemInfo { ItemName = itemName, ItemProps = itemProps };

        }

        /// <summary>
        /// Moving to the new algorithm name!
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="targetClient"></param>
        /// <param name="nameSpace"></param>
        public static void LoadPricingStructureAlgorithm(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            string xml = GetXml("FpML.V5r10.ConfigData.Config.PricingStructureAlgorithms.xml");
            var pricingStructureTypes = XmlSerializerHelper.DeserializeFromString<PricingStructureTypes>(xml);
            //ItemInfo itemInfo = StandardConfigProps("PricingStructureAlgorithms", null);
            //targetClient.SaveObject<PricingStructureTypes>(pricingStructureTypes, itemInfo.ItemName, itemInfo.ItemProps);
            //logger.LogDebug("Loaded pricing structure types.");
            foreach (var pst in pricingStructureTypes.PricingStructureType)
            {
                foreach (var algo in pst.Algorithms)
                {
                    var itemInfo = StandardConfigProps("Algorithm", pst.id + "." + algo.id, nameSpace);
                    targetClient.SaveObject(algo, itemInfo.ItemName, itemInfo.ItemProps);
                    logger.LogDebug("Loaded Algorithm: {0}", itemInfo.ItemName);
                }
            }
        }

        public static void LoadBoundaryRider(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            string xml = GetXml("FpML.V5r10.ConfigData.Config.BoundaryRiderMappingVals.xml");
            var boundaryRiderMappings = XmlSerializerHelper.DeserializeFromString<BoundaryRiderMappings>(xml);
            ItemInfo itemInfo = StandardConfigProps("BoundaryRiderMappingVals", null, nameSpace);
            targetClient.SaveObject(boundaryRiderMappings, itemInfo.ItemName, itemInfo.ItemProps);
            logger.LogDebug("Loaded BoundaryRider mappings.");
        }

        public static void LoadHolidayDates(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string prefix = "FpML.V5r10.ConfigData.Config.HolidayDates";
            Dictionary<string, string> chosenFiles = ResourceHelper.GetResources(assembly, prefix, "xml");
            if (chosenFiles.Count == 0) throw new InvalidOperationException("Missing Date Rules");
            foreach (KeyValuePair<string, string> file in chosenFiles)
            {
                // load daterules from file
                var calendarYears = XmlSerializerHelper.DeserializeFromString<LocationCalendarYears>(file.Value);
                foreach (LocationCalendarYear locationCalendarYear in calendarYears.LocationCalendarYear)
                {
                    ItemInfo itemInfo = HolidayDatesConfigProps(locationCalendarYear, nameSpace);
                    targetClient.SaveObject(locationCalendarYear, itemInfo.ItemName, itemInfo.ItemProps);
                }
            }
            logger.LogDebug("Loaded holiday dates.");
        }

        public static void LoadNewHolidayDates(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string prefix = "FpML.V5r10.ConfigData.Config.HolidayDates";
            Dictionary<string, string> chosenFiles = ResourceHelper.GetResources(assembly, prefix, "xml");
            if (chosenFiles.Count == 0) throw new InvalidOperationException("Missing Date Rules");
            foreach (KeyValuePair<string, string> file in chosenFiles)
            {
                // load daterules from file
                var calendarYears = XmlSerializerHelper.DeserializeFromString<LocationCalendarYears>(file.Value);
                var businessCenterList = new Dictionary<string, BusinessCenterCalendar>();                
                foreach (LocationCalendarYear locationCalendarYear in calendarYears.LocationCalendarYear)
                {
                    BusinessCenterCalendar result;
                    var contains = businessCenterList.TryGetValue(locationCalendarYear.BusinessCenter, out result);
                    if (!contains)
                    {
                        var bc = new BusinessCenterCalendar
                                     {
                                         BusinessCenter = locationCalendarYear.BusinessCenter,
                                         Location = locationCalendarYear.RDMLocation,
                                         LocationName = locationCalendarYear.LocationName,
                                         Holidays = locationCalendarYear.Holidays
                                     };
                        businessCenterList.Add(bc.BusinessCenter, bc);
                    }
                    else
                    {
                        if (locationCalendarYear.Holidays != null)// && result.Holidays != null)
                        {
                            var holidays = new List<DateRule>();
                            if (result.Holidays != null)
                            {
                                holidays = new List<DateRule>(result.Holidays);
                            }
                            holidays.AddRange(locationCalendarYear.Holidays);//Test if null
                            result.Holidays = holidays.ToArray();
                        }
                    }
                }
                foreach (var center in businessCenterList)
                {
                    ItemInfo itemInfo = BusinessCenterHolidayConfigProps(center.Value, nameSpace);
                    targetClient.SaveObject(center.Value, itemInfo.ItemName, itemInfo.ItemProps);
                    logger.LogDebug("Loaded business center holiday dates: {0}", itemInfo.ItemName);
                }
            }
            logger.LogDebug("Loaded business center holiday dates.");
        }

        public static void LoadDateRules(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string prefix = "FpML.V5r10.ConfigData.Config.DateRules";
            Dictionary<string, string> chosenFiles = ResourceHelper.GetResources(assembly, prefix, "xml");
            if (chosenFiles.Count == 0) throw new InvalidOperationException("Missing Date Rules");

            foreach (KeyValuePair<string, string> file in chosenFiles)
            {
                // load daterules from file
                var dateRules = XmlSerializerHelper.DeserializeFromString<DateRules>(file.Value);
                string key = file.Key.Replace(".xml", "").Split('.').Last();
                ItemInfo itemInfo = StandardConfigProps("DateRules", key, nameSpace);
                targetClient.SaveObject(dateRules, itemInfo.ItemName, itemInfo.ItemProps);
            }
            logger.LogDebug("Loaded date rules.");
        }

        public static void LoadGwml(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            string xml = GetXml("FpML.V5r10.ConfigData.Config.GwmlEnumMaps.xml");

            var enumMaps = XmlSerializerHelper.DeserializeFromString<EnumMaps>(xml);
            ItemInfo itemInfo = StandardConfigProps("GwmlEnumMaps", null, nameSpace);
            targetClient.SaveObject(enumMaps, itemInfo.ItemName, itemInfo.ItemProps);
            logger.LogDebug("Loaded GWML enum maps.");
        }

        public static void LoadFpMLCodes(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string prefix = "FpML.V5r10.ConfigData.Config.FpMLCodes";
            Dictionary<string, string> chosenFiles = ResourceHelper.GetResources(assembly, prefix, "xml");
            if (chosenFiles.Count == 0) throw new InvalidOperationException("Missing FpML Code Lists");

            foreach (var file in chosenFiles)
            {
                var data = XmlSerializerHelper.DeserializeFromString<CodeListDocument>(file.Value);
                string classDefName = GetClassDefName(data.Identification.ShortName);

                // determine primary key
                string primaryKey = null;
                foreach (Key key in data.ColumnSet.Key)
                {
                    if (key.Id == "PrimaryKey")
                    {
                        if (primaryKey != null)
                            throw new ApplicationException("PrimaryKey defined more than once!");
                        primaryKey = key.ColumnRef[0].Ref;
                    }
                }
                if (primaryKey == null)
                    throw new ApplicationException("PrimaryKey is not defined!");

                // load rows
                IFpMLCodeScheme scheme = FpMLCodeSchemeFactory.CreateCodeScheme(classDefName);
                foreach (Row row in data.SimpleCodeList.Row)
                {
                    IFpMLCodeValue codeValue = scheme.CreateCodeValue(row);
                    if (scheme is DayCountFractionScheme)
                    {
                        var dcfValue = (DayCountFractionValue)codeValue;
                        if (dcfValue.HLClassName == null)
                            dcfValue.HLClassName = "DefaultClassName";
                    }
                    scheme.AddCodeValue(codeValue);
                }
                var type = scheme.GetItemProps().Get("FpMLCodeScheme");
                scheme.GetItemProps().Set(EnvironmentProp.DataGroup, "Orion.V5r10.Reporting.Configuration." + type);
                scheme.GetItemProps().Set(EnvironmentProp.SourceSystem, "Orion");
                scheme.GetItemProps().Set(EnvironmentProp.Function, FunctionProp.Configuration.ToString());
                scheme.GetItemProps().Set(EnvironmentProp.Type, "FpMLCodeScheme");
                scheme.GetItemProps().Set(EnvironmentProp.Schema, "V5r10.Reporting");
                scheme.GetItemProps().Set(EnvironmentProp.NameSpace, nameSpace);
                string identifier = "Configuration.FpMLCodeScheme." + type;
                string itemName = nameSpace + "." + identifier;
                scheme.GetItemProps().Set(CurveProp.UniqueIdentifier, identifier);
                targetClient.SaveTypedObject(scheme.GetType(), scheme, itemName, scheme.GetItemProps());
            } // foreach file
            logger.LogDebug("Loaded FpML code lists.");
        }

        private static string GetXml(string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string xml = ResourceHelper.GetResource(assembly, name);
            return xml;
        }

        private static string GetClassDefName(string schemeName)
        {
            if (!schemeName.EndsWith("Scheme"))
                throw new ApplicationException(
                    $"Cannot derive class def name from '{schemeName}'.");

            string result = schemeName.Substring(0, (schemeName.Length - 6));
            result = result[0].ToString(CultureInfo.InvariantCulture).ToUpper() + result.Substring(1);
            return result;
        }
    }
}
