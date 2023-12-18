using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadController : MonoBehaviour
{
    private EnemyAttackDistance enemyAttackDistance;
    private Rigidbody2D spikeHeadRb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite eyesOpenSprite;

    void Start()
    {
        enemyAttackDistance = GetComponent<EnemyAttackDistance>();
        spikeHeadRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        FallingSpikeHead();
    }

    private void FallingSpikeHead()
    {
        if (enemyAttackDistance.playerDetected)
        {
            spriteRenderer.sprite = eyesOpenSprite;
            spikeHeadRb.bodyType = RigidbodyType2D.Dynamic;
            spikeHeadRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

}
