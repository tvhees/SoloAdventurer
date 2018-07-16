using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System.Linq;
using System.IO;
using SA._Lua;

namespace Core.Utilities
{
	public class LuaExecutor : MonoBehaviour {
		public enum Src {Resources, StreamingAssets};
		public Src Source;

		private Dictionary<string, string> scripts;

		void Awake() {
			scripts = new  Dictionary<string, string>();
			object[] result = {};
			if (Source == Src.Resources)
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
		}

		public void RunScript(string scriptName)
		{
			UserData.RegisterAssembly();

      Debug.LogFormat("Running script '{0}'", scriptName);

			Script script = new Script();
			// TODO: Extract this function from the Core
			script.Globals["unity"] = new UnityLua();
			script.DoString(scripts[scriptName]);
			DynValue msgFunc = script.Globals.Get("debugString");
			script.Call(msgFunc);
		}
	}
}
