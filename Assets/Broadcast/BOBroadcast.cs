using UnityEngine;
using System.Collections;

public abstract class BOBroadcast
{

	private static BOBroadcast m_Broadcast = null;

	public static BOBroadcast Instance
	{
		get
		{ 
			if (m_Broadcast == null) {
				#if(UNITY_IOS && !UNITY_EDITOR)
				m_Broadcast = new BOBroadcast_iOS();
				#elif(UNITY_ANDROID && !UNITY_EDITOR)
				m_Broadcast = new BOBroadcast_Android();
				#elif(UNITY_STANDALONE || UNITY_EDITOR)
				m_Broadcast = new BOBroadcastHelper();
				#else
				m_Broadcast = null;
				#endif
			}
			return m_Broadcast;
		}
	}

	// Is broadcast function available?
	public static bool Available
	{
		get
		{
			return Instance != null && Instance.BroadcastAvailable;
		}
	}

	// Is broadcast function available on this platform?
	public abstract bool BroadcastAvailable
	{
		get;
	}

	// Changes with broadcast start and finish
	public abstract bool Broadcasting
	{
		get;
	}

	// Changes with broadcast start, finish, pause, resume
	public abstract bool BroadcastStreaming
	{
		get;
	}

	public abstract bool UseCam {
		get;
		set;
	}

	public abstract bool UseMic {
		get;
		set;
	}

	public abstract Rect? CamViewRect {
		get;
		set;
	}

	public abstract void ClearError();
	public abstract string GetError();
	public abstract void BroadcastStart();
	public abstract void BroadcastPause();
	public abstract void BroadcastResume();
	public abstract void BroadcastFinish();
	public abstract string BroadcastURL();
	public abstract string ServiceBundleID ();
	public abstract bool SelectService();

}
