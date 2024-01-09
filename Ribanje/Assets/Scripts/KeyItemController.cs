using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

// script which destroys KeyItem on pickup and destroys obstacles which prevent progress
// this component goes on KeyItemGO
public class KeyItemController : MonoBehaviour
{
    // access to player progress flags
    private GameObject playerGO;
    private RibarKontroler ribarKontroler;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player Ribar");
        ribarKontroler = playerGO.GetComponent<RibarKontroler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "KeyItem1")
            {
                ribarKontroler.PickUpKeyItem1();
                GameObject.Find("KeyItem1Barrier1").SetActive(false);
                GameObject.Find("KeyItem1Barrier2").SetActive(false);
                GameObject.Find("PocetniRibar").GetComponent<NPCDialogueController>().SetNextDialogue();
                gameObject.SetActive(false);
            }

        }
            
        
    }
}
