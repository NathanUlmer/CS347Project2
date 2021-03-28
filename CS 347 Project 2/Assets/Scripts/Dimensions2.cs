using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class Dimensions2 : MonoBehaviour
{
// Dimensions getters/setters
    private float mass = 0;
    [HideInInspector]
    public float Mass{
        get{return mass;}
        set{mass = value;}
    }
    
    private float length = 0;
    [HideInInspector]
    public float Length{
        get{return length;}
        set{length = value;}
    }

    private float time = 0;
    [HideInInspector]
    public float Time{
        get{return time;}
        set{time = value;}
    }

    private float temp = 0;
    [HideInInspector]
    public float Temp{
        get{return temp;}
        set{temp = value;}
    }

    private float charge = 0;
    [HideInInspector]
    public float Charge{
        get{return charge;}
        set{charge = value;}
    }

// Required Objects
    private Rigidbody rb;
    private Transform tf;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tf = this.GetComponent<Transform>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update stuff related to Mass
        rb.mass = rb.mass + mass;
        mass = 0;

        // Update Length stuff

        // Update time stuff

        // Update temp stuff

        // Update charge stuff
    }

    
}