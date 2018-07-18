using Core.Data;
using Core.Utilities;
using MoonSharp.Interpreter;
using SA._Model;
using UnityEngine;

namespace SA._Lua
{
  public class LuaRegister : MonoBehaviour, ILuaRegister
  {
    [SerializeField]
    private PlayerModel _playerModel;

    void Awake ()
    {
      RegisterTypesToUserData();
    }

    public void RegisterTypesToUserData()
    {
      UserData.RegisterType<UnityLua>();
      _playerModel.RegisterToUserData();
    }
    
    public void AddObjectsToScriptGlobals (Script script)
    {
      var unity = UserData.Create(new UnityLua());
      script.Globals.Set("unity", unity);

      _playerModel.AddToScriptGlobals(script);
    }
  }

  public interface ILuaClass
  {
    void RegisterToUserData ();
    void AddToScriptGlobals (Script script);
  }

  public abstract class LuaClassProxy<T> where T : class
  {
    protected T target;

    [MoonSharpHidden]
    public LuaClassProxy (T target)
    {
      this.target = target;
    }

    public abstract void RegisterToUserData ();
  }
}