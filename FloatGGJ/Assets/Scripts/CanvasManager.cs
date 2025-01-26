using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject myCanvas;
    public GameObject phoneCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPhoneCanvas()
    {
        phoneCanvas.SetActive(true);
    }

    public void HidePhoneCanvas()
    {
        phoneCanvas.SetActive(false);
    }

    public void StartGameMenu()
    {

        myCanvas.SetActive(true); // Show the canvas

    }

    public void HideGameMenu()
    {

        myCanvas.SetActive(false); // Hide the canvas

    }

}
