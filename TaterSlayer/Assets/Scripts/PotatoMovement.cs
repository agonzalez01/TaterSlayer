using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMovement : MonoBehaviour
{
    [Header("PlayerMovement")]

    GameObject TurnManager;
    Turns WhatTurn;
    public bool canMove;

    public float speed = 5f;

    private Rigidbody rb;
    private Animator anim;
    private RaycastHit hit;
    private BoxCollider col;

    [Space]
    [Header("Other Things")]

    public LayerMask layer;
    public float hitDistance;

    private bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
        TurnManager = GameObject.Find("TurnManager");
       // TurnManager = Player.GetComponent<Turns>();
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

    private void PlayerMove()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, rb.velocity.z);
        }

        // else
        //  Debug.Log("moveBro");
     

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


    //private bool isGrounded()
    //{
    //    RaycastHit hit = Physics.Raycast(col.bounds.center, col.bounds.size, 0f, -Vector3.up, .1f, layer);

    //    return hit.collider != null;
    //}
}
