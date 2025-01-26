using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemInteraction : MonoBehaviour
{
    public string interactionText;
    public UnityEvent OnItemInteraction;
    public UnityEvent OnItemExit;
    public GameObject proximityPromptPrefab;
    public GameObject textDisplay;
    public GameObject player;
    private bool isHighlighted = false;
    private bool isToggled = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!proximityPromptPrefab)
        {
            Debug.LogError("ProximityPromptPrefab is not set in the inspector!");
        }
        GetComponent<Collider>().isTrigger = true;
        proximityPromptPrefab.SetActive(false);
        textDisplay.GetComponent<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isHighlighted && Input.GetKeyDown(KeyCode.E))
        {
            isToggled = true;
            isHighlighted = false;
            OnItemInteraction.Invoke();

        }
        else if (isToggled && Input.GetKeyDown(KeyCode.E))
        {
            isHighlighted = true;
            isToggled = false;
            OnItemExit.Invoke();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            isHighlighted = true;
            textDisplay.GetComponent<TextMeshProUGUI>().text = interactionText;
            proximityPromptPrefab.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHighlighted = false;
            textDisplay.GetComponent<TextMeshProUGUI>().text = "";
            proximityPromptPrefab.SetActive(false);
        }
    }
}
