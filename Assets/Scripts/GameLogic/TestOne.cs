using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestOne : MonoBehaviour {

    private Button btn;
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
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefebs/TestTwo"));
        TestTwo tt = go.GetComponent<TestTwo>();
        if (null == tt)
        {
            tt = go.AddComponent<TestTwo>();
        }
        Close();
    }
    private void Close()
    {
        Destroy(gameObject);
    }
}
