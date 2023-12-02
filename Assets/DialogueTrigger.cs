using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{   //public object cos;

    public Dialogue dialogueScript;
    private bool playerDetected;
    public GameObject klawisz;
    //cos.object.SetActive
    //Detect trigger with player

    private void Start()
    {
        klawisz.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if(other.CompareTag("Gracz"))
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
            klawisz.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (other.CompareTag("Gracz"))
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
            klawisz.SetActive(false);
        }
    }
    //While detected if we interact start the dialogue
    private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}