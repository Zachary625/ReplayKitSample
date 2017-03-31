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

	public override void ClearError()
	{
		
	}

	public override string GetError()
	{
		return null;
	}
}
