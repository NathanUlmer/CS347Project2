using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
private Animator anim;
public AudioSource audsrc;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent <Animator> ();
        audsrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //standing animation

        
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            anim.CrossFade("Running", .2f);
            audsrc.Play();
        }

        //running animation
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {   
            anim.SetBool("isJumping", false);
            anim.SetBool("isChangingTime", false);
            anim.SetBool("isChangingMass", false);
            anim.SetBool("isChangingLength", false);
            anim.SetBool("isPickingUpObject", false);
            anim.SetBool("isChangingCharge", false);
            anim.SetBool("isChangingTemp", false);
            anim.SetBool("isStanding", false);
            anim.SetBool("isRunning", true);
        }   
        else
        {
            anim.SetBool("isStanding", true);
            anim.SetBool("isRunning", false);
            audsrc.Stop();
        }

        //Jumping Animation
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.CrossFade("JUMP", .2f);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        //Picking Up Object Animation
        if(Input.GetKeyDown(KeyCode.P))
        {
            anim.CrossFade("Pick Up Object", .6f);
        }
        if(Input.GetKey(KeyCode.P))
        {
            anim.SetBool("isPickingUpObject", true);
        }
        else
        {
            anim.SetBool("isPickingUpObject", false);
        }

        //Changing Time Animation
        if(Input.GetKeyDown(KeyCode.T))
        {
            anim.CrossFade("Change Time", .1f);
        }
        if(Input.GetKey(KeyCode.T))
        {
            anim.SetBool("isChangingTime", true);
        }
        else
        {
            anim.SetBool("isChangingTime", false);
        }

        //changing temp animation
        if(Input.GetKeyDown(KeyCode.G))
        {
            anim.CrossFade("Change Temp", .1f);
        }
        if(Input.GetKey(KeyCode.G))
        {
            anim.SetBool("isChangingTemp", true);
        }
        else
        {
            anim.SetBool("isChangingTemp", false);
        }

        //changing charge animation
        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.CrossFade("Change Charge", .1f);
        }
        if(Input.GetKey(KeyCode.R))
        {
            anim.SetBool("isChangingCharge", true);
        }
        else
        {
            anim.SetBool("isChangingCharge", false);
        }


        //changing length animation
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            anim.CrossFade("Change Length End", .6f);
        }
        if(Input.GetKey(KeyCode.G)|| Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("isChangingLength", true);
            anim.SetBool("isTransitionLength", true);
        }
        else
        {
            anim.SetBool("isChangingLength", false);
            anim.SetBool("isTransitionLength", false);
        }

                //changing Mass animation
        if(Input.GetKeyDown(KeyCode.F))
        {
            anim.CrossFade("Change Mass", .1f);
        }
        if(Input.GetKey(KeyCode.F))
        {
            anim.SetBool("isChangingMass", true);
        }
        else
        {
            anim.SetBool("isChangingMass", false);
        }
    }
}

