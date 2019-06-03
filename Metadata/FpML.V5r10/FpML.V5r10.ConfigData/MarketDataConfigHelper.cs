﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Core.Common;
using Metadata.Common;
using Orion.Constants;
using Orion.Util.Helpers;
using Orion.Util.Logging;
using Orion.Util.NamedValues;
using Orion.Util.Serialisation;

namespace FpML.V5r10.ConfigData
{
    public static class MarketDataConfigHelper
    {
        public static void LoadProviderRules(ILogger logger, ICoreCache targetClient, string nameSpace)
        {
            logger.LogDebug("Loading market data provider rules...");
            const string itemType = "MarketData.ProviderRules";
            int count = 0;
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string prefix = "FpML.V5r10.ConfigData.ProviderRuleSets";
            Dictionary<string, string> chosenFiles = ResourceHelper.GetResources(assembly, prefix, "xml");
            if (chosenFiles.Count == 0)
                throw new InvalidOperationException("Missing  market data provider rules!");

            foreach (KeyValuePair<string, string> file in chosenFiles)
            {
                var ruleSet = XmlSerializerHelper.DeserializeFromString<ProviderRuleSet>(file.Value);
                MDSProviderId providerId = ruleSet.provider;
                logger.LogDebug("  Loading {0} ...", providerId);
                var itemProps = new NamedValueSet();
                itemProps.Set(EnvironmentProp.DataGroup, "Orion.V5r10.Configuration." + itemType);
                itemProps.Set(EnvironmentProp.SourceSystem, "Orion");
                itemProps.Set(EnvironmentProp.Function, FunctionProp.Configuration.ToString());
                itemProps.Set(EnvironmentProp.Type, itemType);
                itemProps.Set(EnvironmentProp.Schema, "V5r10.Reporting");
                itemProps.Set(EnvironmentProp.NameSpace, nameSpace);
                string itemName = String.Format(nameSpace + ".Configuration.{0}.{1}", itemType, providerId);
                targetClient.SaveObject(ruleSet, itemName, itemProps, false, TimeSpan.MaxValue);
                count++;
            }
            logger.LogDebug("Loaded {0} market data provider rule sets", count);
        }
    }
}