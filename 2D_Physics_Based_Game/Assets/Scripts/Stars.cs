using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public GameObject Crown1;
    public GameObject Crown2;
    public GameObject Crown3;

    public GameObject Crown1img;
    public GameObject Crown2img;
    public GameObject Crown3img;

    public bool Collected=false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            Collected = true;
            Crown1.SetActive(false);
            Crown1img.SetActive(true);
        }

        
    }
}
