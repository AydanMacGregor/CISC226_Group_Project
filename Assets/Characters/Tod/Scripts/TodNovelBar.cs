using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TodNovelBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetMaxVal(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetVal(float health)
    {
        slider.value = health;
    }
}
