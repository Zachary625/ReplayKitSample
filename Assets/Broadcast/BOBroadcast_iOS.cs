using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using SimpleJSON;

public class BOBroadcast_iOS : BOBroadcast {
	#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern void BOBroadcastClearError();
	[DllImport("__Internal")]
	private static extern string BOBroadcastGetError();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastAvailable();
	[DllImport("__Internal")]
	private static extern bool BOBroadcasting();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastStreaming();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastSelectService();
	[DllImport("__Internal")]
	private static extern string BOBroadcastURL();
	[DllImport("__Internal")]
	private static extern string BOBroadcastServiceBundleID();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastStart();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastPause();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastResume();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastFinish();
	[DllImport("__Internal")]
	private static extern bool BOBroadcastGetUseCam();
	[DllImport("__Internal")]
	private static extern void BOBroadcastSetUseCam(bool useCam);
	[DllImport("__Internal")]
	private static extern bool BOBroadcastGetUseMic();
	[DllImport("__Internal")]
	private static extern void BOBroadcastSetUseMic(bool useMic);
	[DllImport("__Internal")]
	private static extern void BOBroadcastSetCamViewRect(float x, float y, float width, float height);
	[DllImport("__Internal")]
	private static extern string BOBroadcastGetCamViewRect();
	#endif

	public override bool BroadcastAvailable {
		get
		{ 
			#if UNITY_IOS
			return BOBroadcastAvailable();
			#else
			return false;
			#endif
		}
	}

	public override bool Broadcasting {
		get
		{ 
			#if UNITY_IOS
			return BOBroadcasting();
			#else
			return false;
			#endif
		}
	}

	public override bool BroadcastStreaming {
		get
		{ 
			#if UNITY_IOS
			return BOBroadcastStreaming();
			#else
			return false;
			#endif
		}
	}

	public override bool UseCam {
		get { 
			#if UNITY_IOS
			return BOBroadcastGetUseCam();
			#else
			return false;
			#endif
		}
		set { 
			#if UNITY_IOS
			BOBroadcastSetUseCam(value);
			#endif
		}
	}

	public override bool UseMic {
		get { 
			#if UNITY_IOS
			return BOBroadcastGetUseMic();
			#else
			return false;
			#endif
		}
		set { 
			#if UNITY_IOS
			BOBroadcastSetUseMic(value);
			#endif
		}
	}

	public override Rect? CamViewRect {
		get { 
			#if UNITY_IOS
			string rectJson = BOBroadcastGetCamViewRect();
			if(string.IsNullOrEmpty(rectJson))
			{
				return null;
			}

			JSONNode root = JSON.Parse(rectJson);
			try {
				return new Rect() {
					x = float.Parse(root["x"]),
					y = float.Parse(root["y"]),
					width = float.Parse(root["width"]),
					height = float.Parse(root["height"]),
				};
			}
			catch(System.Exception e)
			{
				return null;
			}

			#else
			return null;
			#endif
		}
		set { 
			if (!value.HasValue) {
				return;
			}
			BOBroadcastSetCamViewRect (value.Value.x, value.Value.y, value.Value.width, value.Value.height);
		}
	}

	public override void BroadcastStart()
	{
		#if UNITY_IOS
		BOBroadcastStart();
		#endif
	}

	public override void BroadcastPause()
	{
		#if UNITY_IOS
		BOBroadcastPause();
		#endif
	}

	public override void BroadcastResume()
	{
		#if UNITY_IOS
		BOBroadcastResume();
		#endif
	}

	public override void BroadcastFinish()
	{
		#if UNITY_IOS
		BOBroadcastFinish();
		#endif
	}

	public override bool SelectService ()
	{
		#if UNITY_IOS
		return BOBroadcastSelectService();
		#else
		return false;
		#endif
	}

	public override string BroadcastURL ()
	{
		#if UNITY_IOS
		return BOBroadcastURL();
		#else
		return null;
		#endif
	}

	public override string ServiceBundleID ()
	{
		#if UNITY_IOS
		return BOBroadcastServiceBundleID();
		#else
		return null;
		#endif
	}

	public override void ClearError()
	{
		#if UNITY_IOS
		BOBroadcastClearError();
		#endif
	}

	public override string GetError()
	{
		#if UNITY_IOS
		return BOBroadcastGetError();
		#else
		return null;
		#endif
	}

}
