using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicforRadio : MonoBehaviour {
    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
     public void playaudio()
    {
        audio.Play();
        Debug.Log("radio is playing");
    }
     public void stopAudio()
     {
         audio.Pause();
        Debug.Log("radio is stopped");

    }

}
