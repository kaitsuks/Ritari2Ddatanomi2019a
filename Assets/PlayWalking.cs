using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayWalking : MonoBehaviour {

    public AudioClip walkingClip;
    AudioSource audioSource;
    private IEnumerator coroutine;
    bool soitettu = true;
    int n; //laskuri
    // Use this for initialization
    void Start () {
        print("Alkuaika ............................" + Time.time);
        audioSource = GetComponent<AudioSource>();
        coroutine = Player(2.0f);
        StartCoroutine(coroutine);
    }
	
	// Update is called once per frame
	void Update () {
        n++;
        if(n > 10)
        {
            n = 0;
            //StartCoroutine(coroutine);
            Debug.Log("Soitetaan taas");
            PlaySound();
        }
        
    }

    private IEnumerator Player(float t)
    {
        print("Startataan coroutine  "+Time.time);
        audioSource.Play();
        while (true)
        {
            yield return new WaitForSecondsRealtime(t);
        }
        //print(Time.time);
        //print("Playerista vielä...");
        //soitettu = true;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
