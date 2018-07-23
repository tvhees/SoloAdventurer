using UnityEngine;

namespace Core.Extensions
{
  public static class GameObjectExtensions
  {
    public static GameObject Clone (this GameObject prefab)
    {
      var clone = GameObject.Instantiate(prefab);
      return clone;
    }
  }
}