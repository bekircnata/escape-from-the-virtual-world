using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    private Rigidbody2D fallingPlatformRb;
    private Animator anim;
    [SerializeField] private PlayerMovement PlayerMovementScript;
    private bool touched = false;


    void Start()
    {
        fallingPlatformRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!touched)
        {
            touched = true;
            PlayerMovementScript.isItOnTheGround = true;
            Invoke("PlatformFalling", 1f);
        }
    }

    private void PlatformFalling()
    {
        fallingPlatformRb.bodyType = RigidbodyType2D.Dynamic;
        fallingPlatformRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.SetBool("touched", true);
        Invoke("DestroyPlatform", 5f);
    }

    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
