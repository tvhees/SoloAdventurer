using UnityEngine.Events;
using Core.Data;
using UnityEngine;

namespace SA._Data {
  [System.Serializable]
  public class CardDataEvent : UnityEvent<CardCollection> {}

  public class CardLoader : MonoBehaviour
  {
    public string File;

    public CardDataEvent OnLoad = new CardDataEvent();

    void Awake ()
    {
      var data = CardCollection.LoadStreamingAssets(File);
      OnLoad.Invoke(data);
    }
  }
}