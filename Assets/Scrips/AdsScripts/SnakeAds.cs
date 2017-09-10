using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class SnakeAds : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		string gameId;
		#if UNITY_ANDROID
		gameId = "1538812";
		/*#elif UNITY_IOS
		gameId = "1538812";*/
		#endif

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId);
		}
		Advertisement.Show ("video"); // video is the placement id available in advertisement dashboard

		showRewardingAds ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showRewardingAds() {
		var options = new ShowOptions ();
		options.resultCallback = HandleShowResult;
		Advertisement.Show ("rewardedVideo", options);
	}

	void HandleShowResult(ShowResult result) {
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
}
