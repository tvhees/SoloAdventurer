using System.Collections.Generic;
using Core.Extensions;
using MoonSharp.Interpreter;
using SA._Data;
using SA._Lua;
using UnityEngine;


namespace SA._Model
{
  [CreateAssetMenu]
  [System.Serializable]
  public class PlayerModel : ScriptableObject, ILuaClass
  {
    public List<string> deck;
    public List<string> hand;
    public List<string> discard;
    public List<string> inPlay;

    public int attack;
    public int block;
    public int movement;
    
    public void SetData (PlayerData data)
    {
      deck = data.Deck;
      hand = data.Hand;
      discard = data.Discard;

      attack = 0;
      block = 0;
      movement = 0;
    }

    public void RegisterToUserData ()
    {
      UserData.RegisterProxyType<PlayerModelProxy, PlayerModel>(r => new PlayerModelProxy(r));
    }

    public void AddToScriptGlobals (Script script)
    {
      var playerLua = UserData.Create(this);
      script.Globals.Set("player", playerLua);
    }

    public void DrawCard ()
    {
      var id = deck[0];
      deck.Remove(id);
      hand.Add(id);
    }

    public void DiscardCard (string id)
    {
      hand.Remove(id);
      discard.Add(id);
    }

    public void PlayCard (string id)
    {
      hand.Remove(id);
      inPlay.Add(id);
    }

    public class PlayerModelProxy : LuaClassProxy<PlayerModel>
    {
      public PlayerModelProxy(PlayerModel target) : base(target){}

      public override void RegisterToUserData()
      {
        UserData.RegisterProxyType<PlayerModelProxy, PlayerModel>(r => new PlayerModelProxy(r));
      }

      public void DrawCards (int n = 1)
      {
        n.Times(DrawCard);
      }

      public void DrawCard (int n)
      {
        target.DrawCard();
      }

      public void DrawCard (string id)
      {
        target.deck.Remove(id);
        target.hand.Add(id);
      }

      public void PlayCard (string id)
      {
        target.hand.Remove(id);
        target.inPlay.Add(id);
      }

      public void AddAttack (int n = 1)
      {
        target.attack += n;
      }

      public void AddBlock (int n = 1)
      {
        target.block += n;
      }

      public void AddMovement (int n = 1)
      {
        target.movement += n;
      }
    }
  }
}