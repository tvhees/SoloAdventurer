using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Container")]
public class Container : ScriptableObject
{
  public int Count;
  Dictionary<string, Object> aspects;

  public void RegisterAspect (Object aspect) {
    aspects.Add(aspect.name, aspect);
    Count = aspects.Count;
  }

  public void DeregisterAspect (Object aspect) {
    aspects.Remove(aspect.name);
    Count = aspects.Count;
  }

  public Object this[string key]
  {
    get { return aspects[key]; }
  }
}