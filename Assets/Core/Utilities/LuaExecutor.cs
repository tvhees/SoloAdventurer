using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System.Linq;
using System.IO;
using Core.Utilities;

namespace Core.Data
{
	public class LuaExecutor : MonoBehaviour {

    [SerializeField]
    private LuaDictionary _scriptDictionary;

		public void DescribeScript(string scriptName)
		{
			RunScript(scriptName, "describe");
		}

		public void RunScript(string scriptName, string funcName)
		{
			UserData.RegisterAssembly();

      Debug.LogFormat("Running script '{0}'", scriptName);
			Debug.Log(_scriptDictionary.Script(scriptName));

			Script script = new Script();
			script.Globals["unity"] = new UnityLua();
			script.DoString(_scriptDictionary.Script(scriptName));
			DynValue func = script.Globals.Get(funcName);
			script.Call(func);
		}
	}
}
