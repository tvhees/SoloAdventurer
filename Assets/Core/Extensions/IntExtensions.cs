using System;
using Core.Variables;

namespace Core.Extensions
{
  public static class IntExtensions {
    public static void Times(this int value, Action<int> action) {
      for(int i = 0; i < value; i++)
      {
        action.Invoke(i);
      }
    }

    public static void Times(this int value, Action action) {
      for(int i = 0; i < value; i++)
      {
        action.Invoke();
      }
    }

    public static void Times(this IntReference value, Action<int> action) {
      for(int i = 0; i < value; i++)
      {
        action.Invoke(i);
      }
    }

    public static T[] Times<T>(this int value, Func<int, T> action) {
      var result = new T[value];
      
      for(int i = 0; i < value; i++)
      {
        result[i] = action.Invoke(i);
      }

      return result;
    }

    public static T[] Times<T>(this int value, Func<T> action) {
      var result = new T[value];
      
      for(int i = 0; i < value; i++)
      {
        result[i] = action.Invoke();
      }

      return result;
    }    
  }
}