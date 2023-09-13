// AUTO-GENERATED FILE
// DO NOT MODIFY

using Xunit;


namespace XUnitUtils.TheoryData
{
	public static partial class UtilsForIEnumerable
	{


		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2> ToTheoryData<T1, T2>(IEnumerable<(T1, T2)> collection)
		{
			TheoryData<T1, T2> theoryData = new();
			foreach ((var v1, var v2) in collection)
				theoryData.Add(v1, v2);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3> ToTheoryData<T1, T2, T3>(IEnumerable<(T1, T2, T3)> collection)
		{
			TheoryData<T1, T2, T3> theoryData = new();
			foreach ((var v1, var v2, var v3) in collection)
				theoryData.Add(v1, v2, v3);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4> ToTheoryData<T1, T2, T3, T4>(IEnumerable<(T1, T2, T3, T4)> collection)
		{
			TheoryData<T1, T2, T3, T4> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4) in collection)
				theoryData.Add(v1, v2, v3, v4);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4, T5}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4, T5}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4, T5> ToTheoryData<T1, T2, T3, T4, T5>(IEnumerable<(T1, T2, T3, T4, T5)> collection)
		{
			TheoryData<T1, T2, T3, T4, T5> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4, var v5) in collection)
				theoryData.Add(v1, v2, v3, v4, v5);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4, T5, T6}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4, T5, T6}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4, T5, T6> ToTheoryData<T1, T2, T3, T4, T5, T6>(IEnumerable<(T1, T2, T3, T4, T5, T6)> collection)
		{
			TheoryData<T1, T2, T3, T4, T5, T6> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4, var v5, var v6) in collection)
				theoryData.Add(v1, v2, v3, v4, v5, v6);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4, T5, T6, T7}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4, T5, T6, T7}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4, T5, T6, T7> ToTheoryData<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> collection)
		{
			TheoryData<T1, T2, T3, T4, T5, T6, T7> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4, var v5, var v6, var v7) in collection)
				theoryData.Add(v1, v2, v3, v4, v5, v6, v7);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4, T5, T6, T7, T8}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4, T5, T6, T7, T8}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4, T5, T6, T7, T8> ToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>(IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> collection)
		{
			TheoryData<T1, T2, T3, T4, T5, T6, T7, T8> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4, var v5, var v6, var v7, var v8) in collection)
				theoryData.Add(v1, v2, v3, v4, v5, v6, v7, v8);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4, T5, T6, T7, T8, T9}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> collection)
		{
			TheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4, var v5, var v6, var v7, var v8, var v9) in collection)
				theoryData.Add(v1, v2, v3, v4, v5, v6, v7, v8, v9);
			return theoryData;
		}



		/// <summary>
		/// Converts a collection of tuples to an instance of <see cref="TheoryData{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> collection)
		{
			TheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> theoryData = new();
			foreach ((var v1, var v2, var v3, var v4, var v5, var v6, var v7, var v8, var v9, var v10) in collection)
				theoryData.Add(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
			return theoryData;
		}

	}
}
