using MoonSharp.Interpreter;
using UnityEngine;

namespace Core.Utilities
{
  [MoonSharpUserData]
  public class UnityLua
  {
    public void Print (string message)
    {
      Debug.Log(message);
    }
  }
}