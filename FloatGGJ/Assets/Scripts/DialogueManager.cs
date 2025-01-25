using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    public Image actorImage;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage;
    public static bool isActive = false;
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started convo! Loaded messages: " + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.text;

        Actor actorToDisplay = currentActors[messageToDisplay.id];
        actorImage.sprite = actorToDisplay.sprite;

       
    }

    public void NextMessage()
    { 
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {

            DisplayMessage();
        }
        else 
        {
            Debug.Log("Conversation Ended!");
            isActive = false;
            FindAnyObjectByType<CanvasManager>().HideGameMenu();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }
}
