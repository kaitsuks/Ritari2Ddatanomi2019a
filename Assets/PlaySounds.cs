using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour {

    public AudioClip otherClip;
    public AudioClip thirdClip;
    public AudioClip fourthClip;

   AudioSource audioSource;

    IEnumerator Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = otherClip;
        audioSource.Play();
    }

    public void PlayAllClips()
    {
        audioSource.clip = thirdClip;
        PlayClips();
        audioSource.clip = fourthClip;
        PlayClips();

    }

    public IEnumerator PlayClip()
    {
        Debug.Log("Yritetään soittaa...");
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }

    public void PlayClips()
    {
        Debug.Log("Täällä PlayClips...");
        audioSource.Play();
    }

    public void ShowMe()
    {
        Debug.Log("Täällä ShowMe...");
        audioSource.Play();
    }

    void Update()
    {
        //if (!audioSource.isPlaying)
        //{
        //    audioSource.clip = otherClip;
        //    audioSource.Play();
        //}
    }
}
