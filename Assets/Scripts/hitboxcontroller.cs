using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcontroller : MonoBehaviour
{
    public GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(owner.name + " hit " + collision.gameObject.name);
        }
    }

    public void ActivateHitbox()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateHitbox()
    {
        this.gameObject.SetActive(false);
    }
}
