﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMovement1 : MonoBehaviour
{
    [Header("PlayerMovement")]

   
    public bool canMove;
    public bool canShoot;

    public float speed = 5f;
    public float health = 100f;


    public GameObject Knife;
    public GameObject Sniper;
    public GameObject Launcher;

    private Rigidbody rb;
    private Animator anim;
    private RaycastHit hit;
    private BoxCollider col;

    [Space]
    [Header("Other Things")]

    public LayerMask layer;
    public float hitDistance;

    PotatoMovement playerHit;
    GrenadeLauncher launch;

    private bool isGrounded;

    public bool shootDirection = true;
    public bool isFacingRight;
    int ShootingType; 



    // Start is called before the first frame update
    void Start()
    {
        Knife.SetActive(false);
        Sniper.SetActive(false);
        Launcher.SetActive(false);

        hitDistance = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();
        hit = GetComponent<RaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
        CheckGround();
    }

    public void Shoot(bool shootRight, int shootingType)
    {
        if (canShoot)
        {
            canShoot = false;

            float range = 0;

            if (shootingType == 1)
            {
                range = 0.5f;
                Debug.Log("range is short");
            }

            else if (shootingType == 2)
            {
                range = 6;
                Debug.Log("range is long");
            }

            else if (shootingType == 3)
            {
                launch = GetComponent<GrenadeLauncher>();
                launch.LauncherShot();
                Debug.Log("range can curve");
            }

            RaycastHit hit;
            if (shootRight)
            {
                Debug.DrawRay(transform.position, transform.right, Color.red, 3);
                if (Physics.Raycast(transform.position, transform.right, out hit, range))
                {
                    Debug.Log("hit to the right");
                    playerHit = hit.transform.GetComponent<PotatoMovement>();
                    if (playerHit != null)
                    {
                        Debug.Log("casted");
                        playerHit.health -= 30;
                        if (playerHit.health <= 100)
                        {
                            playerHit.gameObject.SetActive(false);
                        }
                    }

                }
            }

            else
            {
                Debug.DrawRay(transform.position, -transform.right, Color.red, 3);
                if (Physics.Raycast(transform.position, -transform.right, out hit, range))
                {
                    Debug.Log("hit to the left");
                    playerHit = hit.transform.GetComponent<PotatoMovement>();

                    if (playerHit != null)
                    {
                        Debug.Log("casted");
                        playerHit.health -= 30;
                        if (playerHit.health <= 100)
                        {
                            // Object.Destroy(playerHit);
                            playerHit.gameObject.SetActive(false);
                        }
                    }

                }
            }

        }
        
        

    }

    private void PlayerMove()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            var dir = Vector3.zero;
            dir.x = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, rb.velocity.z);
           // transform.rotation = Quaternion.LookRotation(dir);

            if (dir.x > 0 && !isFacingRight)
            {
                shootDirection = true;
                FlipModel();
            }
            else if(dir.x < 0 && isFacingRight)
            {
                shootDirection = false;
                FlipModel();
            }

            if (Input.GetKeyDown(KeyCode.T) && ShootingType != 0)
            {
                Shoot(shootDirection, ShootingType);
            }


        }

    }

    private void PlayerJump()
    {
        if (canMove)
        {
            //float jumpVelocity = 2f;
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
                }
            }

        }
    }

    private void CheckGround()
    {
        if(!Physics.Raycast(transform.position, -Vector3.up, hitDistance + .1f))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    private void FlipModel()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= 1;
        transform.localScale = scaler;
    }

    public void ChooseWeapon(int weapon)
    {
        if(weapon == 1)
        {
            Knife.SetActive(true);
            Sniper.SetActive(false);
            Launcher.SetActive(false);
            ShootingType = 1;
        }

        if(weapon == 2)
        {
            Knife.SetActive(false);
            Sniper.SetActive(true);
            Launcher.SetActive(false);
            ShootingType = 2;
        }

        if(weapon == 3)
        {
            Knife.SetActive(false);
            Sniper.SetActive(false);
            Launcher.SetActive(true);
            ShootingType = 3;
        }
    }
}
