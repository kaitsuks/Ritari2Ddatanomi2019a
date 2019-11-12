using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWeapon : MonoBehaviour {
    private string t; //Luettava merkkijono
    private Text t2; //Tekstikomponentti, johon tulostetaan
    private Dropdown dropdown;
    //private string myWeapon;
    private GameObject go;
    private GameObject gob;

    // Käytetään Awake-metodia alustamiseen:
    //Awake is used to initialize any variables or game state before the game starts.
    //Awake is called only once during the lifetime of the script instance.
    //Awake is called after all objects are initialized so you can safely speak 
    //to other objects or query them.
    void Awake() {
        //Debug.Log("Alustetaan... ");
        //Haetaan Dropdown
        go = GameObject.Find("WeaponDropdown");
        //Debug.Log("Alasvetovalikko löydetty " + go);
        dropdown = go.GetComponent<Dropdown>();
       
        gob = GameObject.Find("TextValittuTyokalu");
        t2 = gob.GetComponent<Text>();
    }

    public void ShowWeapon()
    {
        
        //int numberToSave;
        int selectedIndex = dropdown.value;
        //if (int.TryParse(dropdown.options[selectedIndex].text, out numberToSave)) //Ei tarvittane?
        {
            t = dropdown.options[selectedIndex].text; //.ToString();

            t2.text = t;
        }
        //else
        {
          //  Debug.LogError("Chosen option is no number: " + dropdown.options[selectedIndex].text);
            // or throw an exception or whatever
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
