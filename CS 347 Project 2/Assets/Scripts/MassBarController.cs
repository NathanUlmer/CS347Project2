using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassBarController : MonoBehaviour
{

    public Slider slider;

    //Set max mass
    public void SetMaxMass(float mass)
    {
        slider.maxValue = mass;
        slider.value = mass;
    }

    //Update mass bar
    public void SetMass(float mass)
    {
        slider.value = mass;
    }
}
