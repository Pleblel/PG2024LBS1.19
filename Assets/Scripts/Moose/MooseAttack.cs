using Unity.Mathematics;
using UnityEngine;

public class MooseAttack : MonoBehaviour
{
    //pelle
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
        if (gameObject.transform.position.x >= 500)
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
                shoot();
            }
        }

        //kollar om moose för nära och timer > 10 och sedan skjuter
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
    //skapar bullet
    void shoot()
    {
        Instantiate(bullet, bulletpos.position, quaternion.identity);
    }
//skapar laser
    void lazer()
    {
        Instantiate(lazoor, bulletpos.position, quaternion.identity);
    }
}
