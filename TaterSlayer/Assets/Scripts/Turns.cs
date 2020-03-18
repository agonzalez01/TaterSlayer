using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{

    public GameObject[] Players = new GameObject[6];

    public GameObject PlayerInTurn;

    int index = 0;


    PotatoMovement CanPlayerMove;


    // Start is called before the first frame update
    void Start()
    {
        PlayerInTurn = Players[index];
        CanPlayerMove = PlayerInTurn.GetComponent<PotatoMovement>();
        StartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTurn()
    {
        Debug.Log("SettingTurn");
        CanPlayerMove.canMove = true;
        StartCoroutine(NextTurn());

    }

    IEnumerator NextTurn()
    {
        if(index == 5)
        {
            index = -1;
        }
        yield return new WaitForSecondsRealtime(5f);
        CanPlayerMove.canMove = false;

        yield return new WaitForSecondsRealtime(2f);
        index++;
        PlayerInTurn = Players[index];
        CanPlayerMove = PlayerInTurn.GetComponent<PotatoMovement>();

        StartTurn();



    }
}
