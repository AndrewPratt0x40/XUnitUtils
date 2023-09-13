using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Describes a type that generates theory data items of a specific type.
	/// </summary>
	/// <typeparam name="TItem">The type of the items to generate.</typeparam>
	public interface ITheoryDataItemGenerator<TItem>
	{
		/// <summary>
		/// Generates a single value of type <typeparamref name="TItem"/>.
		/// </summary>
		/// <returns>A valid instance of <typeparamref name="TItem"/>.</returns>
		public abstract static TItem GetAnyValue();


		/// <summary>
		/// Generates several unique values of type <typeparamref name="TItem"/>.
		/// </summary>
		/// <param name="numberOfValues">The number of values to generate.</param>
		/// <returns>Exactly <paramref name="numberOfValues"/> values of type <typeparamref name="TItem"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException">When <paramref name="numberOfValues"/> is negative, or is larger than the maximum possible values of <typeparamref name="TItem"/>.</exception>
		public abstract static IEnumerable<TItem> GetUniqueValues(int numberOfValues);
	}
}
