using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaScript : MonoBehaviour
{
    public Image manaBarImage;
    public float maxMana = 100;
    public float currentMana;
    public float manaGain = 1/12f;
    public float manaPercentage;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = 2;
    }

    private void FixedUpdate()
    {
        if (currentMana <= maxMana)
        {
            currentMana += manaGain;
            currentMana = Mathf.Clamp(currentMana, 0, maxMana);
            UpdateManaBar();
        }
  
    }

    public void UseMana(float manaUsed)
    {
        currentMana -= manaUsed;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        UpdateManaBar();
    }

    // Update is called once per frame
    private void UpdateManaBar()
    {
        manaPercentage = currentMana / maxMana * 100;
        manaBarImage.fillAmount = manaPercentage / 100;
    }
}
