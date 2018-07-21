using System.Collections;
using System.Collections.Generic;
using Core.Data;
using SA._Model;
using UnityEngine;

namespace SA._System
{
  public class CommandSystem : MonoBehaviour
  {
    public CommandQueue _queue;
    bool _isRunning;

    void Update ()
    {
      if (!_isRunning && _queue.Count > 0)
      {
        _isRunning = true;
        StartCoroutine(ExecuteCommandCoroutine());
      }
    }

    IEnumerator ExecuteCommandCoroutine ()
    {
      var cmd = _queue[0];
      cmd.Execute(this);
      _queue.Remove(cmd);
      if (_queue.Count == 0)
      {
        _isRunning = false;
      }

      yield return null;
    }
  }

  public interface ICommand
  {
    bool Execute(CommandSystem system);
  }

  public class DrawCardCommand : ICommand
  {
    PlayerModel _player;

    public DrawCardCommand (PlayerModel player)
    {
      _player = player;
    }

    public bool Execute (CommandSystem system)
    {
      _player.DrawCard();
      return true;
    }
  }

  public class ExecuteLuaCommand : ICommand
  {
    string _script;
    string _function;
    Dictionary<string, object> _args;

    public ExecuteLuaCommand (string script, string function = "describe", Dictionary<string, object> args = null)
    {
      _script = script;
      _function = function;
      _args = args;
    }

    public bool Execute (CommandSystem system)
    {
      system.GetComponent<LuaExecutor>().RunScript(_script, _function, _args);
      return true;
    }
  }

  public class DiscardCardCommand : ICommand
  {
    PlayerModel _player;
    string id;

    public DiscardCardCommand (PlayerModel player, string id)
    {
      _player = player;
    }

    public bool Execute (CommandSystem system)
    {
      _player.DiscardCard(id);
      return true;
    }
  }

  public class DebugMessageCommand : ICommand
  {
    public bool Execute(CommandSystem system)
    {
      Debug.Log("Debug command activated");
      return true;
    }
  }
}