using System;
using UnityEngine;

namespace Core.Variables {
  [Serializable]
  public class Vector3Reference : GenericVariableReference<Vector3, Vector3Variable> {
    public override Vector3Variable Variable {get {return _variable;} set {_variable = value;}}
    [SerializeField] private Vector3Variable _variable;
  }
}