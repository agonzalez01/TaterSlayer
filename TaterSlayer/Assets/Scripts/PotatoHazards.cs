using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoHazards : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Water")
        {
            Debug.Log("Water In");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log("Water In");
        }
    }
}
