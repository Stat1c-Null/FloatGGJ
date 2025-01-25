using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public static ItemController Instance { get; private set; }

    [Serializable]
    public class Item
    {
        public string filePath;
        public Vector3 scale;
        public string interactionText;
        public Vector3 position;
        public Action onInteract;

        public GameObject gameObject;

        public Item(string filePath, float xScale, float zScale, string interactionText, Vector3 position, Action onInteract)
        {
            this.interactionText = interactionText;
            this.position = position;
            this.onInteract = onInteract;
        }
    }

    public GameObject proximityPromptPrefab;
    private GameObject player;
    private Item currentItem;
    private GameObject promptInstance;



    

    private List<Item> items = new List<Item>();

    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Ensure your player GameObject has the "Player" tag
        if (!proximityPromptPrefab)
        {
            Debug.LogError("ProximityPromptPrefab is not set in the inspector!");
        }
    }

    public void InitializeItem(string filePath, float xScale, float zScale, string interactionText, Vector3 position, Action onInteract)
    {
        Debug.Log("Init called");
        GameObject itemObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        itemObject.transform.position = position;
        itemObject.transform.localScale = new Vector3(xScale, 1, zScale);
        itemObject.transform.localEulerAngles = new Vector3(90, 0, 180);


        BoxCollider collider = itemObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(1, 1, 1) * 10; // Adjusting the bounding box size

        MeshRenderer renderer = itemObject.AddComponent<MeshRenderer>();
        // Assuming item loading is based on a file path
        // You can replace this with your own model-loading logic
        renderer.material.color = Color.green;

        Item newItem = new Item(filePath, xScale, zScale, interactionText, position, onInteract);
        newItem.gameObject = itemObject;
        items.Add(newItem);
    }

    public void DestroyAllItems()
    {
        foreach (var item in items)
        {
            if (item.gameObject != null)
            {
                Destroy(item.gameObject);
            }
        }
        items.Clear();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentItem != null)
        {
            Debug.Log("Item Triggerred");   
            if (promptInstance == null && proximityPromptPrefab != null)
            {
                promptInstance = Instantiate(proximityPromptPrefab);
                promptInstance.GetComponentInChildren<Text>().text = currentItem.interactionText;

           
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && promptInstance != null)
        {
            Destroy(promptInstance);
        }
    }

    private void Update()
    {
        if (promptInstance != null && Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.onInteract?.Invoke();
            Destroy(promptInstance);
        }
    }
}
