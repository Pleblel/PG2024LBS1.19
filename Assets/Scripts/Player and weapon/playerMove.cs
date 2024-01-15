using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 moveDir;

    private bool canRoll = true;
    private bool isRolling = false;
    public float rollingSpeed;
    public float rollingTime;
    public float rollingCooldown;
    public float RollingVolume;
    public float WalkingVolume;
    int counting = 0;
    [SerializeField]
    private AudioClip[] SFXWalks;
    [SerializeField]
    private AudioClip SFXDash;
    SpriteRenderer sr;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Check roll
        if (isRolling)
        {
            return;
        }

        //looks for input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //sets direction for movement
        moveDir = new Vector2(moveX, moveY).normalized;

        if (Input.GetButtonDown("Jump") && canRoll)
        {
            StartCoroutine(Roll());
        }
    }

    void FixedUpdate()
    {
        //Check roll
        if (isRolling)
        {
            return;
        }
        //Move player
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

        //Walk run audio HERE!
        if (Mathf.Abs(rb.velocity.magnitude) > WalkingVolume)
        {
            counting++;
            if (counting == 10)
            {
                Debug.Log(SoundFXManager.instance);
                SoundFXManager.instance.PlayRandomSoundFXclip(SFXWalks, transform, 1f);
                counting = 0;
            }
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.magnitude));
    }

    IEnumerator Roll()
    {
        //code for dash
        canRoll = false;
        isRolling = true;
        rb.velocity += new Vector2(moveDir.x * rollingSpeed, moveDir.y * rollingSpeed );

        //DASH AUDIO HERE!
        SoundFXManager.instance.PlaySoundFXclip(SFXDash, transform, RollingVolume);

        //Starts Cooldown
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        yield return new WaitForSeconds(rollingCooldown);
        canRoll = true;
        
    }
}
