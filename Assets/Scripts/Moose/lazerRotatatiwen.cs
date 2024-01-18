using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerRotatatiwen : MonoBehaviour
{
    public int rotSpeed;
    private void Start()
    {
        StartCoroutine(des());
    }

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotSpeed * Time.deltaTime);
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(400 * Time.deltaTime);
        Destroy(gameObject);
    }
}
