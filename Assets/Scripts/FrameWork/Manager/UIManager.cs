using System;
using UnityEngine;
using System.Collections.Generic;

namespace SnowFrameWork
{ 
	public class UIManager : Singleton<UIManager>  
	{
		class UIInfoData
		{
			public EnumUIType UIType{ get; private set; }
			public string Path{ get; private set; }

		}
		/// <summary>
		/// The dic open U is. 当前打开UI的集合
		/// </summary>
		private	Dictionary< EnumUIType, GameObject > dicOpenUIs = null;

		/// <summary>
		/// The stack open U is. 将要打开的UI
		/// </summary>
		private Stack<EnumUIType> stackOpenUIs = null;

		/// <summary>
		/// Init this instance.
		/// 因为父类的构造函数是私有的（protected),所以为了提供初始化方法
		///为其提供了公有的初始化方法 Init()
		/// </summary>
		public override void Init()
		{
			base.Init ();
			Debug.Log ("UIManager : Singleton<UIManager> Init");
		}
    }
}