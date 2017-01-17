using System;
using UnityEngine;
using System.Collections.Generic;

namespace SnowFrameWork
{ 
	public class UIManager : Singleton<UIManager>  
	{
		/// <summary>
		/// User interface info data.
		/// </summary>
		class UIInfoData
		{
			/// <summary>
			/// Gets the type of the user interface.
			/// </summary>
			/// <value>The type of the user interface.</value>
			public EnumUIType UIType{ get; private set; }
			public string Path{ get; private set; }
			public object[]  UIparams{ get; private set; }

			UIInfoData( EnumUIType _uiType, string _path, params object[] _uiParams )
			{
				UIType = _uiType;
				Path = _path;
				UIparams = _uiParams;
			}
		}
		/// <summary>
		/// The dic open U is. 当前打开UI的集合
		/// </summary>
		private	Dictionary< EnumUIType, GameObject > dicOpenUIs = null;

		/// <summary>
		/// The stack open U is. 将要打开的UI
		/// </summary>
		private Stack<UIInfoData> stackOpenUIs = null;

		/// <summary>
		/// Init this instance.
		/// 因为父类的构造函数是私有的（protected),所以为了提供初始化方法
		///为其提供了公有的初始化方法 Init()
		/// </summary>
		public override void Init()
		{
			dicOpenUIs = new Dictionary< EnumUIType, GameObject> ();
			stackOpenUIs = new Stack<UIInfoData> ();
		}
			
		public T GetUI<T>( EnumUIType _uiType) where T : BaseUI
		{
			GameObject _retObj = GetUIObject (_uiType); 
			if (_retObj != null)
				return _retObj.GetComponent<T> ();
			return null;
		}

		/// <summary>
		/// Gets the user interface object.
		/// </summary>
		/// <returns>The user interface object.</returns>
		/// <param name="_uiType">User interface type.</param>
		public GameObject GetUIObject (EnumUIType _uiType)
		{
			GameObject _retObj = null;
			if (!dicOpenUIs.TryGetValue (_uiType, _retObj))
				throw new Exception ("_dicOpenUIs TryGetValue Failure! _uiType: " + _uiType.ToString);
			return _retObj;
		}

		public void OpenUI ( bool _isCloseOhter, EnumUIType[] _uiTypes, params ) 
		{
			
		}
    }
}