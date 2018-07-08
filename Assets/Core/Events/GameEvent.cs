using System.Collections.Generic;
using UnityEngine;

namespace Core.Events {
  [CreateAssetMenu(menuName = "Event/Game Event")]
  public class GameEvent : BaseEvent {

    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    [SerializeField]
    private List<GameEventListener> eventListeners = 
      new List<GameEventListener>();

    public override void Raise() {
      for(int i = eventListeners.Count -1; i >= 0; i--)
        eventListeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener) {
      if (!eventListeners.Contains(listener))
        eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) {
      if (eventListeners.Contains(listener))
        eventListeners.Remove(listener);
    }
  }
}
