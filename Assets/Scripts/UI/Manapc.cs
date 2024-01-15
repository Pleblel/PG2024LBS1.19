using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manapc : MonoBehaviour
{
    public GameObject manapercenttext;
    public TextMeshProUGUI manaUi;
    manaScript number;
    // Start is called before the first frame update
    void Start()
    {
        //Kollar andra slide
        number = manapercenttext.GetComponent<manaScript>();
        manaUi = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //mana percent show text    
        manaUi.text = (number.manaPercentage.ToString() + "%");

    }
}
