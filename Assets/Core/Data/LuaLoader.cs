using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System.Linq;
using System.IO;
using Core.Utilities;

namespace Core.Data
{
	public class LuaLoader : MonoBehaviour {
		public enum SourceFolder {Resources, StreamingAssets};

    [SerializeField]
		private SourceFolder _source;

    [SerializeField]
    private LuaDictionary _scriptDictionary;

		void Awake() {
			var scripts = new  Dictionary<string, string>();
			object[] result = {};
			if (_source == SourceFolder.Resources)
			{
				// When loading from the resources folder
				// .lua files need to be saved as .lua.txt
				// and read as TextAsset types.
				result = Resources.LoadAll("Lua", typeof(TextAsset));
				foreach(TextAsset textAsset in result.OfType<TextAsset>())
				{
					scripts.Add(textAsset.name, textAsset.text);
				}
			} else {
				// When loading from streaming assets
				// the WWW class is required for Android compatibility
				var dirInfo = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, "Lua"));
				foreach(var file in dirInfo.GetFiles("*.lua"))
				{
					WWW www = new WWW("file://" + file.FullName);
        	while(!www.isDone) {}
        	scripts.Add(Path.GetFileNameWithoutExtension(file.Name), www.text);
				}
			}

			Script.DefaultOptions.ScriptLoader = new MoonSharp.Interpreter.Loaders.UnityAssetsScriptLoader(scripts);
      _scriptDictionary.SetData(scripts);
		}
	}
}
