using System;
using System.Collections.Generic;
using Orion.Util.Helpers;
using Orion.Util.Serialisation;
using nab.QDS.FpML.Codes;

namespace nab.QDS.FpML.V47
{
    public static class BasicQuotationHelper
    {
        private static void ParseQuotationSideEnum(string sideAsString, out bool sideSpecified, out QuotationSideEnum side)
        {
            sideSpecified = EnumHelper.TryParse(sideAsString, true, out side);
            if (!sideSpecified)
            {
                // if side not specified, it must be "Last"
                if (String.Compare(sideAsString, "Last", StringComparison.OrdinalIgnoreCase) != 0)
                    throw new ArgumentException("Unknown side: '" + sideAsString + "'");
            }
        }

        public static BasicQuotation Create(decimal value, AssetMeasureEnum assetMeasureEnum, PriceQuoteUnitsEnum priceQuoteUnitsEnum)
        {
            return new BasicQuotation
            {
                valueSpecified = true,
                value = value,
                measureType = new AssetMeasureType { Value = AssetMeasureScheme.GetEnumString(assetMeasureEnum) },
                quoteUnits = new PriceQuoteUnits { Value = PriceQuoteUnitsScheme.GetEnumString(priceQuoteUnitsEnum) }
            };
        }

        public static BasicQuotation Sum(List<BasicQuotation> basicQuotationList)
        {
            if (0 == basicQuotationList.Count)
            {
                throw new ArgumentException("basicQuotationList is empty");
            }
            if (1 == basicQuotationList.Count)
            {
                return BinarySerializerHelper.Clone(basicQuotationList[0]);
            }
            // clone collection internally - just to keep invariant of the method.
            //  
            List<BasicQuotation> clonedCollection = BinarySerializerHelper.Clone(basicQuotationList);

            BasicQuotation firstElement = clonedCollection[0];
            clonedCollection.RemoveAt(0);

            BasicQuotation sumOfTheTail = Sum(clonedCollection);

            return Add(firstElement, sumOfTheTail);
        }

        public static BasicQuotation Add(BasicQuotation basicQuotation1, BasicQuotation basicQuotation2)
        {
            if (basicQuotation1.measureType.Value != basicQuotation2.measureType.Value)
            {
                string errorMessage = String.Format("Error: can't add BasicQuotations with different 'measureTypes'. MeasureType for basicQuotation1 is {0}, MeasureType for basicQuotation2 is {1}", basicQuotation1.measureType.Value, basicQuotation2.measureType.Value);

                throw new Exception(errorMessage);
            }

            BasicQuotation result = BinarySerializerHelper.Clone(basicQuotation1);
            result.value += basicQuotation2.value;

            return result;
        }
        public static BasicQuotation CreateRate(Decimal quote)
        {
            return Create(quote, "Rate");
        }

        public static BasicQuotation CreateDiscount(Decimal quote)
        {
            return Create(quote, "Discount");
        }

        public static BasicQuotation CreateFuturesPrice(Decimal quote)
        {
            return Create(quote, "FuturesPrice");
        }

        public static BasicQuotation Create(Decimal quote, string measureType)
        {
            //if ("Rate" != measureType & "FuturesPrice" != measureType)
            //{
            //    string errorMessage = String.Format("Following measureType : '{0}' is not supported.", measureType);
            //    throw new Exception(errorMessage);
            //}

            var result = new BasicQuotation
                                        {
                                            valueSpecified = true,
                                            value = quote,
                                            measureType = new AssetMeasureType {Value = measureType},
                                            quoteUnits = new PriceQuoteUnits {Value = "DecimalValue"}
                                        };

            return result;
        }

        public static BasicQuotation Create(string measureType, string priceUnits, string sideAsString)
        {
            QuotationSideEnum side;
            bool sideSpecified;
            ParseQuotationSideEnum(sideAsString, out sideSpecified, out side);
            return new BasicQuotation
            {
                valueSpecified = false,
                measureType = AssetMeasureTypeHelper.Parse(measureType),
                quoteUnits = PriceQuoteUnitsHelper.Parse(priceUnits),
                sideSpecified = sideSpecified,
                side = side
            };
        }

        public static BasicQuotation Create(AssetMeasureEnum measureType, PriceQuoteUnitsEnum priceUnits, string sideAsString)
        {
            QuotationSideEnum side;
            bool sideSpecified;
            ParseQuotationSideEnum(sideAsString, out sideSpecified, out side);
            return new BasicQuotation
            {
                valueSpecified = false,
                measureType = AssetMeasureTypeHelper.Create(measureType),
                quoteUnits = PriceQuoteUnitsHelper.Create(priceUnits),
                sideSpecified = sideSpecified,
                side = side
            };
        }

