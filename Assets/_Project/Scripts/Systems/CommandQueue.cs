using Core.Sets;
using UnityEngine;

namespace SA._System
{
  [CreateAssetMenu(menuName = "Command Queue")]
  public class CommandQueue : RuntimeSet<ICommand>
  {
  }
}