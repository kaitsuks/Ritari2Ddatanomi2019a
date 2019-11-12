using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* by dmayers340 · Jul 13, 2018 
 * Play sound when user enters certain zones script.
 * 1.) Attach Script to Zone
 * 2.) If player torch enters the zone, get the audio source and play
 * */

public class PlaySound : MonoBehaviour
{
    public GameObject sounds;
    AudioQueue audioQueue; //REFERENCE to AudioQueue script
    bool hasEntered = false;  //boolean to let know if user has entered the zone before


    //Get audioQueue script from sound
    void Start()
    {
        audioQueue = sounds.GetComponent<AudioQueue>();
    }

    //Use on Trigger. Play torch has the rigid body
    //Sound is attached to this zone object
    private void OnTriggerEnter(Collider other)
    {
        //if the thing entering the zone is the player's torch and they have not entered before
        //then make the boolean true, get the audio source and if it is not playing, play the audio
        if (other.CompareTag("playertorch") && hasEntered == false)
        {
            hasEntered = true;
            Debug.Log("Entered Zone");
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audioQueue.AddAudioSourceToList(audio);
        Debug.Log("Size of audio queue: " + audioQueue.getSize());
        audioQueue.AudioPlay();
    }
}