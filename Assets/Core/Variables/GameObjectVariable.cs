using System;
using UnityEngine;

namespace Core.Variables {
  [Serializable]
  [CreateAssetMenu(menuName="Variable/Game Object")]
  public class GameObjectVariable : GenericVariable<GameObject> {}
}