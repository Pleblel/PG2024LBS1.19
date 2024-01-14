using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class manaScript : MonoBehaviour
{
    Image manaBarImage;
    public float maxMana = 100;
    public float currentMana;
    public float manaGain;
    public float manaPercentage;
    public int timeInMsSFX;
    [SerializeField]
    private AudioClip ManabarfullSFX;
    public float ManaReminderVolume;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        manaBarImage = gameObject.GetComponent<Image>();
        currentMana = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
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
