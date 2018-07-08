using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Variables;

namespace Core.Components
{
  [ExecuteInEditMode]
  public class TransformScaler : MonoBehaviour
  {
    public Vector3Reference scale;

    void OnEnable()
    {
      if (scale != null)
      {
        transform.position = scale.Value;
      }
    }

    void Update()
    {
      if (transform.hasChanged)
      {
        if (scale != null)
        {
          scale.Variable.SetValue(transform.position);
        }
        transform.hasChanged = false;
      }
    }
  }
}
