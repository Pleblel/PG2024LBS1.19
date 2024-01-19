using UnityEngine;

public class dustRot : MonoBehaviour
{
    //Pelle
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //roterar dust effekten
        GetComponent<ParticleSystem>();
        if (moveX == -1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (moveY == -1)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        else if (moveY == 1)
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
