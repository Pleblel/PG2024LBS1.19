using UnityEngine;
using UnityEngine.UI;

public class spellSlotImage2 : MonoBehaviour
{

    public GameObject spellSlot;
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    public int lucas;
    void Update()
    {
        lucas = spellSlot.GetComponent<weapon>().spells;
        if (lucas == 1)
        {
            GetComponent<Image>().sprite = img1;
        }
        if (lucas == 2)
        {
            GetComponent<Image>().sprite = img2;
        }
        if (lucas == 3)
        {
            GetComponent<Image>().sprite = img3;
        }
        if (lucas == 0)
        {
            GetComponent<Image>().sprite = img4;
        }
    }
}