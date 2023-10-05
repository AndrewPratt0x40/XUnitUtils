using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitUtils.TheoryData.ItemGenerators;

namespace XUnitUtils.Exceptions
{
	/// <summary>
	/// The exception that is thrown when <see cref="TheoryData.ItemGenerators.NumericGenerator{TNumber}"/> attempts to generate a negative value of an unsigned type.
	/// </summary>
	public class GetAnyValueNegationException : ArgumentException
	{
		/// <summary>
		/// Creates a new <see cref="GetAnyValueNegationException"/>.
		/// </summary>
		/// <param name="type">The unsigned type parameter.</param>
		/// <param name="paramName">The name of the parameter holding the sign.</param>
		/// <param name="sign">The value held by the parameter with name <paramref name="paramName"/>.</param>
		public GetAnyValueNegationException(Type type, string paramName, TheoryData.ItemGenerators.ENumericValueSign sign) :
			base($"Parameter {paramName} cannot be {sign} because the type {type.Name} is unsigned, and therefore cannot hold a negative value.")
		{ }
	}
}
