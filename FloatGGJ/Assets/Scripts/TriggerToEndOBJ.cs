using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerToEndOBJ : MonoBehaviour
{
    public bool isCompleted;
    public ObjectiveManger manager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")==true)
        {
            isCompleted = true;
        }

    }
}
  
