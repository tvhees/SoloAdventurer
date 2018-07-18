using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System.Linq;
using System.IO;
using Core.Utilities;
using System;

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
			var luaRegister = GetComponent<ILuaRegister>();
			if (luaRegister != null)
			{
				luaRegister.RegisterTypesToUserData();
			} else {
				UserData.RegisterAssembly();
			}
			Script script = new Script();
			if (luaRegister != null)
			{
				luaRegister.AddObjectsToScriptGlobals(script);
			}
			script.Globals["unity"] = new UnityLua();
			script.DoString(_scriptDictionary.Script(scriptName));
			DynValue func = script.Globals.Get(funcName);
			script.Call(func);
		}
	}

	public interface ILuaRegister
	{
		void RegisterTypesToUserData ();

		void AddObjectsToScriptGlobals (Script script);
	}
}
