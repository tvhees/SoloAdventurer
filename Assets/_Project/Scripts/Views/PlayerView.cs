using Core.Extensions;
using SA._Model;
using SA._System;
using UnityEngine;
using System.Linq;
using System;
using TMPro;
using UnityEngine.UI;

namespace SA._View
{
  public class PlayerView : MonoBehaviour
  {
    public float CardSpacing;
    [UnityEngine.Serialization.FormerlySerializedAs("queue")]
    [SerializeField] CommandQueue _queue;
    [SerializeField] PlayerModel _player;
    [SerializeField] CardDatabase _cardDatabase;

    [SerializeField] Transform _deckTransform;
    [SerializeField] Transform _handTransform;
    [SerializeField] GameObject[] _handCardTransforms;

    public void HandleDrawCardPressed ()
    {
      _queue.Add(new DrawCardCommand(_player));
    }

    public void HandleDiscardCardPressed ()
    {
      _queue.Add(new DiscardCardCommand(_player));
    }

    void Update ()
    {
      _deckTransform.localScale = new Vector3(1.5f, 2, _player.deck.Count/25f);
      _handCardTransforms.DoEach(t => t.SetActive(false));
      _player.hand.Zip(_handCardTransforms, Tuple.Create)
        .ToList()
        .DoEach(ShowCard);
      _handTransform.localPosition = (_player.hand.Count - 1) * CardSpacing/2 * Vector2.right;
    }

    void ShowCard(Tuple<string, GameObject> id_card, int index)
    {
      var go = id_card.Item2;
      var data = _cardDatabase.Card(id_card.Item1);
      go.GetComponentInChildren<TMP_Text>().text = data.Name;
      go.GetComponent<Button>().onClick.RemoveAllListeners();
      go.GetComponent<Button>().onClick.AddListener(() => _queue.Add(new ExecuteLuaCommand(data.effect)));
      go.SetActive(true);
      go.transform.localPosition = -1 * index * CardSpacing * Vector2.right;
    }
  }
}