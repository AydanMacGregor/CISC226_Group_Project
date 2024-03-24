using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarD : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = 300f;
        slider.value = 300f;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
    
}
