// AUTO-GENERATED FILE
// DO NOT MODIFY

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using XUnitUtils.TheoryData;

namespace XUnitUtilsTests.Tests
{
	public class TestsFor_UtilsForIEnumerable_ToTheoryData
	{
		#region Generic method wrappers

		public static object? Invoke_ToTheoryData_With2Params(Type T1, Type T2, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 2
			)
			.MakeGenericMethod(T1, T2)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With3Params(Type T1, Type T2, Type T3, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 3
			)
			.MakeGenericMethod(T1, T2, T3)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With4Params(Type T1, Type T2, Type T3, Type T4, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 4
			)
			.MakeGenericMethod(T1, T2, T3, T4)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With5Params(Type T1, Type T2, Type T3, Type T4, Type T5, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 5
			)
			.MakeGenericMethod(T1, T2, T3, T4, T5)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With6Params(Type T1, Type T2, Type T3, Type T4, Type T5, Type T6, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 6
			)
			.MakeGenericMethod(T1, T2, T3, T4, T5, T6)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With7Params(Type T1, Type T2, Type T3, Type T4, Type T5, Type T6, Type T7, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 7
			)
			.MakeGenericMethod(T1, T2, T3, T4, T5, T6, T7)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With8Params(Type T1, Type T2, Type T3, Type T4, Type T5, Type T6, Type T7, Type T8, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 8
			)
			.MakeGenericMethod(T1, T2, T3, T4, T5, T6, T7, T8)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With9Params(Type T1, Type T2, Type T3, Type T4, Type T5, Type T6, Type T7, Type T8, Type T9, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 9
			)
			.MakeGenericMethod(T1, T2, T3, T4, T5, T6, T7, T8, T9)
			.Invoke(null, new object?[] { collection })
		;
		public static object? Invoke_ToTheoryData_With10Params(Type T1, Type T2, Type T3, Type T4, Type T5, Type T6, Type T7, Type T8, Type T9, Type T10, object collection) =>
			typeof(UtilsForIEnumerable)
			.GetMethods()
			.First
			(
				methodInfo =>
					methodInfo.Name == nameof(UtilsForIEnumerable.ToTheoryData)
					&& methodInfo.GetGenericArguments().Length == 10
			)
			.MakeGenericMethod(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)
			.Invoke(null, new object?[] { collection })
		;

		#endregion


