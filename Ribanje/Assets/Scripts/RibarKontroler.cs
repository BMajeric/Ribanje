using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

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


    }

    void FixedUpdate() {
        
        body.velocity = new Vector2(horizontal * brzinaKretanja, vertical * brzinaKretanja);

    }
}
