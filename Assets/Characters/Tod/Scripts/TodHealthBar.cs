using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TodHealthBar : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider = (Slider)FindObjectOfType(typeof(Slider));
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
