using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeBarController : MonoBehaviour
{

    public Slider slider;

    //Set max size
    public void SetMaxSize(float size)
    {
        slider.maxValue = size;
        slider.value = size;
    }

    //Update size bar
    public void SetSize(float size)
    {
        slider.value = size;
    }
}