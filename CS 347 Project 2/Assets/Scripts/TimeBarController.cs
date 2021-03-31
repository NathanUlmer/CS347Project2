using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{

    public Slider slider;

    //Set max time
    public void SetMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    //Update time bar
    public void SetTime(float time)
    {
        slider.value = time;
    }
}