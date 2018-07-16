using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
  [CreateAssetMenu]
  public class LuaDictionary : ScriptableObject
  {
    private Dictionary<string, string> scripts;

    public void SetData (Dictionary<string, string> data)
    {
      scripts = data;
    }

    public string Script (string id)
    {
      return scripts[id];
    }
  }
}