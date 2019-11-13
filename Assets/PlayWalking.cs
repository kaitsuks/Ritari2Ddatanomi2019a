using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayWalking : MonoBehaviour {

    public AudioClip walkingClip;
    AudioSource audioSource;
    private IEnumerator coroutine;
    
    int n; //laskuri, vaihtoehtoinen klassinen tapa ajoitukseen 
    // Use this for initialization
    void Start () {
        //print("Alkuaika ............................" + Time.time);
        audioSource = GetComponent<AudioSource>();
        coroutine = Player(2.0f);
        StartCoroutine(coroutine); //Coroutine hoitaa ajoituksen
    }
	
	// Update is called once per frame
	void Update () {
        n++;
        if(n > 10)
        {
            n = 0;
            
            //Debug.Log("Soitetaan taas");
            //PlaySound(); //voidaan soittaa myös laskurin perusteella
        }
        
    }

    private IEnumerator Player(float t)
    {
        //print("Startataan coroutine  "+Time.time);
        
        while (true)
        {
            audioSource.Play(); //soitetaan t-välein...
            yield return new WaitForSecondsRealtime(t);
            //print(Time.time);
            //print("Playerista vielä...");
        }


    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
