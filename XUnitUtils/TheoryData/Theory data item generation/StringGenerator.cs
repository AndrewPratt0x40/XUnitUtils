using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of type <see langword="string"/>.
	/// </summary>
	public class StringGenerator : ITheoryDataItemGenerator<string>
	{
		/// <inheritdoc/>
		public static string GetAnyValue() =>
			string.Empty
		;


		/// <inheritdoc/>
		public static IEnumerable<string> GetUniqueValues(int numberOfValues = 1) =>
			from valueNum in Enumerable.Range(0, numberOfValues)
			select new string
			(
				(
					from indexInString in Enumerable.Range(0, valueNum / ValidChars.Count() + 1)
					select (char)(valueNum / Math.Pow(ValidChars.Count(), indexInString) % ValidChars.Count())
				)
				.ToArray()
			)
		;


		private static IEnumerable<char> GetAsciiRange(char start, char end) =>
			from charCode in Enumerable.Range(start, end - start)
			select (char)charCode
		;


		/// <summary>
		/// Every possible character to be used in a string.
		/// </summary>
		public static IEnumerable<char> ValidChars =>
			GetAsciiRange('a', 'z')
			.Concat(GetAsciiRange('A', 'Z'))
			.Concat(GetAsciiRange('0', '9'))
		;
	}
}
