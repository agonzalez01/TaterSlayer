using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoHazards : MonoBehaviour
{

    public int potatoHealth = 100;
    public string Dryness = "Dry";


    void Start()
    {
        Debug.Log(potatoHealth);
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Water")
        {
            Dryness = "Soggy";
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            Dryness = "Dry";
        }
    }
}
