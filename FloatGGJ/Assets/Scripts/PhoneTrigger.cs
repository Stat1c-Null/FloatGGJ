using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTrigger : MonoBehaviour
{

    public GameObject phone;
    public GameObject gradient;
    public bool canOpenPhone;
    public bool convoOver;
    public Sprite[] tweetMesg;
    private UnityEngine.UI.Image mesgSprite;
    private int mesgIndex = 0;
    public static bool isActive = false;
    AudioSource phoneBuzz;

    public GameObject buzzPic, buzzPic2;
    // Start is called before the first frame update
    void Start()
    {
        canOpenPhone = false;
        convoOver = false;
        mesgSprite = phone.GetComponent<UnityEngine.UI.Image>();
        phoneBuzz = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && canOpenPhone) {
            phone.SetActive(true);
            gradient.SetActive(true);
            canOpenPhone = false;
            phoneBuzz.Stop();
        }
        if(phone.activeInHierarchy == true && Input.GetMouseButtonDown(0) && mesgIndex < tweetMesg.Length) {
            mesgIndex++;
            mesgSprite.sprite = tweetMesg[mesgIndex];
        } else if(mesgIndex == tweetMesg.Length - 1) {
            phone.SetActive(false);
            gradient.SetActive(false);
            FindAnyObjectByType<CanvasManager>().HidePhoneCanvas();
            mesgIndex = 0;
            convoOver = true;
            isActive = false;
            buzzPic.SetActive(false);
            buzzPic2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true && convoOver == false)
        {
            FindAnyObjectByType<CanvasManager>().StartPhoneCanvas();
            phoneBuzz.Play();
            buzzPic.SetActive(true);
            buzzPic2.SetActive(true);
            canOpenPhone = true;
            mesgSprite.sprite = tweetMesg[mesgIndex];
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            FindAnyObjectByType<CanvasManager>().HidePhoneCanvas();
        }
    }
}
