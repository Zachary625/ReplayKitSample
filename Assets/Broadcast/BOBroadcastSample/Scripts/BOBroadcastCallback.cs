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

	public void BOBroadcast_OnBroadcastFinished()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnBroadcastFinished(): " + BOBroadcast.Instance.GetError());
	}

	public void BOBroadcast_OnStarted()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnStarted(): " + BOBroadcast.Instance.GetError());
	}

	public void BOBroadcast_OnFinished()
	{
		Debug.Log (" @ BOBroadcastCallback.BOBroadcast_OnFinished(): " + BOBroadcast.Instance.GetError());
	}
}
