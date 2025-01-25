using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool conversation;
    public Dialogue_Second trigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
          FindAnyObjectByType<CanvasManager>().StartGameMenu();
           trigger.StartDialogue();
        }
    }

   
}
