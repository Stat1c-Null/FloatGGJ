using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool IsPaused = false;    
    public   void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

   public  void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
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

        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

    }
    public void Resume()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused=false;

    }

}
