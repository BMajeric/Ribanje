using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class NewBehaviourScript : MonoBehaviour
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
        Debug.Log("KeyItem1 collidean");
        ribarKontroler.PickUpKeyItem1();
        // unisti prepreku
        GameObject.Find("KeyItem1Barrier1").SetActive(false);
        // pomakni pocetnog ribara sa strane i promijeni mu dijalog
        GameObject.Find("PocetniRibar").transform.position += new Vector3(8, 8, 0);
        GameObject.Find("PocetniRibar").GetComponent<SingleDialogueScript>().SetNextDialogue();
        gameObject.SetActive(false);
    }
}
