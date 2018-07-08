using Core.Sets;
using UnityEngine;

namespace Core.Pooling {
  [CreateAssetMenu(menuName="Set/Poolable")]
  public class PoolSet : RuntimeSet<IPoolable> {}
}