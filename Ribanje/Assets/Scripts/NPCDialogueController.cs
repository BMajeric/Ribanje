using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script which enables dialogue when in range of an NPC
// this component goes on NPC 
public class NPCDialogueController : MonoBehaviour
{
    // reference to dialogue(s) to play
    public GameObject[] dialogues;
    // index of a dialogue which to show (depends on game progress)
    public int dialogueIndex = 0;

    // dialogue is enabled when player is in close range
    private bool dialogueEnabled;
    // ensures only one active dialogue at a time
    private bool dialogueInProgress;
    // collider which enables dialogue when in range
    private Collider2D circleCollider;

    // access to player to disable movement during dialogue
    private GameObject playerGO;
    // access to player script to disable movement during dialogue
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
