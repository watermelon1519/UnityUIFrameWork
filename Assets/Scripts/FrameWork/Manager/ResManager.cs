using System;
using UnityEngine;

namespace SnowFrameWork
{
	public class ResManager: Singleton<ResManager>
	{
		public override void Init ()
		{
			//base.Init ();
			Debug.Log ("ResManager : Singleton<ResManager> Init");
		}
		public void Test()
		{
			Debug.Log ("ResManager : Singleton<ResManager> test");
		}
	}
}

