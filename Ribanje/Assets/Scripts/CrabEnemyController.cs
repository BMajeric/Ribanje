using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemyController : MonoBehaviour
{
    [Header("Enemy Configuration")]

    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rb;
    private Animator anim;

    private float timeToChangeDirection;
    private int direction;

    private Vector3 movingDirection;
    private Vector2 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeToChangeDirection = Random.Range(1, 3);
        direction = (int) Mathf.Round(Random.Range(-1, 1));
        if (direction == 0)
        {
            movingDirection = new Vector3(-1, 0, 0);
        }
        else
        {
            movingDirection = new Vector3(1, 0, 0);
        }
        movingDirection.Normalize();
        movement = movingDirection;
    }

    private void Update()
    {
        if (timeToChangeDirection <= 0)
        {
            if (direction == 0)
            {
                movingDirection = new Vector3(-1, 0, 0);
                direction = 1;
            } else
            {
                movingDirection = new Vector3(1, 0, 0);
                direction = 0;
            }
            movingDirection.Normalize();
            movement = movingDirection;
            timeToChangeDirection = Random.Range(1, 3);
        }
        timeToChangeDirection -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    private void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }
}
