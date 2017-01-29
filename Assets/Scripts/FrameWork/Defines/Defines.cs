using System;
using UnityEngine;

namespace SnowFrameWork
{
	#region Global delegate
	/// <summary>
	/// State change event.
	/// </summary>
	public delegate void StateChangeEvent( object ui, EnumObjectState newState, EnumObjectState oldState);

	public delegate void MessageEvent(Message msg);

	public delegate void OnTouchEventHandle( GameObject sender , object _args, params object[] _params);  //object _param1 , object _param2

	#endregion


	#region 全局枚举对象 Global enum

	/// <summary>
	/// Enum object state.
	/// </summary>
	public enum EnumObjectState
	{
		None,
		Initial,
		Loading,   
		Ready,
		Disabled,
		Closing
	}
	/// <summary>
	/// Enum user interface type.
	/// </summary>
	public enum EnumUIType:int
	{
		None = -1,
		TestOne = 0,
		TestTwo = 1,
	}

	public enum EnumTouchEventType
	{
		OnClick,
		OnDoubleClick,		
		onDown,
		onExit,
		onUp,
		onSelect,
		onUpdateSelect,
		onDeSelect,
		onDrag,
		onDragEnd,
		onDrop,
		onScroll,
		onMove,
	}
	#endregion

	public class UIPathDefines
	{
		/// <summary>
		/// UI预设
		/// </summary>
		public const string UI_PREFAB = "Prefabs/";

		/// <summary>
		/// UI小控件预设
		/// </summary>
		public const string UI_CONTROLS_PREFAB = "Prefabs/Control/";

		/// <summary>
		/// UI子页面预设
		/// </summary>
		public const string UI_SUBUI_PREFAB = "Prefabs/SubUI/";

		/// <summary>
		/// icon路径
		/// </summary>
		public const string UI_ICON_PATH = "UI/Icon/";

		public static string GetPrefabsPathByType( EnumUIType _uiType )
		{
			string _path = string.Empty;
			switch (_uiType ){
			case EnumUIType.TestOne:
				_path = UI_PREFAB + "TestOne";
				break;
			case EnumUIType.TestTwo:
				_path = UI_PREFAB + "TestTwo";
				break;
			default:
				Debug.Log ("Not Find EnumUIType! type:" + _uiType.ToString() );
				break;
			}
			return _path;
		}

		public static System.Type GetUIScriptByType( EnumUIType _uiType)
		{
			System.Type _scriptType = null;
			switch (_uiType) {

			case EnumUIType.TestOne:
				_scriptType = typeof(TestOne);
				break;
			case EnumUIType.TestTwo:
				_scriptType = typeof(TestTwo);
				break;
			default:
				Debug.Log ("Not Find EnumUIType! type:" + _uiType.ToString ());
				break;

			}
			return _scriptType;
		}

	}
	public class Defines
	{
		public Defines ()
		{
		}
	}
}

