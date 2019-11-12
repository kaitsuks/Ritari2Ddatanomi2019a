using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour {
    public GameObject spriteObjekti;
    public Image im;
    Slider sl;
    SpriteRenderer m_SpriteRenderer;
    Color color;
    // Use this for initialization
    void Start () {
        sl = GetComponent<Slider>();
        m_SpriteRenderer = spriteObjekti.GetComponent<SpriteRenderer>();
    }
	void Update () {
        byte b = (byte)(sl.value * 255);
        color = new Color32(b, 0, b, 255);
        m_SpriteRenderer.color = color;
        im.color = color;
    }
}

