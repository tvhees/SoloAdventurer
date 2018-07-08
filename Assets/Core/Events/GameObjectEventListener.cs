using UnityEngine;
using UnityEngine.Events;

namespace Core.Events {
    [System.Serializable] public class GameObjEvent : UnityEvent<GameObject> {}

    [System.Serializable]
    public class GameObjectEventListener : MonoBehaviour {
        [Tooltip("Event to register with.")]
        public GameObjectEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public GameObjEvent Response;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(GameObject obj) {
            Response.Invoke(obj);
        }
    }
}
