using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using XUnitUtils.TheoryData.ItemGenerators;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_EnumerableGenerator
	{
		#region Generic method wrappers

		public static object? Invoke_GetAnyValue(Type TValue, Type TInnerGenerator) =>
			typeof(EnumerableGenerator<,>)
			.MakeGenericType(TValue, TInnerGenerator)
			.GetMethod("GetAnyValue")!
			.Invoke(null, null)
		;


		public static object? Invoke_GetUniqueValues(Type TValue, Type TInnerGenerator, int numberOfValues) =>
			typeof(EnumerableGenerator<,>)
			.MakeGenericType(TValue, TInnerGenerator)
			.GetMethod("GetUniqueValues")!
			.Invoke(null, new object?[] { numberOfValues })
		;

		#endregion


		#region Theory data

		public static IEnumerable<(Type TValue, Type TInnerGenerator)> ValidTypes =>
			new (Type, Type)[]
			{
				(typeof(bool), typeof(BoolGenerator)),
				(typeof(object), typeof(DefaultReferenceTypeGenerator<object>)),
				(typeof(TestsFor_EnumGenerator.EEnumWith3Values), typeof(EnumGenerator<TestsFor_EnumGenerator.EEnumWith3Values>)),
				(typeof(int), typeof(NumericGenerator<int>)),
				(typeof(uint), typeof(NumericGenerator<uint>)),
				(typeof(float), typeof(NumericGenerator<float>)),
				(typeof(string), typeof(StringGenerator)),
				(typeof(IEnumerable<object>), typeof(EnumerableGenerator<object, DefaultReferenceTypeGenerator<object>>))
			}
		;


		public static IEnumerable<int> ValidNumbersOfValues =>
			Enumerable.Range(0, 2)
		;
		
		
		public static TheoryData<Type, Type> TheoryDataFor_GetAnyValue
		{
			get
			{
				TheoryData<Type, Type> theoryData = new();

				foreach ((Type tValue, Type tInnerGenerator) in ValidTypes)
					theoryData.Add(tValue, tInnerGenerator);

				return theoryData;
			}
		}


		public static TheoryData<Type, Type, int> TheoryDataFor_GetUniqueValues
		{
			get
			{
				TheoryData<Type, Type, int> theoryData = new();

				foreach ((Type tValue, Type tInnerGenerator) in ValidTypes)
				{
					foreach (int numberOfValues in ValidNumbersOfValues)
						theoryData.Add(tValue, tInnerGenerator, numberOfValues);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, Type, int> TheoryDataFor_GetUniqueValues_with_negative_size
		{
			get
			{
				TheoryData<Type, Type, int> theoryData = new();

				foreach ((Type tValue, Type tInnerGenerator) in ValidTypes)
				{
					theoryData.Add(tValue, tInnerGenerator, -1);
					theoryData.Add(tValue, tInnerGenerator, -2);
				}

				return theoryData;
			}
		}

		#endregion


		#region Tests

		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue))]
		public void GetAnyValue_returns_a_valid_value_of_the_expected_type(Type TValue, Type TInnerGenerator)
		{
			// Arrange
			object? returnValue;

			// Act
			returnValue = Invoke_GetAnyValue(TValue, TInnerGenerator);

			// Assert
			returnValue.Should().BeAssignableTo(typeof(IEnumerable<>).MakeGenericType(TValue));
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues))]
		public void GetUniqueValues_returns_a_collection_of_unique_values_of_the_correct_size(Type TValue, Type TInnerGenerator, int numberOfValues)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			Type expectedReturnType = typeof(IEnumerable<>).MakeGenericType(typeof(IEnumerable<>).MakeGenericType(TValue));

			// Act
			returnValue = Invoke_GetUniqueValues(TValue, TInnerGenerator, numberOfValues);

			// Assert
			returnValue.Should().BeAssignableTo
			(
				expectedReturnType,
				$"invoking GetUniqueValues with type parameter {TValue.Name} and generator {TInnerGenerator.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerable = (returnValue as IEnumerable)?.Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking GetUniqueValues with type parameter {TValue.Name} and generator {TInnerGenerator.Name} should return a value that is convertible to {nameof(IEnumerable<object>)}"
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
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_negative(Type TValue, Type TInnerGenerator, int numberOfValues)
		{
			// Arrange
			Action action = () => Invoke_GetUniqueValues(TValue, TInnerGenerator, numberOfValues);

			// Assert
			action.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentOutOfRangeException>();
		}

		#endregion
	}
}
