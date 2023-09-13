using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_BoolGenerator
	{
		#region Tests

		[Fact]
		public void GetAnyValue_returns_a_valid_bool()
		{
			// Arrange
			Action action = () => XUnitUtils.TheoryData.ItemGenerators.BoolGenerator.GetAnyValue();

			// Assert
			action.Should().NotThrow();
		}


		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		public void GetUniqueValues_returns_a_collection_of_unique_bools_of_the_correct_size(int numberOfValues)
		{
			XUnitUtils.TheoryData.ItemGenerators.BoolGenerator.GetUniqueValues(numberOfValues)
				.Should()
				.OnlyHaveUniqueItems()
				.And.HaveCount(numberOfValues)
			;
		}


		[Theory]
		[InlineData(-1)]
		[InlineData(-2)]
		[InlineData(3)]
		[InlineData(4)]
		public void GetUniqueValues_throws_ArgumentOutOfRangeException_when_numberOfValues_is_negative_or_greater_than_2(int numberOfValues)
		{
			// Arrange
			Action action = () => XUnitUtils.TheoryData.ItemGenerators.BoolGenerator.GetUniqueValues(numberOfValues);

			// Assert
			action.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		#endregion
	}
}
