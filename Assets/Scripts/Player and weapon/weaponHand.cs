using UnityEngine;

public class weaponHand : MonoBehaviour
{
    //Pelle
    public GameObject player;
    void Update()
    {
        //s�tter vinkel med mus och spelare
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //s�tter vinkel
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //rotar boken runt en position
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //kollar om mus �r h�ger eller v�nster
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //�ndar saken boken roterar runt
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
