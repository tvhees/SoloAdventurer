using UnityEngine.Events;
using Core.Data;

[System.Serializable]
public class CardDataEvent : UnityEvent<CardCollection> {}

public class CardLoader : XmlLoader<CardCollection>
{
  public CardDataEvent OnLoad = new CardDataEvent();

  public void InstantiateAllEntries()
  {
    OnLoad.Invoke(LoadedData);
  }
}