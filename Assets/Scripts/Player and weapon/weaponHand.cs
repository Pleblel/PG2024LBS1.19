using UnityEngine;

public class weaponHand : MonoBehaviour
{
    //Pelle
    public GameObject player;
    void Update()
    {
        //sätter vinkel med mus och spelare
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //sätter vinkel
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //rotar boken runt en position
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //kollar om mus är höger eller vänster
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //ändar saken boken roterar runt
        if (pos.x >= 0.5f)
        {
            transform.position = new Vector3(player.transform.position.x + 0.3f, transform.position.y, -1);
        }
        else if (pos.x <= 0.5f)
        {
            transform.position = new Vector3(player.transform.position.x - 0.3f, transform.position.y, -1);
        }
    }

}
