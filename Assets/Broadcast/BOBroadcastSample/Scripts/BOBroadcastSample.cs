using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BOBroadcastSample : MonoBehaviour {
	

	public Text TimerText;
	public Text StatusText;
	public Text InfoText;
	public Image CamViewPanel;

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
				"Available: {0}\n" +
				"Broadcasting: {1}\n" +
				"Streaming: {2}\n" +
				"Cam: {3}\n" +
				"Mic: {4}\n",
				BOBroadcast.Available, 
				BOBroadcast.Instance.Broadcasting,
				BOBroadcast.Instance.BroadcastStreaming,
				BOBroadcast.Instance.UseCam,
				BOBroadcast.Instance.UseMic
			);
			StatusText.text = statusString;

			string infoString = string.Format (
				"URL: {0}\n" +
				"Bundle ID: {1}\n" +
				"CamPreviewRect: {2}",
				BOBroadcast.Instance.BroadcastURL(),
				BOBroadcast.Instance.ServiceBundleID(),
				BOBroadcast.Instance.CamViewRect.HasValue? BOBroadcast.Instance.CamViewRect.Value.ToString(): "null"
			);
			InfoText.text = infoString;

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

	public void OnCamButtonClicked()
	{
		if (BOBroadcast.Instance.Broadcasting) {
			Debug.Log (" @ BOBroadcastSample.OnCamButtonClicked(): Broadcasting == true!!!");
			return;
		}

		BOBroadcast.Instance.UseCam = !BOBroadcast.Instance.UseCam;
		if (BOBroadcast.Instance.UseCam) {
			if (CamViewPanel != null) {
				Rect rect = new Rect (0, 0, 100, 200);
				BOBroadcast.Instance.CamViewRect = rect;
			}
		}
	}

	public void OnMicButtonClicked()
	{
		if (BOBroadcast.Instance.Broadcasting) {
			Debug.Log (" @ BOBroadcastSample.OnMicButtonClicked(): Broadcasting == true!!!");
			return;
		}

		BOBroadcast.Instance.UseMic = !BOBroadcast.Instance.UseMic;
	}

	public void OnMusicButtonClicked()
	{
		AudioSource audioSource = this.GetComponent<AudioSource> ();
		if (audioSource == null) {
			return;
		}

		if (audioSource.isPlaying) {
			audioSource.Pause ();
		} else {
			audioSource.Play ();
		}
	}

}
