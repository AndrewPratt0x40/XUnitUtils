using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitUtils.TheoryData
{
	/// <summary>
	/// Contains utilities for types that implement <see cref="IEnumerable{T}"/>.
	/// </summary>
	public static partial class UtilsForIEnumerable
	{
		/// <summary>
		/// Flattens a two-dimensional collection.
		/// </summary>
		/// <typeparam name="TItem">The type of each item in the collection.</typeparam>
		/// <param name="collection">The collection to flatten.</param>
		/// <returns>The flattened collection</returns>
		public static IEnumerable<TItem> Flatten<TItem>(IEnumerable<IEnumerable<TItem>> collection) =>
			collection.SelectMany(item => item)
		;


		/// <summary>
		/// Converts a collection to a sequence of key-value pairs, where the key is the index of each item in the original collection.
		/// </summary>
		/// <typeparam name="TItem">The type of each item in the collection.</typeparam>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static IEnumerable<KeyValuePair<int, TItem>> ToKeyValuePairs<TItem>(IEnumerable<TItem> collection) =>
			collection.Select((item, index) => new KeyValuePair<int, TItem>(index, item))
		;


		/// <summary>
		/// Adds an item to a collection, if the collection doesn't already contain the item.
		/// </summary>
		/// <typeparam name="TItem">The type of each item in the collection.</typeparam>
		/// <param name="collection">The collection to attempt to add <see langword="null"/> to.</param>
		/// <param name="newItem">The item to be added.</param>
		/// <returns><paramref name="collection"/> containing <paramref name="newItem"/>.</returns>
		public static IEnumerable<TItem> AppendIfNotAlreadyIn<TItem>(IEnumerable<TItem> collection, TItem newItem) =>
			collection.Contains(newItem)
				? collection
				: collection.Append(newItem)
		;


		/// <summary>
		/// Converts a collection to an instance of <see cref="TheoryData{T}"/>.
		/// </summary>
		/// <inheritdoc cref="TheoryData{T}" path="//typeparam"/>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>The converted collection.</returns>
		public static TheoryData<T> ToTheoryData<T>(IEnumerable<T> collection)
		{
			TheoryData<T> theoryData = new();
			foreach (T item in collection)
				theoryData.Add(item);
			return theoryData;
		}
	}
}
