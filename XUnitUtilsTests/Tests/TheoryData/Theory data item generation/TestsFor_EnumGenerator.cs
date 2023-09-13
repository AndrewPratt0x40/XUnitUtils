using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using XUnitUtils.TheoryData.ItemGenerators;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_EnumGenerator
	{
		#region Generic method wrappers

		public static object? Invoke_GetAnyValue(Type TValue) =>
			typeof(EnumGenerator<>)
			.MakeGenericType(TValue)
			.GetMethod("GetAnyValue")!
			.Invoke(null, null)
		;


		public static object? Invoke_GetUniqueValues(Type TValue, int numberOfValues) =>
			typeof(EnumGenerator<>)
			.MakeGenericType(TValue)
			.GetMethods()
			.First
			(
				method =>
					method.Name == "GetUniqueValues"
					&& method.GetParameters().Length == 1
			)
			.Invoke(null, new object?[] { numberOfValues })
		;

		#endregion


		#region Theory data

		public enum EEnumWith0Values { }

		public enum EEnumWith1Value
		{
			FirstValue
		}

		public enum EEnumWith3Values
		{
			FirstValue,
			SecondValue,
			ThirdValue
		}


		public static IEnumerable<(Type EnumType, int Size)> ValidTypes =>
			new (Type, int)[]
			{
				(typeof(EEnumWith1Value), 1),
				(typeof(EEnumWith3Values), 3)
			}
		;


		public static TheoryData<Type> TheoryDataFor_GetAnyValue
		{
			get
			{
				TheoryData<Type> theoryData = new();

				foreach ((Type EnumType, int Size) item in ValidTypes)
					theoryData.Add(item.EnumType);

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_valid_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach ((Type EnumType, int Size) item in ValidTypes)
				{
					for (int size = 0; size <= item.Size; size++)
						theoryData.Add(item.EnumType, size);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_negative_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach ((Type EnumType, int Size) item in ValidTypes)
				{
					theoryData.Add(item.EnumType, -1);
					theoryData.Add(item.EnumType, -2);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_too_large_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach ((Type EnumType, int Size) item in ValidTypes)
				{
					theoryData.Add(item.EnumType, item.Size + 1);
					theoryData.Add(item.EnumType, item.Size + 2);
				}

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
				item =>
				{
					item.EnumType.IsEnum.Should().BeTrue();
					item.Size.Should().BeGreaterThanOrEqualTo(0);
				}
			);
		}



		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue))]
		public void GetAnyValue_returns_a_valid_value_of_the_correct_type(Type TValue)
		{
			Invoke_GetAnyValue(TValue).Should().BeOfType(TValue);
		}


		[Fact]
		public void GetAnyValue_with_empty_enum_throws_InvalidOperationException()
		{
			// Arrange
			Action action = () => Invoke_GetAnyValue(typeof(EEnumWith0Values));

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<InvalidOperationException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_valid_size))]
		public void GetUniqueValues_returns_a_collection_of_unique_values_of_the_correct_size(Type TValue, int numberOfValues)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(TValue);

			// Act
			returnValue = Invoke_GetUniqueValues(TValue, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TValue.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable
				.Should()
				.NotBeNull
				(
					$"invoking GetUniqueValues with type parameter {TValue.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
				)
				.And.OnlyHaveUniqueItems()
				.And.HaveCount(numberOfValues)
			;
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_negative_size))]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_negative(Type TValue, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues(TValue, numberOfValues);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_too_large_size))]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_too_large(Type TValue, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues(TValue, numberOfValues);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}


		[Fact]
		public void GetUniqueValues_with_empty_enum_returns_empty_collection_when_numberOfValues_is_zero()
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;

			// Act
			returnValue = Invoke_GetUniqueValues(typeof(EEnumWith0Values), 0);

			// Assert
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {typeof(EEnumWith0Values).Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			returnValueAsEnumerable.Should().BeEmpty();
		}


		[Theory]
		[InlineData(-1)]
		[InlineData(1)]
		[InlineData(2)]
		public void GetUniqueValues_with_empty_enum_throws_ArgumentOutOfRangeException_when_numberOfValues_is_not_zero(int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues(typeof(EEnumWith0Values), numberOfValues);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}

		#endregion
	}
}
