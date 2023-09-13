using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of a default-constructible reference type.
	/// </summary>
	/// <typeparam name="TValue">The type of values to generate.</typeparam>
	public class DefaultReferenceTypeGenerator<TValue> : ITheoryDataItemGenerator<TValue>
		where TValue : class, new()
	{
		/// <inheritdoc/>
		public static TValue GetAnyValue() =>
			(TValue)Activator.CreateInstance(typeof(TValue))!
		;


		/// <inheritdoc/>
		public static IEnumerable<TValue> GetUniqueValues(int numberOfValues = 2)
		{
			if (numberOfValues < 0)
				throw new ArgumentOutOfRangeException($"Cannot generate {numberOfValues} items. Parameter {nameof(numberOfValues)} must be non-negative.");

			return
				from _ in Enumerable.Range(0, numberOfValues)
				select GetAnyValue()
			;
		}
	}
}
