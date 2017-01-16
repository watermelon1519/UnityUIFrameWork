using System;
using UnityEngine;

namespace SnowFrameWork
{ 
	public class UIManager : Singleton<UIManager>  
	{
		public override void Init()
		{
			base.Init ();
			Debug.Log ("UIManager : Singleton<UIManager> Init");
		}
    }
}