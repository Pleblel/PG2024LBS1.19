using System.Collections;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //Pelle
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
    public TrailRenderer tr;

    private void Start()
    {
        // Gets Animator component of gameObject and stores it. - Elm
        animator = GetComponent<Animator>();

        //tar sprite renderer
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //kollar om man rullar
        if (isRolling)
        {
            return;
        }

        //kollar om man klickar wasd
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //sätter rikting
        moveDir = new Vector2(moveX, moveY).normalized;

        if (Input.GetButtonDown("Jump") && canRoll)
        {
            StartCoroutine(Roll());
        }
    }

    void FixedUpdate()
    {
        //kollar om man rullar
        if (isRolling)
        {
            return;
        }
        //flyttar spelaren
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

        //Walk run audio HERE!
        if (Mathf.Abs(rb.velocity.magnitude) > WalkingVolume)
        {
            counting++;
            if (counting == 10)
            {
                SoundFXManager.instance.PlayRandomSoundFXclip(SFXWalks, transform, 1f);
                counting = 0;
            }
        }

        // Updates "xVelocity" variable in the Animator depending on Velocity of Player. - Elm
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.magnitude));
    }

    IEnumerator Roll()
    {
        //flyttar spelaren och säger att man rullar
        canRoll = false;
        isRolling = true;
        rb.velocity += new Vector2(moveDir.x * rollingSpeed, moveDir.y * rollingSpeed );
        tr.emitting = true;
        //DASH AUDIO HERE!
        SoundFXManager.instance.PlaySoundFXclip(SFXDash, transform, RollingVolume);

        //startar cooldown och säger att man inte rullar
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        tr.emitting = false;
        yield return new WaitForSeconds(rollingCooldown);
        canRoll = true;
        
    }
}
