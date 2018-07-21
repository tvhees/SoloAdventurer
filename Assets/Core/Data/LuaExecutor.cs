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

		private ILuaRegister _luaRegister;

		void Start ()
		{
			_luaRegister = GetComponent<ILuaRegister>();
			if (_luaRegister == null)
			{
				UserData.RegisterAssembly();
			}
		}

		public void DescribeScript(string scriptName)
		{
			RunScript(scriptName, "describe");
		}

		public void RunScript(string scriptName, string funcName)
		{
			Script script = new Script();

			if (_luaRegister != null)
			{
				_luaRegister.AddObjectsToScriptGlobals(script);
			}
			
			script.DoString(_scriptDictionary.Script(scriptName));
			DynValue func = script.Globals.Get(funcName);
			script.Call(func);
		}

		public void RunScript(string scriptName, string funcName, Dictionary<string, object> args)
		{
			Script script = new Script();

			if (_luaRegister != null)
			{
				_luaRegister.AddObjectsToScriptGlobals(script);
			}
			
			script.DoString(_scriptDictionary.Script(scriptName));
			DynValue func = script.Globals.Get(funcName);
			script.Call(func, args);
		}
	}

	public interface ILuaRegister
	{
		void RegisterTypesToUserData ();

		void AddObjectsToScriptGlobals (Script script);
	}
}
