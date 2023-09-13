using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of an enum type.
	/// </summary>
	/// <typeparam name="TValue">The type of values to generate.</typeparam>
	public class EnumGenerator<TValue> : ITheoryDataItemGenerator<TValue>
		where TValue : Enum
	{
		/// <summary>
		/// The set of every possible value of type <typeparamref name="TValue"/>.
		/// </summary>
		public static IEnumerable<TValue> AllPossibleValues =>
			Enum.GetValues(typeof(TValue)).Cast<TValue>()
		;


		private static int DefaultNumberOfValues =>
			Math.Min(AllPossibleValues.Count(), 2)
		;


		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown when <typeparamref name="TValue"/> has no values.</exception>
		public static TValue GetAnyValue()
		{
			if (!AllPossibleValues.Any())
				throw new InvalidOperationException($"Cannot generate a value of type {typeof(TValue).Name} as it has no defined enum values.");

			return AllPossibleValues.First();
		}


		/// <inheritdoc/>
		public static IEnumerable<TValue> GetUniqueValues(int numberOfValues)
		{
			if (numberOfValues < 0)
				throw new ArgumentOutOfRangeException($"Cannot generate {numberOfValues} items. Parameter {nameof(numberOfValues)} must be non-negative.");

			if (numberOfValues > AllPossibleValues.Count())
			{
				throw new ArgumentOutOfRangeException($"There are only {AllPossibleValues.Count()} possible {typeof(TValue).Name} values, and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be non-negative and no larger than {AllPossibleValues.Count()}.");
			}

			return AllPossibleValues.Take(numberOfValues);
		}


		/// <inheritdoc cref="GetUniqueValues(int)" path="//summary"/>
		/// <returns>A collection of unique values of type <typeparamref name="TValue"/>.</returns>
		public static IEnumerable<TValue> GetUniqueValues() =>
			GetUniqueValues(DefaultNumberOfValues)
		;

	}
}
