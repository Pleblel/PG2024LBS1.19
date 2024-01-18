using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerRotatatiwen : MonoBehaviour
{
    //pelle
    public int rotSpeed;
    private void Start()
    {
        StartCoroutine(des());
    }

    void Update()
    {
        //snurrar
        transform.rotation *= Quaternion.Euler(0, 0, rotSpeed * Time.deltaTime);
    }
    IEnumerator des()
    {
        //tar bort efter 1500 * 1/fps
        yield return new WaitForSeconds(1500 * Time.deltaTime);
        Destroy(gameObject);
    }
}
