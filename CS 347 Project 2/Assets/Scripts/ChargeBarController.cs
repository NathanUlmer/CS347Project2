using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarController : MonoBehaviour
{

    public Slider slider;

    //Set max charge
    public void SetMaxCharge(float charge)
    {
        slider.maxValue = charge;
        slider.value = charge;
    }

    //Update charge bar
    public void SetCharge(float charge)
    {
        slider.value = charge;
    }
}
