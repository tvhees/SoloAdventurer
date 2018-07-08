using System;
using UnityEngine;

namespace Core.Variables {
  [Serializable]
  public class GameObjectReference : GenericVariableReference<GameObject, GameObjectVariable> {
    public override GameObjectVariable Variable {get {return _variable;} set {_variable = value;}}
    public GameObjectVariable _variable;
  }
}