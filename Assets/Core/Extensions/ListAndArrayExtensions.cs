using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

namespace Core.Extensions
{
  public static class ListAndArrayExtensions {
    public static T GetRandom<T>(this List<T> items, int start = 0, int end = 0)
    {
      if (end == 0) end = items.Count;
      var index = Random.Range(start, end);
      return items[index];
    }

    public static T GetRandom<T>(this T[] items, int start = 0, int end = 0)
    {
      if (end == 0) end = items.Length;
      var index = Random.Range(start, end);
      return items[index];
    }

    public static T RemoveRandom<T>(this List<T> items, int start = 0, int end = 0)
    {
      var item = items.GetRandom(start, end);
      items.Remove(item);
      return item;
    }

    public static IEnumerable<T> DoEach<T>(this IEnumerable<T> items, Action<T> action)
    {
      foreach (var item in items)
      {
        action.Invoke(item);
      }

      return items;
    }

    public static List<T> DoEach<T>(this List<T> items, Action<T> action)
    {
      if (items != null)
      {
        var count = items.Count;
        for (int i = 0; i < count; i++)
        {
          action.Invoke(items[i]);
        }
      }
      else {
        Debug.LogWarningFormat("Trying to DoEach<{0}> on a null list", typeof(T));
      }
      return items;
    }

    public static T[] DoEach<T>(this T[] items, Action<T> action)
    {
      if (items != null)
      {
        var count = items.Length;
        for (int i = 0; i < count; i++)
        {
          action.Invoke(items[i]);
        }
      }
      else {
        Debug.LogWarningFormat("Trying to DoEach<{0}> on a null array", typeof(T));
      }
      return items;
    }

    public static T[] DoEach<T>(this T[] items, Action<T, int> action)
    {
      if (items != null)
      {
        var count = items.Length;
        for (int i = 0; i < count; i++)
        {
          action.Invoke(items[i], i);
        }
      }
      else {
        Debug.LogWarningFormat("Trying to DoEach<{0}> on a null array", typeof(T));
      }
      return items;
    }

    public static T[,] DoEach<T>(this T[,] items, Action<T> action)
    {
      var iCount = items.GetLength(0);
      var jCount = items.GetLength(1);
      for (int i = 0; i < iCount; i++)
      {
        for(int j = 0; j < jCount; j++)
        {
          action.Invoke(items[i,j]);
        }
      }
      return items;
    }

    public static List<T> ToList<T>(this T[,] items)
    {
      var list = new List<T>();
      items.DoEach(i => list.Add(i));
      return list;
    }

    public static T[] ToArray<T>(this T[,] items)
    {
      var array = new T[items.Length];
      var count = 0;
      
      items.DoEach(i => {
        array[count] = i;
        count++;
      });

      return array;
    }

    public static T Repeat<T>(this T[] items, int index)
    {
      return items[(int)Mathf.Repeat(index, items.Length)];
    }

    public static T Repeat<T>(this List<T> items, int index)
    {
      return items[(int)Mathf.Repeat(index, items.Count)];
    }
  }
}