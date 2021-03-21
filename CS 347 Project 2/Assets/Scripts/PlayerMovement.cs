using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rigidb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rigidb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rigidb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rigidb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
    }
}
