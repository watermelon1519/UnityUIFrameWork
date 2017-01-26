using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SnowFrameWork;


public class TestOne : BaseUI {

    private Button btn;
	private Text text;

	#region implemented abstract members of BaseUI
	public override EnumUIType GetUIType()
	{
		return EnumUIType.TestOne;
	}
	#endregion

	// Use this for initialization
	void Start () {
//        btn = transform.Find("Panel/Button").GetComponent<Button>();
//        btn.onClick.AddListener(OnClickBtn);
		text = transform.Find("Panel/Text").GetComponent<Text>();

		//EventTriggerListener.Get (transform.Find ("Panel/Button").gameObject).SetEventHandle (EnumTouchEventType.OnClick, Close);

		EventTriggerListener listener = EventTriggerListener.Get (transform.Find ("Panel/Button").gameObject);
		listener.SetEventHandle (EnumTouchEventType.OnClick, Close, 1, "1234");

	}

	protected override void OnAwake ()
	{
		MessageCenter.Instance.AddListener ("AutoUpdateGold", UpdateGold);
		//MessageCenter.Instance.AddListener ("AutoUpdateGold", UpdateGold);
		base.OnAwake ();
	}
	protected override void OnRelease()
	{
		MessageCenter.Instance.RemoveListener ("AutoUpdateGold", UpdateGold);
		base.OnRelease ();
	}
	private void UpdateGold(Message msg)
	{
		int gold = (int)msg ["gold"] ;
		Debug.Log ("TestOne UpdateGold:"+ gold);
		text.text = "Gold: " + gold.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnClickBtn()
    {
//        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefebs/TestTwo"));
//        TestTwo tt = go.GetComponent<TestTwo>();
//        if (null == tt)
//        {
//            tt = go.AddComponent<TestTwo>();
//        }
//		UIManager.Instance.OpenUI(EnumUIType.TestTwo);
//		UIManager.Instance.CloseUI (EnumUIType.TestOne);
    }
//    private void Close()
//    {
//        Destroy(gameObject);
//    }

	private void Close(GameObject sender , object _args, params object[] _params)
	{
		int i =  (int)_params[0];
		string s = (string)_params [1];
		Debug.Log (i);
		Debug.Log (s);
		UIManager.Instance.OpenUICloseOthers (EnumUIType.TestTwo );
	}
}
