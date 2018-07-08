using UnityEngine;

namespace Core.Extensions
{
  public static class VectorExtensions {
    public static Vector2 RotateByDegrees(this Vector2 vec, float rotation)
    {
      var radians = rotation * Mathf.Deg2Rad;
      return VectorExtensions.RotateByRadians(vec, radians);
    }

    public static Vector2 RotateByRadians(this Vector2 vec, float rotation)
    {
      var _x = vec.x*Mathf.Cos(rotation) - vec.y*Mathf.Sin(rotation);
      var _y = vec.x*Mathf.Sin(rotation) + vec.y*Mathf.Cos(rotation);
      return new Vector2(_x,_y);
    }
  }
}