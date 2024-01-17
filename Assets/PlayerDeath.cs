using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    Animator animator;

    // Plays a death animation for the Player that stops at the last frame. - Elm
    public IEnumerator PlayerDeathAnimation()
    {
        // Sets the gameObject the script is attached to (that will play the animation) to the players position. - Elm
        transform.position = player.transform.position;

        // Plays the animation. - Elm
        animator = GetComponent<Animator>();
        animator.Play("playerdeathanimation");

        // Waits for 3.28 seconds. - Elm
        yield return new WaitForSeconds(3.28f);

        // Sets the animation speed to 0 (effectively stopping it) - Elm
        animator.SetFloat("playerdeathfloat", 0);
    }
}
