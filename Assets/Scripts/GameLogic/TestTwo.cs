using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SnowFrameWork;

public class TestTwo : BaseUI {

    private Button btn;

	#region implemented abstract members of BaseUI
	public override EnumUIType GetUIType()
	{
		return EnumUIType.TestTwo;
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
		UIManager.Instance.OpenUI(EnumUIType.TestOne);
//        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefebs/TestOne"));
//        TestOne tt = go.GetComponent<TestOne>();
//        if (null == tt)
//        {
//            tt = go.AddComponent<TestOne>();
//        }
		UIManager.Instance.CloseUI (EnumUIType.TestTwo);
    }
    private void Close()
    {
        Destroy(gameObject);
    }
}
