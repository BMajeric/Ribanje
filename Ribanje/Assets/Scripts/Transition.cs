using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public GameObject KameraZaIskljuciti;

    public GameObject KameraZaUkljuciti;

    public Collider2D TransitionCollider;
    public Transform TargetPosition;

    public PolygonCollider2D NewBounds;

    // Start is called before the first frame update
    void Start()
    {
        TransitionCollider = this.GetComponent<Collider2D>();
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            //ako je usao objekt sa tagom player, teleportiraj ga na TargetPosition
            Debug.Log("Ayo");
            //teleportiraj ribara, treba neku animaciju napravit kasnije za smooth transition
            other.transform.position = TargetPosition.position;

            //popravi kameru
            KameraZaIskljuciti.SetActive(false);
            KameraZaUkljuciti.SetActive(true);
            

        }
    }
}
