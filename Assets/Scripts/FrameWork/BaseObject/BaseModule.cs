using System;



namespace SnowFrameWork
{
	public class BaseModule  //合并了BaseModel和BaseController，也就是MVC里面的 M和C合并了
	{
		public enum EnumRegisterMode
		{
			NotRegister,
			AutoRegister,
			AlreadyRegister,
		}

		private EnumObjectState state = EnumObjectState.Initial;

		public event StateChangeEvent StateChanged;

		public EnumObjectState State {
			get{ return state;}
			set{
				if (value == state) {
					return;
				}
				else {
					EnumObjectState oldState = state;	
					state = value;
					if (null != StateChanged) {
						StateChanged (this, state, oldState);
					}
					OnStateChanged (state, oldState); //????
				}
			}
		}

		protected virtual void OnStateChanged( EnumObjectState newState, EnumObjectState oldState){
			
		}

		private EnumRegisterMode registerMode = EnumRegisterMode.NotRegister;
		public bool AutoRegister
		{
			get { return registerMode == EnumRegisterMode.NotRegister ? false: true; }
			set{
				if (registerMode == EnumRegisterMode.NotRegister || registerMode == EnumRegisterMode.AutoRegister) {
					registerMode = value ? EnumRegisterMode.AutoRegister : EnumRegisterMode.NotRegister;
				}
			}
		}
		public bool HasRegister
		{
			get{ return registerMode == EnumRegisterMode.AlreadyRegister; }	
		}

		public void Load()
		{
			if( State != EnumObjectState.Initial ) //只能在构造时候使用
			{
				return;
			}
			State = EnumObjectState.Loading;
			//...
			if( registerMode == EnumRegisterMode.AutoRegister){
				//register	
				registerMode = EnumRegisterMode.AlreadyRegister;
			}

			OnLoad ();
			State = EnumObjectState.Ready;
		}
		protected virtual void OnLoad()
		{
			
		}

		public void Release()
		{
			if (State != EnumObjectState.Disabled) {
				State = EnumObjectState.Disabled;
				//...
				if (HasRegister) {
					//unregister
					registerMode = EnumRegisterMode.NotRegister;
				}
				OnRelease();
			}
		}
		protected void OnRelease()
		{
			
		}

		public BaseModule ()
		{
			
		}
	}
}

