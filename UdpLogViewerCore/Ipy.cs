using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Scripting.Hosting;
using System.Text;

namespace stej.Tools.UdpLogViewer.Core
{
	public class Ipy
	{
		static readonly object _lock = new object();
		static ScriptEngine _engine;
		static ScriptRuntime _runtime;

		static ScriptEngine Engine
		{
			get
			{
				if (_engine == null)
				{
					lock (_lock)
					{
						if (_engine == null)
						{
							_runtime = IronPython.Hosting.Python.CreateRuntime();
							_engine = _runtime.GetEngine("IronPython");

							_engine.SetSearchPaths(new string[]
							                       	{
							                       		AppDomain.CurrentDomain.BaseDirectory, 
							                       		Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lib"),
							                       		Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Lib")
							                       	});
							Array.ForEach(AppDomain.CurrentDomain.GetAssemblies(), a => _runtime.LoadAssembly(a));
						}
					}
				}

				return _engine;
			}
		}

		public static void ExecuteScript(string s, Dictionary<string, object> values = null, ScriptScope scope = null)
		{
			if (scope == null)
				scope = CreateScope(values);
			Engine.Execute(s, scope);
		}

		public static void ExecuteFile(string[] files, Dictionary<string, object> values = null, ScriptScope scope = null)
		{
			if (scope == null)
				scope = CreateScope(values);
			foreach (var file in files)
			{
				if (!File.Exists(file))
					throw new FileNotFoundException("IronPython file can not be found.", file);
				ScriptSource src = Engine.CreateScriptSourceFromFile(file, Encoding.UTF8);
				src.Compile().Execute(scope);
				//Engine.ExecuteFile(file, scope);
			}
		}

		public static ScriptScope CreateScope(Dictionary<string, object> values = null)
		{
			ScriptScope scope = Engine.Runtime.CreateScope();
			if (values == null)
				return scope;

			foreach (KeyValuePair<string, object> par in values)
				scope.SetVariable(par.Key, par.Value);
			return scope;
		}

	}

}
