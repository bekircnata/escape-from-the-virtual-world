using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim.SetBool("collecting", true);
            audioSource.Play();
        }
    }

    public void DestroyCollectibleItem()
    {
        gameManager.collectedItem += 1;
        Destroy(gameObject);
    }
}
