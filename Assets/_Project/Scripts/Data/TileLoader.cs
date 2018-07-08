using UnityEngine.Events;
using Core.Data;

[System.Serializable]
public class TileDataEvent : UnityEvent<TileCollection> {}

public class TileLoader : XmlLoader<TileCollection>
{
  public TileDataEvent OnLoad = new TileDataEvent();

  public void InstantiateAllEntries()
  {
    OnLoad.Invoke(LoadedData);
  }
}