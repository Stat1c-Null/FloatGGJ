using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Dialogue : MonoBehaviour
{

  
   

    public TextMeshProUGUI text;
    public string[] lines;
    public float typingSpeed = 0.05f;

    

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            if(text.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void StartDialogue()
    { 
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    void NextLine()
    {
        if(index<lines.Length -1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }

    }


}
