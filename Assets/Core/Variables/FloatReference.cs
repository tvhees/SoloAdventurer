using System;

namespace Core.Variables {
  [Serializable]
  public class FloatReference : GenericVariableReference<float, FloatVariable> {
    public override FloatVariable Variable {get {return _variable;} set {_variable = value;}}
    public FloatVariable _variable;
  }
}