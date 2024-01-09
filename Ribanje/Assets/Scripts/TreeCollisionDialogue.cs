using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollisionDialogue : MonoBehaviour
{
    // reference to dialogue to play
    public GameObject dialogue;
    // dialogue is enabled when player is in close range
    private bool dialogueEnabled;
    private bool dialogueInProgress;
    private Collider2D treeCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        treeCollider = GetComponent<Collider2D>();
        dialogueEnabled = false;
        dialogueInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dialogue") && dialogueEnabled && !dialogueInProgress)
        {
            dialogue.SetActive(true);
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
}


/*
        if (Input.GetKey(KeyCode.C) && isDialogueEnabled)
        {
            GameObject myGO;
            GameObject myText;
            Canvas myCanvas;
            Text text;
            RectTransform rectTransform;

            // Canvas
            myGO = new GameObject();
            myGO.name = "TestCanvas";
            myGO.AddComponent<Canvas>();

            myCanvas = myGO.GetComponent<Canvas>();
            myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            myGO.AddComponent<CanvasScaler>();
            myGO.AddComponent<GraphicRaycaster>();

            // Text
            myText = new GameObject();
            myText.transform.parent = myGO.transform;
            myText.name = "wibble";

            text = myText.AddComponent<Text>();
            text.font = (Font)Resources.Load("MyFont");
            text.text = "wobble";
            text.fontSize = 100;

            // Text position
            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 0, 0);
            rectTransform.sizeDelta = new Vector2(400, 200);

            myCanvas.enabled = true;
        }
*/