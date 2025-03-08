using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerForBusStop : MonoBehaviour
{
    public TextMeshProUGUI dialogueBody;
    public TextMeshProUGUI dialogueTitle;
    bool triggered = false;
    public string dialogue1;
    public string dialogue2;

    private void OnTriggerEnter(Collider collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            StartCoroutine(ExecuteDialogue());
        }
    }

    IEnumerator ExecuteDialogue()
    {
        triggered = true;
        dialogueBody.gameObject.SetActive(true);
        dialogueTitle.gameObject.SetActive(true);
        dialogueBody.text = dialogue1;
        dialogueTitle.text= dialogue2;
        yield return new WaitForSeconds(5);
        dialogueBody.text = "";
        dialogueTitle.text = "";
        dialogueBody.gameObject.SetActive(false);
        dialogueTitle.gameObject.SetActive(false);
    }
}
