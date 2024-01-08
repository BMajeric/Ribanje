using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    [Header("Enemy Configuration")]

    [SerializeField]
    [Tooltip("Distance where the enemy starts to shoot at the player while chasing him")]
    private float chaseDistance;
    [SerializeField]
    [Tooltip("Distance where the enemy stops moving and shoots at the player")]
    private float stopDistance;
    [SerializeField]
    [Tooltip("Distance where the enemy starts to run away form the player to keep some space between them")]
    private float spacingDistance;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private LayerMask playerLayerMask;

    private Rigidbody2D rb;
    private Transform target;

    private Vector3 movingDirection;
    private Vector2 movement;

    private bool inChaseRange;      // Start chasing the player
    private bool inStopRange;       // Stop movement
    private bool inSpaceRange;        // Start running from the player
    
    [Header("Shooting Variables")]

    private Transform firingPoint;

    [SerializeField]
    private float firingRate;
    private float timeToFire;

    [SerializeField]
    private GameObject projectilePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        timeToFire = 0f;
        firingPoint = gameObject.GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        inChaseRange = Physics2D.OverlapCircle(transform.position, chaseDistance, playerLayerMask);
        inStopRange = Physics2D.OverlapCircle(transform.position, stopDistance, playerLayerMask);
        inSpaceRange = Physics2D.OverlapCircle(transform.position, spacingDistance, playerLayerMask);

        movingDirection = target.position - transform.position;
        movingDirection.Normalize();

        if (inSpaceRange)
        {
            movement = -movingDirection;
            Shoot();
        } 
        else if (inStopRange)
        {
            movement = Vector2.zero;
            Shoot();
        } 
        else if (inChaseRange)
        {
            movement = movingDirection;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (inChaseRange || inStopRange || inSpaceRange)
        {
            MoveEnemy(movement);
        }
    }

    private void Shoot()
    {
        if (timeToFire <= 0)
        {
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = firingRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }

}
