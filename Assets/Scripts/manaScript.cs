using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaScript : MonoBehaviour
{
    Image manaBarImage;
    public float maxMana = 100;
    public float currentMana;
    public float manaGain = 1/12f;
    public float manaPercentage;
    // Start is called before the first frame update
    void Start()
    {
        manaBarImage = gameObject.GetComponent<Image>();
        currentMana = 35;
    }

    void FixedUpdate()
    {
        manaGain = 0.05f + 0.0007f * currentMana;
        currentMana += manaGain;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }


        UpdateManaBar();
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
        manaPercentage = currentMana / maxMana;
        manaBarImage.fillAmount = manaPercentage;
    }
}
