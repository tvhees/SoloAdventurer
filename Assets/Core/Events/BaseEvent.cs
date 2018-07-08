using UnityEngine;

namespace Core.Events {
  public abstract class BaseEvent : ScriptableObject
  {
    public abstract void Raise();
  }
}