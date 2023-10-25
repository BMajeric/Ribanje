using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D body;
    public Animator animator;

    float horizontal;
    float vertical;
    Vector3 playerOrijentacija;

    public float brzinaKretanja;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
        playerOrijentacija = transform.localScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
            playerOrijentacija.x = math.abs(transform.localScale.x) * -1;
        else
            playerOrijentacija.x = math.abs(transform.localScale.x);

        transform.localScale = playerOrijentacija;
        animator.SetFloat("Run", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.X))
        animator.SetBool("Attack", true);

        if (Input.GetKeyUp(KeyCode.X))
        animator.SetBool("Attack", false);

    }

    void FixedUpdate() {
        
        body.velocity = new Vector2(horizontal * brzinaKretanja, vertical * brzinaKretanja);

    }
}
