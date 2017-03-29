using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BOBroadcastSample : MonoBehaviour {
	

	public Text TimerText;
	public Text StatusText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer ();
		updateStatus ();

	}

	private void updateStatus()
	{
		if (StatusText) {
			string statusString = string.Format (
				"Broadcast:{0}\n" +
				"Available: {1}\n" +
				"Broadcasting: {2}\n" +
				"Streaming: {3}\n" +
				"URL: {4}\n" +
				"Bundle ID: {5}\n",
				BOBroadcast.Instance.GetType().Name,
				BOBroadcast.Available, 
				BOBroadcast.Instance.Broadcasting,
				BOBroadcast.Instance.BroadcastStreaming,
				BOBroadcast.Instance.BroadcastURL(),
				BOBroadcast.Instance.ServiceBundleID()
			);
			StatusText.text = statusString;
		}
	}

	private void updateTimer()
	{
		if (TimerText) {
			System.DateTime now = System.DateTime.Now;
			string timeString = string.Format ("{0}/{1}/{2}\n{3}:{4}:{5}.{6}", 
				now.Year, now.Month.ToString("D2"), now.Day.ToString("D2"), 
				now.Hour.ToString("D2"), now.Minute.ToString("D2"), now.Second.ToString("D2"), now.Millisecond.ToString("D3"));
			TimerText.text = string.Format ("<b>{0}</b>", timeString);
		}
	}

	public void OnSelectServiceButtonClicked()
	{
		if (!BOBroadcast.Available)
		{
			Debug.Log (" @ BOBroadcastSample.OnSelectServiceButtonClicked(): BOBroadcast.Available == false!!!");
			return;
		}

		if (BOBroadcast.Instance.Broadcasting) 
		{
			Debug.Log (" @ BOBroadcastSample.OnSelectServiceButtonClicked(): Broadcasting == true!!!");
			return;
		}
		BOBroadcast.Instance.SelectService ();
		Debug.Log (" @ BOBroadcastSample.OnSelectServiceButtonClicked(): " + BOBroadcast.Instance.GetError());
	}

	public void OnStartStopButtonClicked()
	{
		if (string.IsNullOrEmpty(BOBroadcast.Instance.ServiceBundleID()))
		{
			Debug.Log (" @ BOBroadcastSample.OnStartStopButtonClicked(): ServiceBundleID == null!!!");
			return;
		}

		if (BOBroadcast.Instance.Broadcasting) {
			BOBroadcast.Instance.BroadcastFinish ();
		} else {
			BOBroadcast.Instance.BroadcastStart ();
		}
		Debug.Log (" @ BOBroadcastSample.OnStartStopButtonClicked(): " + BOBroadcast.Instance.GetError());
	}

	public void OnPauseResumeButtonClicked()
	{
		if (!BOBroadcast.Instance.Broadcasting)
		{
			Debug.Log (" @ BOBroadcastSample.OnPauseResumeButtonClicked(): Broadcasting == false!!!");
			return;
		}

		if (BOBroadcast.Instance.BroadcastStreaming) {
			BOBroadcast.Instance.BroadcastPause ();
		} else {
			BOBroadcast.Instance.BroadcastResume ();
		}
		Debug.Log (" @ BOBroadcastSample.OnPauseResumeButtonClicked(): " + BOBroadcast.Instance.GetError());
	}


}
