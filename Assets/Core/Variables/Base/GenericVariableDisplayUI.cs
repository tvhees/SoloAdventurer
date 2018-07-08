using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core.Variables
{
  public abstract class GenericVariableDisplayUI<T, U, V> : MonoBehaviour where V : GenericVariableReference<T, U> where U : GenericVariable<T>
  {

    public U reference;
    private TextMeshProUGUI display;
    void Awake()
    {
      display = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
      display.text = reference.name + ": "
        + reference.Value;
    }
  }
}