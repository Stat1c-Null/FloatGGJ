using UnityEngine;
using Cinemachine;

public class LookAt : MonoBehaviour
{
    private CinemachineVirtualCamera vCam; // Public reference to the Cinemachine Virtual Camera
    private CinemachineBrain currBrain;

    private void Start()
    {
        vCam = gameObject.GetComponent<CinemachineVirtualCamera>();
        vCam.enabled = false;
    }
    public void Attatch()
    {
        if (vCam == null)
        {
            Debug.LogError("No Cinemachine Virtual Camera assigned! Please assign a Virtual Camera in the Inspector.");
            return;
        }

        // Find the Main Camera in the scene
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No Main Camera found in the scene!");
            return;
        }


        CinemachineBrain mainBrain = mainCamera.GetComponent<CinemachineBrain>();
        if (mainBrain == null)
        {
            mainBrain = mainCamera.gameObject.AddComponent<CinemachineBrain>();
            Debug.Log("CinemachineBrain was not found on the Main Camera. A new CinemachineBrain has been added.");
        }
        else
        {
            Debug.Log("CinemachineBrain already exists on the Main Camera.");
        }

        vCam.enabled = true;
        Debug.Log("Cinemachine Virtual Camera successfully attached to the Main Camera!");
    }

    public void Detatch()
    {
        vCam.enabled = false;
    }
}
