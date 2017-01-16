using System;

namespace SnowFrameWork
{
	#region Global delegate
	/// <summary>
	/// State change event.
	/// </summary>
	public delegate void StateChangeEvent( Object ui, EnumObjectState newState, EnumObjectState oldState);

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
	#endregion

	public class Defines
	{
		public Defines ()
		{
		}
	}
}

