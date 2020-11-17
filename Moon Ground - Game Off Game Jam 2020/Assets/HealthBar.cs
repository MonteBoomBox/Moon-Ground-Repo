using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public Gradient gradient;
    public Image fillColor;

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        fillColor.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;

        fillColor.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
