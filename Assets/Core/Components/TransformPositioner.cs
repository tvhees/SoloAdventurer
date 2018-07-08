using Core.Variables;
using UnityEngine;

namespace Core.Components
{
  [ExecuteInEditMode]
  public class TransformPositioner : MonoBehaviour
  {
    [SerializeField] private Vector3Reference position;

    void OnEnable()
    {
      if (position != null)
      {
        transform.position = position.Value;
      }
    }

    void Update()
    {
      if (transform.hasChanged)
      {
        if (position != null)
        {
          position.Variable.SetValue(transform.position);
        }
        transform.hasChanged = false;
      }
    }
  }
}