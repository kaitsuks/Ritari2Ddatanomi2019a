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
        PlayClip();
        audio.clip = fourthClip;
        PlayClip();

    }

    public IEnumerator PlayClip()
    {
        Debug.Log("Yritetään soittaa...");
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }

    public void PlayClips()
    {
        Debug.Log("Täällä ollaan...");
        audio.Play();
    }

    public void ShowMe()
    {
        Debug.Log("Täällä ollaan...");
        audio.Play();
    }

    void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = otherClip;
            audio.Play();
        }
    }
}
