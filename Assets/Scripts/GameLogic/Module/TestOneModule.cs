using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnowFrameWork;


public class TestOneModule : BaseModule {

	public int Gold{ get; private set;}

	public TestOneModule()
	{
		this.AutoRegister = true;
		Gold = 0;
	}
	protected override void OnLoad()
	{
		MessageCenter.Instance.AddListener (MessageType.Net_MessageTestOne, UpdateGold);
		base.OnLoad ();
	}
	protected override void OnRelease()
	{
		MessageCenter.Instance.RemoveListener (MessageType.Net_MessageTestOne, UpdateGold);
		base.OnRelease ();
	}
	
	private void UpdateGold( Message msg)
	{
		int gold = (int)msg ["gold"];
		if (gold >= 0) {
			Gold = gold;
			Message message = new Message ("AutoUpdateGold", this);
			message ["gold"] = gold;
			message.Send ();
		}
	}
}
