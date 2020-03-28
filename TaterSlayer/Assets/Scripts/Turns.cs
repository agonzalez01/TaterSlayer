﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{

    public GameObject[] Players = new GameObject[6];

    public GameObject PlayerInTurn;

    public Water SinkChanges;

    int index = 0;
    int turnsTaken = 0;

    ShootingType weapon;
    bool hasChosenWeapon;

    PotatoMovement CanPlayerMove;


    // Start is called before the first frame update
    void Start()
    {
        PlayerInTurn = Players[index];
        CanPlayerMove = PlayerInTurn.GetComponent<PotatoMovement>();
        SinkChanges = GameObject.Find("Water").GetComponent<Water>();
        StartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasChosenWeapon)
        {
            if(Input.GetKeyDown("1"))
            {
                MeleeWeapon();
            }

            else if(Input.GetKeyDown("2"))
            {
                SniperWeapon();
            }

            else if(Input.GetKeyDown("3"))
            {
                GrenadeWeapon();
            }
        }
    }

    public void MeleeWeapon()
    {
        if (!hasChosenWeapon)
        {
            weapon = ShootingType.MELEE;
            hasChosenWeapon = true;
            CanPlayerMove.ChooseWeapon(1);
        }
    }

    public void SniperWeapon()
    {
        if (!hasChosenWeapon)
        {
            weapon = ShootingType.SNIPER;
            hasChosenWeapon = true;
            CanPlayerMove.ChooseWeapon(2);
        }
    }

    public void GrenadeWeapon()
    {
        if (!hasChosenWeapon)
        {
            weapon = ShootingType.GRENADE;
            hasChosenWeapon = true;
            CanPlayerMove.ChooseWeapon(3);
        }
    }

    enum ShootingType
    {
        MELEE, GRENADE, SNIPER
    }

    public void StartTurn()
    {
        Debug.Log("SettingTurn");
        CanPlayerMove.canMove = true;
        CanPlayerMove.canShoot = true;
        StartCoroutine(NextTurn());

    }

    IEnumerator NextTurn()
    {
        if(index == 5)
        {
            index = -1;
        }
        yield return new WaitForSecondsRealtime(50f);
        CanPlayerMove.canMove = false;

        yield return new WaitForSecondsRealtime(2f);
        index++;
        turnsTaken++;
        PlayerInTurn = Players[index];
        CanPlayerMove = PlayerInTurn.GetComponent<PotatoMovement>();
        hasChosenWeapon = false;

        StartTurn();

        if(turnsTaken%4 == 0)
        {
            SinkChanges.WaterChange();
        }

    }

}
