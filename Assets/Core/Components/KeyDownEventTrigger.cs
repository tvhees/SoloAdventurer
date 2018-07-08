using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RoboRyanTron.SearchableEnum;

namespace Core.Components
{
	public class KeyDownEventTrigger : MonoBehaviour
	{
		public string DebugMessage;
		[SearchableEnum]
		public KeyCode[] Keys;
		public UnityEvent Event;

		void Update () {
			for (int i = 0; i < Keys.Length - 1; i++)
			{
				if (!Input.GetKey(Keys[i]))
				{
					return;
				}
			}

			if (Input.GetKeyDown(Keys[Keys.Length -1 ]))
			{
				if (!string.IsNullOrEmpty(DebugMessage))
				{
					Debug.Log(DebugMessage);
				}
				
				Event.Invoke();	
			}
		}
	}
}
