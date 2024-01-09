using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    void Update()
    {
        if (isRolling)
        {
            return;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        if (Input.GetButtonDown("Jump") && canRoll)
        {
            StartCoroutine(Roll());
        }
    }

    void FixedUpdate()
    {
        if (isRolling)
        {
            return;
        }
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    IEnumerator Roll()
    {
        canRoll = false;
        isRolling = true;
        rb.velocity += new Vector2(moveDir.x * rollingSpeed, moveDir.y * rollingSpeed );
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        yield return new WaitForSeconds(rollingCooldown);
        canRoll = true;
    }
}
