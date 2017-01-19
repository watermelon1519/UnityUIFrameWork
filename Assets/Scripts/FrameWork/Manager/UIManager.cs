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
		public void OpenUI( EnumUIType[] _uiTypes )
		{
			OpenUI (false, _uiTypes, null);
		}
		public void OpenUI( EnumUIType _uiType , params object[] _uiParams)
		{
			EnumUIType[] _uiTypes = new EnumUIType[1];
			_uiTypes [0] = _uiType;
			OpenUI (false, _uiTypes, _uiParams);
		}
		public void OpenUICloseOthers( EnumUIType[] _uiTypes )
		{
			OpenUI (true, _uiTypes, null);
		}
		public void OpenUICloseOthers( EnumUIType _uiType , params object[] _uiParams )
		{
			EnumUIType[] _uiTypes = new EnumUIType[1];
			_uiTypes [0] = _uiType;
			OpenUI (true, _uiTypes, _uiParams);
		}
		/// <summary>
		/// Opens the U.
		/// </summary>
		/// <param name="_isCloseOther">If set to <c>true</c> is close other.</param>
		/// <param name="_uiTypes">User interface types.</param>
		/// <param name="_uiParams">User interface parameters.</param>
		public void OpenUI ( bool _isCloseOther, EnumUIType[] _uiTypes, params object[] _uiParams) 
		{
			// Close Others UI
			if (_isCloseOther) {
				CloseUIAll ();	
			}

			// Push _uiTypes
			for (int i = 0; i < _uiTypes.Length; i++) {
				EnumUIType _uiType = _uiTypes [i];
				if( !dicOpenUIs.ContainsKey(_uiType ))
				{
					string _path = UIPathDefines.GetPrefabsPathByType(_uiType);
					stackOpenUIs.Push (new UIInfoData (_uiType, _path, _uiParams));
				}
			}
				
			if (stackOpenUIs.Count > 0) {
				CoroutineController.Instance.StartCoroutine (AsyncLoadData ());	
			}
		}

		// load UI Async
		private IEnumerator<int> AsyncLoadData()
		{
			UIInfoData _uiInfoData = null;
			UnityEngine.Object _prefabObj = null;
			GameObject _uiObject = null;
			if (stackOpenUIs != null && stackOpenUIs.Count > 0) {
				do {
					_uiInfoData = stackOpenUIs.Pop ();

					_prefabObj = Resources.Load (_uiInfoData.Path);
					if (_prefabObj != null) {
						_uiObject = MonoBehaviour.Instantiate (_prefabObj) as GameObject;
						BaseUI _baseUI = _uiObject.GetComponent< BaseUI> ();
						if (null != _baseUI) {
							_baseUI.SetUIWhenOpening (_uiInfoData.UIparams);
						}
						dicOpenUIs.Add (_uiInfoData.UIType, _uiObject);
					}

				} while(stackOpenUIs.Count > 0);
			}
			yield return 0;

		}

		public void CloseUIAll()
		{
			List<EnumUIType> _listKey = new List<EnumUIType> (dicOpenUIs.Keys) ;
//			for (int i = 0; i < _listKey.Count; i++) {
//				CloseUI (_listKey [i]);
//			}
			CloseUI (_listKey.ToArray ());
			dicOpenUIs.Clear ();
		}

		public void CloseUI( EnumUIType[] _uiTypes)
		{
			for (int i = 0; i < _uiTypes.Length ; i++) {
				CloseUI (_uiTypes [i]);
			}
		}
		/// <summary>
		/// Closes the U.
		/// </summary>
		/// <param name="_uiType">User interface type.</param>
		public void CloseUI(EnumUIType _uiType)
		{
			GameObject _uiObj = GetUIObject (_uiType);
			if (null == _uiObj) {
				dicOpenUIs.Remove (_uiType);
			} else {
				BaseUI _baseUI = _uiObj.GetComponent<BaseUI> ();
				if (null == _baseUI) {
					GameObject.Destroy (_uiObj);
					dicOpenUIs.Remove (_uiType);
				} else {
					_baseUI.StateChanged += CloseUIHandle;
					_baseUI.Release ();
				}
			}
		}

		/// <summary>
		/// Closes the user interface handle.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="newState">New state.</param>
		/// <param name="oldState">Old state.</param>
		private void CloseUIHandle( object sender, EnumObjectState newState, EnumObjectState oldState)
		{
			if (newState == EnumObjectState.Closing) {
				BaseUI _baseUI = sender as BaseUI;
				dicOpenUIs.Remove (_baseUI.GetUIType ());
				_baseUI.StateChanged -= CloseUIHandle;
			}
		}
    }
}