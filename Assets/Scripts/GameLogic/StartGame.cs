using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SnowFrameWork;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//ResManager.Instance.Test ();
		//UIManager.Instance;


//        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefebs/TestOne"));
//
//        TestOne tt = go.GetComponent<TestOne>();
//        if (null == tt)
//        {
//            tt = go.AddComponent<TestOne>();
//        }

		UIManager.Instance.OpenUI (EnumUIType.TestOne);
    }

}
