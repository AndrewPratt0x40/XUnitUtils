using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of type <see langword="bool"/>.
	/// </summary>
	public class BoolGenerator : ITheoryDataItemGenerator<bool>
	{
		/// <summary>
		/// The set of all possible values of type <see langword="bool"/>.
		/// </summary>
		public static IEnumerable<bool> AllPossibleValues =>
			new bool[] { true, false }
		;


		/// <inheritdoc/>
		public static bool GetAnyValue() => default;


		/// <inheritdoc/>
		public static IEnumerable<bool> GetUniqueValues(int numberOfValues = 2)
		{
			if (numberOfValues < 0)
				throw new ArgumentOutOfRangeException($"Cannot generate {numberOfValues} items. Parameter {nameof(numberOfValues)} must be either 0, 1, or two.");
			if (numberOfValues > 2)
				throw new ArgumentOutOfRangeException($"There are only two possible boolean values, and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be either 0, 1, or two.");

			return AllPossibleValues.Take(numberOfValues);
		}
	}
}
