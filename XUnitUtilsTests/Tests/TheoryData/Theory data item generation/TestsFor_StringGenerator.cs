using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_StringGenerator
	{
		#region Theory data

		public static TheoryData<int> TheoryDataFor_GetUniqueValues_with_valid_size = new()
		{
			0,
			1,
			2,
			XUnitUtils.TheoryData.ItemGenerators.StringGenerator.ValidChars.Count(),
			XUnitUtils.TheoryData.ItemGenerators.StringGenerator.ValidChars.Count() + 1,
			XUnitUtils.TheoryData.ItemGenerators.StringGenerator.ValidChars.Count() * 2,
			XUnitUtils.TheoryData.ItemGenerators.StringGenerator.ValidChars.Count() * 2 + 1,
		};

		#endregion


		#region Tests

		[Fact]
		public void GetAnyValue_returns_a_valid_string()
		{
			// Arrange
			Action action = () => XUnitUtils.TheoryData.ItemGenerators.StringGenerator.GetAnyValue();

			// Assert
			action.Should().NotThrow();
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_GetUniqueValues_with_valid_size))]
		public void GetUniqueValues_returns_a_collection_of_unique_strings_of_the_correct_size(int numberOfValues)
		{
			XUnitUtils.TheoryData.ItemGenerators.StringGenerator.GetUniqueValues(numberOfValues)
				.Should()
				.OnlyHaveUniqueItems()
				.And
				.HaveCount(numberOfValues)
			;
		}


		[Theory]
		[InlineData(-1)]
		[InlineData(-2)]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_negative(int numberOfValues)
		{
			// Arrange
			Action action = () => XUnitUtils.TheoryData.ItemGenerators.StringGenerator.GetUniqueValues(numberOfValues);

			// Assert
			action.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		#endregion
	}
}
