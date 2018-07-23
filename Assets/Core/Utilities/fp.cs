using System;
using System.Linq;

namespace Core.Utilities
{
  public static class fp
  {
    public static Func<T, T> Reduce<T> (Func<T, T> f1, Func<T, T> f2)
		{
			return arg => f2(f1(arg));
		}

    public static Func<T, T> Reduce<T> (params Func<T, T>[] functions)
		{
			return arg => functions.Aggregate((f1, f2) => Reduce(f1, f2))(arg);
		}
  }
}