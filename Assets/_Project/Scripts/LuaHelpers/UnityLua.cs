using MoonSharp.Interpreter;
using UnityEngine;

namespace SA._Lua
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