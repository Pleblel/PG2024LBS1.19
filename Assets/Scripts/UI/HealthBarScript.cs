using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    
    public Slider slider;

    //kod som gör att healthbaren rör på sig baserat på ditt nuvarande HP
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

    }

    // This method is called to set the health to a specific value
   public void SetHealth(float health)
    {
        slider.value = health;
    }
}
