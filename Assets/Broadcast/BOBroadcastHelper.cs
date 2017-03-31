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

	public override bool UseCam {
		get {
			return false;
		}
		set { 
			
		}
	}

	public override bool UseMic {
		get {
			return false;
		}
		set {
			
		}
	}

	public override Rect? CamViewRect {
		get {
			return null;
		}
		set {
			
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

	public override void ClearError()
	{

	}

	public override string GetError()
	{
		return null;
	}
}
