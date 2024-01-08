using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<RibarKontroler>().takeDamage(1);
            Debug.Log("Oof! Took Damage from " + collision.gameObject.name);
        }
    }
}
