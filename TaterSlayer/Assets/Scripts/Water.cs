using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private PotatoHazards potatoHazards;

    Vector3 tempPos;

    void Awake()
    {
        potatoHazards = GameObject.FindObjectOfType<PotatoHazards>();
    }

    // Start is called before the first frame update
    void Start()
    {

        tempPos.x = -0.05f;
        tempPos.y = 1.6f;
        tempPos.z = 9.31f;
        transform.position = tempPos;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e"))
        {

            if (tempPos.y == 1.6f)
            {
                tempPos.y = 2.3f;
                tempPos.z = 9.31f;
                tempPos.x = -0.05f;
                transform.position = tempPos;
            }

            else if (tempPos.y == 2.3f)
            {
                tempPos.y = 2.6f;
                tempPos.z = 9.31f;
                tempPos.x = -0.05f;
                transform.position = tempPos;
            }

            else if (tempPos.y == 2.6f)
            {
                tempPos.y = 1.6f;
                tempPos.z = 9.31f;
                tempPos.x = -0.05f;
                transform.position = tempPos;

                if (potatoHazards.Dryness == "Soggy")
                {

                    potatoHazards.potatoHealth -= 10;

                    Debug.Log(potatoHazards.potatoHealth);

                }

            }

        }


    }
}
