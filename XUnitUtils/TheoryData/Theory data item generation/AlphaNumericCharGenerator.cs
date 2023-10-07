using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates alphanumeric <see langword="char"/> theory data items.
	/// </summary>
	public class AlphaNumericCharGenerator : ITheoryDataItemGenerator<char>
	{
		/// <inheritdoc/>
		public static char GetAnyValue() =>
			throw new NotImplementedException()
		;


		/// <inheritdoc/>
		public static IEnumerable<char> GetUniqueValues(int numberOfValues = 1) =>
			throw new NotImplementedException()
		;
	}
}
