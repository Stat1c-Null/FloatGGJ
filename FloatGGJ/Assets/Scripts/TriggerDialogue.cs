using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueViewer;
    bool triggered = false;
    public string dialogue;

    private void OnTriggerEnter(Collider collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            StartCoroutine(ExecuteDialogue());
        }
    }

    public IEnumerator ExecuteDialogue()
    {
        triggered = true;
        dialogueViewer.text = dialogue;
        yield return new WaitForSeconds(3);
        dialogueViewer.text = "";
    }
}