		#region Theory data

		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With2Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = typeof(ValueTuple<,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1));
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1] }
					;

					theoryData.Add(item.TupleTypes.Take(2), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With3Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = typeof(ValueTuple<,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2));
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2] }
					;

					theoryData.Add(item.TupleTypes.Take(3), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With4Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = typeof(ValueTuple<,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3));
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3] }
					;

					theoryData.Add(item.TupleTypes.Take(4), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With5Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = typeof(ValueTuple<,,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3), item.TupleTypes.ElementAt(4));
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);
						collectionItemType.GetField("Item5")!.SetValue(collectionItem, tuple[4]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3], tuple[4] }
					;

					theoryData.Add(item.TupleTypes.Take(5), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With6Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = typeof(ValueTuple<,,,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3), item.TupleTypes.ElementAt(4), item.TupleTypes.ElementAt(5));
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);
						collectionItemType.GetField("Item5")!.SetValue(collectionItem, tuple[4]);
						collectionItemType.GetField("Item6")!.SetValue(collectionItem, tuple[5]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3], tuple[4], tuple[5] }
					;

					theoryData.Add(item.TupleTypes.Take(6), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With7Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type collectionItemType = typeof(ValueTuple<,,,,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3), item.TupleTypes.ElementAt(4), item.TupleTypes.ElementAt(5), item.TupleTypes.ElementAt(6));
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);
						collectionItemType.GetField("Item5")!.SetValue(collectionItem, tuple[4]);
						collectionItemType.GetField("Item6")!.SetValue(collectionItem, tuple[5]);
						collectionItemType.GetField("Item7")!.SetValue(collectionItem, tuple[6]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3], tuple[4], tuple[5], tuple[6] }
					;

					theoryData.Add(item.TupleTypes.Take(7), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With8Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type innerTupleType = typeof(ValueTuple<>).MakeGenericType(item.TupleTypes.ElementAt(7));
					Type collectionItemType = typeof(ValueTuple<,,,,,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3), item.TupleTypes.ElementAt(4), item.TupleTypes.ElementAt(5), item.TupleTypes.ElementAt(6), innerTupleType);
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);
						collectionItemType.GetField("Item5")!.SetValue(collectionItem, tuple[4]);
						collectionItemType.GetField("Item6")!.SetValue(collectionItem, tuple[5]);
						collectionItemType.GetField("Item7")!.SetValue(collectionItem, tuple[6]);

						object collectionItemRest = collectionItemType.GetField("Rest")!.GetValue(collectionItem)!;
						innerTupleType.GetField("Item1")!.SetValue(collectionItemRest, tuple[7]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3], tuple[4], tuple[5], tuple[6], tuple[7] }
					;

					theoryData.Add(item.TupleTypes.Take(8), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With9Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type innerTupleType = typeof(ValueTuple<,>).MakeGenericType(item.TupleTypes.ElementAt(7), item.TupleTypes.ElementAt(8));
					Type collectionItemType = typeof(ValueTuple<,,,,,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3), item.TupleTypes.ElementAt(4), item.TupleTypes.ElementAt(5), item.TupleTypes.ElementAt(6), innerTupleType);
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);
						collectionItemType.GetField("Item5")!.SetValue(collectionItem, tuple[4]);
						collectionItemType.GetField("Item6")!.SetValue(collectionItem, tuple[5]);
						collectionItemType.GetField("Item7")!.SetValue(collectionItem, tuple[6]);

						object collectionItemRest = collectionItemType.GetField("Rest")!.GetValue(collectionItem)!;
						innerTupleType.GetField("Item1")!.SetValue(collectionItemRest, tuple[7]);
						innerTupleType.GetField("Item2")!.SetValue(collectionItemRest, tuple[8]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3], tuple[4], tuple[5], tuple[6], tuple[7], tuple[8] }
					;

					theoryData.Add(item.TupleTypes.Take(9), collection, expectedResult);
				}

				return theoryData;
			}
		}


		public static TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> TheoryDataFor_ToTheoryData_With10Params
		{
			get
			{
				TheoryData<IEnumerable<Type>, object, IEnumerable<object?[]>> theoryData = new();

				foreach (TestsFor_UtilsForIEnumerable.TheoryDataItemFor_ToTheoryData item in TestsFor_UtilsForIEnumerable.TheoryDataItemsFor_ToTheoryData)
				{
					Type innerTupleType = typeof(ValueTuple<,,>).MakeGenericType(item.TupleTypes.ElementAt(7), item.TupleTypes.ElementAt(8), item.TupleTypes.ElementAt(9));
					Type collectionItemType = typeof(ValueTuple<,,,,,,,>).MakeGenericType(item.TupleTypes.ElementAt(0), item.TupleTypes.ElementAt(1), item.TupleTypes.ElementAt(2), item.TupleTypes.ElementAt(3), item.TupleTypes.ElementAt(4), item.TupleTypes.ElementAt(5), item.TupleTypes.ElementAt(6), innerTupleType);
					Type collectionType = typeof(List<>).MakeGenericType(collectionItemType);

					object collection = Activator.CreateInstance(collectionType)!;
					
					object createCollectionItem(ITuple tuple)
					{
						object collectionItem = Activator.CreateInstance(collectionItemType)!;

						collectionItemType.GetField("Item1")!.SetValue(collectionItem, tuple[0]);
						collectionItemType.GetField("Item2")!.SetValue(collectionItem, tuple[1]);
						collectionItemType.GetField("Item3")!.SetValue(collectionItem, tuple[2]);
						collectionItemType.GetField("Item4")!.SetValue(collectionItem, tuple[3]);
						collectionItemType.GetField("Item5")!.SetValue(collectionItem, tuple[4]);
						collectionItemType.GetField("Item6")!.SetValue(collectionItem, tuple[5]);
						collectionItemType.GetField("Item7")!.SetValue(collectionItem, tuple[6]);

						object collectionItemRest = collectionItemType.GetField("Rest")!.GetValue(collectionItem)!;
						innerTupleType.GetField("Item1")!.SetValue(collectionItemRest, tuple[7]);
						innerTupleType.GetField("Item2")!.SetValue(collectionItemRest, tuple[8]);
						innerTupleType.GetField("Item3")!.SetValue(collectionItemRest, tuple[9]);

						return collectionItem;
					}
					
					void addToCollection(object? value) =>
						collectionType.GetMethod("Add")!.Invoke(collection, new object?[] { value })
					;

					foreach (ITuple tuple in item.Tuples)
						addToCollection(createCollectionItem(tuple));

					IEnumerable<object?[]> expectedResult =
						from tuple in ((IEnumerable)collection).Cast<ITuple>()
						select new object?[] { tuple[0], tuple[1], tuple[2], tuple[3], tuple[4], tuple[5], tuple[6], tuple[7], tuple[8], tuple[9] }
					;

					theoryData.Add(item.TupleTypes.Take(10), collection, expectedResult);
				}

				return theoryData;
			}
		}


		#endregion


		#region Tests

		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With2Params))]
		public void ToTheoryData_With2Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1));

			// Act
			returnValue = Invoke_ToTheoryData_With2Params(types.ElementAt(0), types.ElementAt(1), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(2, "Each row should only contain 2 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With3Params))]
		public void ToTheoryData_With3Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2));

			// Act
			returnValue = Invoke_ToTheoryData_With3Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(3, "Each row should only contain 3 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With4Params))]
		public void ToTheoryData_With4Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3));

			// Act
			returnValue = Invoke_ToTheoryData_With4Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(4, "Each row should only contain 4 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With5Params))]
		public void ToTheoryData_With5Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4));

			// Act
			returnValue = Invoke_ToTheoryData_With5Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(5, "Each row should only contain 5 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With6Params))]
		public void ToTheoryData_With6Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5));

			// Act
			returnValue = Invoke_ToTheoryData_With6Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(6, "Each row should only contain 6 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With7Params))]
		public void ToTheoryData_With7Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6));

			// Act
			returnValue = Invoke_ToTheoryData_With7Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(7, "Each row should only contain 7 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With8Params))]
		public void ToTheoryData_With8Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,,,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), types.ElementAt(7));

			// Act
			returnValue = Invoke_ToTheoryData_With8Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), types.ElementAt(7), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(8, "Each row should only contain 8 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With9Params))]
		public void ToTheoryData_With9Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,,,,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), types.ElementAt(7), types.ElementAt(8));

			// Act
			returnValue = Invoke_ToTheoryData_With9Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), types.ElementAt(7), types.ElementAt(8), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(9, "Each row should only contain 9 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		[Theory]
		[MemberData(nameof(TheoryDataFor_ToTheoryData_With10Params))]
		public void ToTheoryData_With10Params_returns_expected_value(IEnumerable<Type> types, object collection, IEnumerable<object?[]> expectedResult)
		{
			// Arrange
			object? returnValue;
			IEnumerable<object[]>? returnValueAsEnumerableOfArrays;
			Type expectedReturnType = typeof(TheoryData<,,,,,,,,,>).MakeGenericType(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), types.ElementAt(7), types.ElementAt(8), types.ElementAt(9));

			// Act
			returnValue = Invoke_ToTheoryData_With10Params(types.ElementAt(0), types.ElementAt(1), types.ElementAt(2), types.ElementAt(3), types.ElementAt(4), types.ElementAt(5), types.ElementAt(6), types.ElementAt(7), types.ElementAt(8), types.ElementAt(9), collection);

			// Assert
			returnValue.Should().BeOfType
			(
				expectedReturnType,
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} with type parameters [{string.Join(", ", from type in types select type.Name)}] should return an instance of type {expectedReturnType.Name}"
			);
			returnValueAsEnumerableOfArrays = returnValue as IEnumerable<object[]>;
			returnValueAsEnumerableOfArrays.Should().NotBeNull
			(
				$"invoking {nameof(UtilsForIEnumerable.ToTheoryData)} should return a value that is convertible to {nameof(IEnumerable<object[]>)}"
			);

			returnValueAsEnumerableOfArrays.Should().AllSatisfy
			(
				theoryDataRow => theoryDataRow.Length.Should().Be(10, "Each row should only contain 10 items")
			);

			returnValueAsEnumerableOfArrays.Should().BeEquivalentTo(expectedResult);
		}


		#endregion
	}
}
