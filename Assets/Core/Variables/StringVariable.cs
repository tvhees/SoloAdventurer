using System;
using UnityEngine;

namespace Core.Variables {
  [Serializable]
  [CreateAssetMenu(menuName="Variable/String")]
  public class StringVariable : GenericVariable<string> {}
}