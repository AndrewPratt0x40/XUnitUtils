using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using XUnitUtils.TheoryData;
using XUnitUtils.TheoryData.ItemGenerators;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_NumericGenerator
	{
		#region Generic method wrappers

		public static object? Invoke_GetAnyValue(Type TNumber) =>
			typeof(NumericGenerator<>)
			.MakeGenericType(TNumber)
			.GetMethod("GetAnyValue")!
			.Invoke(null, null)
		;


		public static object? Invoke_GetUniqueValues(Type TNumber, int numberOfValues) =>
			typeof(NumericGenerator<>)
			.MakeGenericType(TNumber)
			.GetMethod("GetUniqueValues")!
			.Invoke(null, new object?[] { numberOfValues })
		;

		#endregion


		#region Theory data

		public static IEnumerable<(Type type, int? maxSize)> ValidTypes =>
			new (Type, int?)[]
			{
				(typeof(byte), byte.MaxValue),
				(typeof(char), char.MaxValue),
				(typeof(decimal), null),
				(typeof(double), null),
				(typeof(Half), (int)Half.MaxValue),
				(typeof(Int128), null),
				(typeof(short), short.MaxValue),
				(typeof(int), int.MaxValue),
				(typeof(long), null),
				(typeof(IntPtr), null),
				(typeof(BigInteger), null),
				(typeof(NFloat), null),
				(typeof(sbyte), sbyte.MaxValue),
				(typeof(float), null),
				(typeof(UInt128), null),
				(typeof(ushort), ushort.MaxValue),
				(typeof(ulong), null),
				(typeof(UIntPtr), null)
			}
		;


		public static IEnumerable<int> PositiveNumbersOfValues =>
			Enumerable.Range(1, 3)
		;


		public static TheoryData<Type> TheoryDataFor_GetAnyValue
		{
			get
			{
				TheoryData<Type> theoryData = new();

				foreach ((Type type, int? maxSize) typeItem in ValidTypes)
					theoryData.Add(typeItem.type);

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_valid_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach ((Type type, int? maxSize) typeItem in ValidTypes)
				{
					theoryData.Add(typeItem.type, 0);

					foreach (int numberOfValues in PositiveNumbersOfValues)
						theoryData.Add(typeItem.type, numberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_negative_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach ((Type type, int? maxSize) typeItem in ValidTypes)
				{
					foreach (int positiveNumberOfValues in PositiveNumbersOfValues)
						theoryData.Add(typeItem.type, -positiveNumberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_too_large_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach ((Type type, int? maxSize) typeItem in ValidTypes.Where(x => x.maxSize != null && x.maxSize < int.MaxValue))
					theoryData.Add(typeItem.type, (int)typeItem.maxSize!);

				return theoryData;
			}
		}


		#endregion


		#region Tests

		[Fact]
		public void Theory_data_is_valid()
		{
			ValidTypes.Should().AllSatisfy
			(
				typeItem =>
					typeItem.type.Should().BeAssignableTo(typeof(INumber<>).MakeGenericType(typeItem.type)),
					$"all types in {nameof(ValidTypes)} should implement INumber"
			);

			PositiveNumbersOfValues.Should().AllSatisfy(numberOfValues => numberOfValues.Should().BePositive());
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue))]
		public void GetAnyValue_returns_a_valid_number_of_the_correct_type(Type TNumber)
		{
			Invoke_GetAnyValue(TNumber).Should().BeOfType(TNumber);
		}


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
	}
}
