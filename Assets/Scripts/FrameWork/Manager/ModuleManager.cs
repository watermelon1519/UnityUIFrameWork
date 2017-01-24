using System;
using System.Collections.Generic;

namespace SnowFrameWork
{
	//dic, register典型的中介模式啊！！！
	public class ModuleManager : Singleton<ModuleManager>
	{
//		class UIInfoData
//		{
//			
//		}

		private Dictionary<string, BaseModule> dicModules = null;

		public override void Init ()
		{
			dicModules = new Dictionary<string, BaseModule> ();
		}

		#region Get Module
		public BaseModule Get(string key)
		{
			if (dicModules.ContainsKey (key))
				return dicModules [key];
	
			return null;
		}
		public T Get<T>() where T : BaseModule
		{
			Type t = typeof(T);
			//return Get (t.ToString ()) as T;
			if (dicModules.ContainsKey (t.ToString ()))
				return dicModules [t.ToString ()] as T;
			
			return null;
		}
		#endregion
		#region Register module by module type
		public void Register( BaseModule module)
		{
			Type t = module.GetType ();  //反射机制
			Register (t.ToString (), module);
		}

		public void Register(string key, BaseModule module)
		{
			if (!dicModules.ContainsKey (key)) {
				dicModules.Add (key, module);
			}
		}
		#endregion
		#region unregister module
		public void UnRegister( BaseModule module)
		{
			Type t = module.GetType ();
			UnRegister (t.ToString ());
		}
		/// <summary>
		/// Uns the register.
		/// </summary>
		/// <param name="key">Key.</param>
		public void UnRegister( string key)
		{
			if( dicModules.ContainsKey(key))
			{
				BaseModule module = dicModules [key];
				module.Release ();
				dicModules.Remove (key);
				module = null;
			}
		}
		public void UnRegisterAll()
		{
			List<string> _keyList = new List<string> (dicModules.Keys);

			foreach (string key in _keyList) {
				BaseModule module = dicModules [key];
				UnRegister (module);
			}
			dicModules.Clear ();
		}
		#endregion
	}
}

