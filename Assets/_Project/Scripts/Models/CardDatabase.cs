using System;
using System.Collections.Generic;
using System.Linq;
using SA._Data;
using UnityEngine;

namespace SA._Model
{
  [CreateAssetMenu]
  [System.Serializable]
  public class CardDatabase : ScriptableObject
  {
    public List<CardData> cards;
    
    public void SetData (CardCollection data)
    {
      cards = data.Cards;
    }

    public CardData Card (string id) => cards.Single(HasId(id));

    Func<string, Func<CardData, bool>> HasId = id => card => card.Id == id;
  }
}