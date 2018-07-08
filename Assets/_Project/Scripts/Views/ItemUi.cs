
using UnityEngine;
using TMPro;

[RequireComponent(typeof(ItemId), typeof(TMP_Text))]
public class ItemUi : MonoBehaviour
{
  void Awake ()
  {
    GetComponent<TMP_Text>().text = GetComponent<ItemId>().value;
  }
}