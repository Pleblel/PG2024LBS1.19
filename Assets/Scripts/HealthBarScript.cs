using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public TextMeshProUGUI healthBarText;
    public Slider slider;

    //kod som g�r att healthbaren r�r p� sig baserat p� ditt nuvarande HP
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
