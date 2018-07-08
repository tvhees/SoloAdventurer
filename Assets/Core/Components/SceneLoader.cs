using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Components
{
    public class SceneLoader : MonoBehaviour {
    private Func<AsyncOperation> loadFunction;
    
    public void ForceLoadScene(string name)
    {
      LoadScene(name, LoadSceneMode.Single, true);
    }

    public void LoadScene(string name)
    {
      LoadScene(name, LoadSceneMode.Single);
    }

    public void LoadSceneAdditive(string name)
    {
      LoadScene(name, LoadSceneMode.Additive);
    }

    void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single, bool force = false)
    {
      if (SceneManager.GetSceneByName(name).IsValid() && !force) return;

      loadFunction = () => SceneManager.LoadSceneAsync(name, mode);
      StartCoroutine(LoadSceneRoutine());
    }

    IEnumerator LoadSceneRoutine()
    {
      var loading = loadFunction.Invoke();
      while (!loading.isDone) yield return null;
    }
  }
}