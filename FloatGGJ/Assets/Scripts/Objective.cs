using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Objective 
{
    public bool isActive;
  //  public string title;
    public string description;
   

   public Objective(string descr) 
    {
        isActive = false;

        description = descr;
        
    }
}
