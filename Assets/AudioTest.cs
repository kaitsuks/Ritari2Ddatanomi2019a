using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    //Make a Queue of Audio Clips
    public List<AudioClip> audioQueue = new List<AudioClip>();

    //Have index of where we are at in the queue
    int index = 1;
    int count;
    bool hasEntered = false;

    //Get the One AudioSource
    AudioSource audioSource;

    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;
    public AudioClip fourthClip;
    public AudioClip fifthClip;
    public AudioClip sixthClip;
    public AudioClip seventhClip;
    public AudioClip eigthClip;

   
    // Use this for initialization
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioQueue.Add(firstClip);
        audioQueue.Add(secondClip);
        audioQueue.Add(thirdClip);
        audioQueue.Add(fourthClip);
        audioQueue.Add(fifthClip);
        audioQueue.Add(sixthClip);
        audioQueue.Add(seventhClip);
        audioQueue.Add(eigthClip);
        
        count = audioQueue.Count;
        Debug.Log("audioQueue.Count = " + count);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
            {
            hasEntered = true;
            Debug.Log("Entered Zone!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            PlayAudio();
        }
   
   }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasEntered = false;
            Debug.Log("Exited Zone, no more playing sounds");
            //PlayAudio();
        }

    }

    public void PlayAudio()
    {
        Debug.Log("Index = " + index);
        index += 1;
        if (index > (count - 1))
        {
            index = 1;
            //Debug.Log("Index resetoitu = " + index);
        }
        Debug.Log("Index nyt = " + index);
        if (!audioSource.isPlaying && hasEntered == true)
        {
            audioSource.clip = audioQueue[index];
            audioSource.Play();
        }
    }
}