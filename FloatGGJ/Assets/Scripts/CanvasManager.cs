using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject myCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
