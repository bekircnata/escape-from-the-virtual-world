using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float horizontal = 0;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        AnimationUpdate();
    }

    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(horizontal * moveSpeed, playerRb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }


    }

    private void AnimationUpdate()
    {
        if (horizontal > 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (horizontal < 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
