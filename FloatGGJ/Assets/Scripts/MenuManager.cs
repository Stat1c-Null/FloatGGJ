using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool IsPaused = false;    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

   public  void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("aa");
            if (IsPaused==false)
            {
                Debug.Log("Stopping");
                Stop();
            }
            else
            {
                Resume();
            }



        }
    }
 
    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);


    }
    
    public void Stop()
    {
        IsPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        

    }
    public void Resume()
    {
        IsPaused=false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
      

    }

}
