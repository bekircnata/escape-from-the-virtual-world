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

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim.SetBool("collecting", true);
            audioSource.Play();
            gameManager.collectedItem += 1;
        }
    }

    public void DestroyCollectibleItem()
    {
        Destroy(gameObject);
    }
}
