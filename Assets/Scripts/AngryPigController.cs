using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPigController : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;
    [SerializeField] private EnemyAttackDistance enemyAttackDistanceScript;
    private bool isSoundPlaying = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AnimController();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("hit_the_player", true);
        }else if(collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Bullet"))
        {
            anim.SetBool("isDeath", true);
        }
    }

    private void AnimController()
    {
        if(enemyAttackDistanceScript.playerDetected)
        {
            anim.SetBool("player_detected", true);
            if(!isSoundPlaying)
            {
                audioSource.Play();
                isSoundPlaying = true;
            }
        }else
        {
            anim.SetBool("player_detected", false);
            if(isSoundPlaying)
            {
                audioSource.Stop();
                isSoundPlaying = false;
            }
        }
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
