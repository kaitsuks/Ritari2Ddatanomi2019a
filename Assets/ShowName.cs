using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowName : MonoBehaviour {
    private Text t;
    private string myName;
    private GameObject go;
    private GameObject gob;
    private InputField ifi;
    // Use this for initialization
    void Start () {
        go = GameObject.Find("NameField");
        ifi = go.GetComponent<InputField>();
        
        gob = GameObject.Find("YourName");
        t = gob.GetComponent<Text>();
        
    }
	
    public void Show()
    {
        myName = ifi.text;
        t.text = myName;
        //t.text = "Test";
    }

	// Update is called once per frame
	void Update () {
		
	}
}
