using UnityEngine;
using UnityEngine.Events;

namespace Core.Variables
{
  public abstract class GenericVariable<T> : ScriptableObject
  {
//#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
//#endif

    public T Value { get { return _value; } }
    [SerializeField] private T _value;

    public void SetValue(T value)
    {
      _value = value;
    }

    public void SetValue(GenericVariable<T> value)
    {
      SetValue(value.Value);
    }

    public void ApplyChange(T amount)
    {
      SetValue(Value + (dynamic)amount);
    }

    public void ApplyChange(GenericVariable<T> amount)
    {
      ApplyChange(amount.Value);
    }
  }
}