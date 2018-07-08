using System;
using UnityEngine;

namespace Core.Variables {
  [Serializable]
  [CreateAssetMenu(menuName="Variable/Float")]
  public class FloatVariable : GenericVariable<float> {}
}