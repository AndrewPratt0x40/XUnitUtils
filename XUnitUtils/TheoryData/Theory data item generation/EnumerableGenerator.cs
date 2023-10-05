using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of collections.
	/// </summary>
	/// <typeparam name="TItem">The type of each item in the collections to generate.</typeparam>
	public class EnumerableGenerator<TItem> : ITheoryDataItemGenerator<IEnumerable<TItem>>
	{
		/// <inheritdoc/>
		public static IEnumerable<TItem> GetAnyValue() =>
			throw new NotImplementedException()
		;


		/// <inheritdoc/>
		public static IEnumerable<IEnumerable<TItem>> GetUniqueValues(int numberOfItems = 2) =>
			throw new NotImplementedException()
		;
	}
}
