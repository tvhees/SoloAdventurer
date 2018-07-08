using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Components
{
	public class LifecycleEventTrigger : MonoBehaviour
	{
		public UnityEvent onEnable;
		public UnityEvent onAwake;
		public UnityEvent onStart;
		public UnityEvent onDisable;

		void OnEnable () {
			onEnable.Invoke();
		}

		void Awake () {
			onAwake.Invoke();
		}

		void Start () {
			onStart.Invoke();
		}

		void OnDisable () {
			onDisable.Invoke();
		}
	}
}