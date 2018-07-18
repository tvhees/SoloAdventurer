using System.Collections.Generic;
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
    
    public void SetData (PlayerData data)
    {
      deck = data.Deck;
      hand = data.Hand;
      discard = data.Discard;
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

    public void DiscardCard ()
    {
      var id = hand[0];
      hand.Remove(id);
      discard.Add(id);
    }
  }

  public class PlayerModelProxy : LuaClassProxy<PlayerModel>
  {
    public PlayerModelProxy(PlayerModel target) : base(target){}

    public override void RegisterToUserData()
    {
      UserData.RegisterProxyType<PlayerModelProxy, PlayerModel>(r => new PlayerModelProxy(r));
    }

    public void DrawCard()
    {
      target.DrawCard();
    }
  }
}