using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class Dimensions : MonoBehaviour
{
// Dimensions getters/setters
    private float mass = 0f;
    [HideInInspector]
    public float Mass{
        get{return mass;}
        set{mass = value;}
    }
    
    private float length = 0f;
    [HideInInspector]
    public float Length{
        get{return length;}
        set{length = value;}
    }

    private float timeDiff = 0f;
    [HideInInspector]
    public float time{
        get{return timeDiff;}
        set{ timeDiff = value;}
    }

    private float temp = 0f;
    [HideInInspector]
    public float Temp{
        get{return temp;}
        set{temp = value;}
    }

    private float charge = 0f;
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
    private float fixedDeltaTime;
    public float maxMass;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tf = this.GetComponent<Transform>();
        player = GameObject.Find("PlayerObject");
        pc = this.GetComponent<PlayerMovement>();
        oldGrav = 0.0f;
        this.fixedDeltaTime =Time.fixedDeltaTime;
        this.maxMass = 10;
    }

    void Update()
    {

        // Update time stuff
        if(Time.timeScale + timeDiff >= 0f) {
            Time.timeScale += timeDiff;
            Time.fixedDeltaTime = this.fixedDeltaTime*Time.timeScale;
        }
        if(timeDiff!=0f) timeDiff = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update stuff related to Mass
        if(rb.mass + mass >= 0f && rb.mass + mass < maxMass)
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
        this.gameObject.transform.localScale += new Vector3(length, length,length);
        if(length!=0) length =0;


        // Update temp stuff

        // Update charge stuff
    }

    
}