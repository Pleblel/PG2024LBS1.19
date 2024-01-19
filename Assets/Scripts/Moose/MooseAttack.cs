using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MooseAttack : MonoBehaviour
{
    public bool mooseClose;
    float timer;
    float timer2;
    public GameObject bullet;
    public GameObject lazoor;
    public Transform bulletpos;
    [SerializeField] private AudioClip MooseLazer;
    [SerializeField] private AudioClip Moosebullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets "MooseTooClose" bool value
        mooseClose = GetComponent<Moose>().MooseTooClose;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (mooseClose == false)
        {
            if (timer > 4)
            {
                SoundFXManager.instance.PlaySoundFXclip(Moosebullet, transform, 1f);
                timer = 0;
                shoot();
            }
        }

        if (mooseClose == false)
        {
            if (timer2 > 10)
            {
                SoundFXManager.instance.PlaySoundFXclip(MooseLazer, transform, 1f);
                timer2 = 0;
                lazer();
            }
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletpos.position, quaternion.identity);
    }

    void lazer()
    {
        Instantiate(lazoor, bulletpos.position, quaternion.identity);
    }
}
