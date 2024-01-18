using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaScript : MonoBehaviour
{
    Image manaBarImage;
    public float maxMana = 100;
    public float currentMana;
    public float manaGain;
    public float manaPercentage;
    [SerializeField]
    private AudioClip ManabarfullSFX;
    public float ManaReminderVolume;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        manaBarImage = gameObject.GetComponent<Image>();
        currentMana = 50;
    }

    private void Update()
    {
        // Formula for manaGain. - Elm & Pelle
        manaGain = 0.065f + 0.000125f * currentMana;

        // Continuously adds mana. Stops if mana exceeds max. - Elm
        currentMana += manaGain;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        // Calls to update the manabar meter - Elm
        UpdateManaBar();
    }

    // Removes mana based on parameter. - Elm & Pelle
    public void UseMana(float manaUsed)
    {
        currentMana -= manaUsed;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        UpdateManaBar();
    }

    // Updates the manabar when the currentMana variable changes.
    private void UpdateManaBar()
    {
        manaPercentage = currentMana / maxMana;
        manaBarImage.fillAmount = manaPercentage;

        //play audio
        if (timer > 2 && manaPercentage == 1)
        {
            Debug.Log(SoundFXManager.instance);
            print("audio");
            SoundFXManager.instance.PlaySoundFXclip(ManabarfullSFX, transform, ManaReminderVolume);
            timer = 0;
        }
    }
}
