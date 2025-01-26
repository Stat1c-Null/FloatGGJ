using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    public string interactionText;

    /*public static event Action lookInteract = delegate {
        Debug.Log("Interaction called!"); 
    };*/
    public event Action OnItemInteraction;

    // todo: add different interactions: teleport, look

    // Private
    private GameObject player;
    public GameObject proximityPromptPrefab;
    private bool isHighlighted;

    public GameObject panelToActivate; // i actually forgot what this is supposed to do

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Ensure your player GameObject has the "Player" tag
        if (!proximityPromptPrefab)
        {
            Debug.LogError("ProximityPromptPrefab is not set in the inspector!");
        }
        GetComponent<Collider>().isTrigger = true;
        panelToActivate.SetActive(false);
        proximityPromptPrefab.GetComponent<TextMeshProUGUI>().text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (isHighlighted && Input.GetKeyDown(KeyCode.E))
        {
            OnItemInteraction.Invoke();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            isHighlighted = true;
            proximityPromptPrefab.GetComponent<TextMeshProUGUI>().text = interactionText;
            panelToActivate.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHighlighted = false;
            proximityPromptPrefab.GetComponent<TextMeshProUGUI>().text = "";
            panelToActivate.SetActive(false);
        }
    }
}
