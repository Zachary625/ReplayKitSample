using UnityEngine;
using System.Collections;

public class BOBroadcast_Android : BOBroadcast {
	public override bool BroadcastAvailable {
		get
		{ 
			return false;
		}
	}

	public override bool Broadcasting {
		get {
			return false;
		}
	}

	public override bool BroadcastStreaming {
		get { 
			return false;
		}
	}

	public override BroadcastOption Option {
		get;
		set;
	}

	public override void BroadcastStart ()
	{
	}

	public override void BroadcastFinish()
	{
		
	}

	public override void BroadcastPause()
	{
		
	}

	public override void BroadcastResume()
	{
	}

	public override string BroadcastURL ()
	{
		return null;
	}

	public override bool SelectService ()
	{
		return false;
	}

	public override string ServiceBundleID ()
	{
		return null;
	}
}
