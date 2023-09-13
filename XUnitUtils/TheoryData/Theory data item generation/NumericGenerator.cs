using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Generates theory data items of a numeric type.
	/// </summary>
	/// <typeparam name="TNumber">The type of number to generate.</typeparam>
	public class NumericGenerator<TNumber> : ITheoryDataItemGenerator<TNumber>
		where TNumber : INumber<TNumber>
	{
		private static bool _isMaxValueOfTNumberCalculated = false;
		private static int? _maxValueOfTNumber = null;


		/// <inheritdoc/>
		public static TNumber GetAnyValue() =>
			TNumber.Zero
		;


		/// <inheritdoc/>
		public static IEnumerable<TNumber> GetUniqueValues(int numberOfValues = 2)
		{
			if (numberOfValues < 0)
				throw new ArgumentOutOfRangeException($"Cannot generate {numberOfValues} items. Parameter {nameof(numberOfValues)} must be non-negative.");

			if (MaxValueOfTNumber is not null && MaxValueOfTNumber! <= numberOfValues)
			{
				throw new ArgumentOutOfRangeException($"There are only {MaxValueOfTNumber} possible {typeof(TNumber).Name} values, and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be non-negative and no larger than {MaxValueOfTNumber}.");
			}

			return
				from num in Enumerable.Range(0, numberOfValues)
				select IntToTNumber(num)
			;
		}


		private static int? MaxValueOfTNumber
		{
			get
			{
				if (_isMaxValueOfTNumberCalculated)
					return _maxValueOfTNumber;
				
				_isMaxValueOfTNumberCalculated = true;

				
				if
				(
					typeof(TNumber).IsAssignableTo(typeof(IMinMaxValue<>))
				)
				{
					if (typeof(TNumber).GetField("MaxValue") is FieldInfo maxValueFieldInfo)
					{
						Debug.Assert(maxValueFieldInfo.IsStatic);
						_maxValueOfTNumber = TNumberToInt((TNumber)maxValueFieldInfo.GetValue(null)!);
					}

					if (typeof(TNumber).GetProperty("MaxValue") is PropertyInfo maxValuePropertyInfo)
					{
						Debug.Assert(maxValuePropertyInfo.GetMethod!.IsStatic);
						_maxValueOfTNumber = TNumberToInt((TNumber)maxValuePropertyInfo.GetValue(null)!);
					}
				}

				return _maxValueOfTNumber;
			}
		}


		private static int TNumberToInt(TNumber number) =>
			(int)
			typeof(int)
			.GetMethod(nameof(int.CreateSaturating))!
			.MakeGenericMethod(typeof(TNumber))
			.Invoke(null, new object?[] { number })!
		;


		private static TNumber IntToTNumber(int number)
		{
			if (typeof(TNumber).IsAssignableTo(typeof(IConvertible)))
				return (TNumber)Convert.ChangeType(number, typeof(TNumber));

			MethodInfo? creationMethod = typeof(TNumber).GetMethod(nameof(TNumber.CreateSaturating));
			Debug.Assert(creationMethod is not null);

			return (TNumber)creationMethod!.MakeGenericMethod(typeof(int)).Invoke(null, new object?[] { number })!;
		}
	}
}
