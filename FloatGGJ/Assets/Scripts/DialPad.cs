using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DialAction
{
    Delete,
    Dial,
    Number
}

public class DialPad : MonoBehaviour
{
    public Button[] DialButtons;
    public TextMeshProUGUI dialText;
    public GameObject DialogueCanvas;
    public GameObject DialogueName;
    public GameObject DialScreen;
    public GameObject PhoneCanvas;

    void Start()
    {
        dialText.overflowMode = TextOverflowModes.Overflow;

        foreach (Button btn in DialButtons)
        {
            btn.onClick.AddListener(() => OnDialButtonClicked(btn));
        }
    }

    void OnDialButtonClicked(Button clickedButton)
    {
        TextMeshProUGUI buttonText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
        string buttonValue = buttonText.text;

        DialAction action = GetDialAction(buttonValue);

        switch (action)
        {
            case DialAction.Delete:
                if (dialText.text.Length > 0)
                {
                    dialText.text = dialText.text.Substring(0, dialText.text.Length - 2);
                }
                break;
            
            case DialAction.Dial:
                Debug.Log("Ignore empty input");
                if (dialText.text.Trim() == "9 1 1")
                {
                    DialScreen.SetActive(true);
                    StartCoroutine(ShowDialog());
                }
                break;

            default:
                dialText.text += buttonValue + " ";
                break;
        }
    }

    DialAction GetDialAction(string buttonValue)
    {
        if (buttonValue.ToLower() == "delete") return DialAction.Delete;
        if (buttonValue.ToLower() == "dial") return DialAction.Dial;
        return DialAction.Number;
    }

    IEnumerator ShowDialog() {
        yield return new WaitForSeconds(3);
        DialogueCanvas.SetActive(true);
        DialogueName.GetComponent<TextMeshProUGUI>().text = "911";
        StartCoroutine(gameObject.GetComponent<TriggerDialogue>().ExecuteDialogue());
        StartCoroutine(HideDialogue());
    }

    IEnumerator HideDialogue()
    {
        yield return new WaitForSeconds(5);
        dialText.text = "";
        DialogueCanvas.SetActive(false);
        PhoneCanvas.SetActive(false);
        FindAnyObjectByType<PhoneTrigger>().StopCallingCops();
    }
}
