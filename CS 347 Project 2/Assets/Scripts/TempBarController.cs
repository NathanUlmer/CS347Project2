using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempBarController : MonoBehaviour
{

    public Slider slider;

    //Set max temp
    public void SetMaxTemp(float temp)
    {
        slider.maxValue = temp;
        slider.value = temp;
    }

    //Update temp bar
    public void SetTemp(float temp)
    {
        slider.value = temp;
    }
}
