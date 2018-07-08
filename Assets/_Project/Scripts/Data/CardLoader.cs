using UnityEngine.Events;
using Core.Data;

[System.Serializable]
public class CardDataEvent : UnityEvent<CardCollection> {}

public class CardLoader : XmlLoader<CardCollection>
{
  public CardDataEvent OnLoad = new CardDataEvent();

  void Awake ()
  {
    LoadData();
    OnLoad.Invoke(LoadedData);
  }
}