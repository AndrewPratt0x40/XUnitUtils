using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XUnitUtils.Exceptions;

namespace XUnitUtils.TheoryData.ItemGenerators
{
	/// <summary>
	/// Enumerates possible signs of numeric values.
	/// </summary>
	public enum ENumericValueSign
	{
		/// <summary>
		/// A value equal to zero.
		/// </summary>
		Zero,
		/// <summary>
		/// A value not equal to zero.
		/// </summary>
		NonZero,
		/// <summary>
		/// A value that is positive.
		/// </summary>
		Positive,
		/// <summary>
		/// A value that isn't positive.
		/// </summary>
		NonPositive,
		/// <summary>
		/// A value that is negative.
		/// </summary>
		Negative,
		/// <summary>
		/// A value that isn't negative.
		/// </summary>
		NonNegative,
	}

	// TODO: The calculation for the maximum possible amount of values is likely incorrect.
	/// <summary>
	/// Generates theory data items of a numeric type.
	/// </summary>
	/// <typeparam name="TNumber">The type of number to generate.</typeparam>
	public class NumericGenerator<TNumber> : ITheoryDataItemGenerator<TNumber>
		where TNumber : INumber<TNumber>
	{
		private static bool _isMaxValueOfTNumberCalculated = false;
		private static int? _maxValueOfTNumber = null;
		private static bool? _isTNumberUnsigned = null;


		/// <inheritdoc/>
		public static TNumber GetAnyValue() =>
			TNumber.Zero
		;


		/// <summary>
		/// Generates a single value of type <typeparamref name="TNumber"/> with a given sign.
		/// </summary>
		/// <param name="sign">The sign of the value to generate.</param>
		/// <returns>A valid instance of <typeparamref name="TNumber"/> with the sign specified by <paramref name="sign"/>.</returns>
		/// <exception cref="UnsignedNegationException">Thrown when <typeparamref name="TNumber"/> is unsigned and <paramref name="sign"/> is <see cref="ENumericValueSign.Negative"/>.</exception>
		public static TNumber GetAnyValue(ENumericValueSign sign)
		{
			switch (sign)
			{
				case ENumericValueSign.Zero:
				case ENumericValueSign.NonPositive:
				case ENumericValueSign.NonNegative:
					return TNumber.Zero;

				case ENumericValueSign.Positive:
				case ENumericValueSign.NonZero:
					return TNumber.One;

				default:
					Debug.Assert(sign == ENumericValueSign.Negative);
					if (IsTNumberUnsigned)
						throw new UnsignedNegationException(typeof(TNumber), nameof(sign), sign);
					return -TNumber.One;
			}
		}


		/// <inheritdoc/>
		public static IEnumerable<TNumber> GetUniqueValues(int numberOfValues = 2) =>
			GetUniqueValues(ENumericValueSign.NonNegative, numberOfValues)
		;


		/// <summary>
		/// Generates several unique values of type <typeparamref name="TNumber"/> with a given sign.
		/// </summary>
		/// <param name="sign">The sign of the values to generate.</param>
		/// <param name="numberOfValues"><inheritdoc cref="GetUniqueValues(int)" path="//param[@name='numberOfValues']"/></param>
		/// <returns>Exactly <paramref name="numberOfValues"/> values of type <typeparamref name="TNumber"/> with the sign <paramref name="sign"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="numberOfValues"/> values cannot be generated.</exception>
		public static IEnumerable<TNumber> GetUniqueValues(ENumericValueSign sign, int numberOfValues = 2)
		{
			if (numberOfValues < 0)
				throw new ArgumentOutOfRangeException($"Cannot generate {numberOfValues} items. Parameter {nameof(numberOfValues)} must be non-negative.");

			if (numberOfValues == 0)
				return Enumerable.Empty<TNumber>();

			if (MaxValueOfTNumber is not null && MaxValueOfTNumber! <= numberOfValues)
			{
				throw new ArgumentOutOfRangeException($"There are only {MaxValueOfTNumber} possible {typeof(TNumber).Name} values, and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be non-negative and no larger than {MaxValueOfTNumber}.");
			}

			switch (sign)
			{
				case ENumericValueSign.Zero:
					if (numberOfValues > 1)
						throw new ArgumentOutOfRangeException($"There is only one possible zero {typeof(TNumber).Name} value, and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be zero or one to generate zero-signed values.");
					return new TNumber[] { TNumber.Zero };

				case ENumericValueSign.NonPositive:
					if (IsTNumberUnsigned && numberOfValues > 1)
						throw new ArgumentOutOfRangeException($"There is only one possible non-positive {typeof(TNumber).Name} value (zero), and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be zero or one to generate non-positive values.");
					return
						from number in Enumerable.Range(1 - numberOfValues, numberOfValues)
						select IntToTNumber(number)
					;

				case ENumericValueSign.NonNegative:
					return
						from number in Enumerable.Range(0, numberOfValues)
						select IntToTNumber(number)
					;

				case ENumericValueSign.Positive:
				case ENumericValueSign.NonZero:
					return
						from number in Enumerable.Range(1, numberOfValues)
						select IntToTNumber(number)
					;

				default:
					Debug.Assert(sign == ENumericValueSign.Negative);
					if (IsTNumberUnsigned)
						throw new ArgumentOutOfRangeException($"There are no possible negative {typeof(TNumber).Name} values , and therefore {numberOfValues} items cannot be generated. Parameter {nameof(numberOfValues)} must be zero to generate negative values (which will yield an empty collection).");
					return
						from number in Enumerable.Range(0 - numberOfValues, numberOfValues)
						select IntToTNumber(number)
					;
			}
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


		private static bool IsTNumberUnsigned
		{
			get
			{
				if (_isTNumberUnsigned is bool calculatedIsTNumberUnsigned)
					return calculatedIsTNumberUnsigned;

				try
				{
					_ = typeof(IUnsignedNumber<>).MakeGenericType(typeof(TNumber));
				}
				catch (ArgumentException)
				{
					_isTNumberUnsigned = false;
				}

				_isTNumberUnsigned ??= true;
				return (bool)_isTNumberUnsigned;
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
