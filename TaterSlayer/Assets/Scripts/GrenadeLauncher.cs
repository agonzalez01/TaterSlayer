using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 200f;
    float chargeForce = 25f;

    public List<MonoBehaviour> cancelOther = new List<MonoBehaviour>();

    public GameObject fryShot;

    PotatoMovement launcher;

    Vector2 dir;

    bool shotFired;

    public float charging = 0;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LauncherShot();
    }

    public void LauncherShot()
    {
        if (Input.GetMouseButton(0))
        {
            shotFired = false;

            for (int i = 0; i < cancelOther.Count; i++)
            {
                cancelOther[i].enabled = false;
            }
            
            charging += Time.deltaTime * chargeForce;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject prefab = Instantiate(fryShot, transform.position, Quaternion.identity) as GameObject;
            Rigidbody rb = prefab.GetComponent<Rigidbody>();
            charging = Mathf.Clamp(charging, minForce, maxForce);
            rb.velocity = -transform.right * charging;
            charging = 0f;
            shotFired = true;

            //if (shotFired)
            //{
            //    fryShot.SetActive(false);
            //}

            fryShot.SetActive(true);

            for (int i = 0; i < cancelOther.Count; i++)
            {
                cancelOther[i].enabled = true;
            }

          

            //gameObject.SetActive(false);

        }
    }
}
