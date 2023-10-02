using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit.Sdk;
using XUnitUtils.FluentAssertions.FluentExtensions;

namespace XUnitUtils.FluentAssertionsTests.Tests
{
	public class TestsFor_FluentExtensionsFor_bool
	{
		#region Tests

		[Theory]
		[InlineData(false, true)]
		[InlineData(true, false)]
		public void BeTrueIFF_with_unsatisfactory_values_fails(bool value, bool otherValue)
		{
			// Arrange
			Action action = () => value.Should().BeTrueIFF(otherValue);
			
			// Assert
			action.Should().Throw<XunitException>();
		}


		[Theory]
		[InlineData(false, false)]
		[InlineData(true, true)]
		public void BeTrueIFF_with_satisfactory_values_passes(bool value, bool otherValue)
		{
			// Arrange
			Action action = () => value.Should().BeTrueIFF(otherValue);

			// Assert
			action.Should().NotThrow();
		}


		[Theory]
		[InlineData(false, false)]
		[InlineData(true, true)]
		public void BeFalseIFF_with_unsatisfactory_values_fails(bool value, bool otherValue)
		{
			// Arrange
			Action action = () => value.Should().BeFalseIFF(otherValue);

			// Assert
			action.Should().Throw<XunitException>();
		}


		[Theory]
		[InlineData(false, true)]
		[InlineData(true, false)]
		public void BeFalseIFF_with_satisfactory_values_passes(bool value, bool otherValue)
		{
			// Arrange
			Action action = () => value.Should().BeFalseIFF(otherValue);

			// Assert
			action.Should().NotThrow();
		}

		#endregion
	}
}
