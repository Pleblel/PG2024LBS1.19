using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class spellSlotImage : MonoBehaviour
{

    public GameObject spellSlot;
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    public int lucas;

    
    // 2 3 4 1'
    // 4 3 2 1
    void Update()
    {
        lucas = spellSlot.GetComponent<weapon>().spells;
        if (lucas == 0)
        {
            GetComponent<Image>().sprite = img1;
        }
        if (lucas == 1)
        {
            GetComponent<Image>().sprite = img2;
        }
        if (lucas == 2)
        {
            GetComponent<Image>().sprite = img3;
        }
        if (lucas == 3)
        {
            GetComponent<Image>().sprite = img4;
        }
    }
}
