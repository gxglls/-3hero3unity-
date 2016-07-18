using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ICode.FSMEditor{
	public static class ListExtensions
	{
		
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>
			(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> knownKeys = new HashSet<TKey>();
			foreach (TSource element in source)
			{
				if (knownKeys.Add(keySelector(element)))
				{
					yield return element;
				}
			}
		}
		
		public static IEnumerable<TKey> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
		{
			return source.GroupBy(selector).Select(x => x.Key);
		}
		
		public static void Move(this IList list, int iIndexToMove, int direction)
		{
			//up
			if (direction == 1 && iIndexToMove >0)
			{
				
				var old = list[iIndexToMove - 1];
				list[iIndexToMove -1] = list[iIndexToMove];
				list[iIndexToMove] = old;
			}
			else if(direction != 1 && iIndexToMove<list.Count-1)
			{
				var old = list[iIndexToMove + 1];
				list[iIndexToMove + 1] = list[iIndexToMove];
				list[iIndexToMove] = old;
			}
		}
		
		public static void MoveTo(this IList list, int oldIndex, int newIndex)
		{
			if (list.Count > oldIndex && oldIndex>-1) {
				var item = list [oldIndex];
				list.RemoveAt (oldIndex);
				list.Insert (newIndex, item);
			}
		}
		
		public static void Swap(this IList list,int firstIndex,int secondIndex) {
			if (list != null && firstIndex >= 0 &&
			    firstIndex < list.Count && secondIndex >= 0 &&
			    secondIndex < list.Count) {
				
				if (firstIndex == secondIndex) {
					return;
				}
				var temp = list [firstIndex];
				list [firstIndex] = list [secondIndex];
				list [secondIndex] = temp;
			}
		}
	}
}
