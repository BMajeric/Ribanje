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
    private Animator anim;
    private Transform target;

    private Vector3 direction;

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
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        timeToFire = 0f;
        firingPoint = gameObject.GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        anim.SetBool("isShooting", inShootRange);
        inShootRange = Physics2D.OverlapCircle(transform.position, shootDistance, playerLayerMask);

        direction = target.position - transform.position;

        if (inShootRange)
        {
            if (direction.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            Shoot();
        }
        Debug.Log(target.position - transform.position);
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
