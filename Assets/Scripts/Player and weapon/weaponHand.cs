using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class weaponHand : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (pos.x >= 0.5f)
        {
            transform.position = new Vector2(player.transform.position.x + 0.3f, transform.position.y);
        }
        else if (pos.x <= 0.5f)
        {
            transform.position = new Vector2(player.transform.position.x - 0.3f, transform.position.y);
        }
    }

}
