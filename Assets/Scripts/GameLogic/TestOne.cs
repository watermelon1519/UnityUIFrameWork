using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SnowFrameWork;


public class TestOne : BaseUI {

    private Button btn;

	#region implemented abstract members of BaseUI
	public override EnumUIType GetUIType()
	{
		return EnumUIType.TestOne;
	}
	#endregion

	// Use this for initialization
	void Start () {
        btn = transform.Find("Panel/Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
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
		UIManager.Instance.OpenUI(EnumUIType.TestTwo);
		UIManager.Instance.CloseUI (EnumUIType.TestOne);
    }
    private void Close()
    {
        Destroy(gameObject);
    }
}
