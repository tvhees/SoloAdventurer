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

    public static void Times(this IntReference value, Action<int> action) {
      for(int i = 0; i < value; i++)
      {
        action.Invoke(i);
      }
    }
  }
}