        public static BasicQuotation Clone(BasicQuotation sourceToClone)
        {
            return new BasicQuotation
            {
                businessCenter = sourceToClone.businessCenter,
                cashFlowType = sourceToClone.cashFlowType,
                currency = sourceToClone.currency,
                exchangeId = sourceToClone.exchangeId,
                expiryTime = sourceToClone.expiryTime,
                expiryTimeSpecified = sourceToClone.expiryTimeSpecified,
                informationSource = sourceToClone.informationSource,
                measureType = sourceToClone.measureType,
                quoteUnits = sourceToClone.quoteUnits,
                side = sourceToClone.side,
                sideSpecified = sourceToClone.sideSpecified,
                time = sourceToClone.time,
                timeSpecified = sourceToClone.timeSpecified,
                timing = sourceToClone.timing,
                valuationDate = sourceToClone.valuationDate,
                valuationDateSpecified = sourceToClone.valuationDateSpecified,
                value = sourceToClone.value,
                valueSpecified = sourceToClone.valueSpecified
            };
        }

        public static BasicQuotation Create(BasicQuotation sourceToClone, decimal newValue)
        {
            BasicQuotation result = Clone(sourceToClone);
            result.valueSpecified = true;
            result.value = newValue;
            return result;
        }

        public static BasicQuotation Create(AssetMeasureType measureType, PriceQuoteUnits priceUnits, string sideAsString)
        {
            QuotationSideEnum side;
            bool sideSpecified;
            ParseQuotationSideEnum(sideAsString, out sideSpecified, out side);
            return new BasicQuotation
            {
                valueSpecified = false,
                measureType = measureType,
                quoteUnits = priceUnits,
                sideSpecified = sideSpecified,
                side = side
            };
        }

        public static BasicQuotation Create(string measureType, string priceUnits)
        {
            //if ("Rate" != measureType & "FuturesPrice" != measureType)
            //{
            //    string errorMessage = String.Format("Following measureType : '{0}' is not supported.", measureType);
            //    throw new Exception(errorMessage);
            //}

            var result = new BasicQuotation
            {
                measureType = new AssetMeasureType
                {
                    Value
                        =
                        measureType
                },
                quoteUnits = new PriceQuoteUnits { Value = priceUnits }
            };

            return result;
        }

        public static BasicQuotation Create(Decimal quote, string measureType, string priceUnits)
        {
            //if ("Rate" != measureType & "FuturesPrice" != measureType)
            //{
            //    string errorMessage = String.Format("Following measureType : '{0}' is not supported.", measureType);
            //    throw new Exception(errorMessage);
            //}

            var result = new BasicQuotation
                                        {
                                            valueSpecified = true,
                                            value = quote,
                                            measureType = new AssetMeasureType
                                                              {
                                                                  Value
                                                                      =
                                                                      measureType
                                                              },
                                            quoteUnits = new PriceQuoteUnits {Value = priceUnits}
                                        };

            return result;
        }

        public static BasicQuotation Create(Decimal quote, DateTime quoteTime, string measureType, string quoteTiming, string quoteUnits)
        {
            var result = new BasicQuotation
                                        {
                                            valueSpecified = true,
                                            value = quote,
                                            timeSpecified = true,
                                            time = quoteTime
                                        };

            if (measureType != null)
            {
                result.measureType = new AssetMeasureType {Value = measureType};
            }

            if (quoteUnits != null)
            {
                result.quoteUnits = new PriceQuoteUnits {Value = quoteUnits};
            }

            if (quoteTiming != null)
            {
                result.timing = new QuoteTiming {Value = quoteTiming};
            }

            return result;
        }

        public static string GetStandardFieldName(this BasicQuotation basicQuotation)
        {
            BasicQuotation bq = basicQuotation;
            // use field name supplied in quote if provided
            //if ((providerIdName != null) && (bq.informationSource != null))
            //{
            //    foreach (InformationSource infoSource in bq.informationSource)
            //    {
            //        if (infoSource.rateSource != null)
            //        {
            //            if (infoSource.rateSource.Value.Equals(providerIdName, StringComparison.OrdinalIgnoreCase))
            //            {
            //                // parse rate source page value as a named value set and rteurn the fieldname property
            //                NamedValueSet nvs = new NamedValueSet(infoSource.rateSourcePage.Value);
            //                return nvs.GetValue<string>("FieldName", null);
            //            }
            //        }
            //    }
                
            //}
            // override not supplied
            string result = bq.sideSpecified ? bq.side.ToString() : "Last";
            if ((bq.timing != null) && bq.timing.Value != null)
            {
                result += ("-" + bq.timing.Value);
                if (bq.valuationDateSpecified)
                    result += ("-" + bq.valuationDate.ToString("dd/MM/yyyy"));
            }
            else
                result += "-Live";
            return result;
        }
    }
}