using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemeyController : MonoBehaviour
{
    [Header("Enemy Configuration")]

    [SerializeField]
    [Tooltip("Distance from which the player is detected by the enemy")]
    private float detectionDistance;
    [SerializeField]
    private float chargingSpeed;
    [SerializeField]
    private LayerMask playerLayerMask;

    private Rigidbody2D rb;
    private Transform target;

    private Vector3 chargeDirection;
    private Vector2 movement;

    private bool inChaseRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("SetChargeDirection", 0.0f, 1.75f);
        InvokeRepeating("StopEnemy", 1.65f, 1.75f);
    }

    private void Update()
    {
        inChaseRange = Physics2D.OverlapCircle(transform.position, detectionDistance, playerLayerMask);
    }

    private void FixedUpdate()
    {
        if (inChaseRange)
        {
            MoveEnemy(movement);
        }
    }
    private void SetChargeDirection()
    {
        chargeDirection = target.position - transform.position;
        chargeDirection.Normalize();
        movement = chargeDirection;
    }

    private void StopEnemy()
    {
        chargeDirection = Vector3.zero;
        movement = chargeDirection;
    }

    private void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * chargingSpeed * Time.deltaTime));
    }

}
