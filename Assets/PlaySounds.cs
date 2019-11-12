using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour {

    public AudioClip otherClip;
    public AudioClip thirdClip;
    public AudioClip fourthClip;

    new AudioSource audio;

    IEnumerator Start()
    {
        audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.Play();
    }

    public void PlayAllClips()
    {
        audio.clip = thirdClip;
        PlayClips();
        audio.clip = fourthClip;
        PlayClips();

    }

    public IEnumerator PlayClip()
    {
        Debug.Log("Yritetään soittaa...");
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }

    public void PlayClips()
    {
        Debug.Log("Täällä PlayClips...");
        audio.Play();
    }

    public void ShowMe()
    {
        Debug.Log("Täällä ShowMe...");
        audio.Play();
    }

    void Update()
    {
        //if (!audio.isPlaying)
        //{
        //    audio.clip = otherClip;
        //    audio.Play();
        //}
    }
}
