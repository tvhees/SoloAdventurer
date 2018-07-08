using Core.Variables;
using TMPro;
using UnityEngine;

namespace Core.Components
{
  [RequireComponent(typeof(TMP_Text))]
  public class TextUpdater : MonoBehaviour
  {
    private TMP_Text textComponent;

    void OnEnable () {
      textComponent = GetComponent<TMP_Text>();
    }

    public void UpdateText(StringVariable text) {
      textComponent.text = text.Value;
    }
  }
}