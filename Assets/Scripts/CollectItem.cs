using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim.SetBool("collecting", true);
            gameManager.collectedItem += 1;
        }
    }

    public void DestroyCollectibleItem()
    {
        Destroy(gameObject);
    }
}
