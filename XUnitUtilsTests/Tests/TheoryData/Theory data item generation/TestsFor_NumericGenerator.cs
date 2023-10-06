using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using XUnitUtils.Exceptions;
using XUnitUtils.TheoryData;
using XUnitUtils.TheoryData.ItemGenerators;
using static XUnitUtilsTests.Tests.TestsFor_NumericGenerator;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_NumericGenerator
	{
		#region Generic method wrappers

		public static object? Invoke_GetAnyValue(Type TNumber) =>
			typeof(NumericGenerator<>)
			.MakeGenericType(TNumber)
			.GetMethods()
			.First
			(
				method =>
					method.Name == "GetAnyValue"
					&& method.GetParameters().Length == 0
			)
			.Invoke(null, null)
		;


		public static object? Invoke_GetAnyValue_with_sign(Type TNumber, ENumericValueSign sign) =>
			typeof(NumericGenerator<>)
			.MakeGenericType(TNumber)
			.GetMethods()
			.First
			(
				method =>
					method.Name == "GetAnyValue"
					&& method.GetParameters().Length == 1
			)
			.Invoke(null, new object?[] { sign })
		;


		public static object? Invoke_GetUniqueValues(Type TNumber, int numberOfValues) =>
			typeof(NumericGenerator<>)
			.MakeGenericType(TNumber)
			.GetMethods()
			.First
			(
				method =>
					method.Name == "GetUniqueValues"
					&& method.GetParameters().Length == 1
			)
			.Invoke(null, new object?[] { numberOfValues })
		;


		public static object? Invoke_GetUniqueValues_with_sign(Type TNumber, ENumericValueSign sign, int numberOfValues) =>
			typeof(NumericGenerator<>)
			.MakeGenericType(TNumber)
			.GetMethods()
			.First
			(
				method =>
					method.Name == "GetUniqueValues"
					&& method.GetParameters().Length == 2
			)
			.Invoke(null, new object?[] { sign, numberOfValues })
		;

		#endregion


		#region Theory data

		#region Valid types

		public class NumericTypeTheoryDataItem
		{
			public required Type Type { get; init; }
			public required int? MaxSize { get; init; }
			public required bool IsSigned { get; init; }
			public required Predicate<object> IsZeroPred { get; init; }
			public required Predicate<object> IsPositivePred { get; init; }
			public required Predicate<object>? IsNegativePred { get; init; }
		}

		public static IEnumerable<NumericTypeTheoryDataItem> ValidTypes =>
			new NumericTypeTheoryDataItem[]
			{
				new()
				{
					Type = typeof(byte),
					MaxSize = byte.MaxValue,
					IsSigned = false,
					IsZeroPred = value => (byte)value == 0,
					IsPositivePred = value => (byte)value > 0,
					IsNegativePred = value => (byte)value < 0
				},
				new()
				{
					Type = typeof(char),
					MaxSize = char.MaxValue,
					IsSigned = false,
					IsZeroPred = value => (char)value == 0,
					IsPositivePred = value => (char)value > 0,
					IsNegativePred = null
				},
				new()
				{
					Type = typeof(decimal),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (decimal)value == 0,
					IsPositivePred = value => (decimal)value > 0,
					IsNegativePred = value => (decimal)value < 0
				},
				new()
				{
					Type = typeof(double),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (double)value == 0,
					IsPositivePred = value => (double)value > 0,
					IsNegativePred = value => (double)value < 0
				},
				new()
				{
					Type = typeof(Half),
					MaxSize = (int)Half.MaxValue,
					IsSigned = true,
					IsZeroPred = value => (Half)value == (Half)0,
					IsPositivePred = value => (Half)value > (Half)0,
					IsNegativePred = value => (Half)value < (Half)0
				},
				new()
				{
					Type = typeof(Int128),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (Int128)value == 0,
					IsPositivePred = value => (Int128)value > 0,
					IsNegativePred = value => (Int128)value < 0
				},
				new()
				{
					Type = typeof(short),
					MaxSize = short.MaxValue,
					IsSigned = true,
					IsZeroPred = value => (short)value == 0,
					IsPositivePred = value => (short)value > 0,
					IsNegativePred = value => (short)value < 0
				},
				new()
				{
					Type = typeof(int),
					MaxSize = int.MaxValue,
					IsSigned = true,
					IsZeroPred = value => (int)value == 0,
					IsPositivePred = value => (int)value > 0,
					IsNegativePred = value => (int)value < 0
				},
				new()
				{
					Type = typeof(long),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (long)value == 0,
					IsPositivePred = value => (long)value > 0,
					IsNegativePred = value => (long)value < 0
				},
				new()
				{
					Type = typeof(IntPtr),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (IntPtr)value == 0,
					IsPositivePred = value => (IntPtr)value > 0,
					IsNegativePred = value => (IntPtr)value < 0
				},
				new()
				{
					Type = typeof(BigInteger),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (BigInteger)value == 0,
					IsPositivePred = value => (BigInteger)value > 0,
					IsNegativePred = value => (BigInteger)value < 0
				},
				new()
				{
					Type = typeof(NFloat),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (NFloat)value == 0,
					IsPositivePred = value => (NFloat)value > 0,
					IsNegativePred = value => (NFloat)value < 0
				},
				new()
				{
					Type = typeof(sbyte),
					MaxSize = sbyte.MaxValue,
					IsSigned = true,
					IsZeroPred = value => (sbyte)value == 0,
					IsPositivePred = value => (sbyte)value > 0,
					IsNegativePred = value => (sbyte)value < 0
				},
				new()
				{
					Type = typeof(float),
					MaxSize = null,
					IsSigned = true,
					IsZeroPred = value => (float)value == 0,
					IsPositivePred = value => (float)value > 0,
					IsNegativePred = value => (float)value < 0
				},
				new()
				{
					Type = typeof(UInt128),
					MaxSize = null,
					IsSigned = false,
					IsZeroPred = value => (UInt128)value == 0,
					IsPositivePred = value => (UInt128)value > 0,
					IsNegativePred = null
				},
				new()
				{
					Type = typeof(ushort),
					MaxSize = ushort.MaxValue,
					IsSigned = false,
					IsZeroPred = value => (ushort)value == 0,
					IsPositivePred = value => (ushort)value > 0,
					IsNegativePred = null
				},
				new()
				{
					Type = typeof(ulong),
					MaxSize = null,
					IsSigned = false,
					IsZeroPred = value => (ulong)value == 0,
					IsPositivePred = value => (ulong)value > 0,
					IsNegativePred = null
				},
				new()
				{
					Type = typeof(UIntPtr),
					MaxSize = null,
					IsSigned = false,
					IsZeroPred = value => (UIntPtr)value == 0,
					IsPositivePred = value => (UIntPtr)value > 0,
					IsNegativePred = null
				}
			}
		;

		#endregion


		#region Numbers

		public static IEnumerable<int> PositiveNumbers =>
		Enumerable.Range(1, 3)
		;

		public static IEnumerable<int> NegativeNumbers =>
			from positiveNumber in PositiveNumbers
			select -positiveNumber
		;

		public static IEnumerable<int> NonPositiveNumbers =>
			NegativeNumbers.Append(0)
		;

		public static IEnumerable<int> NonNegativeNumbers =>
			PositiveNumbers.Append(0)
		;

		public static IEnumerable<int> NonZeroNumbers =>
			PositiveNumbers.Concat(NegativeNumbers)
		;

		#endregion


		#region GetAnyValue

		public static TheoryData<Type> TheoryDataFor_GetAnyValue
		{
			get
			{
				TheoryData<Type> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
					theoryData.Add(item.Type);

				return theoryData;
			}
		}


		public static TheoryData<Type, Predicate<object>> TheoryDataFor_GetAnyValue_with_zero_sign
		{
			get
			{
				TheoryData<Type, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
					theoryData.Add(item.Type, item.IsZeroPred);

				return theoryData;
			}
		}


		public static TheoryData<Type, Predicate<object>> TheoryDataFor_GetAnyValue_with_nonzero_sign
		{
			get
			{
				TheoryData<Type, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
					theoryData.Add(item.Type, number => !item.IsZeroPred(number));

				return theoryData;
			}
		}


		public static TheoryData<Type, Predicate<object>> TheoryDataFor_GetAnyValue_with_positive_sign
		{
			get
			{
				TheoryData<Type, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
					theoryData.Add(item.Type, item.IsPositivePred);

				return theoryData;
			}
		}


		public static TheoryData<Type, Predicate<object>> TheoryDataFor_GetAnyValue_with_nonpositive_sign
		{
			get
			{
				TheoryData<Type, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
					theoryData.Add(item.Type, number => !item.IsPositivePred(number));

				return theoryData;
			}
		}


		public static TheoryData<Type, Predicate<object>> TheoryDataFor_GetAnyValue_with_negative_sign_and_signed_type
		{
			get
			{
				TheoryData<Type, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => x.IsSigned))
					theoryData.Add(item.Type, item.IsNegativePred!);

				return theoryData;
			}
		}


		public static TheoryData<Type> TheoryDataFor_GetAnyValue_with_negative_sign_and_unsigned_type
		{
			get
			{
				TheoryData<Type> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => !x.IsSigned))
					theoryData.Add(item.Type);

				return theoryData;
			}
		}


		public static TheoryData<Type, Predicate<object>> TheoryDataFor_GetAnyValue_with_nonnegative_sign
		{
			get
			{
				TheoryData<Type, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
					theoryData.Add(item.Type, number => (!item.IsNegativePred?.Invoke(number)) ?? true);

				return theoryData;
			}
		}

		#endregion


		#region GetUniqueValues

		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_valid_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					theoryData.Add(item.Type, 0);

					foreach (int numberOfValues in NonNegativeNumbers)
					{
						Debug.Assert(item.MaxSize is null || numberOfValues <= item.MaxSize);
						theoryData.Add(item.Type, numberOfValues);
					}
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_negative_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					foreach (int numberOfValues in NegativeNumbers)
						theoryData.Add(item.Type, numberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_too_large_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => x.MaxSize != null && x.MaxSize < int.MaxValue))
					theoryData.Add(item.Type, (int)item.MaxSize! + 1);

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_zero_sign_and_zero_to_one_size
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					theoryData.Add(item.Type, 0, item.IsZeroPred);
					theoryData.Add(item.Type, 1, item.IsZeroPred);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_zero_sign_and_greater_than_one_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					foreach (int numberOfValues in PositiveNumbers.Where(x => x > 1))
						theoryData.Add(item.Type, numberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_nonzero_sign
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					foreach (int numberOfValues in NonNegativeNumbers)
						theoryData.Add(item.Type, numberOfValues, number => !item.IsZeroPred(number));
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_positive_sign
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					foreach (int numberOfValues in NonNegativeNumbers)
						theoryData.Add(item.Type, numberOfValues, item.IsPositivePred);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_nonpositive_sign_and_signed_type
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => x.IsSigned))
				{
					foreach (int numberOfValues in NonNegativeNumbers)
						theoryData.Add(item.Type, numberOfValues, number => !item.IsPositivePred(number));
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_nonpositive_sign_and_zero_to_one_size_and_unsigned_type
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => !x.IsSigned))
				{
					theoryData.Add(item.Type, 0, number => !item.IsPositivePred(number));
					theoryData.Add(item.Type, 1, number => !item.IsPositivePred(number));
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_nonpositive_sign_and_greater_than_one_size_and_unsigned_type
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => !x.IsSigned))
				{
					foreach (int numberOfValues in PositiveNumbers.Where(x => x > 1))
						theoryData.Add(item.Type, numberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_negative_sign_and_signed_type
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => x.IsSigned))
				{
					foreach (int numberOfValues in NonNegativeNumbers)
						theoryData.Add(item.Type, numberOfValues, item.IsNegativePred!);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type> TheoryDataFor_GetUniqueValues_with_negative_sign_and_zero_size_and_unsigned_type
		{
			get
			{
				TheoryData<Type> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => !x.IsSigned))
					theoryData.Add(item.Type);

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_negative_sign_and_greater_than_zero_size_and_unsigned_type
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => !x.IsSigned))
				{
					foreach (int numberOfValues in PositiveNumbers)
						theoryData.Add(item.Type, numberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, Predicate<object>> TheoryDataFor_GetUniqueValues_with_nonnegative_sign
		{
			get
			{
				TheoryData<Type, int, Predicate<object>> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					foreach (int numberOfValues in NonNegativeNumbers)
						theoryData.Add(item.Type, numberOfValues, number => (!item.IsNegativePred?.Invoke(number)) ?? true);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, ENumericValueSign> TheoryDataFor_GetUniqueValues_with_sign_and_negative_size
		{
			get
			{
				TheoryData<Type, int, ENumericValueSign> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes)
				{
					foreach (ENumericValueSign sign in Enum.GetValues<ENumericValueSign>())
					{
						foreach (int numberOfValues in NegativeNumbers)
							theoryData.Add(item.Type, numberOfValues, sign);
					}
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int, ENumericValueSign> TheoryDataFor_GetUniqueValues_with_sign_and_too_large_size
		{
			get
			{
				TheoryData<Type, int, ENumericValueSign> theoryData = new();

				foreach (NumericTypeTheoryDataItem item in ValidTypes.Where(x => x.MaxSize != null && x.MaxSize < int.MaxValue))
				{
					foreach (ENumericValueSign sign in Enum.GetValues<ENumericValueSign>())
						theoryData.Add(item.Type, (int)item.MaxSize! + 1, sign);
				}

				return theoryData;
			}
		}


		#endregion


		#endregion


		#region Tests

		#region Theory data tests

		[Fact]
		public void Theory_data_is_valid()
		{
			ValidTypes.Should().AllSatisfy
			(
				typeItem =>
				{
					typeItem.Type.Should().BeAssignableTo
					(
						typeof(INumber<>).MakeGenericType(typeItem.Type),
						$"all types in {nameof(ValidTypes)} should implement INumber"
					);

					if (typeItem.IsSigned)
						typeItem.IsNegativePred.Should().NotBeNull("all signed types must specify a predicate to determine if a value is negative or not");
				}
			);

			PositiveNumbers
				.Should()
				.AllSatisfy(number => number.Should().BePositive())
				.And
				.Contain(number => number > 1)
			;
			NonPositiveNumbers.Should().AllSatisfy(number => number.Should().BeLessThanOrEqualTo(0));

			NegativeNumbers.Should().AllSatisfy(number => number.Should().BeNegative());
			NonNegativeNumbers.Should().AllSatisfy(number => number.Should().BeGreaterThanOrEqualTo(0));

			NonZeroNumbers.Should().AllSatisfy(number => number.Should().NotBe(0));
		}

		#endregion


		#region GetAnyValue

		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue))]
		public void GetAnyValue_returns_a_valid_number_of_the_correct_type(Type TNumber)
		{
			Invoke_GetAnyValue(TNumber).Should().BeOfType(TNumber);
		}

		#endregion


		#region GetAnyValue with sign

		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_zero_sign))]
		public void GetAnyValue_with_zero_sign_returns_a_zero_value_of_the_correct_type(Type TNumber, Predicate<object> isZeroPred)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.Zero);

			// Assert
			returnValue.Should().BeOfType(TNumber);
			isZeroPred(returnValue!).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_nonzero_sign))]
		public void GetAnyValue_with_nonzero_sign_returns_a_nonzero_value_of_the_correct_type(Type TNumber, Predicate<object> isNonZeroPred)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.NonZero);

			// Assert
			returnValue.Should().BeOfType(TNumber);
			isNonZeroPred(returnValue!).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_positive_sign))]
		public void GetAnyValue_with_positive_sign_returns_a_positive_value_of_the_correct_type(Type TNumber, Predicate<object> isPositivePred)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.Positive);

			// Assert
			returnValue.Should().BeOfType(TNumber);
			isPositivePred(returnValue!).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_nonpositive_sign))]
		public void GetAnyValue_with_nonpositive_sign_returns_a_nonpositive_value_of_the_correct_type(Type TNumber, Predicate<object> isNonPositivePred)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.NonPositive);

			// Assert
			returnValue.Should().BeOfType(TNumber);
			isNonPositivePred(returnValue!).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_negative_sign_and_signed_type))]
		public void GetAnyValue_with_negative_sign_and_a_signed_type_returns_a_negative_value_of_the_correct_type(Type TNumber, Predicate<object> isNegativePred)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.Negative);

			// Assert
			returnValue.Should().BeOfType(TNumber);
			isNegativePred(returnValue!).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_negative_sign_and_unsigned_type))]
		public void GetAnyValue_with_negative_sign_and_an_unsigned_type_throws_UnsignedNegationException(Type TNumber)
		{
			// Arrange
			Action action = () => Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.Negative);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<UnsignedNegationException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue_with_nonnegative_sign))]
		public void GetAnyValue_with_nonnegative_sign_returns_a_nonnegative_value_of_the_correct_type(Type TNumber, Predicate<object> isNonNegativePred)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue_with_sign(TNumber, ENumericValueSign.NonNegative);

			// Assert
			returnValue.Should().BeOfType(TNumber);
			isNonNegativePred(returnValue!).Should().BeTrue();
		}

		#endregion


		#region GetUniqueValues

		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_valid_size))]
		public void GetUniqueValues_returns_a_collection_of_unique_numbers_of_the_correct_size(Type TNumber, int numberOfValues)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues(TNumber, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_negative_size))]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_negative(Type TNumber, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues(TNumber, numberOfValues);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_too_large_size))]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_too_large(Type TNumber, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues(TNumber, numberOfValues);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}

		#endregion


		#region GetUniqueValues with sign

		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_zero_sign_and_zero_to_one_size))]
		public void GetUniqueValues_with_zero_sign_and_zero_to_one_items_returns_a_collection_of_zeros_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isZeroPred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.Zero, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isZeroPred(number)).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_zero_sign_and_greater_than_one_size))]
		public void GetUniqueValues_with_zero_sign_and_greater_than_one_items_throws_ArgumentOutOfRangeException
			(Type TNumber, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.Zero, numberOfValues);

			// Act
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_nonzero_sign))]
		public void GetUniqueValues_with_nonzero_sign_returns_a_collection_of_unique_nonzero_numbers_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isNonZeroPred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.NonZero, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isNonZeroPred(number)).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_positive_sign))]
		public void GetUniqueValues_with_positive_sign_returns_a_collection_of_positive_numbers_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isPositivePred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.Positive, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isPositivePred(number)).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_nonpositive_sign_and_signed_type))]
		public void GetUniqueValues_with_nonpositive_sign_and_signed_type_returns_a_collection_of_nonpositive_numbers_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isNonPositivePred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.NonPositive, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isNonPositivePred(number)).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_nonpositive_sign_and_zero_to_one_size_and_unsigned_type))]
		public void GetUniqueValues_with_nonpositive_sign_and_zero_to_one_size_and_unsigned_type_returns_a_collection_of_nonpositive_numbers_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isNonPositivePred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.NonPositive, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isNonPositivePred(number)).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_nonpositive_sign_and_greater_than_one_size_and_unsigned_type))]
		public void GetUniqueValues_with_nonpositive_sign_and_greater_than_one_size_and_unsigned_type_throws_ArgumentOutOfRangeException
			(Type TNumber, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.NonPositive, numberOfValues);

			// Act
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_negative_sign_and_signed_type))]
		public void GetUniqueValues_with_negative_sign_and_signed_type_returns_a_collection_of_negative_numbers_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isNegativePred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.Negative, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isNegativePred(number)).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_negative_sign_and_zero_size_and_unsigned_type))]
		public void GetUniqueValues_with_negative_sign_and_zero_size_and_unsigned_type_returns_an_empty_collection
			(Type TNumber)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.Negative, 0);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable.Should().BeEmpty();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_negative_sign_and_greater_than_zero_size_and_unsigned_type))]
		public void GetUniqueValues_with_negative_sign_and_greater_than_zero_size_and_unsigned_type_throws_UnsignedNegationException
			(Type TNumber, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.Negative, numberOfValues);

			// Act
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_nonnegative_sign))]
		public void GetUniqueValues_with_nonnegative_sign_returns_a_collection_of_nonnegative_numbers_of_the_correct_size
			(Type TNumber, int numberOfValues, Predicate<object> isNonNegativePred)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TNumber);

			// Act
			returnValue = Invoke_GetUniqueValues_with_sign(TNumber, ENumericValueSign.NonNegative, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TNumber.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
			returnValueAsEnumerable!.All(number => isNonNegativePred(number)).Should().BeTrue();
		}

		#endregion


		#endregion
	}
}
