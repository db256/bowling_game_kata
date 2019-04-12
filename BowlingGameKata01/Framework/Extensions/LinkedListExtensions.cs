using System.Collections.Generic;

namespace BowlingGameKata01.Framework.Extensions
{
	public static class LinkedListExtensions
	{
		public static IEnumerable<LinkedListNode<T>> ToNodes<T>(this LinkedList<T> linkedList)
		{
			var current = linkedList.First;
			yield return current;
			while (current.Next != null)
			{
				yield return current.Next;
				current = current.Next;
			}
		}
	}
}