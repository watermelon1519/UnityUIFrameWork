using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace SnowFrameWork{

	//封装了事件, 把事件的一些信息作为一个类存下来了
	public class TouchHandle
	{
		private event OnTouchEventHandle eventHandle = null;
		private object[] handleParams;

		public void DestoryHandle()
		{
			if (null != eventHandle) {
				eventHandle -= eventHandle;
				eventHandle = null;
			}
		}

		public void SetEventHandle( OnTouchEventHandle _handle, params object[] _params )
		{
			DestoryHandle ();    //唯一性。。只能对应一个——handle;
			eventHandle += _handle;
			handleParams = _params;
		}

		public TouchHandle( OnTouchEventHandle _handle, params object[] _params)
		{
			SetEventHandle (_handle, _params);
		}
		public TouchHandle()
		{
			
		}

		public void CallEventHandle( GameObject _sender, object _args)
		{
			if (eventHandle != null) {
				eventHandle (_sender, _args, handleParams);
			}
		}
	}

	public class EventTriggerListener : MonoBehaviour,
	IPointerClickHandler,
	IPointerDownHandler,
	IPointerUpHandler,
	IPointerEnterHandler,
	IPointerExitHandler,
	ISelectHandler,
	IUpdateSelectedHandler,
	IDeselectHandler,
	IDragHandler,
	IEndDragHandler,
	IDropHandler,
	IScrollHandler,
	IMoveHandler
	{
//		public event void TouchHandle();
		public TouchHandle onClick;
		public TouchHandle onDoubleClick;
		public TouchHandle onDown;
		public TouchHandle onEnter;
		public TouchHandle onExit;
		public TouchHandle onUp;
		public TouchHandle onSelect;
		public TouchHandle onUpdateSelect;
		public TouchHandle onDeSelect;
		public TouchHandle onDrag;
		public TouchHandle onDragEnd;
		public TouchHandle onDrop;
		public TouchHandle onScroll;
		public TouchHandle onMove;
//

		static public EventTriggerListener Get( GameObject go)
		{
//			EventTriggerListener listener = go.GetComponent<EventTriggerListener> ();
//			if (listener == null)
//				listener = go.AddComponent<EventTriggerListener> ();
//			return listener;
			//return go.GetOrAddComponent<EventTriggerListener>();
			return MethodExtension.GetOrAddComponent<EventTriggerListener> (go);

		}

		void OnDestory()
		{
			RemoveAllHandle ();
		}

		private void RemoveAllHandle()
		{
			RemoveHandle (onClick);			
			RemoveHandle( onDoubleClick );
			RemoveHandle( onDown );
			RemoveHandle( onEnter);
			RemoveHandle( onExit);
			RemoveHandle( onUp);
			RemoveHandle(onSelect);
			RemoveHandle(onUpdateSelect);
			RemoveHandle( onDeSelect );
			RemoveHandle( onDrag );
			RemoveHandle( onDragEnd);
			RemoveHandle( onDrop);
			RemoveHandle( onScroll);
			RemoveHandle( onMove);
		}

		private void RemoveHandle( TouchHandle _handle)
		{
			if (null != _handle) {
				_handle.DestoryHandle ();
				_handle = null;
			}
				
		}

		#region IMoveHandler implementation

		public void OnMove (AxisEventData eventData)
		{
			if (null != onMove) {
				onMove.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IScrollHandler implementation

		public void OnScroll (PointerEventData eventData)
		{
			if (null != onScroll) {
				onScroll.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IDropHandler implementation

		public void OnDrop (PointerEventData eventData)
		{
			if (null != onDrop) {
				onDrop.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IEndDragHandler implementation

		public void OnEndDrag (PointerEventData eventData)
		{
			if (null != onDragEnd) {
				onDragEnd.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IDragHandler implementation

		public void OnDrag (PointerEventData eventData)
		{
			if (null != onDrag) {
				onDrag.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IDeselectHandler implementation

		public void OnDeselect (BaseEventData eventData)
		{
			if (null != onDeSelect) {
				onDeSelect.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IUpdateSelectedHandler implementation

		public void OnUpdateSelected (BaseEventData eventData)
		{
			if (null != onUpdateSelect) {
				onUpdateSelect.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region ISelectHandler implementation

		public void OnSelect (BaseEventData eventData)
		{
			if (null != onSelect) {
				onSelect.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IPointerExitHandler implementation

		public void OnPointerExit (PointerEventData eventData)
		{
			if (null != onExit) {
				onExit.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IPointerEnterHandler implementation

		public void OnPointerEnter (PointerEventData eventData)
		{
			if (null != onEnter) {
				onEnter.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IPointerUpHandler implementation

		public void OnPointerUp (PointerEventData eventData)
		{
			if (null != onUp) {
				onUp.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		#region IPointerDownHandler implementation

		public void OnPointerDown (PointerEventData eventData)
		{
			if (null != onDown) {
				onDown.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion



		#region IPointerClickHandler implementation

		public void OnPointerClick (PointerEventData eventData)
		{
			if (null != onClick) {
				onClick.CallEventHandle (this.gameObject, eventData);
			}
		}

		#endregion

		public void SetEventHandle( EnumTouchEventType _type ,OnTouchEventHandle _handle, params object[] _params)
		{
			switch (_type) {
			case EnumTouchEventType.OnClick:
				if (null == onClick)
					onClick = new TouchHandle ();
				onClick.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.OnDoubleClick:
				if (null == onDoubleClick)
					onDoubleClick = new TouchHandle ();
				onDoubleClick.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onDown:
				if (null == onDown)
					onDown = new TouchHandle ();
				onDown.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onExit:
				if (null == onExit)
					onExit = new TouchHandle ();
				onExit.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onUp:
				if (null == onUp)
					onUp = new TouchHandle ();
				onUp.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onSelect:
				if (null == onSelect)
					onSelect = new TouchHandle ();
				onSelect.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onUpdateSelect:
				if (null == onUpdateSelect)
					onUpdateSelect = new TouchHandle ();
				onUpdateSelect.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onDeSelect:
				if (null == onDeSelect)
					onDeSelect = new TouchHandle ();
				onDeSelect.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onDrag:
				if (null == onDrag)
					onDrag = new TouchHandle ();
				onDrag.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onDragEnd:
				if (null == onDragEnd)
					onDragEnd = new TouchHandle ();
				onDragEnd.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onDrop:
				if (null == onDrop)
					onDrop = new TouchHandle ();
				onDrop.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onScroll:
				if (null == onScroll)
					onScroll = new TouchHandle ();
				onScroll.SetEventHandle (_handle, _params);
				break;
			case EnumTouchEventType.onMove:
				if (null == onMove)
					onMove = new TouchHandle ();
				onMove.SetEventHandle (_handle, _params);
				break;
			default:
				break;
			}
		}

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}


	}

}