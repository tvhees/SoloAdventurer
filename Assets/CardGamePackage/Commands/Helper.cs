using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Helper class used to run coroutines for non-monobehaviour objects
    /// </summary>
    public class Helper : Singleton<Helper>
    {
        // Prevent creating additional instances through the empty constructor.
        protected Helper(){ }

        public static UnityEvent OnTurnEnded = new UnityEvent();

        public static Coroutine Run(IEnumerator routine)
        {
            return Instance.StartCoroutine(routine);
        }
    }
}