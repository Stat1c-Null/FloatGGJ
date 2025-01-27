using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveManger : MonoBehaviour
{
    public string displayText;
    public TextMeshProUGUI contentText;
    public GameObject OBJ_Window;
     
    public TriggerForObjectives startTrigger;
    public TriggerToEndOBJ endTrigger;

  
   

    private void Start()
    {
        OBJ_Window.SetActive(false);
        contentText.text = displayText;


    }

    void Update()
    {
        
        if (startTrigger.isTriggered)
        {

            Debug.Log("BLYAT");
            contentText.text = displayText;
            endTrigger.isCompleted = false;
            if(contentText.text != null)
            { OBJ_Window.SetActive(true);
                Debug.Log("Full");
                }
            

        }
        else if ( endTrigger.isCompleted)
        {

            
            contentText.text = null;
            endTrigger.isCompleted = true;
            if (contentText.text == null)
            {OBJ_Window.SetActive(false);
                Debug.Log("Empty");
                 }
        }

    }


}
        

    



   






