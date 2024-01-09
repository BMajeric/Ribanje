using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RibarKontroler : MonoBehaviour
{
    Rigidbody2D body;
    public Animator animator;
    public HealthController health;

    float horizontal;
    float vertical;
    Vector3 playerOrijentacija;

    public float brzinaKretanja;

    bool canMove = true;

    // flags to mark progress
    public bool bKeyItem1PickedUp = false;
    public bool bKeyItem2PickedUp = false;
    public bool bKeyItem3PickedUp = false;
    public bool bKeyItem4PickedUp = false;

    // Attack hitbox
    public GameObject stickAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {

        checkAttack();

        if (canMove) {
            checkMovement();
        }

        testHealthController();

    }

    void FixedUpdate() {
        
        body.velocity = new Vector2(horizontal * brzinaKretanja, vertical * brzinaKretanja);

    }

    void checkAttack()
    {

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    animator.SetBool("Attack", true);
        //    canMove = false;
        //    horizontal = 0;
        //    vertical = 0;

        //    Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        //}

        //if (Input.GetKeyUp(KeyCode.X))
        //{
        //    animator.SetBool("Attack", false);
        //    canMove = true;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }
    }

    void checkMovement(){

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
        playerOrijentacija = transform.localScale;

        if (horizontal < 0)
            playerOrijentacija.x = math.abs(transform.localScale.x);
        if (horizontal > 0)
            playerOrijentacija.x = math.abs(transform.localScale.x) * -1;
        
        transform.localScale = playerOrijentacija;
        animator.SetFloat("Run", Mathf.Abs(horizontal));
        animator.SetFloat("RunUp", vertical);
    }


    public void gameOver() 
    {
        Debug.Log("GAME OVER!");
    }

    public void takeDamage(int amount)
    {
        health.deductHearts(amount);
        if (health.currentHealth <= 0)
        {
            gameOver();
        }
        StartCoroutine(health.Invulnerability());
    }

    public void heal(int amount)
    {
        health.addHearts(amount);
    }

    public void decreaseMaxHealth(int amount)
    {
        health.deductMaxHearts(amount);
    }

    public void increaseMaxHealth(int amount)
    {
        health.addMaxHearts(amount);
    }

    void testHealthController()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            takeDamage(1);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            heal(1);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            decreaseMaxHealth(2);
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            increaseMaxHealth(1);
        }

    }

    public void SetMovement(bool canMove)
    {
        this.canMove = canMove;
    }

    public void PickUpKeyItem1()
    {
        bKeyItem1PickedUp = true;
    }
    public void PickUpKeyItem2()
    {
        bKeyItem2PickedUp = true;
    }
    public void PickUpKeyItem3()
    {
        bKeyItem3PickedUp = true;
    }
    public void PickUpKeyItem4()
    {
        bKeyItem4PickedUp = true;
    }

    public IEnumerator Attack()
    {
        // Start attack animation
        animator.SetBool("Attack", true);
        canMove = false;
        horizontal = 0;
        vertical = 0;

        animator.SetFloat("Run", 0);
        animator.SetFloat("RunUp", 0);

        // Determine attack direction
        var direction = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        Debug.Log(direction);
        var attackPosition = transform.position;
        var duration = 1f;
        if (direction == "Slash up" || direction == "Run up ribar2" || direction == "Idle back ribar2")
        {
            attackPosition.y += 0.6f;
            duration = 0.683f;
        } else if (direction == "Slash down" || direction == "Run down ribar2" || direction == "Idle front ribar2")
        {
            attackPosition.y -= 0.7f;
            duration = 0.683f;
        } else if (direction == "Slash side" || direction == "Run side ribar2" || direction == "Idle side ribar2")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                attackPosition.y += 0.6f;
                duration = 0.683f;
            } else if (Input.GetKeyDown(KeyCode.S)) 
            {
                attackPosition.y -= 0.7f;
                duration = 0.683f;
            } else
            {
                attackPosition.x -= 0.6f * math.sign(transform.localScale.x);
                duration = 0.517f;
            }
        }
        stickAttack.transform.position = attackPosition;


        // Enable attack collider
        stickAttack.GetComponent<Collider2D>().enabled = true;

        // Wait for animation to finish
        yield return new WaitForSeconds(duration);

        // Disable attack collider
        stickAttack.GetComponent<Collider2D>().enabled = false;

        // End attack animation
        animator.SetBool("Attack", false);
        canMove = true;
    }
}
