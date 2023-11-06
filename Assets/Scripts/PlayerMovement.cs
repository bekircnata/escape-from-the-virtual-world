using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator anim;
    private SpriteRenderer sprite;
    private AudioSource audioSource;
    private float horizontalInput = 0;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private AudioClip jumpSoundEffect;

    public bool isItOnTheGround = false;

    private enum MovementState { idle, running, jumping, falling};

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        AnimationUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            isItOnTheGround = true;
        }
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * moveSpeed, playerRb.velocity.y);

        if (Input.GetButtonDown("Jump") && isItOnTheGround)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            audioSource.clip = jumpSoundEffect;
            audioSource.Play();
            isItOnTheGround = false;
        }


    }

    private void AnimationUpdate()
    {
        MovementState state;
        bool isMovingHorizontally = Mathf.Abs(horizontalInput) > 0.1f;

        if (isMovingHorizontally)
        {
            state = MovementState.running;
            sprite.flipX = horizontalInput < 0;
        }
        else
        {
            state = MovementState.idle;
        }

        if(playerRb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }else if(playerRb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
