using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    Animator animator;

    private void Start()
    {
        StartCoroutine(PlayerDeathAnimation());
    }
    public IEnumerator PlayerDeathAnimation()
    {
        transform.position = player.transform.position;
        animator = GetComponent<Animator>();
        animator.Play("playerdeathanimation");
        yield return new WaitForSeconds(3.28f);
        animator.SetFloat("playerdeathfloat", 0);
    }
}
