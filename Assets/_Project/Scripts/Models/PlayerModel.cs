using System.Collections.Generic;
using SA._Data;
using UnityEngine;

namespace SA._Model
{
  [CreateAssetMenu]
  [System.Serializable]
  public class PlayerModel : ScriptableObject
  {
    public List<string> deck;
    public List<string> hand;
    public List<string> discard;
    
    public void SetData (PlayerData data)
    {
      deck = data.Deck;
      hand = data.Hand;
      discard = data.Discard;
    }

    public void DrawCard ()
    {
      var id = deck[0];
      deck.Remove(id);
      hand.Add(id);
    }

    public void DiscardCard ()
    {
      var id = hand[0];
      hand.Remove(id);
      discard.Add(id);
    }
  }
}