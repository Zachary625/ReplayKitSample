using UnityEngine;
using System.Collections;

public class BOBroadcastCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BOBroadcast_OnServicesLoaded()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnServicesLoaded(): " + BOBroadcast.Instance.GetError());
	}

	public void BOBroadcast_OnServiceSelected()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnServiceSelected(): " + BOBroadcast.Instance.GetError());
	}

	private int _originalSleepTimeout = SleepTimeout.SystemSetting;

	public void BOBroadcast_OnStarted()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnStarted(): " + BOBroadcast.Instance.GetError());
		if (Screen.sleepTimeout != SleepTimeout.NeverSleep) {
			_originalSleepTimeout = Screen.sleepTimeout;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}
	}

	public void BOBroadcast_OnFinished()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnFinished(): " + BOBroadcast.Instance.GetError());
		if (Screen.sleepTimeout == SleepTimeout.NeverSleep) {
			Screen.sleepTimeout = _originalSleepTimeout;
			_originalSleepTimeout = SleepTimeout.SystemSetting;
		}
	}

	void OnApplicationQuit() {
		if (Screen.sleepTimeout == SleepTimeout.NeverSleep) {
			Screen.sleepTimeout = _originalSleepTimeout;
			_originalSleepTimeout = SleepTimeout.SystemSetting;
		}
	}

	void OnApplicationPause(bool paused) {
		if (paused) {
			if (Screen.sleepTimeout == SleepTimeout.NeverSleep) {
				Screen.sleepTimeout = _originalSleepTimeout;
				_originalSleepTimeout = SleepTimeout.SystemSetting;
			}
		} else {
			if (Screen.sleepTimeout != SleepTimeout.NeverSleep) {
				_originalSleepTimeout = Screen.sleepTimeout;
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
			}
		}
	}

}
