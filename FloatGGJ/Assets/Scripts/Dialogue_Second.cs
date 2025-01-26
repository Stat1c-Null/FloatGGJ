using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Second : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        FindAnyObjectByType<DialogueManager>().OpenDialogue(messages, actors);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Actor
{
    public string name;
    public Color charColor;
}
[System.Serializable]
public class Message
{
    public int id;
    public string text;
}