using UnityEngine.Events;
using Core.Data;
using UnityEngine;

namespace SA._Data {
  [System.Serializable]
  public class PlayerDataEvent : UnityEvent<PlayerData> {}

  public class PlayerLoader : MonoBehaviour
  {
    public string File;

    public PlayerDataEvent OnLoad = new PlayerDataEvent();

    void Awake ()
    {
      var data = PlayerData.LoadStreamingAssets(File);
      OnLoad.Invoke(data);
    }
  }
}