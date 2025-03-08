using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField]
    private string senderName;
    [SerializeField]
    private TextMeshProUGUI senderNamePlaceholder;
    [SerializeField]
    private GameObject senderMessagePlaceholder;
    [SerializeField]
    private GameObject receiverMessagePlaceholder;
    [SerializeField]
    private Sprite senderProfilePicture;
    private Dictionary<string, string[]> messageCollection = new Dictionary<string, string[]>();
    public string[] senderMessages;
    public string[] receiverMessages;
    // Start is called before the first frame update
    void Start()
    {
        messageCollection.Add(senderName, senderMessages);
        messageCollection.Add("Aria", receiverMessages);
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(string[] message in messageCollection.Values) {
            Debug.Log(message);
        }
    }
}
