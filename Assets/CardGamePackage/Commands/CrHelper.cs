using System.Collections;
using UnityEngine;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Helper class used to run coroutines for non-monobehaviour objects
    /// </summary>
    public class CrHelper : Singleton<CrHelper>
    {
        // Prevent creating additional instances through the empty constructor.
        protected CrHelper(){ }

        public static Coroutine Run(IEnumerator routine)
        {
            return Instance.StartCoroutine(routine);
        }
    }
}