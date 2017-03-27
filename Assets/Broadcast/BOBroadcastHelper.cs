using UnityEngine;
using System.Collections;

public class BOBroadcastHelper : BOBroadcast {

	private bool broadcasting = false;
	private bool broadcastStreaming = false;

	public override bool BroadcastAvailable {
		get
		{ 
			return true;
		}
	}

	public override bool Broadcasting {
		get
		{ 
			return broadcasting;
		}
	}

	public override bool BroadcastStreaming {
		get
		{ 
			return broadcastStreaming;
		}
	}

	private BroadcastOption _Option = new BroadcastOption();

	public override BroadcastOption Option {
		get {
			return _Option;
		}
		set {
			_Option = value;
		}
	}

	public override void BroadcastStart()
	{
		broadcasting = true;
		broadcastStreaming = true;
	}

	public override void BroadcastPause()
	{
		if (broadcasting)
		{
			broadcastStreaming = false;
		}
	}

	public override void BroadcastResume()
	{
		if (broadcasting)
		{
			broadcastStreaming = true;
		}
	}

	public override void BroadcastFinish()
	{
		broadcasting = false;
		broadcastStreaming = false;
	}
}
