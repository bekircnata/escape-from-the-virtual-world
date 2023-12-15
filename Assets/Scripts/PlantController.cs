using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private EnemyAttackDistance enemyAttackDistanceScript;
    private Animator anim;
    private AudioSource audioSource;

    [SerializeField] private GameObject plantBulletPrefab;
    [SerializeField] private float bulletSpeed = 5f;
    private Vector2 bulletDirection;

    void Start()
    {
        enemyAttackDistanceScript = GetComponent<EnemyAttackDistance>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(enemyAttackDistanceScript.playerDetected)
        {
            anim.SetBool("player_detected", true);
        }
        else
        {
            anim.SetBool("player_detected", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            anim.SetBool("isDeath", true);
        }
    }

    private void Attack()
    {
        bulletDirection = Vector2.left;
        Vector2 bulletTransform = new Vector2(transform.position.x - 1, transform.position.y + 0.3f);
        GameObject newBullet = Instantiate(plantBulletPrefab, bulletTransform, Quaternion.identity);
        Rigidbody2D newBulletRb = newBullet.GetComponent<Rigidbody2D>();
        newBulletRb.velocity = bulletDirection * bulletSpeed;
        audioSource.Play();

        Destroy(newBullet, 2f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
