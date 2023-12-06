using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject pineappleBulletPrefab;
    private Vector2 shotDirection;
    private Vector2 newBulletInstantiatePosition;
    private Quaternion newBulletInstantiateRotate;
    private float bulletSpeed = 10f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameManager.collectedItem > 0) 
        {
            Fire();
        }
    }

    private void Fire()
    {
        BulletDirectionControl();

        GameObject newBullet = Instantiate(pineappleBulletPrefab, newBulletInstantiatePosition, newBulletInstantiateRotate);
        Rigidbody2D newBulletRb = newBullet.GetComponent<Rigidbody2D>();
        newBulletRb.velocity = shotDirection * bulletSpeed;

        gameManager.collectedItem--;
        Destroy(newBullet, 2f);
    }

    private void BulletDirectionControl()
    {
        shotDirection = Vector2.right;
        newBulletInstantiatePosition = new Vector2(transform.position.x + 1, transform.position.y);
        newBulletInstantiateRotate = Quaternion.Euler(0f, 0f, -90f);

        if (spriteRenderer.flipX)
        {
            shotDirection = Vector2.left;
            newBulletInstantiatePosition = new Vector2(transform.position.x - 1, transform.position.y);
            newBulletInstantiateRotate = Quaternion.Euler(0f, 0f, 90f);
        }
    }
}
