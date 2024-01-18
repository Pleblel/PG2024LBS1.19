using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public int dmg;
    public int home;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 dir = player.transform.position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;

        float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        StartCoroutine(des());
    }
    private void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        rb.velocity += new Vector2(dir.x, dir.y).normalized / home;

        float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject player = col.gameObject;
        playerMove playerComp = player.GetComponent<playerMove>();
        if (playerComp != null)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(dmg);
            Destroy(gameObject);

        }
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(200 * Time.deltaTime);
        Destroy(gameObject);
    }
}
