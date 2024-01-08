using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

// script for displaying a dialogue
// this component goes on dialogue textbox object (Canvas > Dialogues > DialogueTextboxGO)
public class DialogueTextboxController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    // all the lines in current dialogue, each will be displayed in new textbox
    public string[] dialogueLines;
    // currently displayed dialogue line
    private int index;

    // delay between printing out chars from dialogueLines strings
    public float textDelay;

    // reference to the object (NPC) which is talking
    public GameObject talkableObject;
    private NPCDialogueController dialogueController;

    // access to player to disable movement during dialogue
    private GameObject playerGO;
    private RibarKontroler ribarKontroler;

    // Start is called before the first frame update
    void Start() {}

    // this script will be started via .enabled(true)
    private void OnEnable()
    {
        Debug.Log("dialogue startan");
        if (playerGO == null)
        {
            playerGO = GameObject.Find("Player Ribar");
            ribarKontroler = playerGO.GetComponent<RibarKontroler>();
            Debug.Log("player pronaden");
        }
        if (dialogueController == null)
        {
            dialogueController = talkableObject.GetComponent<NPCDialogueController>();
            Debug.Log("pronaden npc skripta");
        }
        textComponent.text = string.Empty;

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dialogue") && textComponent.text == dialogueLines[index])
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Type each character 1 by 1
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textDelay);
        }
    }

    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("zavrsavamo razgovor");
            dialogueController.SetDialogueInProgress(false);
            Debug.Log("SetDialogueInProgress(false) dovrsen");
            ribarKontroler.SetMovement(true);
            Debug.Log("ribar.SetMovement(true) dovrsen");
            gameObject.SetActive(false);
            Debug.Log("GO disablean");
        }
    }
}
