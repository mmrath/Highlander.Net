#region Using directives

using System;
using System.Globalization;
using Orion.Analytics.Dates;
using Orion.ModelFramework;

#endregion

namespace Orion.Analytics.BusinessCenters
{
    /// <summary>
    /// Warsaw calendar.
    /// </summary>
    /// <remarks>
    /// Holidays:
    /// <list type="table">
    /// <item><description>Saturdays</description></item>
    /// <item><description>Sundays</description></item>
    /// <item><description>New Year's Day, January 1st</description></item>
    /// <item><description>Easter Monday</description></item>
    /// <item><description>Corpus Christi</description></item>
    /// <item><description>Labour Day, May 1st</description></item>
    /// <item><description>Constitution Day, May 3rd</description></item>
    /// <item><description>ssumption of the Blessed Virgin Mary, August 15th</description></item>
    /// <item><description>All Saints Day, November 1st</description></item>
    /// <item><description>Independence Day, November 11th</description></item>
    /// <item><description>Christmas, December 25th</description></item>
    /// <item><description>2nd Day of Christmas, December 26th</description></item>
    /// </list>
    /// </remarks>
    /// <seealso href="http://www.national-holidays.com/">National Holidays (website)</seealso>
    public sealed class Warsaw : WesternCalendarBase
    {
        /// <summary>
        /// Parameterless COM constructor - use <see cref="Instance"/> member instead.
        /// </summary>
        /// <remarks>
        /// This constructor is provided for COM compatibility only.
        /// Use the static member <see cref="Instance"/> to get an object
        /// of this type.
        /// </remarks>
        [ Obsolete("Use Warsaw.Instance in .NET applications.") ]
        public Warsaw() 
            : base( "Warsaw", CultureInfo.CreateSpecificCulture("pl-PL"))
        {}

        #region FactoryItem pattern

        [ Obsolete() ] // just to ignore the CS0618 warning below
        static Warsaw()
        {
            Instance = new Warsaw();	// CS0618
        }

        /// <summary>
        /// A static instance of this type.
        /// </summary>
        static public readonly IBusinessCalendar Instance;

        #endregion

        /// <summary>
        /// The literal name of this day counter.
        /// </summary>
        /// <returns></returns>
        public override string ToFpML()
        {
            return "PLWA";
        }

        /// <summary>
        /// Implementation of the public <see cref="IsBusinessDay"/> method.
        /// </summary>
        /// <remarks>
        /// This method must be implemented by concrete calendar implementations.
        /// </remarks>
        /// <param name="d">The day value, between 1 and 31.</param>
        /// <param name="m">The month, one of <see cref="Month"/>.</param>
        /// <param name="y">The year, between 1 and 9999.</param>
        /// <param name="w">A <see cref="DayOfWeek"/> enumerated constant that
        /// indicates the day of the week. 
        /// This property value ranges from zero, indicating Sunday,
        /// to six, indicating Saturday.</param>
        /// <param name="dd">The day of the year, between 1 and 366.</param>
        /// <param name="em">The day of Easter Monady in the year, between 1 and 366.</param>
        /// <returns><c>True</c> when the given day is a business day.</returns>
        override protected bool IsBusinessDay(
            int d, Month m, int y,
            DayOfWeek w, int dd, int em )
        {
            if ((w == DayOfWeek.Saturday || w == DayOfWeek.Sunday)
                // New Year's Day
                || (d == 1 && m == Month.January)
                // Easter Monday
                || (dd == em)
                // Corpus Christi
                || (dd == em+59)
                // Labour Day
                || (d == 1 && m == Month.May)
                // Constitution Day
                || (d == 3  && m == Month.May)
                // Assumption of the Blessed Virgin Mary
                || (d == 15  && m == Month.August)
                // Republic Day
                || (d == 23  && m == Month.October)
                // All Saints Day
                || (d == 1  && m == Month.November)
                // Independence Day
                || (d == 11  && m == Month.November)
                // Christmas
                || (d == 25 && m == Month.December)
                // 2nd Day of Christmas
                || (d == 26 && m == Month.December)
                )
                return false;
            return true;
        }
    }
}