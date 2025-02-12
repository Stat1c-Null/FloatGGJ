using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialPad : MonoBehaviour
{
    public Button[] DialButtons;
    public TextMeshProUGUI dialText;
    public GameObject DialogueCanvas;
    public GameObject DialogueName;

    void Start() {
        //dialText.enableWordWrapping = true;
        dialText.overflowMode = TextOverflowModes.Overflow;
        
        foreach (Button btn in DialButtons) 
        {
            btn.onClick.AddListener(() => OnDialButtonClicked(btn));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDialButtonClicked(Button clickedButton) {
        TextMeshProUGUI buttonText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();

        Debug.Log(buttonText.text);
        
        if(buttonText.text == "Del"){
            string text = dialText.text.Substring(0, dialText.text.Length - 2);
            dialText.text = text;
        } else if(buttonText.text == "Dial"){
            Debug.Log("Ignore empty input");
            if(dialText.text == "9 1 1 "){
                DialogueCanvas.SetActive(true);
                DialogueName.GetComponent<TextMeshProUGUI>().text = "911";
                StartCoroutine(gameObject.GetComponent<TriggerDialogue>().ExecuteDialogue());
                StartCoroutine(HideDialogue());
            }
        } else {
            dialText.text += buttonText.text + " ";
        }
        
    }

    IEnumerator HideDialogue()
    {
        yield return new WaitForSeconds(3);
        dialText.text = "";
        DialogueCanvas.SetActive(false);
    }
}
