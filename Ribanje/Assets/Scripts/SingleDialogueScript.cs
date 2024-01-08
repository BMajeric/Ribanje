using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDialogueScript : MonoBehaviour
{
    // reference to dialogue(s) to play
    public GameObject[] dialogues;
    public int dialogueIndex = 0;

    // dialogue is enabled when player is in close range
    private bool dialogueEnabled;
    private bool dialogueInProgress;
    private Collider2D circleCollider;


    private GameObject playerGO;
    private RibarKontroler ribarKontroler;


    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<Collider2D>();
        dialogueEnabled = false;
        dialogueInProgress = false;
        playerGO = GameObject.Find("Player Ribar");
        ribarKontroler = playerGO.GetComponent<RibarKontroler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dialogue") && dialogueEnabled && !dialogueInProgress)
        {
            dialogues[dialogueIndex].SetActive(true);
            ribarKontroler.SetMovement(false);
        }
    }


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            dialogueEnabled = true;
        }
        Debug.Log("dialogue enabled");
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            dialogueEnabled = false;
        }
        Debug.Log("dialogue disabled");
    }

    public void SetDialogueInProgress(bool isInProgress)
    {
        dialogueInProgress = isInProgress;
    }

    public void SetNextDialogue()
    {
        dialogueIndex++;
    }
}
