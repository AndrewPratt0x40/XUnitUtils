using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using XUnitUtils.TheoryData;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_UtilsForIEnumerable
	{
		#region Generic method wrappers

		public static object? Invoke_Flatten(Type TItem, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethod(nameof(UtilsForIEnumerable.Flatten))!
			.MakeGenericMethod(TItem)
			.Invoke(null, new object?[] { collection })
		;


		public static object? Invoke_ToKeyValuePairs(Type TItem, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethod(nameof(UtilsForIEnumerable.ToKeyValuePairs))!
			.MakeGenericMethod(TItem)
			.Invoke(null, new object?[] { collection })
		;


		public static object? Invoke_AppendIfNotAlreadyIn(Type TItem, object collection, object? item) =>
			typeof(UtilsForIEnumerable)
			.GetMethod(nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn))!
			.MakeGenericMethod(TItem)
			.Invoke(null, new object?[] { collection, item })
		;


		public static object? Invoke_ToTheoryData(Type T, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 1
			)
			.MakeGenericMethod(T)
			.Invoke(null, new object?[] { collection })
		;

		#endregion


		#region Theory data

		public class TheoryDataItemFor_ToTheoryData
		{
			public required IEnumerable<Type> TupleTypes { get; init; }
			public required ITuple[] Tuples { get; init; }
		}

		public static IEnumerable<TheoryDataItemFor_ToTheoryData> TheoryDataItemsFor_ToTheoryData =>
			new TheoryDataItemFor_ToTheoryData[]
			{
				new()
				{
					TupleTypes = Enumerable.Repeat(typeof(int), 10),
					Tuples = new ITuple[]
					{
						(0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
						(1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
						(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)
					}
				},
				new()
				{
					TupleTypes = new Type[]
					{
						typeof(bool),
						typeof(float),
						typeof(char),
						typeof(string),
						typeof(object),
						typeof(int),
						typeof(int),
						typeof(int),
						typeof(int),
						typeof(int)
					},
					Tuples = new ITuple[]
					{
						(false, 0.0f, 'a', "Foo", (object?)null, 0, 0, 0, 0, 0),
						(true, 1.0f, 'z', "Bar", (object?)new object(), 0, 1, 2, 3, 4)
					}
				}
			}
		;


		public class TheoryDataItemFor_AppendIfNotAlreadyIn
		{
			public required Type TItem { get; init; }
			public required object Collection { get; init; }
			public required object? ItemNotInCollection { get; init; }
		}


		public static IEnumerable<TheoryDataItemFor_AppendIfNotAlreadyIn> TheoryDataItemsFor_AppendIfNotAlreadyIn =>
			new TheoryDataItemFor_AppendIfNotAlreadyIn[]
			{
				// Empty reference type collection
				new()
				{
					TItem = typeof(object),
					Collection = Enumerable.Empty<object>(),
					ItemNotInCollection = new object()
				},
				// Empty value type collection
				new()
				{
					TItem = typeof(int),
					Collection = Enumerable.Empty<int>(),
					ItemNotInCollection = 0
				},
				// Non-empty reference type collection
				new()
				{
					TItem = typeof(object),
					Collection = new object[] { new() },
					ItemNotInCollection = new object()
				},
				// Non-empty value type collection
				new()
				{
					TItem = typeof(int),
					Collection = new int[] { 0 },
					ItemNotInCollection = 1
				},
				// Multi-item value type collection
				new()
				{
					TItem = typeof(int),
					Collection = new int[] { 1, 2, 3 },
					ItemNotInCollection = 0
				},
				// Nullable reference type collection without null item
				new()
				{
					TItem = typeof(object),
					Collection = new object?[] { new() },
					ItemNotInCollection = null
				},
				// Nullable reference type collection with null item
				new()
				{
					TItem = typeof(object),
					Collection = new object?[] { null, new() },
					ItemNotInCollection = new object()
				}
			}
		;


		public static TheoryData<Type, object, object> TheoryDataFor_Flatten => new()
		{
			{
				typeof(object),
				Enumerable.Empty<IEnumerable<object>>(),
				Enumerable.Empty<object>()
			},
			{
				typeof(int),
				Enumerable.Empty<IEnumerable<int>>(),
				Enumerable.Empty<int>()
			},
			{
				typeof(int),
				new IEnumerable<int>[]
				{
					new int[] { 0 }
				},
				new int[]{ 0 }
			},
			{
				typeof(string),
				new IEnumerable<string>[]
				{
					new string[] { "Hello, world!" }
				},
				new string[]{ "Hello, world!" }
			},
			{
				typeof(int),
				new IEnumerable<int>[]
				{
					new int[] { 1 },
					new int[] { 2 }
				},
				new int[]{ 1, 2 }
			},
			{
				typeof(int),
				new IEnumerable<int>[]
				{
					new int[] { 1, 2, 3 },
					new int[] { 4, 5, 6 }
				},
				new int[]{ 1, 2, 3, 4, 5, 6 }
			},
			{
				typeof(int),
				new IEnumerable<int>[]
				{
					new int[] { 1, 2 },
					new int[] { 3, 4, 5 },
					Enumerable.Empty<int>(),
					new int[] { 6 }
				},
				new int[]{ 1, 2, 3, 4, 5, 6 }
			},
			{
				typeof(IEnumerable<int>),
				new IEnumerable<IEnumerable<int>>[]
				{
					new IEnumerable<int>[]
					{
						new int[] { 1, 2 },
						new int[] { 3 },
						Enumerable.Empty<int>(),
					},
					new IEnumerable<int>[]
					{
						new int[] { 4 },
						new int[] { 5, 6 }
					}
				},
				new IEnumerable<int>[]
				{
					new int[] { 1, 2 },
					new int[] { 3 },
					Enumerable.Empty<int>(),
					new int[] { 4 },
					new int[] { 5, 6 }
				}
			}
		};


		public static TheoryData<Type, object, object> TheoryDataFor_ToKeyValuePairs => new()
		{
			{
				typeof(object),
				Enumerable.Empty<object>(),
				Enumerable.Empty<KeyValuePair<int, object>>()
			},
			{
				typeof(int),
				Enumerable.Empty<int>(),
				Enumerable.Empty<KeyValuePair<int, int>>()
			},
			{
				typeof(char),
				new char[] { 'a' },
				new KeyValuePair<int, char>[]
				{
					new(0, 'a')
				}
			},
			{
				typeof(char),
				new char[] { 'a', 'b', 'c' },
				new KeyValuePair<int, char>[]
				{
					new(0, 'a'),
					new(1, 'b'),
					new(2, 'c')
				}
			}
		};


		public static TheoryData<Type, object, object?> TheoryDataFor_AppendIfNotAlreadyIn_with_already_contained_item
		{
			get
			{
				TheoryData<Type, object, object?> theoryData = new();

				foreach (TheoryDataItemFor_AppendIfNotAlreadyIn item in TheoryDataItemsFor_AppendIfNotAlreadyIn)
				{
					foreach (object? itemInCollection in ((IEnumerable)item.Collection).Cast<object>())
						theoryData.Add(item.TItem, item.Collection, itemInCollection);
				}

				return theoryData;
			}
		}


		public static TheoryData<Type, object, object?> TheoryDataFor_AppendIfNotAlreadyIn_with_not_already_contained_item
		{
			get
			{
				TheoryData<Type, object, object?> theoryData = new();

				foreach (TheoryDataItemFor_AppendIfNotAlreadyIn item in TheoryDataItemsFor_AppendIfNotAlreadyIn)
					theoryData.Add(item.TItem, item.Collection, item.ItemNotInCollection);

				return theoryData;
			}
		}


		public static TheoryData<Type, object, IEnumerable<object[]>> TheoryDataFor_ToTheoryData
		{
			get
			{
				TheoryData<Type, object, IEnumerable<object[]>> theoryData = new();

				foreach (TheoryDataItemFor_ToTheoryData item in TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = item.TupleTypes.ElementAt(0);
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;

					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(tuple[0]);

					IEnumerable<object[]> expectedResult =
						from value in ((IEnumerable)collection).Cast<object>()
						select new object[] { value }
					;

					theoryData.Add(collectionItemType, collection, expectedResult);
				}

				return theoryData;
			}
		}

		#endregion


		#region Tests

		[Fact]
		public void TheoryDataItemsFor_ToTheoryData_should_be_valid()
		{
			TheoryDataItemsFor_ToTheoryData.Should().AllSatisfy
			(
				item =>
				{
					item.TupleTypes.Should().HaveCount(10);

					item.Tuples.Should().AllSatisfy
					(
						tuple =>
						{
							tuple.Length.Should().Be(10);

							foreach (int index in Enumerable.Range(0, 10))
								tuple[index]?.Should().BeOfType(item.TupleTypes.ElementAt(index));
						}
					);
				}
			);
		}


		[Fact]
		public void TheoryDataItemsFor_AppendIfNotAlreadyIn_should_be_valid()
		{
			TheoryDataItemsFor_AppendIfNotAlreadyIn.Should().AllSatisfy
			(
				item =>
				{
					item.ItemNotInCollection?.Should().BeOfType(item.TItem);
					item.Collection.Should().BeAssignableTo(typeof(IEnumerable<>).MakeGenericType(item.TItem));
					((IEnumerable)item.Collection).Cast<object?>().Should().NotContain(item.ItemNotInCollection);
				}
			);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_Flatten))]
		public void TheoryDataFor_Flatten_should_be_valid(Type TItem, object collection, object expectedReturnValue)
		{
			// Arrange
			Type expectedCollectionType = typeof(IEnumerable<>).MakeGenericType(typeof(IEnumerable<>).MakeGenericType(TItem));
			Type expectedExpectedReturnValueType = typeof(IEnumerable<>).MakeGenericType(TItem);

			// Assert
			collection.Should().BeAssignableTo(expectedCollectionType);
			expectedReturnValue.Should().BeAssignableTo(expectedExpectedReturnValueType);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToKeyValuePairs))]
		public void TheoryDataFor_ToKeyValuePairs_should_be_valid(Type TItem, object collection, object expectedReturnValue)
		{
			// Arrange
			Type expectedCollectionType = typeof(IEnumerable<>).MakeGenericType(TItem);
			Type expectedExpectedReturnValueType = typeof(IEnumerable<>).MakeGenericType(typeof(KeyValuePair<,>).MakeGenericType(typeof(int), TItem));

			// Assert
			collection.Should().BeAssignableTo(expectedCollectionType);
			expectedReturnValue.Should().BeAssignableTo(expectedExpectedReturnValueType);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_AppendIfNotAlreadyIn_with_already_contained_item))]
		public void TheoryDataFor_AppendIfNotAlreadyIn_with_already_contained_item_should_be_valid(Type TItem, object collection, object? item)
		{
			// Arrange
			Type expectedCollectionType = typeof(IEnumerable<>).MakeGenericType(TItem);
			IEnumerable<object?>? collectionAsEnumerable = ((IEnumerable)collection).Cast<object?>();

			// Assert
			item?.Should().BeOfType(TItem);
			collection.Should().BeAssignableTo(expectedCollectionType);
			collectionAsEnumerable.Should().NotBeNull($"{nameof(collection)} should be convertible to {nameof(IEnumerable<object?>)}");

			collectionAsEnumerable!.Should().Contain(item);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_AppendIfNotAlreadyIn_with_not_already_contained_item))]
		public void TheoryDataFor_AppendIfNotAlreadyIn_with_not_already_contained_item_should_be_valid(Type TItem, object collection, object? item)
		{
			// Arrange
			Type expectedCollectionType = typeof(IEnumerable<>).MakeGenericType(TItem);
			IEnumerable<object?>? collectionAsEnumerable = ((IEnumerable)collection).Cast<object?>();

			// Assert
			item?.Should().BeOfType(TItem);
			collection.Should().BeAssignableTo(expectedCollectionType);
			collectionAsEnumerable.Should().NotBeNull($"{nameof(collection)} should be convertible to {nameof(IEnumerable<object?>)}");

			collectionAsEnumerable!.Should().NotContain(item);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData))]
		public void TheoryDataFor_ToTheoryData_should_be_valid(Type T, object collection, IEnumerable<object[]> _)
		{
			// Arrange
			Type expectedCollectionType = typeof(IEnumerable<>).MakeGenericType(T);

			// Assert
			collection.Should().BeAssignableTo(expectedCollectionType);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_Flatten))]
		public void Flatten_returns_expected_collection(Type TItem, object collection, object expectedReturnValue)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			IEnumerable<object>? expectedReturnValueAsEnumerable = ((IEnumerable)expectedReturnValue).Cast<object>();

			// Act
			returnValue = Invoke_Flatten(TItem, collection);

			// Assert
			returnValueAsEnumerable = ((IEnumerable)returnValue!).Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.Flatten)} should return a value that is convertible to {nameof(IEnumerable<object>)}"
			);
			expectedReturnValueAsEnumerable.Should().NotBeNull
			(
				$"{nameof(expectedReturnValue)} should be convertible to {nameof(IEnumerable<object>)}"
			);

			returnValueAsEnumerable!.Should().BeEquivalentTo(expectedReturnValueAsEnumerable!);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToKeyValuePairs))]
		public void ToKeyValuePairs_returns_expected_collection(Type TItem, object collection, object expectedReturnValue)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object>? returnValueAsEnumerable;
			IEnumerable<object>? expectedReturnValueAsEnumerable = ((IEnumerable)expectedReturnValue).Cast<object>();

			// Act
			returnValue = Invoke_ToKeyValuePairs(TItem, collection);

			// Assert
			returnValueAsEnumerable = ((IEnumerable)returnValue!).Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull($"invoking {nameof(UtilsForIEnumerable.ToKeyValuePairs)} should return a value that is convertible to {nameof(IEnumerable<object>)}");
			expectedReturnValueAsEnumerable.Should().NotBeNull($"{nameof(expectedReturnValue)} should be convertible to {nameof(IEnumerable<object>)}");

			returnValueAsEnumerable!.Should().BeEquivalentTo(expectedReturnValueAsEnumerable!);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_AppendIfNotAlreadyIn_with_already_contained_item))]
		public void AppendIfNotAlreadyIn_with_an_item_already_in_the_collection_returns_unchanged_collection(Type TItem, object collection, object? item)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object?>? collectionAsEnumerable = ((IEnumerable)collection).Cast<object>();
			IEnumerable<object?>? returnValueAsEnumerable;

			// Act
			returnValue = Invoke_AppendIfNotAlreadyIn(TItem, collection, item);

			// Assert
			returnValueAsEnumerable = ((IEnumerable)returnValue!).Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn)} should return a value that is convertible to {nameof(IEnumerable<object?>)}"
			);
			collectionAsEnumerable.Should().NotBeNull
			(
				$"parameter {nameof(collection)} should be convertible to {nameof(IEnumerable<object?>)}"
			);

			returnValueAsEnumerable.Should().BeEquivalentTo
			(
				collectionAsEnumerable!,
				$"invoking {nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn)} with an item that is already contained in the collection should return the same collection unchanged"
			);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_AppendIfNotAlreadyIn_with_not_already_contained_item))]
		public void AppendIfNotAlreadyIn_with_an_item_not_already_in_the_collection_returns_collection_with_item(Type TItem, object collection, object? item)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object?>? collectionAsEnumerable = ((IEnumerable)collection).Cast<object>();
			IEnumerable<object?>? returnValueAsEnumerable;

			// Act
			returnValue = Invoke_AppendIfNotAlreadyIn(TItem, collection, item);

			// Assert
			returnValueAsEnumerable = ((IEnumerable)returnValue!).Cast<object>();
			returnValueAsEnumerable.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn)} should return a value that is convertible to {nameof(IEnumerable<object?>)}"
			);
			collectionAsEnumerable.Should().NotBeNull
			(
				$"parameter {nameof(collection)} should be convertible to {nameof(IEnumerable<object?>)}"
			);

			collectionAsEnumerable.Should().BeSubsetOf
			(
				returnValueAsEnumerable!,
				$"invoking {nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn)} with an item that is not already contained in the collection should return the collection with the item appended"
			);
			returnValueAsEnumerable
				.Should()
				.HaveCount
				(
					collectionAsEnumerable!.Count() + 1,
					$"invoking {nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn)} with an item that is not already contained in the collection should return the collection with the item appended EXACTLY once (therefore having a size exactly one larger than the original collection)"
				)
				.And
				.ContainSingle
				(
					itemInReturnValue => itemInReturnValue == null ? (item == null) : itemInReturnValue!.Equals(item),
					$"invoking {nameof(UtilsForIEnumerable.AppendIfNotAlreadyIn)} with an item that is not already contained in the collection should return the collection with the item appended EXACTLY once"
				)
			;
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData))]
		public void ToTheoryData_returns_expected_value(Type T, object collection, IEnumerable<object[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<>).MakeGenericType(T);

			// Act
			returnValue = Invoke_ToTheoryData(T, collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameter {T.Name} should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(1, "Each row should only contain 1 item")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}

		#endregion
	}
}
