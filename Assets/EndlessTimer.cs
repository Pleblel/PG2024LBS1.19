using UnityEngine;
using TMPro;

public class EndlessTimer : MonoBehaviour
{
    float timer = -0.49f;
    public TextMeshProUGUI textcomponent;

    // Start is called before the first frame update
    void Start()
    {
        textcomponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textcomponent.text = "You have survived for " + Mathf.Round(timer) + " seconds!";
    }
}
