using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using XUnitUtils.TheoryData.ItemGenerators;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_DefaultReferenceTypeGenerator
	{
		#region Generic method wrappers

		public static object? Invoke_GetAnyValue(Type TValue) =>
			typeof(DefaultReferenceTypeGenerator<>)
			.MakeGenericType(TValue)
			.GetMethod("GetAnyValue")!
			.Invoke(null, null)
		;


		public static object? Invoke_GetUniqueValues(Type TValue, int numberOfValues) =>
			typeof(DefaultReferenceTypeGenerator<>)
			.MakeGenericType(TValue)
			.GetMethod("GetUniqueValues")!
			.Invoke(null, new object?[] { numberOfValues })
		;

		#endregion


		#region Theory data

		public class ExampleEmptyClass
		{ }

		public class ExampleNonEmptyClass
		{
			public int MyInt { get; set; }
		}

		public class ExampleClassWithRequiredMember
		{
			public required int MyRequiredInt { get; set; }
		}


		public static IEnumerable<Type> ValidTypes =>
			new Type[]
			{
				typeof(object),
				typeof(ExampleEmptyClass),
				typeof(ExampleNonEmptyClass),
				typeof(ExampleClassWithRequiredMember)
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

				foreach (Type type in ValidTypes)
					theoryData.Add(type);

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_valid_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (Type type in ValidTypes)
				{
					theoryData.Add(type, 0);

					foreach (int size in PositiveNumbersOfValues)
						theoryData.Add(type, size);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, int> TheoryDataFor_GetUniqueValues_with_negative_size
		{
			get
			{
				TheoryData<Type, int> theoryData = new();

				foreach (Type type in ValidTypes)
				{
					foreach (int size in PositiveNumbersOfValues)
						theoryData.Add(type, -size);
				}

				return theoryData;
			}
		}

		#endregion


		#region Tests

		[Fact]
		public void Theory_data_is_valid()
		{
			ValidTypes.Should().AllSatisfy(type => type.IsValueType.Should().BeFalse());

			PositiveNumbersOfValues.Should().AllSatisfy(numberOfValues => numberOfValues.Should().BePositive());
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetAnyValue))]
		public void GetAnyValue_returns_a_valid_value_of_the_correct_type(Type TValue)
		{
			// Arrange
			object? returnValue;
			// Act
			returnValue = Invoke_GetAnyValue(TValue);

			// Assert
			returnValue.Should().BeOfType(TValue);
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

		#endregion
	}
}
