using UnityEngine;

public class cameraControl : MonoBehaviour
{
    //Pelle
    public GameObject player;

    Vector3 camPos;
    public float camSpeed;
    public float maxDis;
    void Update()
    {
        //f�r mus position f�r att flytta
        Vector3 targetPosition = player.transform.position + Vector3.Scale(Camera.main.ScreenToViewportPoint(Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)), new Vector3(camSpeed, camSpeed, 0));
        camPos = targetPosition + new Vector3(0, 0, -10);
        //s�tter max distans fr�n spelaren
        camPos.x = Mathf.Clamp(camPos.x, player.transform.position.x - maxDis, player.transform.position.x + maxDis);
        camPos.y = Mathf.Clamp(camPos.y, player.transform.position.y - maxDis, player.transform.position.y + maxDis);
        camPos.z = Mathf.Clamp(camPos.z, -10, -10);
        //flyttar kameran
        transform.position = camPos;
    }
}
