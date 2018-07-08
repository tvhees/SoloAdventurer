using System.Collections.Generic;
using UnityEngine;

namespace Core.Sets
{
  public abstract class RuntimeSet<T> : ScriptableObject
  {
    public List<T> Items = new List<T>();

    public T this[int i]
    {
      get { return Items[i];}
    }

    public void Add(T item)
    {
      if (!Items.Contains(item))
        Items.Add(item);
    }

    public void Remove(T item)
    {
      if (Items.Contains(item))
        Items.Remove(item);
    }

    public void Clear()
    {
      Items.Clear();
    }
  }
}