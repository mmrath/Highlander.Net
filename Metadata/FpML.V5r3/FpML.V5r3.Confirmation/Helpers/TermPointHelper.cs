#region Using directives

using System;

#endregion

namespace FpML.V5r3.Confirmation
{

    public class TermPointHelper
    {
        public static DateTime GetDate(TermPoint termPoint)
        {
            DateTime date = XsdClassesFieldResolver.TimeDimensionGetDate(termPoint.term);

            return date;
        }
    }
}