using UnityEngine.Events;
using Core.Data;

[System.Serializable]
public class EnemyDataEvent : UnityEvent<EnemyCollection> {}

public class EnemyLoader : XmlLoader<EnemyCollection>
{
  public EnemyDataEvent OnLoad = new EnemyDataEvent();

  public void InstantiateAllEntries()
  {
    OnLoad.Invoke(LoadedData);
  }
}