using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BOBroadcastSample : MonoBehaviour {
	private int clockWidth = 400;
	private int clockHeight = 100;
	private GUIStyle clockStyle = null;

	public Text TimerText;
	public Text StatusText;

	// Use this for initialization
	void Start () {
		Debug.Log ("Screen: " + Screen.width + " * " + Screen.height);
		this.clockStyle = new GUIStyle ()
		{
			fontSize = 48,
			alignment = TextAnchor.MiddleCenter,
			fontStyle = FontStyle.Bold,
			normal = new GUIStyleState()
			{
				textColor = Color.green,
			},
		};
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer ();
		updateStatus ();

	}

	private void updateStatus()
	{
		if (StatusText) {
			string statusString = string.Format ("{0}\nAvailable: {1}\nBroadcasting: {2}\nStreaming: {3}", BOBroadcast.Instance.GetType().Name, BOBroadcast.Available, BOBroadcast.Instance.Broadcasting, BOBroadcast.Instance.BroadcastStreaming);
			StatusText.text = statusString;
		}
	}

	private void updateTimer()
	{
		if (TimerText) {
			System.DateTime now = System.DateTime.Now;
			string timeString = string.Format ("{0}/{1}/{2} {3}:{4}:{5}.{6}", now.Year, now.Month.ToString("D2"), now.Day.ToString("D2"), now.Hour, now.Minute, now.Second, now.Millisecond.ToString("D3"));
			TimerText.text = string.Format ("<b>{0}</b>", timeString);
		}
	}


}
