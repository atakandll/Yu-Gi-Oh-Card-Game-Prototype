using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Extensions
{
    public static class ListExtensions
    {
        public static T RandomItem<T>(this List<T> list)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("List is Empty");

            var randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }
    }
}