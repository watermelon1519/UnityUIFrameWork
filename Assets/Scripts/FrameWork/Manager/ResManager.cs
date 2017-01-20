using System;
using UnityEngine;
using System.Collections.Generic;

namespace SnowFrameWork
{
	public class ResManager: Singleton<ResManager>
	{
		private Dictionary<string , GameObject> dicAssetInfo = null;

		public override void Init ()
		{
			//base.Init ();
			Debug.Log ("ResManager : Singleton<ResManager> Init");
			//Resources.Load ();
			//Resources.LoadAsync ();
		}

		public GameObject LoadInstance(string _path)
		{
			
		}

		public void LoadInstance( string _path, Action<GameObject> _loaded )
		{
			LoadInstance (_path, _loaded, null);
		}

		public void LoadInstance(string _path, Action<UnityEngine.Object> _loaded, Action<float> progress)
		{
			Load( _path, (_obj) => {
				UnityEngine.Object _retObj = null;
				if(null != _obj )
				{
					_retObj = MonoBehaviour.Instantiate(_obj);
					if( null != _retObj)
					{
						if( null != _loaded)
							_loaded(_retObj);
						else
							Debug.LogError("Error: null _loaded");
					}
					else{
						Debug.LogError("Error: null Instantiate _retObj.");
					}
				}
				else{
					Debug.LogError("Error: null Resources Load return _obj.");
				}

			}, progress);
		}

		public UnityEngine.Object Load( string _path )
		{
			Load (_path, null,null);
		}

		public void Load( string _path , Action<UnityEngine.Object> _loaded)
		{
			Load( _path, _loaded, null );
			return null;
		}

		public void Load( string _path, Action<UnityEngine.Object> _loaded,  Action<float> _progress)
		{
			if( string.IsNullOrEmpty(_path ) )
			{
				Debug.LogError("Error: null _path name.");
				if( null != _loaded )
					_loaded(null);
			}
			// Load Res.... 

		}
	}
}

