using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    [Header("Enemy Configuration")]

    [SerializeField]
    [Tooltip("Distance where the enemy starts to chase the player")]
    private float chaseDistance;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private LayerMask playerLayerMask;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform target;

    private Vector3 movingDirection;
    private Vector2 movement;

    private bool inChaseRange;      // Start chasing the player

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        anim.SetBool("isChasing", inChaseRange);

        inChaseRange = Physics2D.OverlapCircle(transform.position, chaseDistance, playerLayerMask);

        movingDirection = target.position - transform.position;
        movingDirection.Normalize();
        movement = movingDirection;
    }

    private void FixedUpdate()
    {
        if (inChaseRange)
        {
            if (movingDirection.x >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            MoveEnemy(movement);
        }
    }

    private void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }
}
