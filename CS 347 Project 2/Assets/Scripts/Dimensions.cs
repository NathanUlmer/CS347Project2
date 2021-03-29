using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class Dimensions : MonoBehaviour
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
    PlayerMovement pc;
    public float oldGrav;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tf = this.GetComponent<Transform>();
        player = GameObject.Find("PlayerObject");
        pc = this.GetComponent<PlayerMovement>();
        oldGrav = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update stuff related to Mass
        rb.mass = rb.mass + mass;

        if(rb.mass<0.5){
            if(oldGrav == 0f) oldGrav = pc.gravity;
            pc.gravity = 0.01f/(0.5f-rb.mass);
            pc.isFloating = true;
            //rb.AddForce(new Vector3(0,0.1f/(0.4f-rb.mass),0));
            rb.useGravity = false;
        }

        else if(oldGrav!=0) {
            


            pc.isFloating = false;
            pc.gravity = oldGrav;
            pc.isFloating = false;
            rb.useGravity = true;
            oldGrav = 0f;
        }
        mass = 0f;
        // Update Length stuff

        // Update time stuff

        // Update temp stuff

        // Update charge stuff
    }

    
}