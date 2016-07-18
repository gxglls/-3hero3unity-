using System.Collections.Generic;

namespace ICode{
	public static class ArrayUtility
	{
		public static T[] Add<T>(T[] array, T item)
		{
			return (new List<T>(array)
			        {
				item
			}).ToArray();
		}
		
		public static T[] AddRange<T>(T[] array, T[] items)
		{
			List<T> ts = new List<T>(array);
			ts.AddRange(items);
			return ts.ToArray();
		}
		
		public static T[] Copy<T>(T[] array)
		{
			return (new List<T>(array)).ToArray();
		}
		
		public static T[] MoveItem<T>(T[] array, int oldIndex, int newIndex)
		{
			List<T> ts = new List<T>(array);
			T item = ts[oldIndex];
			ts.RemoveAt(oldIndex);
			ts.Insert(newIndex, item);
			return ts.ToArray();
		}
		
		public static T[] Remove<T>(T[] array, T item)
		{
			List<T> ts = new List<T>(array);
			ts.Remove(item);
			return ts.ToArray();
		}

		public static T[] RemoveAt<T>(T[] array, int index)
		{
			List<T> ts = new List<T>(array);
			ts.RemoveAt (index);
			return ts.ToArray();
		}

		public static T[] Insert<T>(T[] array, T item, int index)
		{
			List<T> ts = new List<T>(array);
			ts.Insert (index,item);
			return ts.ToArray();
		}


		public static T[] Sort<T>(T[] array)
		{
			List<T> ts = new List<T>(array);
			ts.Sort();
			return ts.ToArray();
		}

		public static T[] Sort<T>(T[] array,IComparer<T> comparer)
		{
			List<T> ts = new List<T> (array);
			ts.Sort(comparer);
			return ts.ToArray();
		}

		public static T[] Reverse<T>(T[] array)
		{
			List<T> ts = new List<T>(array);
			ts.Reverse ();
			return ts.ToArray();
		}
	}
}