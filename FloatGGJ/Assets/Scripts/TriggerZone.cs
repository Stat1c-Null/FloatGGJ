using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool conversation = false;
    public Dialogue_Second trigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true && conversation == false)
        {
           FindAnyObjectByType<CanvasManager>().StartGameMenu();
           trigger.StartDialogue();
           conversation = true;
        }
    }

   
}
