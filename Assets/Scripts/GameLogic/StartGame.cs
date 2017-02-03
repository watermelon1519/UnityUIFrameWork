using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SnowFrameWork;
using System;

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
		RegisterAllModules();
		UIManager.Instance.OpenUI (EnumUIType.TestOne);
//
//		float tm = System.Environment.TickCount;
//		for (int i = 0; i < 10000; i++) {
//			GameObject go = null;
//
//			//plan1 
////			go = Instantiate (Resources.Load<GameObject> ("Prefabs/Cube"));
////			go.transform.position = UnityEngine.Random.insideUnitSphere * 10;
//
//			// plan 2
//			//go = ResManager.Instance.LoadInstance( "Prefabs/Cube" ) as GameObject;
//			//go.transform.position = UnityEngine.Random.insideUnitSphere * 10;
//
//			//plan3 
//			//GameObject go = new GameObject();
////			ResManager.Instance.LoadAsyncInstance ("Prefabs/Cube", (_obj) => {
////				go = _obj as GameObject; 
////				go.transform.position = UnityEngine.Random.insideUnitSphere * 10;
////			});
//
//			//plan4
//			ResManager.Instance.LoadCoroutineInstance("Prefabs/Cube", (_obj) => {
//				go = _obj as GameObject; 
//				go.transform.position = UnityEngine.Random.insideUnitSphere * 10;
//			});
//
//		}
//		Debug.Log("Times:" + ( System.Environment.TickCount - tm ) * 1000);

		StartCoroutine (AutoUpdateGold ());
	}

	private void RegisterAllModules()
	{
//		TestOneModule testOneModule = new TestOneModule ();
//		testOneModule.Load ();
		LoadModule( typeof(TestOneModule) );
		//....
	}
	private void LoadModule( Type moduleType ) 
	{
		BaseModule bm = System.Activator.CreateInstance (moduleType) as BaseModule;
		bm.Load ();
	}

	//simulate server message
	private IEnumerator AutoUpdateGold()
	{
		int gold = 0;
		while (true) {
			gold++;
			yield return new WaitForSeconds(1.0f);
			//MessageCenter.Instance.SendMessage (MessageType.Net_MessageTestOne, this, null, gold);
			Message message = new Message (MessageType.Net_MessageTestOne, this);
			message ["gold"] = gold;
			message.Send ();
		}
	}
}
