using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] dialogueLines;
    public float textDelay;

    // currently displayed dialogue line
    private int index;
    private GameObject talkableObject;
    private TreeCollisionDialogue treeCollisionDialogue;


    private GameObject playerGO;
    private RibarKontroler ribarKontroler;

    // Start is called before the first frame update
    void Start()
    {
        /*
        textComponent.text = string.Empty;
        canvas.enabled = true;
        StartDialogue();
        */ 
    }

    private void OnEnable()
    {
        if (talkableObject == null)
        {
            talkableObject = GameObject.Find("DrvoDialogue");
            treeCollisionDialogue = talkableObject.GetComponent<TreeCollisionDialogue>();
        }
        if (playerGO == null)
        {
            playerGO = GameObject.Find("Player Ribar");
            ribarKontroler = playerGO.GetComponent<RibarKontroler>();
        }

        treeCollisionDialogue.SetDialogueInProgress(true);
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
            gameObject.SetActive(false);
            treeCollisionDialogue.SetDialogueInProgress(false);
            ribarKontroler.SetMovement(true);
        }
    }
}
