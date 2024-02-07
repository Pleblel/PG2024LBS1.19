using Unity.Mathematics;
using UnityEngine;

public class MooseAttack : MonoBehaviour
{
    //pelle
    public bool mooseClose;
    float timer;
    float timer2;
    public GameObject bullet;
    public GameObject lazer;
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

        //gör så att den inte attakerar innan den spawnar
        if (transform.position.x >= 500)
        {
            return;
        }

        //kollar om moose för nära och timer > 4 och sedan skjuter
        if (mooseClose == false)
        {
            if (timer > 4)
            {
                SoundFXManager.instance.PlaySoundFXclip(Moosebullet, transform, 1f);
                timer = 0;
                Shoot();
            }
        }

        //kollar om moose för nära och timer > 10 och sedan skjuter
        if (mooseClose == false)
        {
            if (timer2 > 10)
            {
                SoundFXManager.instance.PlaySoundFXclip(MooseLazer, transform, 1f);
                timer2 = 0;
                Lazer();
            }
        }
    }
    //skapar bullet
    void Shoot()
    {
        Instantiate(bullet, bulletpos.position, quaternion.identity);
    }
//skapar laser
    void Lazer()
    {
        Instantiate(lazer, bulletpos.position, quaternion.identity);
    }
}
