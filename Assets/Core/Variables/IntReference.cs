using System;

namespace Core.Variables {
  [Serializable]
  public class IntReference : GenericVariableReference<int, IntVariable> {
    public override IntVariable Variable {get {return _variable;} set {_variable = value;}}
    public IntVariable _variable;
  }
}