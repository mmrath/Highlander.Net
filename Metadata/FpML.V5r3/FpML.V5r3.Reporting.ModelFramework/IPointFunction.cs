#region Using Directives
using System.ComponentModel;
using System.Runtime.InteropServices;
#endregion

namespace Orion.ModelFramework
{

    /// <summary>
    /// This is a base class for any function that is used to create a curve or n-dimensional surface. It defines only very basic 
    /// functionality, such as 
    /// - y=f(x), where x is a "point" (meaning any n-dimensional point, where dimension
    /// might be expressed as just about anything, i.e. dates, strikes, tenors etc...)
    /// - ability to set an interpolator, which defines how f behaves (in general sense).
    /// and has an identifier.
    /// It is not aware of any functionality such as whether y returned is interest rate, volatility, 
    /// default probability, inflation level or anything else. These are left to the specific implementation
    /// as whenever an instance of this is used, it actually knows which of the curves it uses 
    /// (to a rather specific precision - for example it'd be possible that both credit and ir curves provide
    /// discount factor which can be used in exactly the same way).
    /// </summary>
    public interface IPointFunction
    {
        /// <summary>
        /// For any point, there should exist a function value. The point can be multi-dimensional.
        /// </summary>
        /// <param name="point"><c>IPoint</c> A point must have at least one dimension.
        /// <seealso cref="IPoint"/> The interface for a multi-dimensional point.</param>
        /// <returns>The <c>double</c> function value at the point</returns>
        [Description("The function value.") ]
        double Value(IPoint point);
    }

}
