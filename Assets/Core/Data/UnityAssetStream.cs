using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

namespace Core.Data
{
  public class UnityAssetStream : FileStream
  {
    public UnityAssetStream(string fileName, FileMode mode = FileMode.Open)
      : base(Path.Combine(Application.streamingAssetsPath, fileName), mode){}

    public UnityAssetStream(string[] paths, FileMode mode = FileMode.Open)
      : base(StreamingAssetsPath(paths), mode) {}

    static string StreamingAssetsPath(string[] paths)
    {
      var p = new List<string>(){Application.streamingAssetsPath};
      p.AddRange(paths);
      return Path.Combine(p.ToArray());
    }
  }
}