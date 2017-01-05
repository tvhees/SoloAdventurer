using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension {

    /// <summary>
    /// Randomises an array in place.
    /// </summary>
    public static void Shuffle<T>(this T[] original){
        for (var i = 0; i < original.Length; i++) {
            var temp = original [i];
            var randomIndex = Random.Range (i, original.Length);
            original [i] = original [randomIndex];
            original [randomIndex] = temp;
        }
    }

    /// <summary>
    /// Randomises a List in place.
    /// </summary>
    public static void Shuffle<T>(this List<T> original){
        for (var i = 0; i < original.Count; i++) {
            var temp = original [i];
            var randomIndex = Random.Range (i, original.Count);
            original [i] = original [randomIndex];
            original [randomIndex] = temp;
        }
    }

    public static void SafeRemove<T>(this List<T> param, T input)
    {
        if (param.Contains(input))
            param.Remove(input);
    }

    public static void SafeAdd<T>(this List<T> param, T input)
    {
        if (param.Contains(input))
            return;

        param.Add(input);
    }

    public static bool IsEmpty(this ICollection param)
    {
        return param.Count == 0;
    }
}