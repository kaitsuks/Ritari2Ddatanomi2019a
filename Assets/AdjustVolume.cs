using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour {
    Slider sl;
    private Text t;
    private GameObject go;
    private float val;
    // Use this for initialization
    void Start () {
        sl = GetComponent<Slider>();
        go = GameObject.Find("VolumeArvo");
        t = go.GetComponent<Text>();
    }
	public void Adjust()
    {
        val = sl.value;
        t.text = val.ToString();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
