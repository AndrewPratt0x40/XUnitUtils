using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_AlphaNumericCharGenerator
	{
		#region Theory data

		public static int NumberOfPossibleAlphaNumericChars => (26 * 2) + 10;


		public static TheoryData<int> TheoryDataFor_GetUniqueValues_with_valid_size = new()
		{
			0,
			1,
			2,
			NumberOfPossibleAlphaNumericChars - 1,
			NumberOfPossibleAlphaNumericChars
		};

		public static TheoryData<int> TheoryDataFor_GetUniqueValues_with_too_large_size = new()
		{
			NumberOfPossibleAlphaNumericChars + 1,
			NumberOfPossibleAlphaNumericChars + 2,
		};

		#endregion


		#region Tests

		[Fact]
		public void GetAnyValue_returns_a_valid_alphanumeric_char()
		{
			// Arrange
			char returnValue;

			// Act
			returnValue = XUnitUtils.TheoryData.ItemGenerators.AlphaNumericCharGenerator.GetAnyValue();

			// Assert
			char.IsLetterOrDigit(returnValue).Should().BeTrue();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_valid_size))]
		public void GetUniqueValues_returns_a_collection_of_unique_alphanumeric_chars_of_the_correct_size(int numberOfValues)
		{
			// Arrange
			IEnumerable<char> returnValue;

			// Act
			returnValue = XUnitUtils.TheoryData.ItemGenerators.AlphaNumericCharGenerator.GetUniqueValues(numberOfValues);

			// Assert
			returnValue
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;

			if (numberOfValues > 0)
				returnValue.Should().AllSatisfy(item => char.IsLetterOrDigit(item));
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_too_large_size))]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_too_large(int numberOfValues)
		{
			// Arrange
			Action action = () => XUnitUtils.TheoryData.ItemGenerators.AlphaNumericCharGenerator.GetUniqueValues(numberOfValues);

			// Assert
			action.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}


		[Theory]
		[InlineData(-1)]
		[InlineData(-2)]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_negative(int numberOfValues)
		{
			// Arrange
			Action action = () => XUnitUtils.TheoryData.ItemGenerators.AlphaNumericCharGenerator.GetUniqueValues(numberOfValues);

			// Assert
			action.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		#endregion
	}
}
