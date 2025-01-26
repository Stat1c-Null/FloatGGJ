using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerForObjectives : MonoBehaviour
{
   

    public bool isTriggered;
    public ObjectiveManger manager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")==true)
        {
            
            isTriggered = true;
        }
      
    }

   
}
