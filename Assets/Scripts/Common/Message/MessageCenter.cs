using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnowFrameWork
{
	public class MessageCenter : Singleton<MessageCenter>
	{
		// 事件需要优先级、循环发送，有响应事件时候，可以对MessageEvent进行封装，List就有用了，目前List没用
		private Dictionary<string , List<MessageEvent>> dicMessageEvents = null;

		public override void Init()
		{
			dicMessageEvents = new Dictionary< string , List<MessageEvent>> ();
		}

		#region Add & Remove Listener

		public void AddListener( MessageType messageType, MessageEvent messageEvent)
		{
			AddListener (messageType.ToString (), messageEvent);
		}
		public void RemoveListener( MessageType messageType, MessageEvent messageEvent)
		{
			RemoveListener (messageType.ToString (), messageEvent);
		}

		public void AddListener( string messageName, MessageEvent messageEvent )
		{
			List<MessageEvent> list = null;
			if (dicMessageEvents.ContainsKey(messageName)) {
				list = dicMessageEvents [messageName];
			} else {
				list = new List<MessageEvent> ();
				dicMessageEvents.Add (messageName, list);
			}
			if (!list.Contains (messageEvent)) {
				list.Add (messageEvent);
			}
		}
		public void RemoveListener( string messageName , MessageEvent messageEvent)
		{
			if (dicMessageEvents.ContainsKey (messageName)) {
				List<MessageEvent> list = dicMessageEvents [messageName];
				if( list.Contains(messageEvent)) {
					list.Remove(messageEvent);
				}
				if(list.Count<=0)
				{
					dicMessageEvents.Remove(messageName);				
				}
			}
		}

		public void RemoveAllListener()
		{
			dicMessageEvents.Clear ();
		}
		#endregion

		#region SendMessage()

		public void SendMessage( MessageType messageType, object sender)
		{
			SendMessage( new Message( messageType.ToString(), sender) );
		}
		public void SendMessage( MessageType messageType, object sender, object content)
		{
			SendMessage( new Message( messageType.ToString(), sender , content) );
		}
		public void SendMessage( MessageType messageType, object sender, object content, params object[] dicParams)
		{
			SendMessage( new Message( messageType.ToString(), sender, content, dicParams) );
		}

		public void SendMessage( Message message)
		{
			DoMessageDispatcher (message);
		}

		public void SendMessage( string name, object sender)
		{
			SendMessage (new Message (name, sender));
		}

		public void SendMessage( string name, object sender, object content)
		{
			SendMessage (new Message (name, sender,content));
		}

		public void SendMessage( string name, object sender, object content, params object[] dicParams)
		{
			SendMessage (new Message (name, sender,content,dicParams));
		}

		private void DoMessageDispatcher( Message message )
		{
		//	Debug.Log ("DoMessageDispatcher Name: " + message.Name);
			if (dicMessageEvents == null || !dicMessageEvents.ContainsKey(message.Name) )
				return;
			List<MessageEvent> list = dicMessageEvents [message.Name];
			for (int i = 0; i < list.Count; i++) {
				MessageEvent messageEvent = list [i];
				if (messageEvent != null) {
					messageEvent (message);
				}
			}
		}
		#endregion
	}
}

