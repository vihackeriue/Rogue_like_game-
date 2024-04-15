using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarPlayer : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float h){
        slider.maxValue = h*5/100;
        slider.value = h*5/100;

        fill.color = gradient.Evaluate(1f);
        Debug.Log(h);
    }
    public void SetHealth(float h){
        slider.value = h*5/100;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.Log(h);
    }
}
