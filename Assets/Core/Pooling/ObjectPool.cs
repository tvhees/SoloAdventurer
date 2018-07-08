using Core.Sets;
using Core.Variables;
using UnityEngine;

namespace Core.Pooling {
  public interface IPoolable {
    void SetActive(bool value);
  }

  public interface IPooler<T> {
    T GetItem();
    void ReturnItem(T item);
  }

  // TODO: Move get/return logic to scriptable object
  public class ObjectPool : MonoBehaviour, IPooler<IPoolable> {
    public IntReference InitialCount;
    public GameObject prefab;
    public PoolSet Set;
    public PoolSet Active;

    private GameObject holder;

    void OnEnable()
    {
      holder = new GameObject(prefab.name + " Holder");
      for(int i = 0; i < InitialCount; i++) {
        var go = Instantiate(prefab, holder.transform);
        go.name = prefab.name + " " + i;
        
        var item = go.GetComponent<IPoolable>();
        item.SetActive(false);
        Set.Add(item);
      }
    }

    public IPoolable GetItem ()
    {
      if (Set.Items.Count == 0) return null;

      var item = Set.Items[0];
      Set.Remove(item);
      Active.Add(item);
      item.SetActive(true);
      return item;
    }

    public void ReturnItem (IPoolable item) {
      item.SetActive(false);
      Active.Remove(item);
      Set.Add(item);
    }

    void OnDisable()
    {
        Set.Clear();
        Destroy(holder);
    }
  }
}