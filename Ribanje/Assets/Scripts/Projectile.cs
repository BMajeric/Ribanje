using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 15)]
    [SerializeField]
    private float speed = 7f;

    [Range(1, 5)]
    [SerializeField]
    private float lifeTime = 2.5f;

    private Rigidbody2D rb;
    private Transform target;
    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        direction = target.position - transform.position;
        direction.Normalize();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
