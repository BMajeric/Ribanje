using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRangedEnemyController : MonoBehaviour
{
    [Header("Enemy Configuration")]

    [SerializeField]
    [Tooltip("Distance where the enemy starts to shoot at the player")]
    private float shootDistance;
    [SerializeField]
    private LayerMask playerLayerMask;

    private Rigidbody2D rb;
    private Transform target;

    private bool inShootRange;
    
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
        inShootRange = Physics2D.OverlapCircle(transform.position, shootDistance, playerLayerMask);

        if (inShootRange)
        {
            Shoot();
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

}
