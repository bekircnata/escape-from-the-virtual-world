using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;
    [SerializeField] private AudioClip deathSoundEffect;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemie"))
        {
            anim.SetTrigger("death");
            audioSource.clip = deathSoundEffect;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemie"))
        {
            anim.SetTrigger("death");
            audioSource.clip = deathSoundEffect;
            audioSource.Play();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
