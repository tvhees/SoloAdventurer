using System;

namespace Core.Variables {
  [Serializable]
  public abstract class GenericVariableReference<T, U> where U : GenericVariable<T> {
    public bool UseConstant = true;
    public T ConstantValue;
    abstract public U Variable {get; set;}

    public GenericVariableReference() {}

    public GenericVariableReference(T value) {
      UseConstant = true;
      ConstantValue = value;
    }

    public T Value {
      get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator T(GenericVariableReference<T, U> reference) {
      return reference.Value;
    }
  }
}