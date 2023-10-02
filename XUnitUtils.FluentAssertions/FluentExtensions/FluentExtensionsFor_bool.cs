using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace XUnitUtils.FluentAssertions.FluentExtensions
{
	/// <summary>
	/// Contains fluent extensions for instances of the type <see cref="bool"/>.
	/// </summary>
	public static class FluentExtensionsFor_bool
	{
		/// <summary>
		/// Asserts that the value is <see langword="true"/> if and only if another value is <see langword="true"/>.
		/// </summary>
		/// <param name="instance">The value to assert.</param>
		/// <param name="other">The value to compare with.</param>
		/// <param name="because"><inheritdoc cref="BooleanAssertions{TAssertions}.Be(bool, string, object[])" path="//param[@name='because']"/></param>
		/// <param name="becauseArgs"><inheritdoc cref="BooleanAssertions{TAssertions}.Be(bool, string, object[])" path="//param[@name='becauseArgs']"/></param>
		public static AndConstraint<BooleanAssertions> BeTrueIFF(this BooleanAssertions instance, bool other, string because = "", params object[] becauseArgs)
		{
			if (other)
				return instance.BeTrue(because, becauseArgs);

			return instance.BeFalse(because, becauseArgs);
		}


		/// <summary>
		/// Asserts that the value is <see langword="false"/> if and only if another value is <see langword="true"/>.
		/// </summary>
		/// <param name="instance">The value to assert.</param>
		/// <param name="other">The value to compare with.</param>
		/// <param name="because"><inheritdoc cref="BooleanAssertions{TAssertions}.Be(bool, string, object[])" path="//param[@name='because']"/></param>
		/// <param name="becauseArgs"><inheritdoc cref="BooleanAssertions{TAssertions}.Be(bool, string, object[])" path="//param[@name='becauseArgs']"/></param>
		public static AndConstraint<BooleanAssertions> BeFalseIFF(this BooleanAssertions instance, bool other, string because = "", params object[] becauseArgs)
		{
			if (other)
				return instance.BeFalse(because, becauseArgs);

			return instance.BeTrue(because, becauseArgs);
		}
	}
}
