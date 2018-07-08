using System;

namespace Core.Variables {
  [Serializable]
  public class StringReference : GenericVariableReference<string, StringVariable> {
    public override StringVariable Variable {get {return _variable;} set {_variable = value;}}
    public StringVariable _variable;
  }
}