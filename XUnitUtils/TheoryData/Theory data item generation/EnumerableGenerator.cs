using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of collections.
	/// </summary>
	/// <typeparam name="TItem">The type of each item in the collections to generate.</typeparam>
	/// <typeparam name="TInnerGenerator">The type to generate values of type <typeparamref name="TItem"/>.</typeparam>
	public class EnumerableGenerator<TItem, TInnerGenerator> : ITheoryDataItemGenerator<IEnumerable<TItem>>
		where TInnerGenerator : ITheoryDataItemGenerator<TItem>
	{
		/// <inheritdoc/>
		public static IEnumerable<TItem> GetAnyValue() =>
			Enumerable.Empty<TItem>()
		;


		/// <inheritdoc/>
		public static IEnumerable<IEnumerable<TItem>> GetUniqueValues(int numberOfValues = 2)
		{
			if (numberOfValues < 0)
				throw new ArgumentOutOfRangeException($"Cannot generate {numberOfValues} items. Parameter {nameof(numberOfValues)} must be non-negative.");

			IEnumerable<IEnumerable<TItem>> values = Enumerable.Empty<IEnumerable<TItem>>();

			int numberOfInnerValues = 0;
			while (values.Count() < numberOfValues)
				values = values.Concat(GeneratePermutations(TInnerGenerator.GetUniqueValues(numberOfInnerValues++), numberOfValues - values.Count()));

			return values;
		}


		private static IEnumerable<IEnumerable<TItem>> GeneratePermutations(IEnumerable<TItem> items, int maxPermutations) =>
			items.Any()
				? GeneratePermutationsStep(items.Count(), items.ToList(), Enumerable.Empty<IEnumerable<TItem>>(), maxPermutations)
				: Enumerable.Empty<IEnumerable<TItem>>()
		;
		
		
		private static IEnumerable<IEnumerable<TItem>> GeneratePermutationsStep(int k, IList<TItem> items, IEnumerable<IEnumerable<TItem>> generatedPermutations, int maxPermutations)
		{
			Debug.Assert(k >= 1);
			Debug.Assert(maxPermutations >= 0);
			Debug.Assert(generatedPermutations.Count() <= maxPermutations);
			
			if (generatedPermutations.Count() < maxPermutations)
			{
				// Permutations are generated using Heap's algorithm: https://en.wikipedia.org/wiki/Heap%27s_algorithm

				if (k == 1)
					return generatedPermutations.Append(items);

				generatedPermutations = GeneratePermutationsStep(k - 1, items, generatedPermutations, maxPermutations);

				bool isKEven = k % 2 == 0;
				for (int i = 0; i < k - 1; i++)
				{
					if (isKEven)
						(items[i], items[k - 1]) = (items[k - 1], items[i]);
					else
						(items[0], items[k - 1]) = (items[k - 1], items[0]);

					generatedPermutations = GeneratePermutationsStep(k - 1, items, generatedPermutations, maxPermutations);
				}
			}

			return generatedPermutations;
		}
	}
}
