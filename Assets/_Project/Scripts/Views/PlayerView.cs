using Core.Extensions;
using SA._Model;
using SA._System;
using UnityEngine;
using System.Linq;
using System;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using SA._Data;
using Core.Utilities;
using GoFunc = System.Func<UnityEngine.GameObject, UnityEngine.GameObject>;

namespace SA._View
{
  public class PlayerView : MonoBehaviour
  {
    public float CardSpacing;
    public bool IsShowingDeckPreview;

    [UnityEngine.Serialization.FormerlySerializedAs("queue")]
    [SerializeField] CommandQueue _queue;
    [SerializeField] PlayerModel _player;
    [SerializeField] CardDatabase _cardDatabase;

    [SerializeField] GameObject _deckView;
    [SerializeField] CardCollectionView _handView;
    [SerializeField] CardCollectionView _inPlayView;
    [SerializeField] CardCollectionView _deckPreviewView;
    [SerializeField] TMP_Text[] _attributeTexts;

    public void HandleDrawCardPressed ()
    {
      _queue.Add(new DrawCardCommand(_player));
    }

    void Update ()
    {
      ShowCards();
      ShowAttributes();
    }

    void ShowCards ()
    {
      _deckView.transform.localScale = new Vector3(1.5f, 2, _player.deck.Count/25f);
      
      _handView.DoForViews(ShowCards(_player.hand, ShowPlayableCard));
      _handView.transform.localPosition = (_player.hand.Count - 1) * CardSpacing/2 * Vector2.right;

      _inPlayView.DoForViews(ShowCards(_player.inPlay, ShowNonPlayableCard));
      _inPlayView.transform.localPosition = (_player.inPlay.Count - 1) * CardSpacing/2 * Vector2.right;

      _deckPreviewView.DoForViews(IsShowingDeckPreview ?
        ShowCards(_player.deck, ShowNonPlayableCard) :
        HideCards());
      _deckPreviewView.transform.localPosition = (_player.deck.Count -1) * CardSpacing/2 * Vector2.right;
    }

    Action<GameObject[]> HideCards ()
    {
      return cardViews => cardViews.DoEach(go => go.SetActive(false));
    }
    
    Action<GameObject[]> ShowCards (List<string> ids, Func<CardData, int, GoFunc> showCard)
    {
      return cardViews => {
        cardViews.DoEach(go => go.SetActive(false));
        ids.Zip(cardViews, (id, view) => new {Data = _cardDatabase.Card(id), View = view})
          .ToList()
          .DoEach((c, i) => showCard(c.Data, i)(c.View));
      };
    }

    GoFunc ShowPlayableCard (CardData data, int index)
    {
      return fp.Reduce(
        SetActive,
        SetTextAsName(data),
        SetLocalPosition(index),
        SetOnClickListener(data, _player)
      );
    }

    GoFunc ShowNonPlayableCard (CardData data, int index)
    {
      return fp.Reduce(
        SetActive,
        SetTextAsName(data),
        SetLocalPosition(index)
      );
    }

    void ShowCard (Tuple<string, GameObject> id_card, int index)
    {
      var go = id_card.Item2;
      var data = _cardDatabase.Card(id_card.Item1);
      go.GetComponentInChildren<TMP_Text>().text = data.Name;
      go.GetComponent<Button>().onClick.RemoveAllListeners();
      go.GetComponent<Button>().onClick.AddListener(() =>
        _queue.Add(new ExecuteLuaCommand(data.effect, "execute",
        new Dictionary<string, object>{
          ["player"] = _player,
          ["card"] = id_card.Item1
        })));
      go.SetActive(true);
      go.transform.localPosition = -1 * index * CardSpacing * Vector2.right;
    }

    GameObject SetActive (GameObject view)
    {
      view.SetActive(true);
      return view;
    }

    GoFunc SetTextAsName (CardData data)
    {
      return view => {
        view.GetComponentInChildren<TMP_Text>().text = data.Name;
        return view;
      };
    }

    GoFunc SetLocalPosition (int index)
    {
      return view => {
        view.transform.localPosition = -1 * index * CardSpacing * Vector2.right;
        return view;
      };
    }

    GoFunc SetOnClickListener (CardData data, PlayerModel player)
    {
      return view => {
        view.GetComponent<Button>().onClick.RemoveAllListeners();
        view.GetComponent<Button>().onClick.AddListener(() =>
          _queue.Add(new ExecuteLuaCommand(data.effect, "execute",
          new Dictionary<string, object>{
            ["player"] = player,
            ["card"] = data.Id
          })));
        return view;
      };
    }

    void ShowAttributes()
    {
      new [] {
          "Movement", _player.movement.ToString(),
          "Attack", _player.attack.ToString(),
          "Block", _player.block.ToString()
        }
        .DoEach((txt, i) => _attributeTexts[i].text = txt);
    }

    public void ShowDeckPreview (bool value)
    {
      IsShowingDeckPreview = value;
    }
  }
}