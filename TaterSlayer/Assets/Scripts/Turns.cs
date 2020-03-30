using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{

    public GameObject[] Players = new GameObject[6];
    public bool[] playersDead = new bool[6];

    public GameObject PlayerInTurn;

    public GameObject EndState;
    public GameObject Inventory;
    public GameObject PowerBar;
    public Text Timer;

    float currentTime = 45;
    float startingTime = 45;

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

        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1*Time.deltaTime;

        Timer.text = currentTime.ToString("0");

        if(currentTime<=0)
        {
            currentTime = 0;
        }
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
        if (CanPlayerMove.gameObject.activeInHierarchy)
        {
            CanPlayerMove.canMove = true;
            CanPlayerMove.canShoot = true;
            StartCoroutine(NextTurn());
        }
        else
        {
            playersDead[index] = true;
            if (index == 5)
            {
                index = -1;
            }

            index++;
            PlayerInTurn = Players[index];
            CanPlayerMove = PlayerInTurn.GetComponent<PotatoMovement>();
            StartTurn();
        }

    }

    IEnumerator NextTurn()
    {
        if (playersDead[1] && playersDead[3] && playersDead[5])
        {
            Time.timeScale = 0;
            EndState.SetActive(true);
            Inventory.SetActive(false);
            PowerBar.SetActive(false);
        }

        else
        {

            if (index == 5)
            {
                index = -1;
            }
            yield return new WaitForSecondsRealtime(45f);
            CanPlayerMove.canMove = false;

            yield return new WaitForSecondsRealtime(1f);
            currentTime = 45;
            index++;
            turnsTaken++;
            PlayerInTurn = Players[index];
            CanPlayerMove = PlayerInTurn.GetComponent<PotatoMovement>();
            hasChosenWeapon = false;

            StartTurn();

            if (turnsTaken % 4 == 0)
            {
                SinkChanges.WaterChange();
            }

        }

    }

}
