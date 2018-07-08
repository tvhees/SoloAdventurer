using System.Collections.Generic;
using UnityEngine;

namespace Core.Events {
  [CreateAssetMenu(menuName = "Event/GameObject Event")]
  public class GameObjectEvent : BaseEvent {

    [SerializeField] private GameObject gameObject;

    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    [SerializeField]
    private List<GameObjectEventListener> eventListeners = 
      new List<GameObjectEventListener>();

    public override void Raise() {
      for(int i = eventListeners.Count -1; i >= 0; i--)
        eventListeners[i].OnEventRaised(gameObject);
    }

    public void Raise(GameObject obj) {
      for(int i = eventListeners.Count -1; i >= 0; i--)
        eventListeners[i].OnEventRaised(obj);
    }

    public void RegisterListener(GameObjectEventListener listener) {
      if (!eventListeners.Contains(listener))
        eventListeners.Add(listener);
    }

    public void UnregisterListener(GameObjectEventListener listener) {
      if (eventListeners.Contains(listener))
        eventListeners.Remove(listener);
    }
  }
}
