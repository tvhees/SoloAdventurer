using System;
using UnityEngine;

namespace Core.Variables {
  [Serializable]
  [CreateAssetMenu(menuName="Variable/Vector3")]
  public class Vector3Variable : GenericVariable<Vector3> {}
}