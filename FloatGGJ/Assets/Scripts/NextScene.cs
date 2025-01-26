using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene;
    public PlayableDirector playable;

    private void Start()
    {
        playable = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (playable != null && playable.state != PlayState.Playing)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
