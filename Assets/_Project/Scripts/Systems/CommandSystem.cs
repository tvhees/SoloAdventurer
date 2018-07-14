using System.Collections;
using System.Collections.Generic;
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
      cmd.Execute();
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
    bool Execute();
  }

  public class DrawCardCommand : ICommand
  {
    PlayerModel _player;

    public DrawCardCommand (PlayerModel player)
    {
      _player = player;
    }

    public bool Execute ()
    {
      _player.DrawCard();
      return true;
    }
  }

  public class DiscardCardCommand : ICommand
  {
    PlayerModel _player;

    public DiscardCardCommand (PlayerModel player)
    {
      _player = player;
    }

    public bool Execute ()
    {
      _player.DiscardCard();
      return true;
    }
  }

  public class DebugMessageCommand : ICommand
  {
    public bool Execute()
    {
      Debug.Log("Debug command activated");
      return true;
    }
  }
}