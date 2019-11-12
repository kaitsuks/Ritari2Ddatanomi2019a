using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    //Make a Queue of Audio Clips
    public List<AudioClip> audioQueue = new List<AudioClip>();

    //Have index of where we are at in the queue
    int index = 0;

    //Get the One AudioSource
    new AudioSource audio;

    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;
    public AudioClip fourthClip;
    public AudioClip fifthClip;
    public AudioClip sixthClip;
    public AudioClip seventhClip;
    public AudioClip eigthClip;

    bool hasEntered = false;
    // Use this for initialization
    void Start()
    {
        audioQueue.Add(firstClip);
        audioQueue.Add(secondClip);
        audioQueue.Add(thirdClip);
        audioQueue.Add(fourthClip);
        audioQueue.Add(fifthClip);
        audioQueue.Add(sixthClip);
        audioQueue.Add(seventhClip);
        audioQueue.Add(eigthClip);
    }

    void OnTriggerEnter(Collider other)
    {
        audio = other.GetComponent<AudioSource>();
        if (other.CompareTag("zone") && hasEntered == false)
        {
            hasEntered = true;
            Debug.Log("Entered Zone");
            if (!audio.isPlaying)
            {
                audio.clip = audioQueue[index];
                audio.Play();
                index += 1;
            }
        }
    }
}